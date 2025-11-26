using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using StudyProcessManagement.Business.Teacher;   // THÊM


namespace StudyProcessManagement.Views.Teacher.Controls
{
    public partial class StudentsControl : UserControl
    {
        // ============================================
        // PRIVATE FIELDS
        // ============================================
        private Panel headerPanel;
        private Label lblTitle;
        private Label lblBreadcrumb;
        private Panel filterPanel;
        private ComboBox cboCourse;
        private ComboBox cboStatus;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel summaryPanel;
        private Label lblTotalStudents;
        private Label lblActiveStudents;
        private Label lblCompletedStudents;
        private Panel tablePanel;
        private DataGridView dgvStudents;

        // Database
        private string currentTeacherID = "USR002";
        private readonly StudentService studentService;

        public StudentsControl()
        {
            InitializeComponent();
            studentService = new StudentService();
            InitStatusCombo();
            dgvStudents.Columns[0].FillWeight = 60;  // Mã SV
            dgvStudents.Columns[1].FillWeight = 150; // Họ tên
            dgvStudents.Columns[2].FillWeight = 180; // Email
            dgvStudents.Columns[3].FillWeight = 160; // Khóa học
            dgvStudents.Columns[4].FillWeight = 90;  // Ngày đăng ký
            dgvStudents.Columns[5].FillWeight = 90;  // Tiến độ
            dgvStudents.Columns[6].FillWeight = 90;

            studentService = new StudentService();   // THÊM

            if (!DesignMode)
            {
                LoadCourseFilter();
                LoadStudents();
                LoadSummary();
            }
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.lblBreadcrumb = new Label();
            this.filterPanel = new Panel();
            this.cboCourse = new ComboBox();
            this.cboStatus = new ComboBox();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.summaryPanel = new Panel();
            this.lblTotalStudents = new Label();
            this.lblActiveStudents = new Label();
            this.lblCompletedStudents = new Label();
            this.tablePanel = new Panel();
            this.dgvStudents = new DataGridView();

            this.headerPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.summaryPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();

            // headerPanel
            this.headerPanel.BackColor = Color.White;
            this.headerPanel.Controls.Add(this.lblBreadcrumb);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Location = new Point(0, 0);
            this.headerPanel.Padding = new Padding(30, 20, 30, 20);
            this.headerPanel.Size = new Size(1000, 100);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(45, 45, 48);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Text = "Quản lý học viên";

            // lblBreadcrumb
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new Font("Segoe UI", 9F);
            this.lblBreadcrumb.ForeColor = Color.FromArgb(117, 117, 117);
            this.lblBreadcrumb.Location = new Point(33, 60);
            this.lblBreadcrumb.Text = "Trang chủ  >  Quản lý học viên  >  Danh sách học viên";

            // filterPanel
            this.filterPanel.BackColor = Color.White;
            this.filterPanel.Controls.Add(this.btnSearch);
            this.filterPanel.Controls.Add(this.txtSearch);
            this.filterPanel.Controls.Add(this.cboStatus);
            this.filterPanel.Controls.Add(this.cboCourse);
            this.filterPanel.Dock = DockStyle.Top;
            this.filterPanel.Location = new Point(0, 100);
            this.filterPanel.Padding = new Padding(30, 15, 30, 15);
            this.filterPanel.Size = new Size(1000, 70);

            // cboCourse
            this.cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCourse.Font = new Font("Segoe UI", 10F);
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new Point(30, 20);
            this.cboCourse.Size = new Size(250, 25);
            this.cboCourse.SelectedIndexChanged += new EventHandler(this.cboCourse_SelectedIndexChanged);

            // cboStatus
            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new Font("Segoe UI", 10F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
                "Tất cả trạng thái",
                "Learning",
                "Completed",
                "Suspended"
            });
            this.cboStatus.Location = new Point(300, 20);
            this.cboStatus.Size = new Size(180, 25);
            this.cboStatus.SelectedIndex = 0;
            this.cboStatus.SelectedIndexChanged += new EventHandler(this.cboStatus_SelectedIndexChanged);

