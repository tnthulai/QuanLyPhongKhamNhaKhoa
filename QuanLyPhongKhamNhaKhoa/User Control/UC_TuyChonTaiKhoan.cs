using QuanLyPhongKhamNhaKhoa.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    public partial class UC_TuyChonTaiKhoan : UserControl
    {
        public UC_TuyChonTaiKhoan()
        {
            InitializeComponent();
        }

        

        private void UC_TuyChonTaiKhoan_Load(object sender, EventArgs e)
        {
            lblUserName.Text = CurrentUser.currentUser.FullName;
        }

        private void lblXemHoSo_Click(object sender, EventArgs e)
        {
            AccountInfoForm accountInfoForm = new AccountInfoForm();
            //lấy userID chuyển qua cho accountInfoForm
            accountInfoForm.userID = CurrentUser.currentUser.UserID;
            accountInfoForm.ShowDialog();
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }
    }
}
