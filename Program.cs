using System;
using System.Windows.Forms;
using StudyProcessManagement.Views;
using StudyProcessManagement.Views.Admin;
using StudyProcessManagement.Views.Admin.Dashboard;
using StudyProcessManagement.Views.Admin.User;
using StudyProcessManagement.Views.Login;
using StudyProcessManagement.Views.Teacher;

namespace StudyProcessManagement
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

            // Ông đang chạy MainForm (Giao diện Admin) để test đúng không?
            // Nếu muốn chạy từ màn hình Đăng nhập thì sửa thành: new Login()
            Application.Run(new MainForm());
        }
    }
}