            // txtSearch
            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new Point(500, 20);
            this.txtSearch.Size = new Size(280, 25);
            this.txtSearch.Text = "🔍 Tìm kiếm theo tên hoặc email...";
            this.txtSearch.ForeColor = Color.Gray;
            this.txtSearch.Enter += new EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new EventHandler(this.txtSearch_Leave);

            // btnSearch
            this.btnSearch.BackColor = Color.FromArgb(33, 150, 243);
            this.btnSearch.Cursor = Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Location = new Point(790, 20);
            this.btnSearch.Size = new Size(80, 25);
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // summaryPanel
            this.summaryPanel.BackColor = Color.FromArgb(245, 245, 245);
            this.summaryPanel.Controls.Add(this.lblCompletedStudents);
            this.summaryPanel.Controls.Add(this.lblActiveStudents);
            this.summaryPanel.Controls.Add(this.lblTotalStudents);
            this.summaryPanel.Dock = DockStyle.Top;
            this.summaryPanel.Location = new Point(0, 170);
            this.summaryPanel.Padding = new Padding(30, 20, 30, 20);
            this.summaryPanel.Size = new Size(1000, 100);

            // lblTotalStudents
            this.lblTotalStudents.BackColor = Color.FromArgb(33, 150, 243);
            this.lblTotalStudents.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalStudents.ForeColor = Color.White;
            this.lblTotalStudents.Location = new Point(30, 20);
            this.lblTotalStudents.Size = new Size(280, 60);
            this.lblTotalStudents.Text = "📊 Tổng số học viên: 0";
            this.lblTotalStudents.TextAlign = ContentAlignment.MiddleCenter;

            // lblActiveStudents
            this.lblActiveStudents.BackColor = Color.FromArgb(76, 175, 80);
            this.lblActiveStudents.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblActiveStudents.ForeColor = Color.White;
            this.lblActiveStudents.Location = new Point(330, 20);
            this.lblActiveStudents.Size = new Size(280, 60);
            this.lblActiveStudents.Text = "✅ Đang học: 0";
            this.lblActiveStudents.TextAlign = ContentAlignment.MiddleCenter;

            // lblCompletedStudents
            this.lblCompletedStudents.BackColor = Color.FromArgb(255, 152, 0);
            this.lblCompletedStudents.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblCompletedStudents.ForeColor = Color.White;
            this.lblCompletedStudents.Location = new Point(630, 20);
            this.lblCompletedStudents.Size = new Size(280, 60);
            this.lblCompletedStudents.Text = "🎓 Hoàn thành: 0";
            this.lblCompletedStudents.TextAlign = ContentAlignment.MiddleCenter;

            // tablePanel
            this.tablePanel.BackColor = Color.White;
            this.tablePanel.Controls.Add(this.dgvStudents);
            this.tablePanel.Dock = DockStyle.Fill;
            this.tablePanel.Location = new Point(0, 270);
            this.tablePanel.Padding = new Padding(30);
            this.tablePanel.Size = new Size(1000, 430);

