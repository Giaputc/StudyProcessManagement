
using StudyProcessManagement.Views.Login;
using StudyProcessManagement.Views.Student.assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using StudyProcessManagement.Views;

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

            Application.Run(new Login());
            //Application.Run(new assignments());


            // Ông đang chạy MainForm (Giao diện Admin) để test đúng không?
            // Nếu muốn chạy từ màn hình Đăng nhập thì sửa thành: new Login()


        }
    }
}