using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public class GradingControl : UserControl
    {
        private Panel headerPanel;
        private Label lblTitle;
        private Label lblBreadcrumb;
        private Panel filterPanel;
        private ComboBox cboCourse;
        private ComboBox cboStatus;
        private Panel summaryPanel;
        private Label lblSummaryTitle;
        private Label lblSummaryCount;
        private Panel tablePanel;
        private DataGridView dgvSubmissions;

        public GradingControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.lblBreadcrumb = new Label();
            this.filterPanel = new Panel();
            this.cboCourse = new ComboBox();
            this.cboStatus = new ComboBox();
            this.summaryPanel = new Panel();
            this.lblSummaryTitle = new Label();
            this.lblSummaryCount = new Label();
            this.tablePanel = new Panel();
            this.dgvSubmissions = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSubmissions)).BeginInit();

            // Main control
            this.BackColor = Color.FromArgb(248, 248, 248);
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(30, 20, 30, 20);

            // headerPanel
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 70;
            this.headerPanel.BackColor = Color.Transparent;

            // lblTitle
            this.lblTitle.Text = "Chấm Điểm & Phản Hồi";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(40, 40, 40);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(0, 5);

            // lblBreadcrumb
            this.lblBreadcrumb.Text = "Trang chủ / Đánh giá / Chấm điểm";
            this.lblBreadcrumb.Font = new Font("Segoe UI", 9F);
            this.lblBreadcrumb.ForeColor = Color.FromArgb(120, 120, 120);
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Location = new Point(0, 40);

            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblBreadcrumb);

            // filterPanel
            this.filterPanel.Dock = DockStyle.Top;
            this.filterPanel.Height = 80;
            this.filterPanel.BackColor = Color.White;
            this.filterPanel.Padding = new Padding(20, 15, 20, 15);

            this.filterPanel.Paint += (s, e) =>
            {
                // Draw rounded rectangle
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 8;
                    var rect = new Rectangle(0, 0, this.filterPanel.Width - 1, this.filterPanel.Height - 1);
                    path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    
                    using (var brush = new SolidBrush(Color.White))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    
                    using (var pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // cboCourse
            this.cboCourse.Size = new Size(220, 35);
            this.cboCourse.Font = new Font("Segoe UI", 10F);
            this.cboCourse.Location = new Point(20, 20);
            this.cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCourse.Items.AddRange(new object[] {
                "Tất cả khóa học",
                "Lập trình Web với React",
                "Python cơ bản",
                "JavaScript nâng cao",
                "SQL Server từ A-Z"
            });
            this.cboCourse.SelectedIndex = 0;

            // cboStatus
            this.cboStatus.Size = new Size(220, 35);
            this.cboStatus.Font = new Font("Segoe UI", 10F);
            this.cboStatus.Location = new Point(260, 20);
            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatus.Items.AddRange(new object[] {
                "Tất cả trạng thái",
                "Chưa chấm",
                "Đã chấm",
                "Nộp trễ"
            });
            this.cboStatus.SelectedIndex = 0;

            this.filterPanel.Controls.Add(this.cboCourse);
            this.filterPanel.Controls.Add(this.cboStatus);

            // summaryPanel
            this.summaryPanel.Dock = DockStyle.Top;
            this.summaryPanel.Height = 70;
            this.summaryPanel.BackColor = Color.Transparent;
            this.summaryPanel.Padding = new Padding(0, 15, 0, 0);

            // lblSummaryTitle
            this.lblSummaryTitle.Text = "Bài tập cần chấm";
            this.lblSummaryTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = Color.FromArgb(40, 40, 40);
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Location = new Point(0, 15);

            // lblSummaryCount
            this.lblSummaryCount.Text = "24 bài chưa chấm";
            this.lblSummaryCount.Font = new Font("Segoe UI", 11F);
            this.lblSummaryCount.ForeColor = Color.FromArgb(120, 120, 120);
            this.lblSummaryCount.AutoSize = true;
            this.lblSummaryCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblSummaryCount.Location = new Point(this.summaryPanel.Width - 150, 20);

            this.summaryPanel.Controls.Add(this.lblSummaryTitle);
            this.summaryPanel.Controls.Add(this.lblSummaryCount);

            // tablePanel
            this.tablePanel.Dock = DockStyle.Fill;
            this.tablePanel.BackColor = Color.White;
            this.tablePanel.Padding = new Padding(0);

            this.tablePanel.Paint += (s, e) =>
            {
                // Draw rounded rectangle
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 8;
                    var rect = new Rectangle(0, 0, this.tablePanel.Width - 1, this.tablePanel.Height - 1);
                    path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    
                    using (var pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // dgvSubmissions
            this.dgvSubmissions.Dock = DockStyle.Fill;
            this.dgvSubmissions.AllowUserToAddRows = false;
            this.dgvSubmissions.AllowUserToDeleteRows = false;
            this.dgvSubmissions.RowHeadersVisible = false;
            this.dgvSubmissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubmissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubmissions.BackgroundColor = Color.White;
            this.dgvSubmissions.BorderStyle = BorderStyle.None;
            this.dgvSubmissions.RowTemplate.Height = 65;
            this.dgvSubmissions.ColumnHeadersHeight = 50;
            this.dgvSubmissions.Margin = new Padding(0);
            this.dgvSubmissions.GridColor = Color.FromArgb(240, 240, 240);
            this.dgvSubmissions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSubmissions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvSubmissions.EnableHeadersVisualStyles = false;
            this.dgvSubmissions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 248, 248);
            this.dgvSubmissions.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvSubmissions.DefaultCellStyle.Padding = new Padding(15, 5, 15, 5);
            this.dgvSubmissions.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            this.dgvSubmissions.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100);
            this.dgvSubmissions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.dgvSubmissions.ColumnHeadersDefaultCellStyle.Padding = new Padding(15, 5, 15, 5);
            this.dgvSubmissions.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);

            // Columns
            this.dgvSubmissions.Columns.Clear();
            
            var colStudent = new DataGridViewTextBoxColumn();
            colStudent.Name = "colStudent";
            colStudent.HeaderText = "Học viên";
            colStudent.Width = 180;
            this.dgvSubmissions.Columns.Add(colStudent);

            var colAssignment = new DataGridViewTextBoxColumn();
            colAssignment.Name = "colAssignment";
            colAssignment.HeaderText = "Bài tập";
            this.dgvSubmissions.Columns.Add(colAssignment);

            var colCourse = new DataGridViewTextBoxColumn();
            colCourse.Name = "colCourse";
            colCourse.HeaderText = "Khóa học";
            this.dgvSubmissions.Columns.Add(colCourse);

            var colSubmitDate = new DataGridViewTextBoxColumn();
            colSubmitDate.Name = "colSubmitDate";
            colSubmitDate.HeaderText = "Ngày nộp";
            colSubmitDate.Width = 120;
            this.dgvSubmissions.Columns.Add(colSubmitDate);

            var colDueDate = new DataGridViewTextBoxColumn();
            colDueDate.Name = "colDueDate";
            colDueDate.HeaderText = "Hạn nộp";
            colDueDate.Width = 120;
            this.dgvSubmissions.Columns.Add(colDueDate);

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Width = 130;
            this.dgvSubmissions.Columns.Add(colStatus);

            var colAction = new DataGridViewTextBoxColumn();
            colAction.Name = "colAction";
            colAction.HeaderText = "Thao tác";
            colAction.ReadOnly = true;
            colAction.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colAction.Width = 150;
            this.dgvSubmissions.Columns.Add(colAction);

            // Sample data
            this.dgvSubmissions.Rows.Add("Nguyễn Văn An", "Component trong React", "Lập trình Web với React", "15/11/2025", "18/11/2025", "Chưa chấm", "");
            this.dgvSubmissions.Rows.Add("Trần Thị Bình", "Component trong React", "Lập trình Web với React", "16/11/2025", "18/11/2025", "Chưa chấm", "");
            this.dgvSubmissions.Rows.Add("Lê Văn Cường", "To-do List App", "Python cơ bản", "14/11/2025", "20/11/2025", "Chưa chấm", "");
            this.dgvSubmissions.Rows.Add("Phạm Thị Dung", "Database Design", "SQL Server từ A-Z", "10/11/2025", "15/11/2025", "Đã chấm (8.5)", "");
            this.dgvSubmissions.Rows.Add("Hoàng Văn Em", "Component trong React", "Lập trình Web với React", "17/11/2025", "18/11/2025", "Nộp trễ", "");

            // Custom painting for status and action columns
            int hoverRow = -1;

            this.dgvSubmissions.CellPainting += (sender, e) =>
            {
                if (e.RowIndex < 0) return;

                // Paint status column
                if (e.ColumnIndex == this.dgvSubmissions.Columns["colStatus"].Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                    
                    var status = this.dgvSubmissions.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString() ?? "";
                    Color bgColor, textColor;
                    
                    if (status.StartsWith("Chưa chấm"))
                    {
                        bgColor = Color.FromArgb(255, 243, 224);
                        textColor = Color.FromArgb(230, 81, 0);
                    }
                    else if (status.StartsWith("Đã chấm"))
                    {
                        bgColor = Color.FromArgb(200, 230, 201);
                        textColor = Color.FromArgb(27, 94, 32);
                    }
                    else // Nộp trễ
                    {
                        bgColor = Color.FromArgb(255, 205, 210);
                        textColor = Color.FromArgb(198, 40, 40);
                    }

                    var badgeRect = new Rectangle(
                        e.CellBounds.X + 15,
                        e.CellBounds.Y + (e.CellBounds.Height - 26) / 2,
                        e.CellBounds.Width - 30,
                        26);

                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int radius = 4;
                        path.AddArc(badgeRect.X, badgeRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(badgeRect.Right - radius * 2, badgeRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(badgeRect.Right - radius * 2, badgeRect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        path.AddArc(badgeRect.X, badgeRect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();

                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        using (var brush = new SolidBrush(bgColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        using (var textBrush = new SolidBrush(textColor))
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            e.Graphics.DrawString(status, new Font("Segoe UI", 9F, FontStyle.Bold), textBrush, badgeRect, sf);
                        }
                    }

                    e.Handled = true;
                }

                // Paint action column
                if (e.ColumnIndex == this.dgvSubmissions.Columns["colAction"].Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    var status = this.dgvSubmissions.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString() ?? "";
                    var isGraded = status.StartsWith("Đã chấm");
                    var isHover = e.RowIndex == hoverRow;

                    var buttonRect = new Rectangle(
                        e.CellBounds.X + (e.CellBounds.Width - 120) / 2,
                        e.CellBounds.Y + (e.CellBounds.Height - 32) / 2,
                        120, 32);

                    Color btnColor;
                    string btnText;

                    if (isGraded)
                    {
                        btnColor = isHover ? Color.FromArgb(25, 118, 210) : Color.FromArgb(33, 150, 243);
                        btnText = "👁️ Xem";
                    }
                    else
                    {
                        btnColor = isHover ? Color.FromArgb(56, 142, 60) : Color.FromArgb(76, 175, 80);
                        btnText = "✅ Chấm điểm";
                    }

                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int radius = 6;
                        path.AddArc(buttonRect.X, buttonRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(buttonRect.Right - radius * 2, buttonRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(buttonRect.Right - radius * 2, buttonRect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        path.AddArc(buttonRect.X, buttonRect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();

                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        using (var brush = new SolidBrush(btnColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        using (var textBrush = new SolidBrush(Color.White))
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            e.Graphics.DrawString(btnText, new Font("Segoe UI", 9F, FontStyle.Bold), textBrush, buttonRect, sf);
                        }
                    }

                    e.Handled = true;
                }
            };

            this.dgvSubmissions.CellMouseEnter += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvSubmissions.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    this.dgvSubmissions.Cursor = Cursors.Hand;
                    hoverRow = e.RowIndex;
                    this.dgvSubmissions.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            this.dgvSubmissions.CellMouseLeave += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvSubmissions.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    this.dgvSubmissions.Cursor = Cursors.Default;
                    hoverRow = -1;
                    this.dgvSubmissions.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            this.dgvSubmissions.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvSubmissions.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    var student = this.dgvSubmissions.Rows[e.RowIndex].Cells["colStudent"].Value;
                    var assignment = this.dgvSubmissions.Rows[e.RowIndex].Cells["colAssignment"].Value;
                    var status = this.dgvSubmissions.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString() ?? "";
                    
                    if (status.StartsWith("Đã chấm"))
                    {
                        MessageBox.Show($"Xem bài đã chấm:\nHọc viên: {student}\nBài tập: {assignment}");
                    }
                    else
                    {
                        MessageBox.Show($"Chấm điểm bài tập:\nHọc viên: {student}\nBài tập: {assignment}");
                    }
                }
            };

            this.tablePanel.Controls.Add(this.dgvSubmissions);

            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.summaryPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.headerPanel);

            ((System.ComponentModel.ISupportInitialize)(this.dgvSubmissions)).EndInit();
        }
    }
}
