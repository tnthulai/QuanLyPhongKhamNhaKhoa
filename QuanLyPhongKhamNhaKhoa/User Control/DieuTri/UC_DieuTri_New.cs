using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.Entity;
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
    public partial class UC_DieuTri_New : UserControl
    {
        public UC_DieuTri_New()
        {
            InitializeComponent();
        }
        SQLConnectionData mydb = new SQLConnectionData();
        ServiceDao serviceDao = new ServiceDao();
        AppointmentDao appointmentDao = new AppointmentDao();
        PatientsDao patientsDao = new PatientsDao();


        String doctorID = "DENT5705";

        private void UC_DieuTri_New_Load(object sender, EventArgs e)
        {
            LoadAppointments();
            
        }

        private void LoadAppointments()
        {
            //TimeSpan currentTime = DateTime.Now.TimeOfDay;
            TimeSpan currentTime = new TimeSpan(8, 30, 0);

            string query = "SELECT appointmentID, patientsID, startTime, endTime FROM Appointment WHERE appointmentDate = @currentDate AND userID = @doctorID";

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
            UpdateTotalCost();
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
                    UC_ItemDichVuSelected uC_ItemDichVuSelected = new UC_ItemDichVuSelected(serviceName, cost, unit);
                    
                    uC_ItemDichVuSelected.TotalCostChanged += UC_ItemDichVuSelected_TotalCostChanged;

                    pnDichVuDaChon.Controls.Add(uC_ItemDichVuSelected);
                }
            }

            /*SqlCommand cmd = new SqlCommand( "SELECT serviceID, serviceName, cost, unit FROM Service",mydb.getConnection);
            DataTable dtService = serviceDao.getService(cmd);

            foreach (DataRow row in dtService.Rows)
            {
                string id = row["serviceID"].ToString();
                string serviceName = row["serviceName"].ToString();
                string unit = row["unit"].ToString();
                float cost;

                if (float.TryParse(row["cost"].ToString(), out cost))
                {
                    UC_ItemDichVu uC_itemDichVu = new UC_ItemDichVu(id,serviceName, cost, unit);
                    uC_itemDichVu.CheckBoxCheckedChanged += UC_ItemDichVu_CheckBoxCheckedChanged;

                    pnListDichVu.Controls.Add(uC_itemDichVu);
                }
            }*/
        }

        /*private void UC_ItemDichVu_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            UC_ItemDichVu selectedDichVu = sender as UC_ItemDichVu;
            if (selectedDichVu.checkBox.Checked)
            {
                // Tạo mới UC_DichVuSelected với dữ liệu từ UC_CustomListDichVu và thêm vào pnDichVuDaChon
                UC_ItemDichVuSelected selectedService = new UC_ItemDichVuSelected(selectedDichVu.ServiceName, selectedDichVu.ServiceCost, selectedDichVu.ServiceUnit);

                selectedService.TotalCostChanged += UC_ItemDichVuSelected_TotalCostChanged;
                pnDichVuDaChon.Controls.Add(selectedService);
                UpdateTotalCost();
            }
            else
            {
                foreach (Control control in pnDichVuDaChon.Controls)
                {
                    if (control is UC_ItemDichVuSelected)
                    {
                        UC_ItemDichVuSelected item = control as UC_ItemDichVuSelected;
                        if (item.ServiceName == selectedDichVu.ServiceName)
                        {
                            pnDichVuDaChon.Controls.Remove(control);
                            break;
                        }
                    }
                }
                UpdateTotalCost();
            }

        }*/
        private void UpdateTotalCost()
        {
            totalCost = 0;
            foreach (Control control in pnDichVuDaChon.Controls)
            {
                if (control is UC_ItemDichVuSelected)
                {
                    UC_ItemDichVuSelected selectedService = control as UC_ItemDichVuSelected;
                    float serviceTotalCost;
                    if (float.TryParse(selectedService.lblTotalCost.Text.Replace("VND", ""), out serviceTotalCost))
                    {
                        totalCost += serviceTotalCost;
                    }
                }
            }

            lblTotalCost.Text = totalCost.ToString("0.##") + "VND";
        }
        private float totalCost = 0;

        private void UC_ItemDichVuSelected_TotalCostChanged(object sender, EventArgs e)
        {
            totalCost = 0;
            foreach (Control control in pnDichVuDaChon.Controls)
            {
                UC_ItemDichVuSelected selectedService = sender as UC_ItemDichVuSelected;
                float serviceTotalCost;// = float.Parse(selectedService.lblTotalCost.Text);

                if (float.TryParse(selectedService.lblTotalCost.Text.Replace("VND", ""), out serviceTotalCost))
                {
                    totalCost += serviceTotalCost;
                }
            }

            lblTotalCost.Text = totalCost.ToString("0.##") + "VND";
            UpdateTotalCost();
        }




    }
}

