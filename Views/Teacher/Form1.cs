using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyProcessManagement.Views.Teacher.Controls;

namespace StudyProcessManagement.Views.Teacher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            ShowCourses();
        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            ShowContent();
        }

        private void btnGrading_Click(object sender, EventArgs e)
        {
            ShowGrading();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            ShowStudents();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Simple placeholder: close form to simulate logout
            this.Close();
        }

        private void ShowDashboard()
        {
            panelContent.Controls.Clear();
            var ctrl = new DashboardControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }

        private void ShowCourses()
        {
            panelContent.Controls.Clear();
            var ctrl = new CourseControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }

        private void ShowContent()
        {
            panelContent.Controls.Clear();
            var ctrl = new ContentControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }

        private void ShowGrading()
        {
            panelContent.Controls.Clear();
            var ctrl = new GradingControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }

        private void ShowStudents()
        {
            panelContent.Controls.Clear();
            var ctrl = new StudentsControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }
    }
}
