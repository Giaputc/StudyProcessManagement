using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public class DashboardControl : UserControl
    {
        private Label lblTitle;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel cardsTable;
        private Panel card1, card2, card3, card4;
        private Label lblCard1Value, lblCard1Text;
        private Label lblCard2Value, lblCard2Text;
        private Label lblCard3Value, lblCard3Text;
        private Label lblCard4Value, lblCard4Text;
        private Panel panelCourses;
        private Label lblCoursesTitle;
        private DataGridView dgvCourses;
        private Button btnCreateCourse;
        private Panel panelAssignments;
        private Label lblAssignmentsTitle;
        private DataGridView dgvAssignments;
        private Button btnViewAllAssignments;

        public DashboardControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.mainLayout = new TableLayoutPanel();
            this.cardsTable = new TableLayoutPanel();
            this.card1 = new Panel();
            this.card2 = new Panel();
            this.card3 = new Panel();
            this.card4 = new Panel();
            this.lblCard1Value = new Label();
            this.lblCard1Text = new Label();
            this.lblCard2Value = new Label();
            this.lblCard2Text = new Label();
            this.lblCard3Value = new Label();
            this.lblCard3Text = new Label();
            this.lblCard4Value = new Label();
            this.lblCard4Text = new Label();
            this.panelCourses = new Panel();
            this.lblCoursesTitle = new Label();
            this.dgvCourses = new DataGridView();
            this.btnCreateCourse = new Button();
            this.panelAssignments = new Panel();
            this.lblAssignmentsTitle = new Label();
            this.dgvAssignments = new DataGridView();
            this.btnViewAllAssignments = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();

            // Title
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Text = "Dashboard";
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new Padding(16, 0, 0, 0);

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 4;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            // rows: title, cards, courses, assignments
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F)); // title
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F)); // cards
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F)); // courses
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F)); // assignments
            this.mainLayout.Padding = new Padding(8);

            // cardsTable: 4 columns
            this.cardsTable.Dock = DockStyle.Fill;
            this.cardsTable.ColumnCount = 4;
            this.cardsTable.RowCount = 1;
            for (int i = 0; i < 4; i++) this.cardsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.cardsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.cardsTable.Padding = new Padding(0);

            Action<Panel> styleCard = (p) =>
            {
                p.Margin = new Padding(4);
                p.BackColor = Color.WhiteSmoke;
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Dock = DockStyle.Fill;
            };

            styleCard(this.card1);
            styleCard(this.card2);
            styleCard(this.card3);
            styleCard(this.card4);

            // card contents
            this.lblCard1Value.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblCard1Value.Text = "8";
            this.lblCard1Value.AutoSize = true;
            this.lblCard1Value.Location = new Point(12, 12);
            this.lblCard1Text.Font = new Font("Segoe UI", 9F);
            this.lblCard1Text.Text = "Khóa học của tôi";
            this.lblCard1Text.AutoSize = true;
            this.lblCard1Text.Location = new Point(12, 50);
            this.card1.Controls.Add(this.lblCard1Value);
            this.card1.Controls.Add(this.lblCard1Text);

            this.lblCard2Value.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblCard2Value.Text = "342";
            this.lblCard2Value.AutoSize = true;
            this.lblCard2Value.Location = new Point(12, 12);
            this.lblCard2Text.Font = new Font("Segoe UI", 9F);
            this.lblCard2Text.Text = "Tổng học viên";
            this.lblCard2Text.AutoSize = true;
            this.lblCard2Text.Location = new Point(12, 50);
            this.card2.Controls.Add(this.lblCard2Value);
            this.card2.Controls.Add(this.lblCard2Text);

            this.lblCard3Value.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblCard3Value.Text = "24";
            this.lblCard3Value.AutoSize = true;
            this.lblCard3Value.Location = new Point(12, 12);
            this.lblCard3Text.Font = new Font("Segoe UI", 9F);
            this.lblCard3Text.Text = "Bài tập chưa chấm";
            this.lblCard3Text.AutoSize = true;
            this.lblCard3Text.Location = new Point(12, 50);
            this.card3.Controls.Add(this.lblCard3Value);
            this.card3.Controls.Add(this.lblCard3Text);

            this.lblCard4Value.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblCard4Value.Text = "4.8";
            this.lblCard4Value.AutoSize = true;
            this.lblCard4Value.Location = new Point(12, 12);
            this.lblCard4Text.Font = new Font("Segoe UI", 9F);
            this.lblCard4Text.Text = "Đánh giá TB";
            this.lblCard4Text.AutoSize = true;
            this.lblCard4Text.Location = new Point(12, 50);
            this.card4.Controls.Add(this.lblCard4Value);
            this.card4.Controls.Add(this.lblCard4Text);

            // Courses Panel
            this.panelCourses.Dock = DockStyle.Fill;
            this.panelCourses.Margin = new Padding(4);
            this.panelCourses.BorderStyle = BorderStyle.FixedSingle;

            // Courses title and button panel
            var topCoursesPanel = new Panel();
            topCoursesPanel.Dock = DockStyle.Top;
            topCoursesPanel.Height = 52;
            topCoursesPanel.Padding = new Padding(15, 10, 15, 10);
            topCoursesPanel.BackColor = Color.White;

            // Add border bottom
            topCoursesPanel.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawLine(pen, 0, topCoursesPanel.Height - 1, topCoursesPanel.Width, topCoursesPanel.Height - 1);
                }
            };

            this.lblCoursesTitle.Text = "Khóa học của tôi";
            this.lblCoursesTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblCoursesTitle.AutoSize = true;
            this.lblCoursesTitle.Location = new Point(15, 12);

            this.btnCreateCourse.Text = "+ Tạo khóa mới";
            this.btnCreateCourse.Size = new Size(130, 35);
            this.btnCreateCourse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCreateCourse.Location = new Point(topCoursesPanel.Width - 142, 8);
            this.btnCreateCourse.BackColor = Color.FromArgb(76, 175, 80);
            this.btnCreateCourse.ForeColor = Color.White;
            this.btnCreateCourse.FlatStyle = FlatStyle.Flat;
            this.btnCreateCourse.FlatAppearance.BorderSize = 0;
            this.btnCreateCourse.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.btnCreateCourse.Cursor = Cursors.Hand;

            // Thêm hover effect
            this.btnCreateCourse.MouseEnter += (s, e) =>
            {
                this.btnCreateCourse.BackColor = Color.FromArgb(56, 142, 60);
            };
            this.btnCreateCourse.MouseLeave += (s, e) =>
            {
                this.btnCreateCourse.BackColor = Color.FromArgb(76, 175, 80);
            };

            topCoursesPanel.Controls.Add(this.lblCoursesTitle);
            topCoursesPanel.Controls.Add(this.btnCreateCourse);
            this.panelCourses.Controls.Add(topCoursesPanel);

            // dgvCourses
            this.dgvCourses.Dock = DockStyle.Fill;
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.BackgroundColor = Color.White;
            this.dgvCourses.BorderStyle = BorderStyle.None;
            this.dgvCourses.RowTemplate.Height = 55;
            this.dgvCourses.ColumnHeadersHeight = 45;
            this.dgvCourses.Margin = new Padding(0);
            this.dgvCourses.GridColor = Color.FromArgb(230, 230, 230);
            this.dgvCourses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCourses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvCourses.EnableHeadersVisualStyles = false;
            this.dgvCourses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 248, 255);
            this.dgvCourses.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvCourses.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            this.dgvCourses.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            this.dgvCourses.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            this.dgvCourses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.dgvCourses.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            this.dgvCourses.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            this.dgvCourses.Columns.Clear();
            this.dgvCourses.Columns.Add("colName", "Tên khóa học");
            this.dgvCourses.Columns.Add("colCategory", "Danh mục");
            this.dgvCourses.Columns.Add("colStudents", "Số học viên");
            this.dgvCourses.Columns.Add("colStatus", "Trạng thái");
            this.dgvCourses.Columns.Add("colUpdated", "Cập nhật");

            // Sử dụng TextBoxColumn thay vì ButtonColumn để custom paint
            var btnCol = new DataGridViewTextBoxColumn();
            btnCol.Name = "colAction";
            btnCol.HeaderText = "Thao tác";
            btnCol.ReadOnly = true;
            btnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnCol.Width = 110;
            this.dgvCourses.Columns.Add(btnCol);

            this.dgvCourses.Rows.Add("Lập trình Web với React", "Lập trình", "45", "Đã duyệt", "2 giờ trước", "");
            this.dgvCourses.Rows.Add("Python cơ bản", "Lập trình", "78", "Đã duyệt", "1 ngày trước", "");
            this.dgvCourses.Rows.Add("JavaScript nâng cao", "Lập trình", "32", "Chờ duyệt", "5 ngày trước", "");

            // Tracking hover state
            int hoverRowCourses = -1;

            // Custom paint button với bo góc
            this.dgvCourses.CellPainting += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvCourses.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    // Vẽ button
                    var buttonWidth = 80;
                    var buttonHeight = 30;
                    var buttonRect = new Rectangle(
                        e.CellBounds.X + (e.CellBounds.Width - buttonWidth) / 2,
                        e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2,
                        buttonWidth, buttonHeight);

                    // Kiểm tra hover
                    var isHover = e.RowIndex == hoverRowCourses;
                    var buttonColor = isHover ? Color.FromArgb(25, 118, 210) : Color.FromArgb(33, 150, 243);

                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int radius = 5;
                        path.AddArc(buttonRect.X, buttonRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(buttonRect.Right - radius * 2, buttonRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(buttonRect.Right - radius * 2, buttonRect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        path.AddArc(buttonRect.X, buttonRect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();

                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        using (var brush = new SolidBrush(buttonColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        using (var textBrush = new SolidBrush(Color.White))
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            e.Graphics.DrawString("Quản lý", new Font("Segoe UI", 9F), textBrush, buttonRect, sf);
                        }
                    }

                    e.Handled = true;
                }
            };

            this.dgvCourses.CellMouseEnter += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvCourses.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    this.dgvCourses.Cursor = Cursors.Hand;
                    hoverRowCourses = e.RowIndex;
                    this.dgvCourses.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            this.dgvCourses.CellMouseLeave += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvCourses.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    this.dgvCourses.Cursor = Cursors.Default;
                    hoverRowCourses = -1;
                    this.dgvCourses.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            this.dgvCourses.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvCourses.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    MessageBox.Show($"Quản lý khóa học: {this.dgvCourses.Rows[e.RowIndex].Cells["colName"].Value}");
                }
            };

            this.panelCourses.Controls.Add(this.dgvCourses);

            // Assignments Panel
            this.panelAssignments.Dock = DockStyle.Fill;
            this.panelAssignments.Margin = new Padding(4);
            this.panelAssignments.BorderStyle = BorderStyle.FixedSingle;

            var topAssignPanel = new Panel();
            topAssignPanel.Dock = DockStyle.Top;
            topAssignPanel.Height = 52;
            topAssignPanel.Padding = new Padding(15, 10, 15, 10);
            topAssignPanel.BackColor = Color.White;

            // Add border bottom
            topAssignPanel.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawLine(pen, 0, topAssignPanel.Height - 1, topAssignPanel.Width, topAssignPanel.Height - 1);
                }
            };

            this.lblAssignmentsTitle.Text = "Bài tập cần chấm";
            this.lblAssignmentsTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblAssignmentsTitle.AutoSize = true;
            this.lblAssignmentsTitle.Location = new Point(15, 12);

            this.btnViewAllAssignments.Text = "Xem tất cả";
            this.btnViewAllAssignments.Size = new Size(130, 35);
            this.btnViewAllAssignments.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnViewAllAssignments.Location = new Point(topAssignPanel.Width - 142, 8);
            this.btnViewAllAssignments.BackColor = Color.FromArgb(33, 150, 243);
            this.btnViewAllAssignments.ForeColor = Color.White;
            this.btnViewAllAssignments.FlatStyle = FlatStyle.Flat;
            this.btnViewAllAssignments.FlatAppearance.BorderSize = 0;
            this.btnViewAllAssignments.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.btnViewAllAssignments.Cursor = Cursors.Hand;

            // Thêm hover effect
            this.btnViewAllAssignments.MouseEnter += (s, e) =>
            {
                this.btnViewAllAssignments.BackColor = Color.FromArgb(25, 118, 210);
            };
            this.btnViewAllAssignments.MouseLeave += (s, e) =>
            {
                this.btnViewAllAssignments.BackColor = Color.FromArgb(33, 150, 243);
            };

            topAssignPanel.Controls.Add(this.lblAssignmentsTitle);
            topAssignPanel.Controls.Add(this.btnViewAllAssignments);
            this.panelAssignments.Controls.Add(topAssignPanel);

            this.dgvAssignments.Dock = DockStyle.Fill;
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            this.dgvAssignments.RowHeadersVisible = false;
            this.dgvAssignments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.BackgroundColor = Color.White;
            this.dgvAssignments.BorderStyle = BorderStyle.None;
            this.dgvAssignments.RowTemplate.Height = 55;
            this.dgvAssignments.ColumnHeadersHeight = 45;
            this.dgvAssignments.Margin = new Padding(0);
            this.dgvAssignments.GridColor = Color.FromArgb(230, 230, 230);
            this.dgvAssignments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAssignments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvAssignments.EnableHeadersVisualStyles = false;
            this.dgvAssignments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 248, 255);
            this.dgvAssignments.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvAssignments.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            this.dgvAssignments.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            this.dgvAssignments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            this.dgvAssignments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.dgvAssignments.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            this.dgvAssignments.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            this.dgvAssignments.Columns.Clear();
            this.dgvAssignments.Columns.Add("colTask", "Bài tập");
            this.dgvAssignments.Columns.Add("colCourse", "Khóa học");
            this.dgvAssignments.Columns.Add("colSubmitted", "Học viên nộp");
            this.dgvAssignments.Columns.Add("colDue", "Hạn nộp");

            var btnCol2 = new DataGridViewTextBoxColumn();
            btnCol2.Name = "colAction2";
            btnCol2.HeaderText = "Thao tác";
            btnCol2.ReadOnly = true;
            btnCol2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnCol2.Width = 110;
            this.dgvAssignments.Columns.Add(btnCol2);

            this.dgvAssignments.Rows.Add("Bài tập 1: Component trong React", "Lập trình Web với React", "35/45", "18/11/2025", "");
            this.dgvAssignments.Rows.Add("Bài tập 2: State và Props", "Lập trình Web với React", "40/45", "20/11/2025", "");

            // Tracking hover state
            int hoverRowAssignments = -1;

            // Custom paint button với bo góc
            this.dgvAssignments.CellPainting += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvAssignments.Columns["colAction2"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    // Vẽ button
                    var buttonWidth = 90;
                    var buttonHeight = 30;
                    var buttonRect = new Rectangle(
                        e.CellBounds.X + (e.CellBounds.Width - buttonWidth) / 2,
                        e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2,
                        buttonWidth, buttonHeight);

                    // Kiểm tra hover
                    var isHover = e.RowIndex == hoverRowAssignments;
                    var buttonColor = isHover ? Color.FromArgb(56, 142, 60) : Color.FromArgb(76, 175, 80);

                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int radius = 5;
                        path.AddArc(buttonRect.X, buttonRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(buttonRect.Right - radius * 2, buttonRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(buttonRect.Right - radius * 2, buttonRect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        path.AddArc(buttonRect.X, buttonRect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();

                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        using (var brush = new SolidBrush(buttonColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        using (var textBrush = new SolidBrush(Color.White))
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            e.Graphics.DrawString("Chấm điểm", new Font("Segoe UI", 9F), textBrush, buttonRect, sf);
                        }
                    }

                    e.Handled = true;
                }
            };

            this.dgvAssignments.CellMouseEnter += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvAssignments.Columns["colAction2"].Index && e.RowIndex >= 0)
                {
                    this.dgvAssignments.Cursor = Cursors.Hand;
                    hoverRowAssignments = e.RowIndex;
                    this.dgvAssignments.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            this.dgvAssignments.CellMouseLeave += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvAssignments.Columns["colAction2"].Index && e.RowIndex >= 0)
                {
                    this.dgvAssignments.Cursor = Cursors.Default;
                    hoverRowAssignments = -1;
                    this.dgvAssignments.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            this.dgvAssignments.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvAssignments.Columns["colAction2"].Index && e.RowIndex >= 0)
                {
                    MessageBox.Show($"Chấm điểm: {this.dgvAssignments.Rows[e.RowIndex].Cells["colTask"].Value}");
                }
            };

            this.panelAssignments.Controls.Add(this.dgvAssignments);

            // add cards to cardsTable
            this.cardsTable.Controls.Add(this.card1, 0, 0);
            this.cardsTable.Controls.Add(this.card2, 1, 0);
            this.cardsTable.Controls.Add(this.card3, 2, 0);
            this.cardsTable.Controls.Add(this.card4, 3, 0);

            // add rows to mainLayout
            this.mainLayout.Controls.Add(this.lblTitle, 0, 0);
            this.mainLayout.Controls.Add(this.cardsTable, 0, 1);
            this.mainLayout.Controls.Add(this.panelCourses, 0, 2);
            this.mainLayout.Controls.Add(this.panelAssignments, 0, 3);

            this.Controls.Add(this.mainLayout);

            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
        }
    }
}
