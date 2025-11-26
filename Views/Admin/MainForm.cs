using StudyProcessManagement.Views.Admin.Course;
using StudyProcessManagement.Views.Admin.Dashboard;
using StudyProcessManagement.Views.Admin.Student.StudentManagement;
using StudyProcessManagement.Views.Admin.Teacher.TeacherMangement;
using StudyProcessManagement.Views.Admin.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyProcessManagement.Views.Login;
namespace StudyProcessManagement.Views.Admin
{
    public partial class MainForm : Form
    {
        private Form currentChildForm;
        public MainForm()
        {
            InitializeComponent();
            FormatMenuButtons();

            // Mặc định mở Dashboard khi chạy lên
            OpenChildForm(new DashboardForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void FormatMenuButtons()
        {
            // Cấu hình chung cho các nút menu
            System.Windows.Forms.Button[] menuButtons = { this.btnMenuDashboard, this.btnMenuUsers, this.btnMenuTeachers, this.btnMenuStudents, this.btnMenuCourses };
            foreach (var btn in menuButtons)
            {
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
                btn.Font = new System.Drawing.Font("Segoe UI", 10F);
                btn.Size = new System.Drawing.Size(220, 40);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
                btn.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            childForm.TopLevel = false; // Biến form thành control thường
            childForm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền
            childForm.Dock = DockStyle.Fill; // Lấp đầy panel

            panelContent.Controls.Add(childForm); 
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnMenuDashboard_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardForm());
        }

        private void btnMenuUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserManagement());
        }

        private void btnMenuTeachers_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new TeacherMangement());
        }

        private void btnMenuStudents_Click_1(object sender, EventArgs e)
        {

            OpenChildForm(new StudentManagement());
        }

        private void btnMenuCourses_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CourseManagement());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                var loginForm = new StudyProcessManagement.Views.Login.Login();
                loginForm.Show();
            }
        }
    }
}
