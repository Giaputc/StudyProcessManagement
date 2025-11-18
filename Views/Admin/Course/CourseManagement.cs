using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Admin.Course
{
    public partial class CourseManagement : Form
    {
        public CourseManagement()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            flowCourses.Controls.Clear();

            // --- Dữ liệu mẫu Khóa học (Admin View) ---
            AddCourseCard("Lập trình Web ReactJS", "CNTT", "GV. Nguyễn Văn A", Color.FromArgb(103, 116, 220), "⚛️", "Đã duyệt", true);
            AddCourseCard("Python cho người mới", "CNTT", "GV. Trần Thị B", Color.FromArgb(38, 198, 157), "🐍", "Đã duyệt", true);
            AddCourseCard("Tiếng Anh Giao Tiếp", "Ngoại Ngữ", "GV. John Smith", Color.FromArgb(255, 152, 0), "🇺🇸", "Chờ duyệt", false);
            AddCourseCard("Digital Marketing", "Kinh Tế", "GV. Lê Văn C", Color.FromArgb(233, 30, 99), "📢", "Đã duyệt", true);
            AddCourseCard("Thiết kế UI/UX", "Đa phương tiện", "GV. Phạm D", Color.FromArgb(156, 39, 176), "🎨", "Chờ duyệt", false);
            AddCourseCard("Quản trị mạng Cisco", "CNTT", "GV. Hoàng E", Color.FromArgb(33, 150, 243), "🌐", "Đã duyệt", true);
        }

        // Hàm vẽ thẻ Khóa học "sang-xịn-mịn"
        private void AddCourseCard(string title, string category, string teacher, Color headerColor, string icon, string status, bool isApproved)
        {
            // 1. Main Panel (Thẻ)
            Panel card = new Panel();
            card.Size = new Size(320, 350); // Kích thước thẻ
            card.Margin = new Padding(15);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            // Vẽ bo góc + Đổ bóng (Code thần thánh của bạn ông)
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 15;
                    Rectangle rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                    path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    card.Region = new Region(path);

                    using (Pen pen = new Pen(Color.FromArgb(20, 0, 0, 0), 1)) // Bóng mờ
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // 2. Header (Màu nền + Icon)
            Panel pnlHeader = new Panel();
            pnlHeader.Size = new Size(320, 150);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.BackColor = headerColor;

            pnlHeader.Paint += (s, e) =>
            {
                // Gradient chéo
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    pnlHeader.ClientRectangle, headerColor, ControlPaint.Light(headerColor), 45f))
                {
                    e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
                }
                // Vẽ Icon to
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                using (Font font = new Font("Segoe UI Emoji", 50F))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                {
                    SizeF iconSize = e.Graphics.MeasureString(icon, font);
                    e.Graphics.DrawString(icon, font, brush,
                        (pnlHeader.Width - iconSize.Width) / 2, (pnlHeader.Height - iconSize.Height) / 2);
                }
            };
            card.Controls.Add(pnlHeader);

            // 3. Content (Thông tin khóa học)
            Panel pnlContent = new Panel();
            pnlContent.Size = new Size(320, 200);
            pnlContent.Location = new Point(0, 150);
            pnlContent.BackColor = Color.White;

            // Danh mục (Chữ nhỏ màu xám)
            Label lblCat = new Label();
            lblCat.Text = category.ToUpper();
            lblCat.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCat.ForeColor = Color.Gray;
            lblCat.Location = new Point(15, 15);
            lblCat.AutoSize = true;

            // Tên khóa học (Chữ to đậm)
            Label lblName = new Label();
            lblName.Text = title;
            lblName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(40, 40, 40);
            lblName.AutoSize = false;
            lblName.Size = new Size(290, 55); // Cho phép xuống dòng nếu tên dài
            lblName.Location = new Point(12, 35);

            // Giảng viên phụ trách
            Label lblTeacher = new Label();
            lblTeacher.Text = "👨‍🏫 " + teacher;
            lblTeacher.Font = new Font("Segoe UI", 9.5F);
            lblTeacher.ForeColor = Color.DimGray;
            lblTeacher.Location = new Point(15, 95);
            lblTeacher.AutoSize = true;

            // Badge Trạng thái (Đã duyệt / Chờ duyệt)
            Label lblStatus = new Label();
            lblStatus.Text = status;
            lblStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblStatus.ForeColor = isApproved ? Color.FromArgb(27, 94, 32) : Color.FromArgb(230, 81, 0); // Xanh lá hoặc Cam
            lblStatus.BackColor = isApproved ? Color.FromArgb(200, 230, 201) : Color.FromArgb(255, 224, 178); // Nền nhạt
            lblStatus.AutoSize = true;
            lblStatus.Padding = new Padding(5, 3, 5, 3);
            lblStatus.Location = new Point(15, 125);

            // Nút bấm (Sửa / Xóa)
            Button btnEdit = CreateButton("✏️", Color.White, Color.Orange, 230, 120);
            Button btnDelete = CreateButton("🗑️", Color.White, Color.Red, 270, 120);

            pnlContent.Controls.AddRange(new Control[] { lblCat, lblName, lblTeacher, lblStatus, btnEdit, btnDelete });
            card.Controls.Add(pnlContent);

            // Hiệu ứng hover
            card.MouseEnter += (s, e) => card.BackColor = Color.WhiteSmoke;
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            flowCourses.Controls.Add(card);
        }

        // Hàm tạo nút tròn nhỏ
        private Button CreateButton(string text, Color backColor, Color foreColor, int x, int y)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new Size(35, 35);
            btn.Location = new Point(x, y);
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatAppearance.BorderColor = foreColor;
            btn.FlatAppearance.BorderSize = 1;
            btn.Cursor = Cursors.Hand;
            return btn;
        }
    }
}