            // dgvStudents
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.BackgroundColor = Color.White;
            this.dgvStudents.BorderStyle = BorderStyle.None;
            this.dgvStudents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStudents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvStudents.ColumnHeadersHeight = 40;
            this.dgvStudents.Dock = DockStyle.Fill;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.GridColor = Color.FromArgb(230, 230, 230);
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.RowTemplate.Height = 50;
            this.dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(250, 250, 250);
            headerStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(117, 117, 117);
            headerStyle.SelectionBackColor = Color.FromArgb(250, 250, 250);
            headerStyle.SelectionForeColor = Color.FromArgb(117, 117, 117);
            this.dgvStudents.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9F);
            cellStyle.ForeColor = Color.FromArgb(45, 45, 48);
            cellStyle.SelectionBackColor = Color.FromArgb(229, 243, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(45, 45, 48);
            cellStyle.Padding = new Padding(10, 5, 10, 5);
            this.dgvStudents.DefaultCellStyle = cellStyle;

            this.dgvStudents.Columns.Add("colStudentID", "Mã SV");
            this.dgvStudents.Columns.Add("colStudentName", "Họ tên");
            this.dgvStudents.Columns.Add("colEmail", "Email");
            this.dgvStudents.Columns.Add("colCourseName", "Khóa học");
            this.dgvStudents.Columns.Add("colEnrollDate", "Ngày đăng ký");
            this.dgvStudents.Columns.Add("colProgress", "Tiến độ");
            this.dgvStudents.Columns.Add("colStatus", "Trạng thái");

            //this.dgvStudents.Columns[0].Width = 100;
            //this.dgvStudents.Columns[1].Width = 150;
            //this.dgvStudents.Columns[2].Width = 200;
            //this.dgvStudents.Columns[3].Width = 180;
            //this.dgvStudents.Columns[4].Width = 120;
            //this.dgvStudents.Columns[5].Width = 120;
            //this.dgvStudents.Columns[6].Width = 110;

            this.dgvStudents.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvStudents_CellPainting);

