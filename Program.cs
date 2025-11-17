using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            // Temporarily run Form1 for testing the new UI instead of Login
            Application.Run(new Form1());
        }
    }
}
