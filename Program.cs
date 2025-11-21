using System;
using System.Windows.Forms;
using StudyProcessManagement.Views;
using StudyProcessManagement.Views.Admin;
using StudyProcessManagement.Views.Admin.Course;
using StudyProcessManagement.Views.Admin.Dashboard;
using StudyProcessManagement.Views.Admin.Student.StudentManagement;
using StudyProcessManagement.Views.Admin.Teacher.TeacherMangement;
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

        
            Application.Run(new CourseManagement());
        }
    }
}