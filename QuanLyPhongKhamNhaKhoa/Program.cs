using QuanLyPhongKhamNhaKhoa.User_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*Test test = new Test();
            test.ShowDialog();
            */
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            
            Application.Run(new MainForm());
        }
    }
}
