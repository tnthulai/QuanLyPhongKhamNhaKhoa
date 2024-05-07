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
      

        private void UC_DieuTri_New_Load(object sender, EventArgs e)
        {
            
            LoadPanelDichVu();

        }

        private void LoadPanelDichVu()
        {
            SqlCommand cmd = new SqlCommand( "SELECT serviceID, serviceName, cost, unit FROM Service",mydb.getConnection);
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
            }
        }

        private void UC_ItemDichVu_CheckBoxCheckedChanged(object sender, EventArgs e)
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
            
        }
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
            /*totalCost = 0;
            foreach (Control control in pnDichVuDaChon.Controls)
            {
                UC_ItemDichVuSelected selectedService = sender as UC_ItemDichVuSelected;
                float serviceTotalCost;// = float.Parse(selectedService.lblTotalCost.Text);

                if (float.TryParse(selectedService.lblTotalCost.Text.Replace("VND", ""), out serviceTotalCost))
                {
                    totalCost += serviceTotalCost;
                }
            }

            lblTotalCost.Text = totalCost.ToString("0.##") + "VND";*/
            UpdateTotalCost();
        }
       
        private DataTable GetData(String query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}

