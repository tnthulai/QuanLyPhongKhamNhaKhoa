using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.Entity;
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

namespace QuanLyPhongKhamNhaKhoa
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        UserDao userDao = new UserDao();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE userID = @User AND password = @Pass");
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = txtTenDangNhap.Text.Trim();
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtMatKhau.Text.Trim();

            User user = userDao.getUser(command);
            if (user != null)
            {
                CurrentUser.currentUser = user; // Lưu thông tin người dùng vào UserManager
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu sai.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbHienPassword_Click(object sender, EventArgs e)
        {
            if (pbHienPassword.Image == an)
            {
                pbHienPassword.Image = hien;
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                pbHienPassword.Image = an;
                txtMatKhau.PasswordChar = '*';
            }
        }
        Image hien = Image.FromFile("../../image/visible.png");
        Image an = Image.FromFile("../../image/visiblefalse.png");
        private void LoginForm_Load(object sender, EventArgs e)
        {
            pbHienPassword.Image = an;
            txtMatKhau.PasswordChar = '*';
        }
    }
}
