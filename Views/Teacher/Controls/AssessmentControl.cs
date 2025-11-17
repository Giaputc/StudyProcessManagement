using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public class AssessmentControl : UserControl
    {
        private TableLayoutPanel mainLayout;
        private Panel headerPanel;
        private Label lblTitle;
        private ComboBox cboCourse;
        private ComboBox cboType;
        private Button btnCreate;
        private Panel contentPanel;
        private DataGridView dgvAssessments;

        public AssessmentControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mainLayout = new TableLayoutPanel();
            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.cboCourse = new ComboBox();
            this.cboType = new ComboBox();
            this.btnCreate = new Button();
            this.contentPanel = new Panel();
            this.dgvAssessments = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessments)).BeginInit();

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
            this.lblTitle.Text = "Quản lý Bài tập & Kiểm tra";
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.Width = 380;
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // cboType
            this.cboType.Size = new Size(150, 30);
            this.cboType.Font = new Font("Segoe UI", 9.5F);
            this.cboType.Location = new Point(this.headerPanel.Width - 475, 18);
            this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboType.Items.AddRange(new object[] { "Tất cả", "Quiz", "Bài tập", "Đồ án" });
            this.cboType.SelectedIndex = 0;

            // cboCourse
            this.cboCourse.Size = new Size(150, 30);
            this.cboCourse.Font = new Font("Segoe UI", 9.5F);
            this.cboCourse.Location = new Point(this.headerPanel.Width - 315, 18);
            this.cboCourse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCourse.Items.AddRange(new object[] {
                "Tất cả khóa học",
                "Lập trình Web với React",
                "Python cơ bản",
                "JavaScript nâng cao"
            });
            this.cboCourse.SelectedIndex = 0;

            // btnCreate
            this.btnCreate.Text = "+ Tạo mới";
            this.btnCreate.Size = new Size(140, 38);
            this.btnCreate.Location = new Point(this.headerPanel.Width - 148, 13);
            this.btnCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCreate.BackColor = Color.FromArgb(76, 175, 80);
            this.btnCreate.ForeColor = Color.White;
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.Font = new Font("Segoe UI", 9.5F);
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
            this.headerPanel.Controls.Add(this.cboType);
            this.headerPanel.Controls.Add(this.cboCourse);
            this.headerPanel.Controls.Add(this.btnCreate);

            // contentPanel
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.Margin = new Padding(4);
            this.contentPanel.BorderStyle = BorderStyle.FixedSingle;

            // dgvAssessments
            this.dgvAssessments.Dock = DockStyle.Fill;
            this.dgvAssessments.AllowUserToAddRows = false;
            this.dgvAssessments.AllowUserToDeleteRows = false;
            this.dgvAssessments.RowHeadersVisible = false;
            this.dgvAssessments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssessments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssessments.BackgroundColor = Color.White;
            this.dgvAssessments.BorderStyle = BorderStyle.None;
            this.dgvAssessments.RowTemplate.Height = 55;
            this.dgvAssessments.ColumnHeadersHeight = 45;
            this.dgvAssessments.Margin = new Padding(0);
            this.dgvAssessments.GridColor = Color.FromArgb(230, 230, 230);
            this.dgvAssessments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAssessments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvAssessments.EnableHeadersVisualStyles = false;
            this.dgvAssessments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 248, 255);
            this.dgvAssessments.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvAssessments.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            this.dgvAssessments.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            this.dgvAssessments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            this.dgvAssessments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.dgvAssessments.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            this.dgvAssessments.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            // Columns
            this.dgvAssessments.Columns.Clear();
            this.dgvAssessments.Columns.Add("colName", "Tên bài");
            this.dgvAssessments.Columns.Add("colType", "Loại");
            this.dgvAssessments.Columns["colType"].Width = 100;
            this.dgvAssessments.Columns.Add("colCourse", "Khóa học");
            this.dgvAssessments.Columns.Add("colDueDate", "Hạn nộp");
            this.dgvAssessments.Columns["colDueDate"].Width = 130;
            this.dgvAssessments.Columns.Add("colSubmitted", "Đã nộp");
            this.dgvAssessments.Columns["colSubmitted"].Width = 100;
            this.dgvAssessments.Columns.Add("colStatus", "Trạng thái");
            this.dgvAssessments.Columns["colStatus"].Width = 120;

            var colAction = new DataGridViewTextBoxColumn();
            colAction.Name = "colAction";
            colAction.HeaderText = "Thao tác";
            colAction.ReadOnly = true;
            colAction.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colAction.Width = 200;
            this.dgvAssessments.Columns.Add(colAction);

            // Sample data
            this.dgvAssessments.Rows.Add("Quiz 1: Giới thiệu React", "Quiz", "Lập trình Web với React", "20/11/2025", "35/45", "Đang mở", "");
            this.dgvAssessments.Rows.Add("Bài tập 1: Component", "Bài tập", "Lập trình Web với React", "25/11/2025", "40/45", "Đang mở", "");
            this.dgvAssessments.Rows.Add("Quiz 2: State và Props", "Quiz", "Lập trình Web với React", "15/11/2025", "45/45", "Đã đóng", "");
            this.dgvAssessments.Rows.Add("Đồ án cuối khóa", "Đồ án", "Python cơ bản", "30/11/2025", "25/78", "Đang mở", "");
            this.dgvAssessments.Rows.Add("Quiz 1: Biến và Kiểu dữ liệu", "Quiz", "Python cơ bản", "18/11/2025", "78/78", "Đang mở", "");

            // Tracking hover state
            int hoverRow = -1;
            string hoverButton = "";

            // Custom paint for action buttons
            this.dgvAssessments.CellPainting += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvAssessments.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                    // Button "Sửa"
                    var btnEditRect = new Rectangle(
                        e.CellBounds.X + (e.CellBounds.Width - 170) / 2,
                        e.CellBounds.Y + (e.CellBounds.Height - 30) / 2,
                        80, 30);

                    // Button "Chấm"
                    var btnGradeRect = new Rectangle(
                        btnEditRect.Right + 10,
                        e.CellBounds.Y + (e.CellBounds.Height - 30) / 2,
                        80, 30);

                    var isHoverEdit = e.RowIndex == hoverRow && hoverButton == "edit";
                    var isHoverGrade = e.RowIndex == hoverRow && hoverButton == "grade";

                    var editColor = isHoverEdit ? Color.FromArgb(25, 118, 210) : Color.FromArgb(33, 150, 243);
                    var gradeColor = isHoverGrade ? Color.FromArgb(56, 142, 60) : Color.FromArgb(76, 175, 80);

                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    // Draw Edit button
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int radius = 5;
                        path.AddArc(btnEditRect.X, btnEditRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(btnEditRect.Right - radius * 2, btnEditRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(btnEditRect.Right - radius * 2, btnEditRect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        path.AddArc(btnEditRect.X, btnEditRect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();

                        using (var brush = new SolidBrush(editColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        using (var textBrush = new SolidBrush(Color.White))
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            e.Graphics.DrawString("Sửa", new Font("Segoe UI", 9F), textBrush, btnEditRect, sf);
                        }
                    }

                    // Draw Grade button
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int radius = 5;
                        path.AddArc(btnGradeRect.X, btnGradeRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(btnGradeRect.Right - radius * 2, btnGradeRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(btnGradeRect.Right - radius * 2, btnGradeRect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                        path.AddArc(btnGradeRect.X, btnGradeRect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();

                        using (var brush = new SolidBrush(gradeColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }

                        using (var textBrush = new SolidBrush(Color.White))
                        using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            e.Graphics.DrawString("Chấm", new Font("Segoe UI", 9F), textBrush, btnGradeRect, sf);
                        }
                    }

                    e.Handled = true;
                }
            };

            this.dgvAssessments.CellMouseMove += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvAssessments.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    var cellRect = this.dgvAssessments.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    var btnEditRect = new Rectangle(
                        cellRect.X + (cellRect.Width - 170) / 2,
                        cellRect.Y + (cellRect.Height - 30) / 2,
                        80, 30);
                    var btnGradeRect = new Rectangle(
                        btnEditRect.Right + 10,
                        cellRect.Y + (cellRect.Height - 30) / 2,
                        80, 30);

                    var mousePos = this.dgvAssessments.PointToClient(Cursor.Position);
                    var relativePos = new Point(mousePos.X - cellRect.X, mousePos.Y - cellRect.Y);

                    if (btnEditRect.Contains(relativePos))
                    {
                        if (hoverRow != e.RowIndex || hoverButton != "edit")
                        {
                            hoverRow = e.RowIndex;
                            hoverButton = "edit";
                            this.dgvAssessments.Cursor = Cursors.Hand;
                            this.dgvAssessments.InvalidateCell(e.ColumnIndex, e.RowIndex);
                        }
                    }
                    else if (btnGradeRect.Contains(relativePos))
                    {
                        if (hoverRow != e.RowIndex || hoverButton != "grade")
                        {
                            hoverRow = e.RowIndex;
                            hoverButton = "grade";
                            this.dgvAssessments.Cursor = Cursors.Hand;
                            this.dgvAssessments.InvalidateCell(e.ColumnIndex, e.RowIndex);
                        }
                    }
                    else
                    {
                        if (hoverRow != -1)
                        {
                            int oldRow = hoverRow;
                            hoverRow = -1;
                            hoverButton = "";
                            this.dgvAssessments.Cursor = Cursors.Default;
                            this.dgvAssessments.InvalidateCell(e.ColumnIndex, oldRow);
                        }
                    }
                }
            };

            this.dgvAssessments.CellMouseLeave += (sender, e) =>
            {
                if (hoverRow != -1)
                {
                    int oldRow = hoverRow;
                    hoverRow = -1;
                    hoverButton = "";
                    this.dgvAssessments.Cursor = Cursors.Default;
                    if (oldRow >= 0 && oldRow < this.dgvAssessments.Rows.Count)
                    {
                        this.dgvAssessments.InvalidateCell(this.dgvAssessments.Columns["colAction"].Index, oldRow);
                    }
                }
            };

            this.dgvAssessments.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == this.dgvAssessments.Columns["colAction"].Index && e.RowIndex >= 0)
                {
                    var cellRect = this.dgvAssessments.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    var btnEditRect = new Rectangle(
                        cellRect.X + (cellRect.Width - 170) / 2,
                        cellRect.Y + (cellRect.Height - 30) / 2,
                        80, 30);
                    var btnGradeRect = new Rectangle(
                        btnEditRect.Right + 10,
                        cellRect.Y + (cellRect.Height - 30) / 2,
                        80, 30);

                    var mousePos = this.dgvAssessments.PointToClient(Cursor.Position);
                    var relativePos = new Point(mousePos.X - cellRect.X, mousePos.Y - cellRect.Y);

                    if (btnEditRect.Contains(relativePos))
                    {
                        MessageBox.Show($"Sửa bài: {this.dgvAssessments.Rows[e.RowIndex].Cells["colName"].Value}");
                    }
                    else if (btnGradeRect.Contains(relativePos))
                    {
                        MessageBox.Show($"Chấm bài: {this.dgvAssessments.Rows[e.RowIndex].Cells["colName"].Value}\n" +
                            $"Đã nộp: {this.dgvAssessments.Rows[e.RowIndex].Cells["colSubmitted"].Value}");
                    }
                }
            };

            this.contentPanel.Controls.Add(this.dgvAssessments);

            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.contentPanel, 0, 1);

            this.Controls.Add(this.mainLayout);
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessments)).EndInit();
        }
    }
}