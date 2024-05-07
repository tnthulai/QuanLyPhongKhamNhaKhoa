using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.DieuTri;
using QuanLyPhongKhamNhaKhoa.Entity;
using QuanLyPhongKhamNhaKhoa.FormXuLyLichHen;
using QuanLyPhongKhamNhaKhoa.User_Control.DieuTri;
using QuanLyPhongKhamNhaKhoa.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        string patientID;
        string treatmentID;
        TreatmentDao treatmentDao = new TreatmentDao();

        private void UC_DieuTri_New_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            KiemTraTimKiemDieuTri();
            comboBoxLichHen.SelectedIndex = -1;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
<<<<<<< Updated upstream
=======
            DateTime currentDate = DateTime.Parse(dateTPDate.Value.ToString("MM/dd/yyyy"));
>>>>>>> Stashed changes

            string query = "SELECT appointmentID, patientsID, startTime, endTime FROM Appointment " +
                "WHERE appointmentDate = @currentDate AND userID = @doctorID " +
                "ORDER BY startTime ASC";

            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            command.Parameters.Add("@currentDate", SqlDbType.DateTime).Value = currentDate;
            if(CurrentUser.currentUser.UserID != null)
            {
                command.Parameters.Add("@doctorID", SqlDbType.VarChar).Value = CurrentUser.currentUser.UserID;
            }
            

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
            
            if(comboBoxLichHen.SelectedItem != null)
            {
                SqlCommand command = new SqlCommand("SELECT patientsID FROM Appointment WHERE appointmentID = @ID", mydb.getConnection);

                command.Parameters.Add("@ID", SqlDbType.VarChar).Value = comboBoxLichHen.SelectedValue.ToString().Trim();
                DataTable table = appointmentDao.getAppointment(command);
                if (table.Rows.Count > 0)
                {
                    patientID = table.Rows[0]["patientsID"].ToString().Trim();
                    lblNameBN.Text = patientsDao.GetNameByID(patientID);
                }
                LoadPanelDichVu();
            }
            else {}
        }
        private void comboBoxLichHen_SelectedValueChanged(object sender, EventArgs e)
        {
            txtTreatmentID.Text = "";
            KiemTraTimKiemDieuTri();
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
            UpdateTotalCostDichVu();

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
        private float totalCostDichVu;
        private float totalCostThuoc;
        private float totalCost;
        private void UpdateTotalCostDichVu()
        {
            totalCostDichVu = 0;
            foreach (Control control in pnDichVuDaChon.Controls)
            {
                if (control is UC_ItemSelected)
                {
                    UC_ItemSelected selectedService = control as UC_ItemSelected;
                    float serviceTotalCost;
                    if (float.TryParse(selectedService.lblTotalCost.Text.Replace("VND", ""), out serviceTotalCost))
                    {
                        totalCostDichVu += serviceTotalCost;
                    }
                }
                
            }
            lblTotalCostService.Text = "Tổng chi phí dịch vụ: " + string.Format("{0:N0}", totalCostDichVu) + " VND";

            totalCost = totalCostDichVu + totalCostThuoc;
            lblTotalCost.Text = "Tổng chi phí: " + string.Format("{0:N0}", totalCost) + "VND";
        }
        private void UpdateTotalCostThuoc()
        {
            totalCostThuoc = 0;
            foreach (UC_ItemSelected uC_ItemSelected in pnThuocDaChon.Controls)
            {
                
                    float medicineTotalCost;
                    if (float.TryParse(uC_ItemSelected.lblTotalCost.Text.Replace("VND", ""), out medicineTotalCost))
                    {
                        totalCostThuoc += medicineTotalCost;
                    }
            }
            lblTotalCostMedicine.Text = "Tổng chi phí  thuốc: " + string.Format("{0:N0}", totalCostThuoc) + "VND";
            totalCost = totalCostDichVu + totalCostThuoc;
            lblTotalCost.Text = "Tổng chi phí: " + string.Format("{0:N0}", totalCost) + "VND";
        }
        
        private void UC_ItemDichVuSelected_TotalCostChanged(object sender, EventArgs e)
        {
            UpdateTotalCostDichVu();
        }

        private void pBThemDichVu_Click(object sender, EventArgs e)
        {
            if (comboBoxLichHen.SelectedValue != null)
            {
                FormChonDichVu formChonDichVu = new FormChonDichVu(setValueList, comboBoxLichHen.SelectedValue.ToString());
                formChonDichVu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn cuộc hẹn!", "Add Services", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
<<<<<<< Updated upstream
            
=======
>>>>>>> Stashed changes
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
                    uC_ItemSelected.TotalCostChanged += UC_ItemSelected_TotalCostChanged;
                    pnThuocDaChon.Controls.Add(uC_ItemSelected);
                }
            }
            UpdateTotalCostThuoc();
        }

        private void UC_ItemSelected_TotalCostChanged(object sender, EventArgs e)
        {
            UpdateTotalCostThuoc();
        }

        private void UC_ItemSelected_PBExit_Click(object sender, EventArgs e)
        {
            try
            {
                UC_ItemSelected uC_ItemThuocSelected = (UC_ItemSelected)sender;
                
                foreach(Medicine medicine in listMedicine)
                {
                    if(medicine.MedicineID == uC_ItemThuocSelected.ID)
                    {
                        listMedicine.Remove(medicine);
                        break;
                    }
                }
                LoadPanelThuocDaChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pBThemThuoc_Click(object sender, EventArgs e)
        {
            FormChonThuoc formChonThuoc = new FormChonThuoc(setValueListMedicine);
            formChonThuoc.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            themThongTinDieuTri();
        }
        private void thuocDieuTri()
=======
            ThemThongTinDieuTri();
        }
        private void LuuThuocDieuTri()
>>>>>>> Stashed changes
        {
            try
            {
                foreach (UC_ItemSelected uC_ItemSelected in pnThuocDaChon.Controls)
                {
                    Medicine_Treatment medicine_Treatment = new Medicine_Treatment();
                    medicine_Treatment.TreatmentID = treatmentID;
<<<<<<< Updated upstream
                    medicine_Treatment.MedicineID = uC_ItemSelected.ID;
                    medicine_Treatment.Amount = uC_ItemSelected.NumAmount;
                    treatmentDao.insertMedicineTreatment(medicine_Treatment);
=======
                    MessageBox.Show(medicine_Treatment.TreatmentID);
                    medicine_Treatment.MedicineID = uC_ItemSelected.ID;
                    medicine_Treatment.Amount = uC_ItemSelected.NumAmount;
                    if (treatmentDao.insertMedicineTreatment(medicine_Treatment))
                    {
                        MessageBox.Show("Thành công");
                    }
                    else MessageBox.Show("Thất bại");
>>>>>>> Stashed changes
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
<<<<<<< Updated upstream
        private void luuDichVuDieuTri()
=======
        private void LuuDichVuDieuTri()
>>>>>>> Stashed changes
        {
            try
            {
                foreach (UC_ItemSelected uC_ItemSelected in pnDichVuDaChon.Controls)
                {
                    Service_Treatment service_Treatment = new Service_Treatment();
                    service_Treatment.TreatmentID = treatmentID;
<<<<<<< Updated upstream
                    service_Treatment.ServiceID = uC_ItemSelected.ID;
                    service_Treatment.Amount = uC_ItemSelected.NumAmount;
                    treatmentDao.insertServiceTreatment(service_Treatment);
=======
                    MessageBox.Show(service_Treatment.TreatmentID);
                    service_Treatment.ServiceID = uC_ItemSelected.ID;
                    service_Treatment.Amount = uC_ItemSelected.NumAmount;
                    if (treatmentDao.insertServiceTreatment(service_Treatment))
                    {
                        MessageBox.Show("Thành công");
                    }else MessageBox.Show("Thất bại");
>>>>>>> Stashed changes
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
<<<<<<< Updated upstream
        private void themThongTinDieuTri()
=======
        private void ThemThongTinDieuTri()
>>>>>>> Stashed changes
        {
            try
            {
                Treatment treatment = new Treatment();
                treatmentID = treatmentDao.taoMaStreatment();
                treatment.TreatmentID = treatmentID;
                treatment.PatientsID = patientID;
                treatment.UserID = CurrentUser.currentUser.UserID;
                DateTime startDate = dateTPStartDate.Value.Date;
                DateTime endDate = dateTPEndDate.Value.Date;
                DateTime nowDate = DateTime.Now.Date;

                if (nowDate > startDate || startDate > endDate)
                {
                    MessageBox.Show("Thời gian không hợp lệ!", "Error Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                treatment.StartDate = startDate;
                treatment.EndDate = endDate;
                if (txtDetail.Text == "" || txtAdvice.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Error Infomation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                treatment.TreatmentDetail = txtDetail.Text.Trim();
                treatment.Advice = txtAdvice.Text.Trim();

                //thêm điều trị
                if (treatmentDao.insertTreatment(treatment))
                {
<<<<<<< Updated upstream
                    MessageBox.Show("Thêm điều trị thành công!", "Add Treatment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTreatmentID.Text = treatmentID;
                    luuDichVuDieuTri();
                    thuocDieuTri();
=======
                    txtTreatmentID.Text = treatmentID;
                    LuuDichVuDieuTri();
                    LuuThuocDieuTri();
                    MessageBox.Show("Thêm điều trị thành công!", "Add Treatment", MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> Stashed changes
                }
                else
                {
                    throw new InvalidExistPatients("Thêm điều trị thất bại!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Add Treatment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
<<<<<<< Updated upstream
=======

        private void dateTPDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            KiemTraTimKiemDieuTri();
            txtTreatmentID_TextChanged(sender, e);
        }

        private void txtTreatmentID_TextChanged(object sender, EventArgs e)
        {
            KiemTraTimKiemDieuTri();
            LoadPanelDichVuDaChonTheoTreatment();
            LoadPanelThuocDaChonTheoTreatment();
        }


        private void LoadPanelThuocDaChonTheoTreatment()
        {
            pnThuocDaChon.Controls.Clear();
            SqlCommand cmd = new SqlCommand(@"SELECT m.medicineID, m.medicineName, m.unit, m.cost
                                            FROM Medicine_Treatment m_t 
                                            join Medicine m on m.medicineID = m_t.medicineID
                                            where m_t.treatmentID = @ID", mydb.getConnection);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtTreatmentID.Text.Trim();
            DataTable dtService = serviceDao.getService(cmd);

            foreach (DataRow row in dtService.Rows)
            {
                string medicineID = row["medicineID"].ToString();
                string medicineName = row["medicineName"].ToString();
                string unit = row["unit"].ToString();
                float cost;

                if (float.TryParse(row["cost"].ToString(), out cost))
                {
                    UC_ItemSelected uC_ItemDichVuSelected = new UC_ItemSelected(medicineID, medicineName, cost, unit);
                    uC_ItemDichVuSelected.numAmount.Enabled = false;
                    uC_ItemDichVuSelected.pBExit.Visible = false;
                    
                    pnThuocDaChon.Controls.Add(uC_ItemDichVuSelected);
                }
            }
            UpdateTotalCostThuoc();

        }
        private void LoadPanelDichVuDaChonTheoTreatment()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT s.serviceID, s.serviceName, s.cost, s.unit 
                                            FROM Service_Treatment a 
                                            join Service s on a.serviceID = s.serviceID
                                            where a.treatmentID = @ID", mydb.getConnection);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtTreatmentID.Text.Trim();
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
                    uC_ItemDichVuSelected.numAmount.Enabled = false;
                    uC_ItemDichVuSelected.pBExit.Visible = false;
                    pnDichVuDaChon.Controls.Add(uC_ItemDichVuSelected);
                }
            }
            UpdateTotalCostDichVu();
        }
        private void KiemTraTimKiemDieuTri()
        {
            if(txtTreatmentID.Text.ToString() == "")
            {
                pBThemDichVu.Enabled = true;
                pBThemThuoc.Enabled = true;
            }
            else
            {
                pBThemDichVu.Enabled = false;
                pBThemThuoc.Enabled = false;
            }
        }
>>>>>>> Stashed changes
    }
}

