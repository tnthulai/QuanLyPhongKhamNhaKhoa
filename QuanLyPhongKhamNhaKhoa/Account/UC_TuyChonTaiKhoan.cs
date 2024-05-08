using QuanLyPhongKhamNhaKhoa.Account;
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
            try
            {
                AccountInfoForm accountInfoForm = new AccountInfoForm();
                //lấy userID chuyển qua cho accountInfoForm
                accountInfoForm.userID = CurrentUser.currentUser.UserID;
                this.Visible = false;
                accountInfoForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }

        private void lblDoiMatKhau_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            this.Visible = false;
            changePasswordForm.ShowDialog();
        }
        public event EventHandler DangXuatClicked;

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Khi người dùng chấp nhận đăng xuất, kích hoạt sự kiện DangXuatClicked
                    DangXuatClicked?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
