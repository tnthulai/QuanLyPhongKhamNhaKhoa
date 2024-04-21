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

      

        private void UC_DieuTri_New_Load(object sender, EventArgs e)
        {
            
            LoadListViewCustom();
            customlvDichVu.ItemCheckedChanged += CustomListViewDichVu_ItemCheckedChanged;

        }

        private void LoadListViewCustom()
        {
            customlvDichVu.Columns.Clear();
            customlvDichVu.Columns.Add("", 20, HorizontalAlignment.Left);
            customlvDichVu.Columns.Add("Tên Dịch Vụ", 140, HorizontalAlignment.Left);
            customlvDichVu.Columns.Add("Giá", 60, HorizontalAlignment.Left);
            customlvDichVu.Columns.Add("Đơn Vị", 50, HorizontalAlignment.Left);
            customlvDichVu.Columns.Add("Số Lượng", 80, HorizontalAlignment.Left);

            string query = "SELECT serviceName, cost, unit FROM Service";
            DataTable dtService = GetData(query);

            // Thêm dữ liệu vào ListView
            foreach (DataRow row in dtService.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(row["serviceName"].ToString());
                //item.SubItems.Add(row["serviceName"].ToString()); // Tên dịch vụ
                item.SubItems.Add(row["cost"].ToString()); // Giá
                item.SubItems.Add(row["unit"].ToString()); // Đơn vị
                item.SubItems.Add(""); 

                customlvDichVu.Items.Add(item);
                customlvDichVu.AddControlsToItem(item);

            }
            
            
        }
        private void CustomListViewDichVu_ItemCheckedChanged(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem item = e.Item;
            // Thêm dữ liệu từ item vào lvDichVuDaChon
            lvDichVuDaChon.Items.Add((ListViewItem)item.Clone());
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

