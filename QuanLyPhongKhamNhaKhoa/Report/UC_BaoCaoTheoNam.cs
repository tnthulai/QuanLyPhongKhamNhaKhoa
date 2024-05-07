using QuanLyPhongKhamNhaKhoa.Dao;
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
using System.Windows.Forms.DataVisualization.Charting;
namespace QuanLyPhongKhamNhaKhoa.Report
{
    public partial class UC_BaoCaoTheoNam : UserControl
    {
        public UC_BaoCaoTheoNam()
        {
            InitializeComponent();
        }
        SQLConnectionData mydb = new SQLConnectionData();
        BillDao billDao = new BillDao();

        private void UC_BaoCaoTheoNam_Load(object sender, EventArgs e)
        {
            loadComboBox();
            cbNam.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        private void loadRevenueByYear()
        {
            using (SqlCommand command = new SqlCommand("CalculateRevenueByYear", mydb.getConnection))
            {
                int year;
                if (cbNam.SelectedItem != null)
                {
                    year = Convert.ToInt32(cbNam.SelectedItem.ToString());
                }
                else
                {
                    return;
                }
                //Hiển thị label tổng doanh thu
                double tongDoanhThu = billDao.CalculateYearlyRevenue(year);
                lblTongDoanhThu.Text = "Tổng doanh thu: " + string.Format("{0:N0}", tongDoanhThu) + "VND";

                command.CommandType = CommandType.StoredProcedure;
                mydb.openConnection();
                command.Parameters.Add("@Year", SqlDbType.Int).Value = year;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thiết lập dữ liệu cho biểu đồ
                    chartDoanhThuNam.Series.Clear();
                    chartDoanhThuNam.Series.Add("Doanh thu");
                    chartDoanhThuNam.Series["Doanh thu"].ChartType = SeriesChartType.Column;
                    chartDoanhThuNam.ChartAreas[0].AxisX.Title = "Tháng";
                    chartDoanhThuNam.ChartAreas[0].AxisY.Title = "Doanh thu";

                    // Lặp qua tất cả các tháng trong năm và thêm dữ liệu tương ứng
                    for (int month = 1; month <= 12; month++)
                    {
                        DataRow[] rows = dataTable.Select("Month = " + month.ToString());
                        double revenue = rows.Length > 0 ? Convert.ToDouble(rows[0]["Revenue"]) : 0;

                        // Thêm điểm vào biểu đồ với giá trị tiền làm tròn
                        chartDoanhThuNam.Series["Doanh thu"].Points.AddXY(month.ToString(), revenue);

                        // Thêm nhãn cho điểm
                        chartDoanhThuNam.Series["Doanh thu"].Points.Last().Label = string.Format("{0:N0}", revenue);
                        chartDoanhThuNam.MouseMove += (sender1, ev) =>
                        {
                            var chart = (Chart)sender1;
                            var result = chart.HitTest(ev.X, ev.Y);

                            // Kiểm tra xem điểm nào được di chuột vào
                            if (result.ChartElementType == ChartElementType.DataPoint)
                            {
                                var dataPoint = chart.Series["Doanh thu"].Points[result.PointIndex];

                                // Thiết lập kích thước font size lớn hơn khi di chuột vào
                                dataPoint.Font = new System.Drawing.Font("Arial", 11);
                            }
                            else
                            {
                                // Thiết lập kích thước font size nhỏ hơn khi di chuột ra khỏi điểm
                                foreach (var point in chart.Series["Doanh thu"].Points)
                                {
                                    point.Font = new System.Drawing.Font("Arial", 7);
                                }
                            }
                        };
                    }
                }
            }


            mydb.closeConnection();


        }
        private void loadComboBox()
        {
            try
            {
                mydb.openConnection();

                string query = "\r\nSELECT DISTINCT YEAR(exportBillDate) AS Year FROM Bill ORDER BY Year DESC";
                mydb.openConnection();
                using (SqlCommand command = new SqlCommand(query, mydb.getConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbNam.Items.Add(reader.GetInt32(0).ToString());
                        }
                    }
                }
                cbNam.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading ComboBox: " + ex.Message);
            }
            finally
            {
                mydb.closeConnection();
            }

        }

        private void cbNam_SelectedValueChanged(object sender, EventArgs e)
        {
            loadRevenueByYear();
        }
    }
}
