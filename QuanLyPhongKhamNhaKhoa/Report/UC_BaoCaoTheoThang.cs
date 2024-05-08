using Microsoft.ReportingServices.Diagnostics.Internal;
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

namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    public partial class UC_BaoCaoTheoThang : UserControl
    {
        public UC_BaoCaoTheoThang()
        {
            InitializeComponent();
        }
        SQLConnectionData mydb = new SQLConnectionData();
        BillDao billDao = new BillDao();

        private void UC_BaoCao_Load(object sender, EventArgs e)
        {
            loadComboBox();
            cbNam.DropDownStyle = ComboBoxStyle.DropDownList;
            
            cbThang.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void loadComboBox()
        {
            try
            {
                mydb.openConnection();

                // Load dữ liệu của tháng từ 1 đến 12 vào ComboBox cbThang
                for (int month = 1; month <= 12; month++)
                {
                    cbThang.Items.Add(month.ToString());
                }
                int currentMonth = DateTime.Now.Month;
                cbThang.SelectedItem = (currentMonth - 1).ToString();

                // Tạo một truy vấn SQL để lấy năm từ bảng Bill
                string query = "\r\nSELECT DISTINCT YEAR(exportBillDate) AS Year FROM Bill ORDER BY Year DESC";
                mydb.openConnection();
                using (SqlCommand command = new SqlCommand(query, mydb.getConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Đọc từng năm từ kết quả truy vấn và thêm vào ComboBox cbNam
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
                // Xử lý exception nếu có
                MessageBox.Show("Error loading ComboBox: " + ex.Message);
            }
            finally
            {
                mydb.closeConnection();
            }

        }

        private void loadRevenueByMonth()
        {

            //MessageBox.Show(cbNam.SelectedItem.ToString());
            try
            {
                using (SqlCommand command = new SqlCommand("CalculateRevenueByMonth", mydb.getConnection))
                {

                    int month;
                    int year;
                    if (cbNam.SelectedItem != null)
                    {
                        month = Convert.ToInt32(cbThang.SelectedItem.ToString());
                        year = Convert.ToInt32(cbNam.SelectedItem.ToString());
                    }
                    else
                    {
                        return;
                    }
                    //Hiển thị label tổng doanh thu
                    double tongDoanhThu = billDao.CalculateMonthlyRevenue(month, year);
                    lblTongDoanhThu.Text = "Tổng doanh thu: " + string.Format("{0:N0}", tongDoanhThu) + "VND";


                    command.CommandType = CommandType.StoredProcedure;
                    mydb.openConnection();
                    command.Parameters.Add("@Month", SqlDbType.Int).Value = month;
                    command.Parameters.Add("@Year", SqlDbType.Int).Value = year;

                    // Tạo một SqlDataAdapter để lấy dữ liệu từ store procedure
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Thiết lập dữ liệu cho biểu đồ
                        chartDoanhThuThang.Series.Clear();
                        chartDoanhThuThang.Series.Add("Doanh thu");
                        chartDoanhThuThang.Series["Doanh thu"].ChartType = SeriesChartType.Line;
                        chartDoanhThuThang.ChartAreas[0].AxisX.Title = "Ngày";
                        chartDoanhThuThang.ChartAreas[0].AxisY.Title = "Doanh thu";

                        // Lặp qua tất cả các ngày trong tháng và thêm dữ liệu tương ứng
                        DateTime firstDayOfMonth = new DateTime(year, month, 1);
                        DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                        while (firstDayOfMonth <= lastDayOfMonth)
                        {
                            // Kiểm tra xem có dữ liệu cho ngày hiện tại không
                            DataRow[] rows = dataTable.Select("Date = '" + firstDayOfMonth.ToString("yyyy-MM-dd") + "'");
                            if (rows.Length > 0)
                            {
                                double revenue = Convert.ToDouble(rows[0]["Revenue"]);

                                // Thêm điểm vào biểu đồ với giá trị tiền làm tròn
                                chartDoanhThuThang.Series["Doanh thu"].Points.AddXY(firstDayOfMonth.ToString("dd/MM"), revenue);

                                // Thiết lập nhãn cho trục hoành của điểm
                                chartDoanhThuThang.Series["Doanh thu"].Points.Last().AxisLabel = firstDayOfMonth.ToString("dd/MM");

                                // Thêm nhãn cho điểm
                                chartDoanhThuThang.Series["Doanh thu"].Points.Last().Label = string.Format("{0:N0}", revenue);
                                chartDoanhThuThang.MouseMove += (sender1, ev) =>
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
                            else
                            {
                                // Nếu không có dữ liệu, thêm một điểm với giá trị 0
                                chartDoanhThuThang.Series["Doanh thu"].Points.AddXY(firstDayOfMonth.ToString("dd/MM"), 0);

                                // Thiết lập nhãn cho trục hoành của điểm
                                chartDoanhThuThang.Series["Doanh thu"].Points.Last().AxisLabel = firstDayOfMonth.ToString("dd/MM");

                                // Thêm nhãn cho điểm
                                //chartDoanhThuThang.Series["Doanh thu"].Points.Last().Label = "0"; // Số tiền doanh thu
                            }

                            // Chuyển sang ngày tiếp theo trong tháng
                            firstDayOfMonth = firstDayOfMonth.AddDays(1);
                        }
                    }
                }
                mydb.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void cbThang_SelectedValueChanged(object sender, EventArgs e)
        {
            loadRevenueByMonth();
        }

        private void cbNam_SelectedValueChanged_1(object sender, EventArgs e)
        {
            loadRevenueByMonth();
        }
    }
}
