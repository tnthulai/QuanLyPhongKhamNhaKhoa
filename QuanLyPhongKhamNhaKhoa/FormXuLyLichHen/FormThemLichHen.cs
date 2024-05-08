using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.Entity;
using QuanLyPhongKhamNhaKhoa.User_Control;
using QuanLyPhongKhamNhaKhoa.User_Control.DieuTri;
using QuanLyPhongKhamNhaKhoa.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa.FormXuLyLichHen
{

    public delegate void ListDichVuSelected(List<Service> list);
    public partial class FormThemLichHen : Form
    {
        private UC_LichHen uc_LichHenTest;

        public FormThemLichHen(UC_LichHen uc_LichHenTest)
        {
            InitializeComponent();
            this.uc_LichHenTest = uc_LichHenTest;
        }

        SQLConnectionData mydb = new SQLConnectionData();
        PatientsDao patientsDao = new PatientsDao();
        AppointmentDao appDao = new AppointmentDao();
        public string fullNameNS;
        public string userIDNS;
        string patientsID = null;
        string appointmentID;
        public List<Service> listService = new List<Service>();

        private void setValueList(List<Service> list)
        {
            listService = list;
            panelDichVu.Controls.Clear();
            loadListDichVuDaChon();
        }

        private void pBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormThemLichHen_Load(object sender, EventArgs e)
        {
            lblTenNhaSi.Text = fullNameNS;
            taoThoiGianChoCbTime();
            loadListDichVuDaChon();
            cbTime.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void taoThoiGianChoCbTime()
        {
            try
            {
                cbTime.Items.Clear();
                string dateString = dateTPKLichHen.Value.ToString("dd/MM/yyyy");
                DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime thoiGianHienTai = DateTime.Now;
                DateTime dateNow = thoiGianHienTai.Date;
                int hourNow = thoiGianHienTai.Hour;
                if (dateNow <= date)
                {
                    cbTime.Enabled = true;
                    panelDichVu.Controls.Clear();
                    List<int> hourTimeList = new List<int>();
                    SqlCommand command = new SqlCommand(@"SELECT startTime FROM Appointment WHERE userID=@userID AND appointmentDate=@appointmentDate");
                    command.Parameters.Add("@userID", SqlDbType.VarChar).Value = userIDNS.Trim();
                    command.Parameters.Add("@appointmentDate", SqlDbType.DateTime).Value = date;

                    DataTable table = appDao.getAppointment(command);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            TimeSpan startTime = (TimeSpan)row["startTime"];
                            int hour = startTime.Hours;
                            hourTimeList.Add(hour);
                        }
                    }

                    if (date.Equals(dateNow))
                    {
                        for (int i = hourNow; i < 17; i++)
                        {
                            if (!hourTimeList.Contains(i) && i != 12 && i >= 8)
                            {
                                string temp = i.ToString() + "h - " + (i + 1).ToString() + "h";
                                cbTime.Items.Add(temp);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 8; i < 17; i++)
                        {
                            if (!hourTimeList.Contains(i) && i != 12)
                            {
                                string temp = i.ToString() + "h - " + (i + 1).ToString() + "h";
                                cbTime.Items.Add(temp);
                            }
                        }
                    }
                }
                else
                {
                    cbTime.Enabled = false;
                    panelDichVu.Controls.Clear();
                    Label labelThongBao = new Label();
                    labelThongBao.Text = "Thời gian đặt lịch không hợp lệ.";

                    panelDichVu.Controls.Add(labelThongBao);
                    labelThongBao.Location = new Point(10, 10);
                    labelThongBao.ForeColor = Color.Gold;
                    labelThongBao.Font = new Font(labelThongBao.Font.FontFamily, 13, FontStyle.Bold);
                    panelDichVu.Controls.Add(labelThongBao);
                    labelThongBao.AutoSize = true;
                    int x = (panelDichVu.Width - labelThongBao.Width) / 2;
                    int y = (panelDichVu.Height - labelThongBao.Height) / 2;
                    labelThongBao.Location = new Point(x, y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT fullName, phoneNumber, patientsID " +
                "FROM Patients WHERE persionalID LIKE @persionalID");
                command.Parameters.Add("@persionalID", SqlDbType.VarChar).Value = "%" + txtCCCD.Text.Trim() + "%";

                DataTable table = patientsDao.getPatients(command);
                if (table.Rows.Count > 0)
                {
                    txtTenBN.Text = table.Rows[0]["fullName"].ToString().Trim();
                    txtSDTBN.Text = table.Rows[0]["phoneNumber"].ToString().Trim();
                    patientsID = table.Rows[0]["patientsID"].ToString().Trim();
                }
                else
                {
                    txtTenBN.Text = "";
                    txtSDTBN.Text = "";
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void themBenhNhan()
        {
            try
            {
                if (verifBenhNhan())
                {
                    throw new InvalidData();
                }
                string fullName = txtTenBN.Text.Trim();
                string persionalID = txtCCCD.Text.Trim();
                string phone = txtSDTBN.Text.Trim();
                if (!Regex.IsMatch(fullName, @"^[\p{L}\s]+$"))
                {
                    throw new InvalidName();
                }
                if (!Regex.IsMatch(persionalID, @"^\d{12}$"))
                {
                    throw new InvalidPersionalID();
                }
                if (!Regex.IsMatch(phone, @"^0\d{9}$"))
                {
                    throw new InvalidSDT();
                }
                //kiểm tra cccd đã tồn tại hay chưa
                if (patientsDao.existPersionalIDPatients(persionalID))
                {
                    throw new InvalidPersionalID(persionalID);
                }
                //do bên đặt lịch hẹn ko có ảnh người dùng nên gắn ảnh tạm
                MemoryStream pic = new MemoryStream();
                Image image = Image.FromFile(@"..\..\image\user.jpg");
                image.Save(pic, image.RawFormat);

                //tạo mã user tự động
                patientsID = patientsDao.taoMaPatients();

                SqlCommand command = new SqlCommand("INSERT INTO Patients (patientsID, fullName, birthDate, persionalID, phoneNumber, image)" +
                " VALUES (@id, @fn, @bdt, @perID, @phn, @image)", mydb.getConnection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = patientsID.Trim();
                command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fullName.Trim();
                command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@perID", SqlDbType.VarChar).Value = persionalID.Trim();
                command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone.Trim();
                command.Parameters.Add("@image", SqlDbType.Image).Value = pic.ToArray();

                mydb.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    mydb.closeConnection();
                    MessageBox.Show("Thêm bệnh nhân thành công!", "Add Patients", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    mydb.closeConnection();
                    throw new InvalidExistPatients("Thêm bệnh nhân thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Add Patients", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool verifBenhNhan()
        {
            if ((txtTenBN.Text.Trim() == "")
                        || (txtCCCD.Text.Trim() == "")
                        || (txtSDTBN.Text.Trim() == ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void txtTenBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCCCD.Text.Length >= 12 && e.KeyChar != (char)Keys.Back || !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDTBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSDTBN.Text.Length >= 10 && e.KeyChar != (char)Keys.Back ||
            (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) || (txtSDTBN.Text.Length == 0 && e.KeyChar != '0'))))
            {
                e.Handled = true;
            }
        }

        private void btnThemBN_Click(object sender, EventArgs e)
        {
            themBenhNhan();
        }

        private void pBSearchPatient_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT persionalID " +
                "FROM Patients WHERE persionalID LIKE @persionalID AND patientsID=@patientsID");
                command.Parameters.Add("@persionalID", SqlDbType.VarChar).Value = "%" + txtCCCD.Text.Trim() + "%";
                command.Parameters.Add("@patientsID", SqlDbType.VarChar).Value = patientsID.Trim();
                DataTable table = patientsDao.getPatients(command);
                if (table.Rows.Count > 0)
                {
                    txtCCCD.Text = table.Rows[0]["persionalID"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTPKLichHen_ValueChanged(object sender, EventArgs e)
        {
            taoThoiGianChoCbTime();
            loadListDichVuDaChon();
        }

        private void pBThemDichVu_Click(object sender, EventArgs e)
        {
            themDichVu();
        }

        private void lblThemDichVu_Click(object sender, EventArgs e)
        {
            themDichVu();
        }

        private void themDichVu()
        {
            FormChonDichVu formChonDichVu = new FormChonDichVu(setValueList, "");
            formChonDichVu.ShowDialog();
        }
        private void loadListDichVuDaChon()
        {
            try
            {
                if (listService != null)
                {
                    foreach (Service service in listService)
                    {
                        UC_Item uC_ItemDichVu = new UC_Item(service.ServiceID, service.ServiceName, service.Cost, service.Unit);
                        uC_ItemDichVu.checkBox.Checked = true;
                        uC_ItemDichVu.checkBox.Enabled = false;
                        panelDichVu.Controls.Add(uC_ItemDichVu);
                    }
                }
                else
                {
                    UC_Item uC_Item = new UC_Item("TV", "Tư vấn", 0, "Lần");
                    uC_Item.checkBox.Checked = true;
                    uC_Item.checkBox.Enabled = false;
                    panelDichVu.Controls.Add(uC_Item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCCCD.Text.ToString() == "" || patientsID == "" || cbTime.Text.ToString() == "")
                {
                    MessageBox.Show("Chưa đủ dữ liệu!", "Add Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                themLichHen();
                themLichHenDichVu();

                // Sau khi thêm lịch hẹn, gọi phương thức UpdateCalendar trên form UC_LichHenTest
                uc_LichHenTest.UpdateCalendar();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void themLichHenDichVu()
        {
            try
            {
                foreach (Service service in listService)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Appointment_Service (appointmentID, serviceID) VALUES(@appointmentID, @serviceID)", mydb.getConnection);
                    command.Parameters.Add("@appointmentID", SqlDbType.VarChar).Value = appointmentID;
                    command.Parameters.Add("@serviceID", SqlDbType.VarChar).Value = service.ServiceID;
                    mydb.openConnection();
                    command.ExecuteNonQuery();
                    mydb.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void themLichHen()
        {
            try
            {
                appointmentID = appDao.taoMaAppointment();
                if (patientsID == null)
                {
                    SqlCommand command = new SqlCommand("SELECT patientsID FROM Patients WHERE persionalID=@persionalID");
                    command.Parameters.Add("@persionalID", SqlDbType.VarChar).Value = txtCCCD.Text.Trim();
                    DataTable table = patientsDao.getPatients(command);
                    if (table.Rows.Count > 0)
                    {
                        patientsID = table.Rows[0]["patientsID"].ToString().Trim();
                    }
                }

                DateTime ngayHen = dateTPKLichHen.Value;
                string time = cbTime.SelectedItem.ToString();
                string[] parts = time.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                int startTime = int.Parse(parts[0].Replace("h", ""));
                int endTime = int.Parse(parts[1].Replace("h", ""));
                string timestart = startTime.ToString("00") + ":00:00";
                string timeend = endTime.ToString("00") + ":00:00";

                if (appDao.insertAppointment(appointmentID, patientsID, userIDNS, ngayHen, timestart, timeend, "BOOKED"))
                {
                    MessageBox.Show("Thêm cuộc hẹn thành công!", "Add Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new InvalidExistAppointment("Thêm cuộc hẹn thất bại!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Add Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}