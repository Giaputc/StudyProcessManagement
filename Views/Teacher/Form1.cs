using System;
using System.Drawing;
using System.Windows.Forms;
using StudyProcessManagement.Views.Teacher.Controls;

namespace StudyProcessManagement.Views.Teacher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                ShowDashboard();
            }
        }

        // =============================================
        // EVENT HANDLERS CHO CÁC BUTTONS
        // =============================================
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            ShowCourses();
        }

        private void btnContent_Click(object sender, EventArgs e)
        {
            ShowContent();
        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            ShowAssessments();
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
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                var loginForm = new StudyProcessManagement.Views.Login.Login();
                loginForm.Show();
            }
        }

        // =============================================
        // METHODS HIỂN THỊ CÁC CONTROLS
        // =============================================
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

        private void ShowAssessments()
        {
            panelContent.Controls.Clear();
            var ctrl = new AssessmentControl();
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

        // =============================================
        // PUBLIC METHODS ĐỂ DASHBOARD GỌI - ✅ THÊM MỚI
        // =============================================
        public void NavigateToCourseManagement()
        {
            ShowCourses();
        }

        public void NavigateToGradingWithFilter(string filter)
        {
            ShowGrading();
            // TODO: Có thể set filter cho GradingControl nếu cần
        }

        // =============================================
        // PAINT EVENT
        // =============================================
        private void panelLogout_Paint(object sender, PaintEventArgs e)
        {
            var avatarRect = new Rectangle(20, 8, 40, 40);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(Color.FromArgb(76, 175, 80)))
            {
                e.Graphics.FillEllipse(brush, avatarRect);
            }

            using (var font = new Font("Segoe UI", 16F, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.White))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString("T", font, textBrush, new Rectangle(avatarRect.X, avatarRect.Y, avatarRect.Width, avatarRect.Height), sf);
            }

            using (var font = new Font("Segoe UI", 10.5F, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.White))
            {
                e.Graphics.DrawString("Teacher", font, textBrush, 68, 11);
            }

            using (var font = new Font("Segoe UI", 8.5F))
            using (var textBrush = new SolidBrush(Color.FromArgb(180, 180, 180)))
            {
                e.Graphics.DrawString("Giảng viên", font, textBrush, 68, 30);
            }
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            this.btnLogout.BackColor = Color.FromArgb(192, 57, 43);
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            this.btnLogout.BackColor = Color.FromArgb(201, 69, 57);
        }
    }
}
