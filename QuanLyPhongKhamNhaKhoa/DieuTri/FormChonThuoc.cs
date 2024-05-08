using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.Entity;
using QuanLyPhongKhamNhaKhoa.FormXuLyLichHen;
using QuanLyPhongKhamNhaKhoa.User_Control;
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

namespace QuanLyPhongKhamNhaKhoa.DieuTri
{

    public partial class FormChonThuoc : Form
    {
        public ListThuocSelected listThuocSelected;
        public FormChonThuoc()
        {
            InitializeComponent();
        }
        SQLConnectionData mydb = new SQLConnectionData();
        
        MedicineDao medicineDao = new MedicineDao();
        List<Medicine> listMedicine = new List<Medicine>();
        public FormChonThuoc(ListThuocSelected sender)
        {
            InitializeComponent();
            this.listThuocSelected = sender;
        }

        private void FormChonThuoc_Load(object sender, EventArgs e)
        {
            LoadListThuoc("");
        }

        private void LoadListThuoc(string name)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd = new SqlCommand(@"SELECT medicineID, medicineName, cost, unit
                                     FROM Medicine
                                      where medicineName like @name", mydb.getConnection);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "%" + name + "%";

                DataTable dtService = medicineDao.getMedicine(cmd);


                panelThuoc.Controls.Clear();
                foreach (DataRow row in dtService.Rows)
                {
                    string serviceName = row["medicineName"].ToString();
                    string unit = row["unit"].ToString();
                    string id = row["medicineID"].ToString();
                    float cost;

                    if (float.TryParse(row["cost"].ToString(), out cost))
                    {
                        UC_Item uC_itemThuoc = new UC_Item(id, serviceName, cost, unit);
                        uC_itemThuoc.CheckBoxCheckedChanged += UC_itemThuoc_CheckBoxCheckedChanged;
                        panelThuoc.Controls.Add(uC_itemThuoc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_itemThuoc_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UC_Item selectedThuoc = sender as UC_Item;
                if (selectedThuoc.checkBox.Checked)
                {
                    Medicine medicine = new Medicine(selectedThuoc.ServiceId, selectedThuoc.ServiceName, selectedThuoc.ServiceCost, selectedThuoc.ServiceUnit);
                    listMedicine.Add(medicine);
                }
                else
                {
                    listMedicine.RemoveAll(medicine => medicine.MedicineID == selectedThuoc.ServiceId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtThuoc_TextChanged(object sender, EventArgs e)
        {
            LoadListThuoc(txtThuoc.Text.Trim());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.listThuocSelected(listMedicine);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
