using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public class StudentsControl : UserControl
    {
        private TableLayoutPanel mainLayout;
        private Panel headerPanel;
        private Label lblTitle;
        private TextBox txtSearch;
        private ComboBox cboFilter;
        private Panel contentPanel;
        private DataGridView dgvStudents;

        public StudentsControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mainLayout = new TableLayoutPanel();
            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.txtSearch = new TextBox();
            this.cboFilter = new ComboBox();
            this.contentPanel = new Panel();
            this.dgvStudents = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 2;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainLayout.Padding = new Padding(8);

            // headerPanel
            this.headerPanel.Dock = DockStyle.Fill;
            this.headerPanel.Padding = new Padding(8);

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Text = "Quản lý Học viên";
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.Width = 300;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // txtSearch
            this.txtSearch.Size = new Size(250, 30);
            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new Point(this.headerPanel.Width - 430, 15);
            this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.txtSearch.Text = "Tìm kiếm học viên...";
            this.txtSearch.ForeColor = Color.Gray;

            // Clear placeholder on focus
            this.txtSearch.Enter += (s, e) =>
            {
                if (this.txtSearch.Text == "Tìm kiếm học viên...")
                {
                    this.txtSearch.Text = "";
                    this.txtSearch.ForeColor = Color.Black;
                }
            };

            // Restore placeholder if empty
            this.txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(this.txtSearch.Text))
                {
                    this.txtSearch.Text = "Tìm kiếm học viên...";
                    this.txtSearch.ForeColor = Color.Gray;
                }
            };

            // cboFilter
            this.cboFilter.Size = new Size(150, 30);
            this.cboFilter.Font = new Font("Segoe UI", 9.5F);
            this.cboFilter.Location = new Point(this.headerPanel.Width - 165, 15);
            this.cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboFilter.Items.AddRange(new object[] { "Tất cả", "Đang học", "Đã hoàn thành", "Chưa hoàn thành" });
            this.cboFilter.SelectedIndex = 0;

            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.txtSearch);
            this.headerPanel.Controls.Add(this.cboFilter);

            // contentPanel
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.Margin = new Padding(4);
            this.contentPanel.BorderStyle = BorderStyle.FixedSingle;

            // dgvStudents
            this.dgvStudents.Dock = DockStyle.Fill;
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = Color.White;
            this.dgvStudents.BorderStyle = BorderStyle.None;
            this.dgvStudents.RowTemplate.Height = 55;
            this.dgvStudents.ColumnHeadersHeight = 45;
            this.dgvStudents.Margin = new Padding(0);
            this.dgvStudents.GridColor = Color.FromArgb(230, 230, 230);
            this.dgvStudents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStudents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 248, 255);
            this.dgvStudents.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvStudents.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            this.dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            this.dgvStudents.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            // Columns
            this.dgvStudents.Columns.Clear();

            var colName = new DataGridViewTextBoxColumn();
            colName.Name = "colName";
            colName.HeaderText = "Họ tên";
            colName.Width = 180;
            this.dgvStudents.Columns.Add(colName);

            var colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "colEmail";
            colEmail.HeaderText = "Email";
            this.dgvStudents.Columns.Add(colEmail);

            var colCourse = new DataGridViewTextBoxColumn();
            colCourse.Name = "colCourse";
            colCourse.HeaderText = "Khóa học";
            this.dgvStudents.Columns.Add(colCourse);

            var colEnrollDate = new DataGridViewTextBoxColumn();
            colEnrollDate.Name = "colEnrollDate";
            colEnrollDate.HeaderText = "Ngày đăng ký";
            colEnrollDate.Width = 130;
            this.dgvStudents.Columns.Add(colEnrollDate);

            var colProgress = new DataGridViewTextBoxColumn();
            colProgress.Name = "colProgress";
            colProgress.HeaderText = "Tiến độ";
            colProgress.Width = 180;
            this.dgvStudents.Columns.Add(colProgress);

            var colGrade = new DataGridViewTextBoxColumn();
            colGrade.Name = "colGrade";
            colGrade.HeaderText = "Điểm TB";
            colGrade.Width = 80;
            this.dgvStudents.Columns.Add(colGrade);

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Width = 130;
            this.dgvStudents.Columns.Add(colStatus);

            var colAction = new DataGridViewTextBoxColumn();
            colAction.Name = "colAction";
            colAction.HeaderText = "Thao tác";
            colAction.ReadOnly = true;
            colAction.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colAction.Width = 110;
            this.dgvStudents.Columns.Add(colAction);

            // Sample data - format: completed/total (percentage)
            this.dgvStudents.Rows.Add("Nguyễn Văn An", "nguyenvanan@email.com", "Lập trình Web với React", "01/10/2025", "9/12 (75%)", "8.5", "Đang học", "");
            this.dgvStudents.Rows.Add("Trần Thị Bình", "tranthib@email.com", "Python cơ bản", "05/10/2025", "20/20 (100%)", "9.2", "Hoàn thành", "");
            this.dgvStudents.Rows.Add("Lê Văn Cường", "levanc@email.com", "Lập trình Web với React", "10/10/2025", "6/12 (50%)", "7.8", "Đang học", "");
            this.dgvStudents.Rows.Add("Phạm Thị Dung", "phamtd@email.com", "SQL Server từ A-Z", "15/10/2025", "5/18 (28%)", "6.5", "Chậm tiến độ", "");
            this.dgvStudents.Rows.Add("Hoàng Văn Em", "hoangvanem@email.com", "NodeJS & Express", "20/10/2025", "19/22 (86%)", "8.9", "Đang học", "");
            this.dgvStudents.Rows.Add("Vũ Thị Giang", "vuthig@email.com", "Python cơ bản", "25/10/2025", "13/20 (65%)", "8.0", "Đang học", "");

            // Tracking hover state
            int hoverRow = -1;

            // Custom paint for progress bar, status badge and action button
            this.dgvStudents.CellPainting += (sender, e) =>
            {
                if (e.RowIndex < 0) return;

                // Paint progress column with progress bar
                if (e.ColumnIndex == this.dgvStudents.Columns["colProgress"].Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    var progressText = this.dgvStudents.Rows[e.RowIndex].Cells["colProgress"].Value?.ToString() ?? "";

                    // Parse progress percentage
                    int percentage = 0;
                    if (progressText.Contains("(") && progressText.Contains("%"))
                    {
                        var percentStr = progressText.Substring(progressText.IndexOf("(") + 1);
                        percentStr = percentStr.Replace("%)", "").Replace("%", "").Trim();
                        int.TryParse(percentStr, out percentage);
                    }

                    // Draw progress bar background
                    var progressBarRect = new Rectangle(
                        e.CellBounds.X + 15,
                        e.CellBounds.Y + (e.CellBounds.Height - 20) / 2,
                        e.CellBounds.Width - 30,
                        20);

                    // Background (gray)
                    using (var bgBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
                    {
                        e.Graphics.FillRectangle(bgBrush, progressBarRect);
                    }

                    // Foreground (green progress)
                    if (percentage > 0)
                    {
                        var fillWidth = (int)(progressBarRect.Width * (percentage / 100.0));
                        var fillRect = new Rectangle(progressBarRect.X, progressBarRect.Y, fillWidth, progressBarRect.Height);

                        Color progressColor;
                        if (percentage >= 80) progressColor = Color.FromArgb(76, 175, 80);  // Green
                        else if (percentage >= 50) progressColor = Color.FromArgb(255, 193, 7);  // Yellow
                        else progressColor = Color.FromArgb(244, 67, 54);  // Red

                        using (var fillBrush = new SolidBrush(progressColor))
                        {
                            e.Graphics.FillRectangle(fillBrush, fillRect);
                        }
                    }

                    // Draw text on top
                    using (var textBrush = new SolidBrush(Color.FromArgb(60, 60, 60)))
                    using (var font = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawString(progressText, font, textBrush, progressBarRect, sf);
                    }

                    e.Handled = true;
                }

                // Paint status column with badge
                if (e.ColumnIndex == this.dgvStudents.Columns["colStatus"].Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    var status = this.dgvStudents.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString() ?? "";
                    Color bgColor, textColor;

                    if (status == "Hoàn thành")
                    {
                        bgColor = Color.FromArgb(200, 230, 201);
                        textColor = Color.FromArgb(27, 94, 32);
                    }
                    else if (status == "Chậm tiến độ")
                    {
                        bgColor = Color.FromArgb(255, 224, 178);
                        textColor = Color.FromArgb(230, 81, 0);
                    }
                    else // Đang học
                    {
                        bgColor = Color.FromArgb(179, 229, 252);
                        textColor = Color.FromArgb(1, 87, 155);
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
                if (e.ColumnIndex == this.dgvStudents.Columns["colAction"].Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    var buttonWidth = 90;
                    var buttonHeight = 30;
                    var buttonRect = new Rectangle(
                        e.CellBounds.X + (e.CellBounds.Width - buttonWidth) / 2,
                        e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2,
                        buttonWidth, buttonHeight);

                    var isHover = e.RowIndex == hoverRow;
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
                            e.Graphics.DrawString("👁️ Chi tiết", new Font("Segoe UI", 9F, FontStyle.Bold), textBrush, buttonRect, sf);
                        }
                    }

                    e.Handled = true;
                }
            };

            this.dgvStudents.CellMouseEnter += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvStudents.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    this.dgvStudents.Cursor = Cursors.Hand;
                    hoverRow = e.RowIndex;
                    this.dgvStudents.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            this.dgvStudents.CellMouseLeave += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvStudents.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    this.dgvStudents.Cursor = Cursors.Default;
                    hoverRow = -1;
                    this.dgvStudents.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            this.dgvStudents.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvStudents.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    MessageBox.Show($"Xem chi tiết học viên: {this.dgvStudents.Rows[e.RowIndex].Cells["colName"].Value}\n" +
                        $"Email: {this.dgvStudents.Rows[e.RowIndex].Cells["colEmail"].Value}\n" +
                        $"Tiến độ: {this.dgvStudents.Rows[e.RowIndex].Cells["colProgress"].Value}",
                        "Thông tin học viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            this.contentPanel.Controls.Add(this.dgvStudents);

            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.contentPanel, 0, 1);

            this.Controls.Add(this.mainLayout);
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
        }
    }
}