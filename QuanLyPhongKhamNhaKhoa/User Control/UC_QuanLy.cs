using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    public partial class UC_QuanLy : UserControl
    {
        public UC_QuanLy()
        {
            InitializeComponent();
        }

        ServiceDao serviceDao = new ServiceDao();
        MedicineDao medicineDao = new MedicineDao();

        private void UC_QuanLy_Load(object sender, EventArgs e)
        {
            if (radThuoc.Checked)
            {
                hienThiDanhSachThuoc();
            }
            else
            {
                hienThiDanhSachDichVu();
            }
        }

        private void hienThiDanhSachThuoc()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT medicineID, medicineName, unit, cost FROM Medicine");
                fillGrid(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hienThiDanhSachDichVu()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT serviceID, serviceName, unit, cost FROM Service");
                fillGrid(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillGrid(SqlCommand command)
        {
            try
            {
                dataGVThongTin.ReadOnly = true;
                dataGVThongTin.DataSource = serviceDao.getService(command);
                dataGVThongTin.AllowUserToAddRows = false;

                if (radThuoc.Checked)
                {
                    dataGVThongTin.Columns["medicineID"].HeaderText = "Mã";
                    dataGVThongTin.Columns["medicineName"].HeaderText = "Tên";
                    dataGVThongTin.Columns["unit"].HeaderText = "Đơn vị";
                    dataGVThongTin.Columns["cost"].HeaderText = "Giá";
                }
                else
                {
                    dataGVThongTin.Columns["serviceID"].HeaderText = "Mã";
                    dataGVThongTin.Columns["serviceName"].HeaderText = "Tên";
                    dataGVThongTin.Columns["unit"].HeaderText = "Đơn vị";
                    dataGVThongTin.Columns["cost"].HeaderText = "Giá";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (radThuoc.Checked)
            {
                reset();
                hienThiDanhSachThuoc();
            }
        }

        private void radDichVu_CheckedChanged(object sender, EventArgs e)
        {
            if (radDichVu.Checked)
            {
                reset();
                hienThiDanhSachDichVu();
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else if (char.IsControl(e.KeyChar))
            {
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiemTraThongTin())
                {
                    MessageBox.Show("Nhập đầy đủ thông tin!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                string name = txtTen.Text.Trim();
                float cost = float.Parse(txtGia.Text.Trim());
                string unit = txtDonVi.Text.Trim();

                if (radThuoc.Checked)
                {
                    string id = medicineDao.taoMaMedicine();
                    Medicine medicine = new Medicine(id, name, cost, unit);
                    if (medicineDao.insertMedicine(medicine))
                    {
                        MessageBox.Show("Thêm thuốc thành công!", "Add Medicine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hienThiDanhSachThuoc();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thuốc thất bại!", "Add Medicine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    string id = serviceDao.taoMaService();
                    Service service = new Service(id, name, cost, unit);
                    if (serviceDao.insertService(service))
                    {
                        MessageBox.Show("Thêm dịch vụ thành công!", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hienThiDanhSachDichVu();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thuốc thất bại!", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiemTraThongTin())
                {
                    MessageBox.Show("Nhập đầy đủ thông tin!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string id = txtMa.Text.Trim();
                string name = txtTen.Text.Trim();
                float cost = float.Parse(txtGia.Text.Trim());
                string unit = txtDonVi.Text.Trim();

                if (radThuoc.Checked)
                {
                    Medicine medicine = new Medicine(id, name, cost, unit);
                    if (medicineDao.updateMedicine(medicine))
                    {
                        MessageBox.Show("Chỉnh sửa thuốc thành công!", "Update Medicine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hienThiDanhSachThuoc();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thuốc thất bại!", "Add Medicine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    Service service = new Service(id, name, cost, unit);
                    if (serviceDao.updateService(service))
                    {
                        MessageBox.Show("Chỉnh sửa dịch vụ thành công!", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hienThiDanhSachDichVu();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thuốc thất bại!", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reset()
        {
            txtTen.Text = "";
            txtGia.Text = "";
            txtDonVi.Text = "";
            txtMa.Text = "";
        }
        private bool kiemTraThongTin()
        {
            if (txtDonVi.Text.ToString() == "" || txtTen.Text.ToString() == "" || txtGia.Text.ToString() == "")
                return true;
            else return false;
        }

        private void dataGVThongTin_Click(object sender, EventArgs e)
        {
            txtMa.Text = dataGVThongTin.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dataGVThongTin.CurrentRow.Cells[1].Value.ToString();
            txtDonVi.Text = dataGVThongTin.CurrentRow.Cells[2].Value.ToString();
            txtGia.Text = dataGVThongTin.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
