using QuanLyPhongKhamNhaKhoa.Dao;
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

namespace QuanLyPhongKhamNhaKhoa.Account
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }
        UserDao userDao = new UserDao();
        Image hien = Image.FromFile("../../image/visible.png");
        Image an = Image.FromFile("../../image/visiblefalse.png");
        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            pbHienPassword.Image = an;
            txtMKHienTai.PasswordChar = '*';
        }

        private void pbHienPassword_Click(object sender, EventArgs e)
        {
            if(pbHienPassword.Image == an)
            {
                pbHienPassword.Image = hien;
                txtMKHienTai.PasswordChar = '\0';
            } else
            {
                pbHienPassword.Image = an;
                txtMKHienTai.PasswordChar = '*';
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if(txtMKHienTai.Text == CurrentUser.currentUser.Password)
            {
                if(txtMKMoi.Text == txtNhapLaiMK.Text)
                {
                    CurrentUser.currentUser.Password = txtMKMoi.Text.Trim();
                    
                    if(userDao.changePassWord(CurrentUser.currentUser))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công.", "Change Password Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không hợp lệ.", "Change Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hiện tại.", "Change Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
