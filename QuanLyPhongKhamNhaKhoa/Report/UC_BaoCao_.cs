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

namespace QuanLyPhongKhamNhaKhoa.Report
{
    public partial class UC_BaoCao_ : UserControl
    {
        public UC_BaoCao_()
        {
            InitializeComponent();
        }
        BillDao billDao = new BillDao();
        private void UC_BaoCao__Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            try
            {
                reset();
                DateTime selectedDate = pkdateTime.Value.Date;

                SqlCommand cmd = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY exportBillDate) AS [STT], p.fullName AS [Bệnh nhân], u.fullName AS [Bác sĩ], totalCost AS [DoanhThu]
                                            FROM Treatment t join Users u ON t.userID = u.userID 
                                                                join Patients p ON t.patientsID = p.patientsID 
                                                                join Bill b ON t.treatmentID = b.treatmentID
                                            WHERE CONVERT(date, b.exportBillDate) = @SelectedDate");
                cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);
                dataDanhSachHoaDon.ReadOnly = true;
                dataDanhSachHoaDon.DataSource = billDao.getBill(cmd);
                lblSLDieuTri.Text = dataDanhSachHoaDon.Rows.Count.ToString();

                // Tính toán và gán doanh thu vào lblDoanhThu
                double doanhThu = billDao.CalculateDailyRevenue(selectedDate);
                lblDoanhThu.Text = string.Format("{0:N0}", doanhThu) + "VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void reset()
        {
            uC_BaoCaoTheoNam1.Visible = false;
            uC_BaoCaoTheoThang1.Visible = false;
        }
        private void NgayItemToolTip_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void thangItemToolTip_Click(object sender, EventArgs e)
        {
            reset();
            uC_BaoCaoTheoThang1.Visible = true;
        }

        private void NamItemToolTip_Click(object sender, EventArgs e)
        {
            reset();
            uC_BaoCaoTheoNam1.Visible = true;
        }

        private void pkdateTime_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
