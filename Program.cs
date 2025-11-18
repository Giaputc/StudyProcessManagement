using System;
using System.Windows.Forms;
using StudyProcessManagement.Views;
using StudyProcessManagement.Views.Admin;
using StudyProcessManagement.Views.Admin.Dashboard;
using StudyProcessManagement.Views.Admin.User;
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
            Application.Run(new MainForm());
        }
    }
}
