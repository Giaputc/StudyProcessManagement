using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StudyProcessManagement.Business.Admin;
using StudyProcessManagement.Models;

namespace StudyProcessManagement.Views.Admin.Course
{
    public partial class CourseManagement : Form
    {
        private CourseService courseService = new CourseService();

        public CourseManagement()
        {
            InitializeComponent();
            LoadStats();
            LoadCourseData();

            // Gắn sự kiện tìm kiếm chuẩn chỉ
            txtSearch.TextChanged += (s, e) => { if (txtSearch.Text != "Tìm kiếm khóa học...") LoadCourseData(); };
            txtSearch.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) { LoadCourseData(); e.SuppressKeyPress = true; e.Handled = true; }
            };
            lblSearchIcon.Click += (s, e) => LoadCourseData();

            // Placeholder events
            txtSearch.Enter += (s, e) => { if (txtSearch.Text.StartsWith("Tìm")) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Tìm kiếm khóa học..."; txtSearch.ForeColor = Color.Gray; } };
        }

        private void LoadStats()
        {
            var stats = courseService.GetDashboardStats();
            lblStatCourses.Text = $"📘 Tổng khóa học: {stats["Courses"]}";
            lblStatStudents.Text = $"👥 Tổng học viên: {stats["Students"]}";
            lblStatLessons.Text = $"📖 Tổng bài học: {stats["Lessons"]}";
        }

        private void LoadCourseData()
        {
            try
            {
                flowCourses.Controls.Clear();
                string keyword = txtSearch.Text.Trim();
                if (keyword.StartsWith("Tìm")) keyword = "";

                List<Models.Course> list = courseService.GetAllCourses(keyword);

                foreach (var c in list)
                {
                    Color color = Color.FromArgb(38, 198, 157); // Xanh ngọc
                    string icon = "📚";
                    if (c.CategoryName.Contains("Lập trình")) { color = Color.FromArgb(103, 116, 220); icon = "💻"; }
                    if (c.CategoryName.Contains("Ngoại ngữ")) { color = Color.FromArgb(255, 152, 0); icon = "🌏"; }
                    if (c.CategoryName.Contains("Thiết kế")) { color = Color.FromArgb(233, 30, 99); icon = "🎨"; }

                    AddCourseCard(c.CourseID.ToString(), c.CourseName, c.CategoryName, c.TeacherName, color, icon, c.DisplayStatus, c.IsApproved);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void AddCourseCard(string courseId, string title, string category, string teacher, Color headerColor, string icon, string status, bool isApproved)
        {
            Panel card = new Panel { Size = new Size(320, 360), Margin = new Padding(15), BackColor = Color.White };

            // Header
            Panel pnlHeader = new Panel { Size = new Size(320, 150), Location = new Point(0, 0), BackColor = headerColor };
            pnlHeader.Paint += (s, e) => {
                using (Font font = new Font("Segoe UI Emoji", 50F))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                {
                    SizeF iconSize = e.Graphics.MeasureString(icon, font);
                    e.Graphics.DrawString(icon, font, brush, (pnlHeader.Width - iconSize.Width) / 2, (pnlHeader.Height - iconSize.Height) / 2);
                }
            };
            card.Controls.Add(pnlHeader);

            // Content
            Panel pnlContent = new Panel { Size = new Size(320, 210), Location = new Point(0, 150), BackColor = Color.White };

            Label lblCat = new Label { Text = category.ToUpper(), Font = new Font("Segoe UI", 8F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(15, 15), AutoSize = true };
            Label lblName = new Label { Text = title, Font = new Font("Segoe UI", 13F, FontStyle.Bold), ForeColor = Color.FromArgb(40, 40, 40), AutoSize = false, Size = new Size(290, 55), Location = new Point(12, 35) };
            Label lblTeacher = new Label { Text = "👨‍🏫 " + teacher, Font = new Font("Segoe UI", 9.5F), ForeColor = Color.DimGray, Location = new Point(15, 95), AutoSize = true };

            Label lblStatus = new Label
            {
                Text = status,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = isApproved ? Color.FromArgb(27, 94, 32) : Color.FromArgb(230, 81, 0),
                BackColor = isApproved ? Color.FromArgb(200, 230, 201) : Color.FromArgb(255, 224, 178),
                AutoSize = true,
                Padding = new Padding(5, 3, 5, 3),
                Location = new Point(15, 125)
            };

            // Nút Xem & Duyệt
            Button btnVerify = new Button
            {
                Text = "👁️ Xem & Duyệt",
                Size = new Size(110, 35),
                Location = new Point(190, 160),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(33, 150, 243),
                Cursor = Cursors.Hand
            };
            btnVerify.FlatAppearance.BorderSize = 1;
            btnVerify.FlatAppearance.BorderColor = Color.FromArgb(33, 150, 243);
            btnVerify.Click += (s, e) => {
                CourseVerificationForm form = new CourseVerificationForm(courseId, title);
                if (form.ShowDialog() == DialogResult.OK) LoadCourseData();
            };

            // Nút Xóa (Thêm vào cho đủ bộ CRUD Admin)
            Button btnDelete = new Button
            {
                Text = "🗑️",
                Size = new Size(35, 35),
                Location = new Point(145, 160),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Red,
                Cursor = Cursors.Hand
            };
            btnDelete.FlatAppearance.BorderSize = 1;
            btnDelete.FlatAppearance.BorderColor = Color.Red;
            btnDelete.Click += (s, e) => {
                if (MessageBox.Show("Xóa khóa học này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (courseService.DeleteCourse(courseId)) LoadCourseData();
                }
            };

            pnlContent.Controls.AddRange(new Control[] { lblCat, lblName, lblTeacher, lblStatus, btnVerify, btnDelete });
            card.Controls.Add(pnlContent);
            flowCourses.Controls.Add(card);
        }

        // Các hàm sự kiện rác (nếu có) có thể xóa hoặc để trống
        private void flowCourses_Paint(object sender, PaintEventArgs e) { }
        private void CourseManagement_KeyDown(object sender, KeyEventArgs e) { }

        private void lblSearchIcon_Click(object sender, EventArgs e)
        {

        }

        private void lblStatCourses_Click(object sender, EventArgs e)
        {

        }
    }
}