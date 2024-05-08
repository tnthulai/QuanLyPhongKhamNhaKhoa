using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace QuanLyPhongKhamNhaKhoa.Account
{
    public partial class FormForgotPassword : Form
    {
        string randomCode;
        public static string to;
        public FormForgotPassword()
        {
            InitializeComponent();
        }

        private void btnGuiEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ email!", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra email không tồn tại
                if (existEmail() == false)
                {
                    MessageBox.Show("Email không tồn tại, vui lòng kiểm tra lại email", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo mã ngẫu nhiên và gửi email
                string from, pass, messageBody;
                Random rand = new Random();
                randomCode = (rand.Next(999999)).ToString();
                MailMessage message = new MailMessage();

                string to = txtEmail.Text.ToString().Trim();
                from = "nguyentranthulai@gmail.com"; // Email của bạn
                pass = "opta rrst uesb fdqc";

                messageBody = "Code: " + randomCode;

                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "Creation code successful";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);

                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Đã gửi mã thành công!", "Code Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message, "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool existEmail()
        {
            try
            {
                SQLConnectionData myDB = new SQLConnectionData();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE email = '" + txtEmail.Text.ToString().Trim() + "'", myDB.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                if (tb.Rows.Count > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (checkCode() == false)
            {
                return;
            }
            else
            {
                CapNhatMatKhau();
            }
        }

        private void CapNhatMatKhau()
        {
            try
            {
                SQLConnectionData myDB = new SQLConnectionData();
                SqlCommand cmd = new SqlCommand("UPDATE Users SET password = @pass WHERE email = @email", myDB.getConnection);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtNewPassword.Text.Trim();
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();

                if (checkInfor())
                {
                    if (txtNewPassword.Text.ToString().Trim() != txtRePass.Text.ToString().Trim())
                    {
                        MessageBox.Show("Xác thực mật khẩu thất bại, vui lòng kiểm tra lại!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNewPassword.Text = "";
                        txtRePass.Text = "";
                        return;
                    }
                    myDB.openConnection();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        myDB.closeConnection();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng không để trống thông tin!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool checkInfor()
        {
            if (txtNewPassword.Text.Trim() == "" || txtRePass.Text.Trim() == "")
                return false;
            return true;
        }
        private bool checkCode()
        {
            if (txtMaXacThuc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã xác thực!", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (randomCode.Trim() == txtMaXacThuc.Text.ToString().Trim())
            {
                to = txtEmail.Text.Trim();
                return true;
            }
            else
            {
                MessageBox.Show("Mã xác thực bị sai, vui lòng nhập lại mã!", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