            // StudentsControl
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.summaryPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.headerPanel);
            this.Size = new Size(1000, 700);

            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.summaryPanel.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
        }

        // ============================================
        // DATABASE METHODS
        // ============================================

        void LoadCourseFilter()
        {
            try
            {
                cboCourse.Items.Clear();
                cboCourse.Items.Add(new CourseItem { CourseID = "", CourseName = "-- Tất cả khóa học --" });

                DataTable dt = studentService.GetTeacherCourses(currentTeacherID);

                foreach (DataRow row in dt.Rows)
                {
                    cboCourse.Items.Add(new CourseItem
                    {
                        CourseID = row["CourseID"].ToString(),
                        CourseName = row["CourseName"].ToString()
                    });
                }

                cboCourse.DisplayMember = "CourseName";
                cboCourse.ValueMember = "CourseID";
                cboCourse.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadStudents()
        {
            try
            {
                string searchKeyword = txtSearch.Text;
                if (searchKeyword == "🔍 Tìm kiếm theo tên hoặc email...")
                    searchKeyword = "";

                // Lấy CourseID được chọn (có thể rỗng = tất cả)
                string selectedCourseID = "";
                if (cboCourse.SelectedItem is CourseItem cItem && !string.IsNullOrEmpty(cItem.CourseID))
                    selectedCourseID = cItem.CourseID;

                // Lấy trạng thái filter
                string statusFilter = "Tất cả trạng thái";
                if (cboStatus.SelectedItem is StatusItem sItem && !string.IsNullOrEmpty(sItem.Value))
                    statusFilter = sItem.Value;               // Learning / Completed / Suspended

                DataTable dt = studentService.GetStudents(
                    currentTeacherID,
                    selectedCourseID,
                    statusFilter,
                    searchKeyword
                );

                dgvStudents.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int progress = Convert.ToInt32(row["ProgressPercent"]);

                    dgvStudents.Rows.Add(
                        row["UserID"],
                        row["FullName"],
                        row["Email"],
                        row["CourseName"],
                        Convert.ToDateTime(row["EnrollmentDate"]).ToString("dd/MM/yyyy"),
                        progress + "%",
                        row["Status"]      // tí nữa CellPainting sẽ đổi sang tiếng Việt
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadSummary()
        {
            try
            {
                string selectedCourseID = "";
                if (cboCourse.SelectedItem is CourseItem cItem && !string.IsNullOrEmpty(cItem.CourseID))
                    selectedCourseID = cItem.CourseID;

                DataTable dt = studentService.GetStudentSummary(currentTeacherID, selectedCourseID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblTotalStudents.Text = $"📊 Tổng số học viên: {row["Total"]}";
                    lblActiveStudents.Text = $"✅ Đang học: {row["Active"]}";
                    lblCompletedStudents.Text = $"🎓 Hoàn thành: {row["Completed"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // ============================================
        // EVENT HANDLERS
        // ============================================

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudents();
            LoadSummary();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "🔍 Tìm kiếm theo tên hoặc email...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "🔍 Tìm kiếm theo tên hoặc email...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }
        private string GetStatusDisplay(string status)
        {
            switch (status)
            {
                case "Learning": return "Đang học";
                case "Completed": return "Hoàn thành";
                case "Suspended": return "Tạm dừng";
                default: return status; // fallback
            }
        }
        private void dgvStudents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Progress bar
            if (e.ColumnIndex == dgvStudents.Columns["colProgress"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string progressText = dgvStudents.Rows[e.RowIndex].Cells["colProgress"].Value?.ToString();
                if (!string.IsNullOrEmpty(progressText))
                {
                    int progress = int.Parse(progressText.Replace("%", ""));

                    Color progressColor = progress >= 80 ? Color.FromArgb(76, 175, 80) :
                                         progress >= 50 ? Color.FromArgb(255, 193, 7) :
                                         Color.FromArgb(244, 67, 54);

                    Rectangle barRect = new Rectangle(
                        e.CellBounds.X + 10,
                        e.CellBounds.Y + (e.CellBounds.Height - 20) / 2,
                        e.CellBounds.Width - 20, 20);

                    using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
                        e.Graphics.FillRectangle(bgBrush, barRect);

                    int fillWidth = (int)(barRect.Width * progress / 100.0);
                    using (SolidBrush fillBrush = new SolidBrush(progressColor))
                        e.Graphics.FillRectangle(fillBrush, new Rectangle(barRect.X, barRect.Y, fillWidth, barRect.Height));

                    using (Font font = new Font("Segoe UI", 8F, FontStyle.Bold))
                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(progressText, font, textBrush, barRect, sf);
                    }
                }
            }

            // Status badge
            if (e.ColumnIndex == dgvStudents.Columns["colStatus"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string status = dgvStudents.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString();
                string displayText = GetStatusDisplay(status);
                if (!string.IsNullOrEmpty(status))
                {
                    Color badgeColor = status == "Learning" ? Color.FromArgb(33, 150, 243) :
                                      status == "Completed" ? Color.FromArgb(76, 175, 80) :
                                      Color.FromArgb(255, 152, 0);

                    Rectangle badgeRect = new Rectangle(
                        e.CellBounds.X + 10,
                        e.CellBounds.Y + (e.CellBounds.Height - 24) / 2,
                        e.CellBounds.Width - 20, 24);

                    using (GraphicsPath path = GetRoundedRectPath(badgeRect, 12))
                    using (SolidBrush brush = new SolidBrush(badgeColor))
                        e.Graphics.FillPath(brush, path);

                    using (Font font = new Font("Segoe UI", 8F, FontStyle.Bold))
                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(GetStatusDisplay(status), font, textBrush, badgeRect, sf);
                    }
                }
            }
        }

        // ============================================
        // HELPER METHODS
        // ============================================

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ============================================
        // NESTED CLASSES
        // ============================================

        private class CourseItem
        {
            public string CourseID { get; set; }
            public string CourseName { get; set; }
        }
        private class StatusItem
        {
            public string Value { get; set; } // Giá trị lưu trong DB (Learning/Completed/Suspended)
            public string Text { get; set; }  // Text hiển thị trên Combobox

            public override string ToString() => Text;
        }
        private void InitStatusCombo()
        {
            cboStatus.Items.Clear();
            cboStatus.DisplayMember = "Text";
            cboStatus.ValueMember = "Value";

            cboStatus.Items.Add(new StatusItem { Value = "", Text = "Tất cả trạng thái" });
            cboStatus.Items.Add(new StatusItem { Value = "Learning", Text = "Đang học" });
            cboStatus.Items.Add(new StatusItem { Value = "Completed", Text = "Hoàn thành" });
            cboStatus.Items.Add(new StatusItem { Value = "Suspended", Text = "Tạm dừng" });

            cboStatus.SelectedIndex = 0;
        }
    }
}
