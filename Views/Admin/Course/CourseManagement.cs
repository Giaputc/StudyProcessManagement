using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            LoadStats();      // Load số liệu 3 ô màu
            LoadCourseData(); // Load danh sách thẻ

            txtSearch.TextChanged += (s, e) => { if (txtSearch.Text != "Tìm kiếm khóa học...") LoadCourseData(); };
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
                if (list.Count == 0 && !string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Không tìm thấy khóa học nào!");
                }
                foreach (var c in list)
                {
                    // Logic màu sắc theo danh mục
                    Color color = Color.FromArgb(38, 198, 157); // Mặc định xanh ngọc
                    string icon = "📚";
                    if (c.CategoryName.Contains("Lập trình")) { color = Color.FromArgb(103, 116, 220); icon = "💻"; }
                    if (c.CategoryName.Contains("Ngoại ngữ")) { color = Color.FromArgb(255, 152, 0); icon = "🌏"; }
                    if (c.CategoryName.Contains("Thiết kế")) { color = Color.FromArgb(233, 30, 99); icon = "🎨"; }

                    AddCourseCard(c.CourseID, c.CourseName, c.CategoryName, c.TeacherName, color, icon, c.DisplayStatus, c.IsApproved);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải khóa học: " + ex.Message); }
        }

        // HÀM VẼ THẺ "THẦN THÁNH"
        private void AddCourseCard(string courseId, string title, string category, string teacher, Color headerColor, string icon, string status, bool isApproved)
        {
            // 1. Thẻ chính
            Panel card = new Panel();
            card.Size = new Size(320, 360);
            card.Margin = new Padding(15);
            card.BackColor = Color.White;

            // 2. Header (Màu + Icon)
            Panel pnlHeader = new Panel();
            pnlHeader.Size = new Size(320, 150);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.BackColor = headerColor;
            pnlHeader.Paint += (s, e) => {
                using (Font font = new Font("Segoe UI Emoji", 50F))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                {
                    SizeF iconSize = e.Graphics.MeasureString(icon, font);
                    e.Graphics.DrawString(icon, font, brush, (pnlHeader.Width - iconSize.Width) / 2, (pnlHeader.Height - iconSize.Height) / 2);
                }
            };
            card.Controls.Add(pnlHeader);

            // 3. Nội dung
            Panel pnlContent = new Panel();
            pnlContent.Size = new Size(320, 210);
            pnlContent.Location = new Point(0, 150);
            pnlContent.BackColor = Color.White;

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
                Size = new Size(120, 35),
                Location = new Point(180, 160),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(33, 150, 243),
                Cursor = Cursors.Hand
            };
            btnVerify.FlatAppearance.BorderSize = 1;
            btnVerify.FlatAppearance.BorderColor = Color.FromArgb(33, 150, 243);

            btnVerify.Click += (s, e) => {
                CourseVerificationForm form = new CourseVerificationForm(courseId, title);
                if (form.ShowDialog() == DialogResult.OK) LoadCourseData(); // Reload nếu duyệt thành công
            };

            pnlContent.Controls.AddRange(new Control[] { lblCat, lblName, lblTeacher, lblStatus, btnVerify });
            card.Controls.Add(pnlContent);
            flowCourses.Controls.Add(card);
        }

        private void flowCourses_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSearchIcon_Click(object sender, EventArgs e)
        {
            LoadCourseData();
        }

        private void CourseManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadCourseData();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}