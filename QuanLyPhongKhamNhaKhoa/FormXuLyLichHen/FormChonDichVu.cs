using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.Entity;
using QuanLyPhongKhamNhaKhoa.User_Control;
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
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa.FormXuLyLichHen
{
    
    public partial class FormChonDichVu : Form
    {
        public ListDichVuSelected listDichVuSelected;
        public FormChonDichVu()
        {
            InitializeComponent();
        }
        public FormChonDichVu(ListDichVuSelected sender)
        {
            InitializeComponent();
            this.listDichVuSelected = sender;
        }

        SQLConnectionData mydb = new SQLConnectionData();
        ServiceDao serviceDao = new ServiceDao();


        public List<Service> listService = new List<Service>();

        private void FormChonDichVu_Load(object sender, EventArgs e)
        {
            LoadListDichVu("");
        }

        private void LoadListDichVu(string service)
        {
            SqlCommand cmd = new SqlCommand("SELECT serviceID, serviceName, cost, unit FROM Service where serviceName like @serviceName", mydb.getConnection);
            cmd.Parameters.Add("@serviceName", SqlDbType.NVarChar).Value = "%" + service + "%";
            DataTable dtService = serviceDao.getService(cmd);


            panelDichVu.Controls.Clear();
            foreach (DataRow row in dtService.Rows)
            {
                string serviceName = row["serviceName"].ToString();
                string unit = row["unit"].ToString();
                string id = row["serviceID"].ToString();
                float cost;

                if (float.TryParse(row["cost"].ToString(), out cost))
                {
                    UC_ItemDichVu uC_itemDichVu = new UC_ItemDichVu(id, serviceName, cost, unit);
                    uC_itemDichVu.CheckBoxCheckedChanged += UC_ItemDichVu_CheckBoxCheckedChanged;

                    panelDichVu.Controls.Add(uC_itemDichVu);


                }
            }
        }
        private void UC_ItemDichVu_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            UC_ItemDichVu selectedDichVu = sender as UC_ItemDichVu;
            if (selectedDichVu.checkBox.Checked)
            {
                Service service = new Service(selectedDichVu.ServiceId, selectedDichVu.ServiceName, selectedDichVu.ServiceCost, selectedDichVu.ServiceUnit);
                //MessageBox.Show(selectedDichVu.ServiceId + selectedDichVu.ServiceName + selectedDichVu.ServiceCost + selectedDichVu.ServiceUnit);
                listService.Add(service);
            }
            else
            {
                listService.RemoveAll(service => service.ServiceID == selectedDichVu.ServiceId);
            }
        
        }
        private void txtDichVu_TextChanged(object sender, EventArgs e)
        {
            LoadListDichVu(txtDichVu.Text.Trim());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.listDichVuSelected(listService);
            this.Close();
        }

        private void pBExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
