using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public class CourseControl : UserControl
    {
        private TableLayoutPanel mainLayout;
        private Panel headerPanel;
        private Label lblTitle;
        private Button btnCreate;
        private FlowLayoutPanel flowCourses;

        public CourseControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mainLayout = new TableLayoutPanel();
            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.btnCreate = new Button();
            this.flowCourses = new FlowLayoutPanel();

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 2;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainLayout.Padding = new Padding(20);

            // headerPanel
            this.headerPanel.Dock = DockStyle.Fill;
            this.headerPanel.Padding = new Padding(0);

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Text = "Danh sách khóa học (8 khóa)";
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.Width = 400;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // btnCreate
            this.btnCreate.Text = "➕ Tạo khóa học mới";
            this.btnCreate.Size = new Size(180, 45);
            this.btnCreate.Dock = DockStyle.Right;
            this.btnCreate.BackColor = Color.FromArgb(76, 175, 80);
            this.btnCreate.ForeColor = Color.White;
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCreate.Cursor = Cursors.Hand;

            this.btnCreate.MouseEnter += (s, e) =>
            {
                this.btnCreate.BackColor = Color.FromArgb(56, 142, 60);
            };
            this.btnCreate.MouseLeave += (s, e) =>
            {
                this.btnCreate.BackColor = Color.FromArgb(76, 175, 80);
            };

            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.btnCreate);

            // flowCourses
            this.flowCourses.Dock = DockStyle.Fill;
            this.flowCourses.AutoScroll = true;
            this.flowCourses.Padding = new Padding(0, 10, 0, 10);
            this.flowCourses.WrapContents = true;

            // Add course cards
            AddCourseCard("Lập trình Web với React", "Lập trình", Color.FromArgb(103, 116, 220), "💻", 245, 12, "Đã duyệt", true);
            AddCourseCard("Python cơ bản", "Lập trình", Color.FromArgb(38, 198, 157), "🐍", 389, 20, "Đã duyệt", true);
            AddCourseCard("React Native Mobile", "Lập trình", Color.FromArgb(237, 106, 177), "📱", 0, 15, "Chờ duyệt", false);
            AddCourseCard("JavaScript nâng cao", "Lập trình", Color.FromArgb(255, 152, 0), "⚡", 156, 18, "Đã duyệt", true);
            AddCourseCard("Data Science với Python", "Khoa học dữ liệu", Color.FromArgb(103, 116, 220), "📊", 89, 25, "Đã duyệt", true);
            AddCourseCard("Machine Learning cơ bản", "AI & ML", Color.FromArgb(38, 198, 157), "🤖", 67, 30, "Chờ duyệt", false);
            AddCourseCard("Node.js Backend", "Lập trình", Color.FromArgb(76, 175, 80), "🟢", 134, 22, "Đã duyệt", true);
            AddCourseCard("UI/UX Design", "Thiết kế", Color.FromArgb(237, 106, 177), "🎨", 203, 16, "Đã duyệt", true);

            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.flowCourses, 0, 1);

            this.Controls.Add(this.mainLayout);
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Dock = DockStyle.Fill;
        }

        private void AddCourseCard(string title, string category, Color headerColor, string icon, int students, int lessons, string status, bool isApproved)
        {
            // Main card panel
            var card = new Panel();
            card.Size = new Size(330, 320);
            card.Margin = new Padding(12);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            // Add rounded corner effect with paint
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 12;
                    var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                    path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    card.Region = new Region(path);

                    // Draw shadow effect
                    using (var pen = new Pen(Color.FromArgb(30, 0, 0, 0), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // Header panel with gradient
            var headerPanel = new Panel();
            headerPanel.Size = new Size(330, 160);
            headerPanel.Location = new Point(0, 0);
            headerPanel.BackColor = headerColor;

            headerPanel.Paint += (s, e) =>
            {
                // Draw gradient
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    headerPanel.ClientRectangle,
                    headerColor,
                    Color.FromArgb(Math.Max(0, headerColor.R - 30), Math.Max(0, headerColor.G - 30), Math.Max(0, headerColor.B - 30)),
                    45f))
                {
                    e.Graphics.FillRectangle(brush, headerPanel.ClientRectangle);
                }

                // Draw icon
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                using (var font = new Font("Segoe UI Emoji", 48F))
                using (var brush = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                {
                    var iconSize = e.Graphics.MeasureString(icon, font);
                    e.Graphics.DrawString(icon, font, brush,
                        (headerPanel.Width - iconSize.Width) / 2,
                        (headerPanel.Height - iconSize.Height) / 2);
                }
            };

            card.Controls.Add(headerPanel);

            // Content area
            var contentPanel = new Panel();
            contentPanel.Location = new Point(0, 160);
            contentPanel.Size = new Size(330, 160);
            contentPanel.BackColor = Color.White;

            // Category label
            var lblCategory = new Label();
            lblCategory.Text = $"📁 {category}";
            lblCategory.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblCategory.ForeColor = Color.FromArgb(120, 120, 120);
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(18, 12);

            // Title label
            var lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(295, 28);
            lblTitle.Location = new Point(18, 35);

            // Status badge
            var lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblStatus.ForeColor = isApproved ? Color.FromArgb(27, 94, 32) : Color.FromArgb(230, 81, 0);
            lblStatus.BackColor = isApproved ? Color.FromArgb(200, 230, 201) : Color.FromArgb(255, 224, 178);
            lblStatus.AutoSize = true;
            lblStatus.Padding = new Padding(10, 4, 10, 4);
            lblStatus.Location = new Point(18, 68);

            // Info panel
            var infoPanel = new Panel();
            infoPanel.Location = new Point(18, 100);
            infoPanel.Size = new Size(295, 22);
            infoPanel.BackColor = Color.White;

            var lblStudents = new Label();
            lblStudents.Text = $"👥 {students} học viên";
            lblStudents.Font = new Font("Segoe UI", 9F);
            lblStudents.ForeColor = Color.FromArgb(90, 90, 90);
            lblStudents.AutoSize = true;
            lblStudents.Location = new Point(0, 0);

            var lblLessons = new Label();
            lblLessons.Text = $"📚 {lessons} bài";
            lblLessons.Font = new Font("Segoe UI", 9F);
            lblLessons.ForeColor = Color.FromArgb(90, 90, 90);
            lblLessons.AutoSize = true;
            lblLessons.Location = new Point(150, 0);

            infoPanel.Controls.Add(lblStudents);
            infoPanel.Controls.Add(lblLessons);

            contentPanel.Controls.Add(lblCategory);
            contentPanel.Controls.Add(lblTitle);
            contentPanel.Controls.Add(lblStatus);
            contentPanel.Controls.Add(infoPanel);

            // Button panel - đặt trong card, không phải contentPanel
            var btnPanel = new Panel();
            btnPanel.Location = new Point(18, 287);
            btnPanel.Size = new Size(295, 28);
            btnPanel.BackColor = Color.White;

            var btnInfo = new Button();
            btnInfo.Text = "📊 Thông kê";
            btnInfo.Size = new Size(142, 28);
            btnInfo.Location = new Point(0, 0);
            btnInfo.BackColor = Color.FromArgb(33, 150, 243);
            btnInfo.ForeColor = Color.White;
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.FlatAppearance.BorderSize = 0;
            btnInfo.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnInfo.Cursor = Cursors.Hand;

            btnInfo.MouseEnter += (s, e) => btnInfo.BackColor = Color.FromArgb(25, 118, 210);
            btnInfo.MouseLeave += (s, e) => btnInfo.BackColor = Color.FromArgb(33, 150, 243);
            btnInfo.Click += (s, e) => MessageBox.Show($"Xem thống kê khóa học: {title}");

            var btnEdit = new Button();
            btnEdit.Text = "✏️ Chỉnh sửa";
            btnEdit.Size = new Size(142, 28);
            btnEdit.Location = new Point(153, 0);
            btnEdit.BackColor = Color.FromArgb(255, 152, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnEdit.Cursor = Cursors.Hand;

            btnEdit.MouseEnter += (s, e) => btnEdit.BackColor = Color.FromArgb(245, 124, 0);
            btnEdit.MouseLeave += (s, e) => btnEdit.BackColor = Color.FromArgb(255, 152, 0);
            btnEdit.Click += (s, e) => MessageBox.Show($"Chỉnh sửa khóa học: {title}");

            btnPanel.Controls.Add(btnInfo);
            btnPanel.Controls.Add(btnEdit);

            card.Controls.Add(btnPanel);
            card.Controls.Add(contentPanel);

            // Hover effect
            card.MouseEnter += (s, e) =>
            {
                card.BackColor = Color.FromArgb(250, 250, 250);
            };
            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
            };

            this.flowCourses.Controls.Add(card);
        }
    }
}
