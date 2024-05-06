using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.DieuTri;
using QuanLyPhongKhamNhaKhoa.Entity;
using QuanLyPhongKhamNhaKhoa.FormXuLyLichHen;
using QuanLyPhongKhamNhaKhoa.User_Control.DieuTri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    public delegate void ListThuocSelected(List<Medicine> list);
    public partial class UC_DieuTri : UserControl
    {
        public UC_DieuTri()
        {
            InitializeComponent();
        }
        SQLConnectionData mydb = new SQLConnectionData();
        ServiceDao serviceDao = new ServiceDao();
        AppointmentDao appointmentDao = new AppointmentDao();
        PatientsDao patientsDao = new PatientsDao();
        public List<Service> listService;
        public List<Medicine> listMedicine;

        private void UC_DieuTri_New_Load(object sender, EventArgs e)
        {
            LoadAppointments();
            
        }

        private void LoadAppointments()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            //TimeSpan currentTime = new TimeSpan(23, 30, 0);

            string query = "SELECT appointmentID, patientsID, startTime, endTime FROM Appointment WHERE appointmentDate = @currentDate AND userID = @doctorID ORDER BY startTime ASC";

            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            command.Parameters.Add("@currentDate", SqlDbType.DateTime).Value = DateTime.Today;
            command.Parameters.Add("@doctorID", SqlDbType.VarChar).Value = CurrentUser.currentUser.UserID;

            DataTable table = appointmentDao.getAppointment(command);
            DataColumn timeRangeColumn = new DataColumn("TimeRange", typeof(string));
            table.Columns.Add(timeRangeColumn);

            int selectedIndex = -1;
            foreach (DataRow row in table.Rows)
            {
                TimeSpan startTime = (TimeSpan)row["startTime"];
                TimeSpan endTime = (TimeSpan)row["endTime"];
                string timeRange = $"{startTime.ToString()} - {endTime.ToString()}";
                row["TimeRange"] = timeRange;
                
                // Kiểm tra xem thời gian hiện tại có nằm trong khoảng thời gian của appointment không
                if (currentTime >= startTime && currentTime <= endTime)
                {
                    selectedIndex = table.Rows.IndexOf(row);

                }
            }

            comboBoxLichHen.DataSource = table;
            comboBoxLichHen.DisplayMember = "TimeRange";
            comboBoxLichHen.ValueMember = "appointmentID";

            if (selectedIndex != -1)
            {
                comboBoxLichHen.SelectedIndex = selectedIndex; // Chọn giá trị mặc định 
            }
        }
        
        private void getData()
        {
            lblNameNS.Text = CurrentUser.currentUser.FullName;
            
            SqlCommand command = new SqlCommand("SELECT patientsID FROM Appointment WHERE appointmentID = @ID", mydb.getConnection);

            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = comboBoxLichHen.SelectedValue.ToString().Trim();
            DataTable table = appointmentDao.getAppointment(command);
            if (table.Rows.Count > 0)
            {
                string patientID = table.Rows[0]["patientsID"].ToString().Trim();
                lblNameBN.Text = patientsDao.GetNameByID(patientID);
            }
            LoadPanelDichVu();
            
        }
        private void comboBoxLichHen_SelectedValueChanged(object sender, EventArgs e)
        {
            getData();
        }
        private void LoadPanelDichVu()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT s.serviceID, s.serviceName, s.cost, s.unit 
                                            FROM Appointment a 
                                            join Appointment_Service a_s on a.appointmentID = a_s.appointmentID 
                                            join Service s on a_s.serviceID = s.serviceID
                                            where a.appointmentID = @ID", mydb.getConnection);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = comboBoxLichHen.SelectedValue.ToString();
            DataTable dtService = serviceDao.getService(cmd);
            pnDichVuDaChon.Controls.Clear();
            foreach (DataRow row in dtService.Rows)
            {
                string id = row["serviceID"].ToString();
                string serviceName = row["serviceName"].ToString();
                string unit = row["unit"].ToString();
                float cost;

                if (float.TryParse(row["cost"].ToString(), out cost))
                {
                    UC_ItemSelected uC_ItemDichVuSelected = new UC_ItemSelected(id, serviceName, cost, unit);
                    uC_ItemDichVuSelected.PBExit_Click += UC_ItemDichVuSelected_PBExit_Click;
                    uC_ItemDichVuSelected.TotalCostChanged += UC_ItemDichVuSelected_TotalCostChanged;

                    pnDichVuDaChon.Controls.Add(uC_ItemDichVuSelected);
                }
            }
            UpdateTotalCost();

        }

        private void UC_ItemDichVuSelected_PBExit_Click(object sender, EventArgs e)
        {
            try
            {
                UC_ItemSelected uC_ItemDichVuSelected = (UC_ItemSelected)sender;
                string serviceId = uC_ItemDichVuSelected.ID;

                SqlCommand command = new SqlCommand("DELETE FROM Appointment_Service WHERE appointmentID=@appointmentID AND serviceID = @serviceID", mydb.getConnection);
                command.Parameters.Add("@appointmentID", SqlDbType.VarChar).Value = comboBoxLichHen.SelectedValue.ToString();
                command.Parameters.Add("@serviceID", SqlDbType.VarChar).Value = serviceId;
                mydb.openConnection();
                
                command.ExecuteNonQuery();

                LoadPanelDichVu();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTotalCost()
        {
            totalCost = 0;
            foreach (Control control in pnDichVuDaChon.Controls)
            {
                if (control is UC_ItemSelected)
                {
                    UC_ItemSelected selectedService = control as UC_ItemSelected;
                    float serviceTotalCost;
                    if (float.TryParse(selectedService.lblTotalCost.Text.Replace("VND", ""), out serviceTotalCost))
                    {
                        totalCost += serviceTotalCost;
                    }
                }
            }

            lblTotalCostService.Text = "Tổng chi phí dịch vụ: " + totalCost.ToString("0.##") + "VND";
        }
        private float totalCost = 0;

        private void UC_ItemDichVuSelected_TotalCostChanged(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }

        private void pBThemDichVu_Click(object sender, EventArgs e)
        {
            FormChonDichVu formChonDichVu = new FormChonDichVu(setValueList, comboBoxLichHen.SelectedValue.ToString());
            formChonDichVu.ShowDialog();
        }

        private void setValueList(List<Service> list)
        {
            listService = list;
            ThemDichVu();
        }

        private void ThemDichVu()
        {
            string appointmentID = comboBoxLichHen.SelectedValue.ToString();
            if (listService != null)
            {
                foreach (Service service in listService)
                {
                    appointmentDao.insertAppointmentService(appointmentID, service.ServiceID);
                }
            }
            LoadPanelDichVu();

        }

        private void setValueListMedicine(List<Medicine> list)
        {
            listMedicine = list;
            LoadPanelThuocDaChon();
            
        }
        private void LoadPanelThuocDaChon()
        {
            pnThuocDaChon.Controls.Clear();
            if (listMedicine != null)
            {
                foreach (Medicine medicine in listMedicine)
                {
                    UC_ItemSelected uC_ItemSelected = new UC_ItemSelected(medicine.MedicineID, medicine.MedicineName, medicine.Cost, medicine.Unit);
                    uC_ItemSelected.PBExit_Click += UC_ItemSelected_PBExit_Click;
                    pnThuocDaChon.Controls.Add(uC_ItemSelected);
                }
            }
        }

        private void UC_ItemSelected_PBExit_Click(object sender, EventArgs e)
        {
            try
            {
                UC_ItemSelected uC_ItemThuocSelected = (UC_ItemSelected)sender;
                string serviceId = uC_ItemThuocSelected.ID;

                foreach (Control control in pnDichVuDaChon.Controls)
                {
                    if (control is UC_ItemSelected)
                    {
                        UC_ItemSelected item = control as UC_ItemSelected;
                        if (item.ServiceName == uC_ItemThuocSelected.ServiceName)
                        {
                            pnThuocDaChon.Controls.Remove(control);
                            break;
                        }
                    }
                }
                LoadPanelThuocDaChon();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pBThemThuoc_Click(object sender, EventArgs e)
        {
            FormChonThuoc formChonThuoc = new FormChonThuoc(setValueListMedicine);
            formChonThuoc.ShowDialog();
        }
    }
}

