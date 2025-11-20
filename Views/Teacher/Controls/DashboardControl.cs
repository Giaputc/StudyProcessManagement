using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using StudyProcessManagement.Business.Teacher; // ✅ Import Service

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public partial class DashboardControl : UserControl
    {      
        private DashboardService dashboardService;
        private string currentTeacherID = "USR002"; // TODO: Lấy từ session/login

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
        private Button btnViewAllCourses;
        private Panel panelAssignments;
        private Label lblAssignmentsTitle;
        private DataGridView dgvAssignments;
        private Button btnViewAllAssignments;
        private Panel topCoursesPanel;
        private Panel topAssignPanel;

        private DataGridViewTextBoxColumn colCourseName;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colStudents;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colUpdated;
        private DataGridViewTextBoxColumn colAssignment;
        private DataGridViewTextBoxColumn colCourse;
        private DataGridViewTextBoxColumn colSubmissions;
        private DataGridViewTextBoxColumn colDueDate;

        // ============================================
        // CONSTRUCTOR
        // ============================================
        public DashboardControl()
        {
            InitializeComponent();

            // ✅ Khởi tạo Service
            dashboardService = new DashboardService();

            if (!this.DesignMode)
            {
                LoadDashboardData();
            }
        }

        // ============================================
        // ✅ LOAD DATA - GỌI SERVICE
        // ============================================
        private void LoadDashboardData()
        {
            try
            {
                LoadStatisticsCards();
                LoadRecentCourses();
                LoadPendingSubmissions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Dashboard: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatisticsCards()
        {
            try
            {
                // ✅ Gọi Service - lấy tất cả thống kê trong 1 query
                DataTable dt = dashboardService.GetDashboardStatistics(currentTeacherID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Card 1: Tổng số khóa học
                    lblCard1Value.Text = row["TotalCourses"].ToString();

                    // Card 2: Tổng số học viên
                    lblCard2Value.Text = row["TotalStudents"].ToString();

                    // Card 3: Bài tập chưa chấm
                    lblCard3Value.Text = row["PendingGrades"].ToString();

                    // Card 4: Điểm trung bình
                    decimal avgScore = row["AverageScore"] != DBNull.Value
                        ? Convert.ToDecimal(row["AverageScore"])
                        : 0;
                    lblCard4Value.Text = avgScore.ToString("F1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentCourses()
        {
            try
            {
                dgvCourses.Rows.Clear();

                // ✅ Gọi Service
                DataTable dt = dashboardService.GetRecentCourses(currentTeacherID);

                foreach (DataRow row in dt.Rows)
                {
                    string courseName = row["CourseName"].ToString();
                    string category = row["CategoryName"]?.ToString() ?? "N/A";
                    int students = row["TotalStudents"] != DBNull.Value
                        ? Convert.ToInt32(row["TotalStudents"])
                        : 0;
                    string status = row["Status"]?.ToString() ?? "N/A";
                    DateTime createdAt = Convert.ToDateTime(row["CreatedAt"]);

                    // Format time ago
                    TimeSpan timeSpan = DateTime.Now - createdAt;
                    string timeAgo;
                    if (timeSpan.TotalDays < 1)
                        timeAgo = $"{(int)timeSpan.TotalHours} giờ trước";
                    else if (timeSpan.TotalDays < 7)
                        timeAgo = $"{(int)timeSpan.TotalDays} ngày trước";
                    else
                        timeAgo = createdAt.ToString("dd/MM/yyyy");

                    dgvCourses.Rows.Add(courseName, category, students.ToString(), status, timeAgo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPendingSubmissions()
        {
            try
            {
                dgvAssignments.Rows.Clear();

                // ✅ Gọi Service
                DataTable dt = dashboardService.GetPendingSubmissions(currentTeacherID);

                foreach (DataRow row in dt.Rows)
                {
                    string assignmentTitle = row["AssignmentTitle"].ToString();
                    string courseName = row["CourseName"].ToString();
                    int totalSubmissions = Convert.ToInt32(row["TotalSubmissions"]);
                    int totalStudents = Convert.ToInt32(row["TotalStudents"]);
                    DateTime dueDate = Convert.ToDateTime(row["DueDate"]);

                    string submissionsText = $"{totalSubmissions}/{totalStudents}";
                    string dueDateText = dueDate.ToString("dd/MM/yyyy");

                    dgvAssignments.Rows.Add(assignmentTitle, courseName, submissionsText, dueDateText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải bài tập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshDashboard()
        {
            LoadDashboardData();
        }

        // ============================================
        // INITIALIZE COMPONENT (AUTO-GENERATED UI CODE)
        // ============================================
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.cardsTable = new System.Windows.Forms.TableLayoutPanel();
            this.card1 = new System.Windows.Forms.Panel();
            this.lblCard1Value = new System.Windows.Forms.Label();
            this.lblCard1Text = new System.Windows.Forms.Label();
            this.card2 = new System.Windows.Forms.Panel();
            this.lblCard2Value = new System.Windows.Forms.Label();
            this.lblCard2Text = new System.Windows.Forms.Label();
            this.card3 = new System.Windows.Forms.Panel();
            this.lblCard3Value = new System.Windows.Forms.Label();
            this.lblCard3Text = new System.Windows.Forms.Label();
            this.card4 = new System.Windows.Forms.Panel();
            this.lblCard4Value = new System.Windows.Forms.Label();
            this.lblCard4Text = new System.Windows.Forms.Label();
            this.panelCourses = new System.Windows.Forms.Panel();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.colCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topCoursesPanel = new System.Windows.Forms.Panel();
            this.btnViewAllCourses = new System.Windows.Forms.Button();
            this.lblCoursesTitle = new System.Windows.Forms.Label();
            this.panelAssignments = new System.Windows.Forms.Panel();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.colAssignment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubmissions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topAssignPanel = new System.Windows.Forms.Panel();
            this.btnViewAllAssignments = new System.Windows.Forms.Button();
            this.lblAssignmentsTitle = new System.Windows.Forms.Label();

            this.mainLayout.SuspendLayout();
            this.cardsTable.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.panelCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.topCoursesPanel.SuspendLayout();
            this.panelAssignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.topAssignPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(156, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";

            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.cardsTable, 0, 0);
            this.mainLayout.Controls.Add(this.panelCourses, 0, 1);
            this.mainLayout.Controls.Add(this.panelAssignments, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 70);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Size = new System.Drawing.Size(1200, 630);
            this.mainLayout.TabIndex = 1;

            // 
            // cardsTable
            // 
            this.cardsTable.ColumnCount = 4;
            this.cardsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cardsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cardsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cardsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cardsTable.Controls.Add(this.card1, 0, 0);
            this.cardsTable.Controls.Add(this.card2, 1, 0);
            this.cardsTable.Controls.Add(this.card3, 2, 0);
            this.cardsTable.Controls.Add(this.card4, 3, 0);
            this.cardsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardsTable.Location = new System.Drawing.Point(23, 3);
            this.cardsTable.Name = "cardsTable";
            this.cardsTable.RowCount = 1;
            this.cardsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardsTable.Size = new System.Drawing.Size(1154, 114);
            this.cardsTable.TabIndex = 0;

            // 
            // card1 (Blue - Courses)
            // 
            this.card1.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.card1.Controls.Add(this.lblCard1Value);
            this.card1.Controls.Add(this.lblCard1Text);
            this.card1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card1.Location = new System.Drawing.Point(10, 10);
            this.card1.Margin = new System.Windows.Forms.Padding(10);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(268, 94);
            this.card1.TabIndex = 0;

            this.lblCard1Value.AutoSize = true;
            this.lblCard1Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCard1Value.ForeColor = System.Drawing.Color.White;
            this.lblCard1Value.Location = new System.Drawing.Point(15, 15);
            this.lblCard1Value.Name = "lblCard1Value";
            this.lblCard1Value.Size = new System.Drawing.Size(37, 45);
            this.lblCard1Value.TabIndex = 0;
            this.lblCard1Value.Text = "0";

            this.lblCard1Text.AutoSize = true;
            this.lblCard1Text.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard1Text.ForeColor = System.Drawing.Color.White;
            this.lblCard1Text.Location = new System.Drawing.Point(15, 60);
            this.lblCard1Text.Name = "lblCard1Text";
            this.lblCard1Text.Size = new System.Drawing.Size(120, 19);
            this.lblCard1Text.TabIndex = 1;
            this.lblCard1Text.Text = "Tổng số khóa học";

            // 
            // card2 (Green - Students)
            // 
            this.card2.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.card2.Controls.Add(this.lblCard2Value);
            this.card2.Controls.Add(this.lblCard2Text);
            this.card2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card2.Location = new System.Drawing.Point(298, 10);
            this.card2.Margin = new System.Windows.Forms.Padding(10);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(268, 94);
            this.card2.TabIndex = 1;

            this.lblCard2Value.AutoSize = true;
            this.lblCard2Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCard2Value.ForeColor = System.Drawing.Color.White;
            this.lblCard2Value.Location = new System.Drawing.Point(15, 15);
            this.lblCard2Value.Name = "lblCard2Value";
            this.lblCard2Value.Size = new System.Drawing.Size(37, 45);
            this.lblCard2Value.TabIndex = 0;
            this.lblCard2Value.Text = "0";

            this.lblCard2Text.AutoSize = true;
            this.lblCard2Text.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard2Text.ForeColor = System.Drawing.Color.White;
            this.lblCard2Text.Location = new System.Drawing.Point(15, 60);
            this.lblCard2Text.Name = "lblCard2Text";
            this.lblCard2Text.Size = new System.Drawing.Size(116, 19);
            this.lblCard2Text.TabIndex = 1;
            this.lblCard2Text.Text = "Tổng số học viên";

            // 
            // card3 (Orange - Pending)
            // 
            this.card3.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.card3.Controls.Add(this.lblCard3Value);
            this.card3.Controls.Add(this.lblCard3Text);
            this.card3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card3.Location = new System.Drawing.Point(586, 10);
            this.card3.Margin = new System.Windows.Forms.Padding(10);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(268, 94);
            this.card3.TabIndex = 2;

            this.lblCard3Value.AutoSize = true;
            this.lblCard3Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCard3Value.ForeColor = System.Drawing.Color.White;
            this.lblCard3Value.Location = new System.Drawing.Point(15, 15);
            this.lblCard3Value.Name = "lblCard3Value";
            this.lblCard3Value.Size = new System.Drawing.Size(37, 45);
            this.lblCard3Value.TabIndex = 0;
            this.lblCard3Value.Text = "0";

            this.lblCard3Text.AutoSize = true;
            this.lblCard3Text.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard3Text.ForeColor = System.Drawing.Color.White;
            this.lblCard3Text.Location = new System.Drawing.Point(15, 60);
            this.lblCard3Text.Name = "lblCard3Text";
            this.lblCard3Text.Size = new System.Drawing.Size(126, 19);
            this.lblCard3Text.TabIndex = 1;
            this.lblCard3Text.Text = "Bài tập chưa chấm";

            // 
            // card4 (Purple - Average Score)
            // 
            this.card4.BackColor = System.Drawing.Color.FromArgb(156, 39, 176);
            this.card4.Controls.Add(this.lblCard4Value);
            this.card4.Controls.Add(this.lblCard4Text);
            this.card4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card4.Location = new System.Drawing.Point(874, 10);
            this.card4.Margin = new System.Windows.Forms.Padding(10);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(270, 94);
            this.card4.TabIndex = 3;

            this.lblCard4Value.AutoSize = true;
            this.lblCard4Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCard4Value.ForeColor = System.Drawing.Color.White;
            this.lblCard4Value.Location = new System.Drawing.Point(15, 15);
            this.lblCard4Value.Name = "lblCard4Value";
            this.lblCard4Value.Size = new System.Drawing.Size(37, 45);
            this.lblCard4Value.TabIndex = 0;
            this.lblCard4Value.Text = "0";

            this.lblCard4Text.AutoSize = true;
            this.lblCard4Text.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCard4Text.ForeColor = System.Drawing.Color.White;
            this.lblCard4Text.Location = new System.Drawing.Point(15, 60);
            this.lblCard4Text.Name = "lblCard4Text";
            this.lblCard4Text.Size = new System.Drawing.Size(119, 19);
            this.lblCard4Text.TabIndex = 1;
            this.lblCard4Text.Text = "Điểm trung bình";

            // 
            // panelCourses
            // 
            this.panelCourses.BackColor = System.Drawing.Color.White;
            this.panelCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCourses.Controls.Add(this.dgvCourses);
            this.panelCourses.Controls.Add(this.topCoursesPanel);
            this.panelCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCourses.Location = new System.Drawing.Point(30, 130);
            this.panelCourses.Margin = new System.Windows.Forms.Padding(10);
            this.panelCourses.Name = "panelCourses";
            this.panelCourses.Size = new System.Drawing.Size(1140, 235);
            this.panelCourses.TabIndex = 1;

            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.AllowUserToResizeRows = false;
            this.dgvCourses.BackgroundColor = System.Drawing.Color.White;
            this.dgvCourses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCourses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCourses.ColumnHeadersHeight = 40;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCourseName,
                this.colCategory,
                this.colStudents,
                this.colStatus,
                this.colUpdated});
            this.dgvCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCourses.GridColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.dgvCourses.Location = new System.Drawing.Point(0, 60);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.RowTemplate.Height = 45;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(1138, 173);
            this.dgvCourses.TabIndex = 1;

            this.colCourseName.HeaderText = "Khóa học";
            this.colCourseName.Name = "colCourseName";
            this.colCourseName.ReadOnly = true;
            this.colCourseName.Width = 400;

            this.colCategory.HeaderText = "Danh mục";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 200;

            this.colStudents.HeaderText = "Học viên";
            this.colStudents.Name = "colStudents";
            this.colStudents.ReadOnly = true;
            this.colStudents.Width = 150;

            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 200;

            this.colUpdated.HeaderText = "Cập nhật";
            this.colUpdated.Name = "colUpdated";
            this.colUpdated.ReadOnly = true;
            this.colUpdated.Width = 150;

            // 
            // topCoursesPanel
            // 
            this.topCoursesPanel.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.topCoursesPanel.Controls.Add(this.btnViewAllCourses);
            this.topCoursesPanel.Controls.Add(this.lblCoursesTitle);
            this.topCoursesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topCoursesPanel.Location = new System.Drawing.Point(0, 0);
            this.topCoursesPanel.Name = "topCoursesPanel";
            this.topCoursesPanel.Size = new System.Drawing.Size(1138, 60);
            this.topCoursesPanel.TabIndex = 0;
            this.topCoursesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);

            this.btnViewAllCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAllCourses.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnViewAllCourses.FlatAppearance.BorderSize = 0;
            this.btnViewAllCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAllCourses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewAllCourses.ForeColor = System.Drawing.Color.White;
            this.btnViewAllCourses.Location = new System.Drawing.Point(1018, 15);
            this.btnViewAllCourses.Name = "btnViewAllCourses";
            this.btnViewAllCourses.Size = new System.Drawing.Size(100, 32);
            this.btnViewAllCourses.TabIndex = 1;
            this.btnViewAllCourses.Text = "Xem tất cả";
            this.btnViewAllCourses.UseVisualStyleBackColor = false;
            this.btnViewAllCourses.Click += new System.EventHandler(this.btnViewAllCourses_Click);
            this.btnViewAllCourses.MouseEnter += new System.EventHandler(this.btnViewAll_MouseEnter);
            this.btnViewAllCourses.MouseLeave += new System.EventHandler(this.btnViewAll_MouseLeave);

            this.lblCoursesTitle.AutoSize = true;
            this.lblCoursesTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCoursesTitle.Location = new System.Drawing.Point(15, 18);
            this.lblCoursesTitle.Name = "lblCoursesTitle";
            this.lblCoursesTitle.Size = new System.Drawing.Size(188, 25);
            this.lblCoursesTitle.TabIndex = 0;
            this.lblCoursesTitle.Text = "Khóa học gần đây";

            // 
            // panelAssignments
            // 
            this.panelAssignments.BackColor = System.Drawing.Color.White;
            this.panelAssignments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAssignments.Controls.Add(this.dgvAssignments);
            this.panelAssignments.Controls.Add(this.topAssignPanel);
            this.panelAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAssignments.Location = new System.Drawing.Point(30, 385);
            this.panelAssignments.Margin = new System.Windows.Forms.Padding(10);
            this.panelAssignments.Name = "panelAssignments";
            this.panelAssignments.Size = new System.Drawing.Size(1140, 215);
            this.panelAssignments.TabIndex = 2;

            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            this.dgvAssignments.AllowUserToResizeRows = false;
            this.dgvAssignments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAssignments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAssignments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAssignments.ColumnHeadersHeight = 40;
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAssignments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAssignment,
                this.colCourse,
                this.colSubmissions,
                this.colDueDate});
            this.dgvAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssignments.GridColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.dgvAssignments.Location = new System.Drawing.Point(0, 60);
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.ReadOnly = true;
            this.dgvAssignments.RowHeadersVisible = false;
            this.dgvAssignments.RowTemplate.Height = 45;
            this.dgvAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignments.Size = new System.Drawing.Size(1138, 153);
            this.dgvAssignments.TabIndex = 1;

            this.colAssignment.HeaderText = "Bài tập";
            this.colAssignment.Name = "colAssignment";
            this.colAssignment.ReadOnly = true;
            this.colAssignment.Width = 450;

            this.colCourse.HeaderText = "Khóa học";
            this.colCourse.Name = "colCourse";
            this.colCourse.ReadOnly = true;
            this.colCourse.Width = 350;

            this.colSubmissions.HeaderText = "Bài nộp";
            this.colSubmissions.Name = "colSubmissions";
            this.colSubmissions.ReadOnly = true;
            this.colSubmissions.Width = 150;

            this.colDueDate.HeaderText = "Hạn nộp";
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.ReadOnly = true;
            this.colDueDate.Width = 150;

            // 
            // topAssignPanel
            // 
            this.topAssignPanel.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.topAssignPanel.Controls.Add(this.btnViewAllAssignments);
            this.topAssignPanel.Controls.Add(this.lblAssignmentsTitle);
            this.topAssignPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topAssignPanel.Location = new System.Drawing.Point(0, 0);
            this.topAssignPanel.Name = "topAssignPanel";
            this.topAssignPanel.Size = new System.Drawing.Size(1138, 60);
            this.topAssignPanel.TabIndex = 0;
            this.topAssignPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);

            this.btnViewAllAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAllAssignments.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnViewAllAssignments.FlatAppearance.BorderSize = 0;
            this.btnViewAllAssignments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAllAssignments.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewAllAssignments.ForeColor = System.Drawing.Color.White;
            this.btnViewAllAssignments.Location = new System.Drawing.Point(1018, 15);
            this.btnViewAllAssignments.Name = "btnViewAllAssignments";
            this.btnViewAllAssignments.Size = new System.Drawing.Size(100, 32);
            this.btnViewAllAssignments.TabIndex = 1;
            this.btnViewAllAssignments.Text = "Xem tất cả";
            this.btnViewAllAssignments.UseVisualStyleBackColor = false;
            this.btnViewAllAssignments.Click += new System.EventHandler(this.btnViewAllAssignments_Click);
            this.btnViewAllAssignments.MouseEnter += new System.EventHandler(this.btnViewAll_MouseEnter);
            this.btnViewAllAssignments.MouseLeave += new System.EventHandler(this.btnViewAll_MouseLeave);

            this.lblAssignmentsTitle.AutoSize = true;
            this.lblAssignmentsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAssignmentsTitle.Location = new System.Drawing.Point(15, 18);
            this.lblAssignmentsTitle.Name = "lblAssignmentsTitle";
            this.lblAssignmentsTitle.Size = new System.Drawing.Size(204, 25);
            this.lblAssignmentsTitle.TabIndex = 0;
            this.lblAssignmentsTitle.Text = "Bài tập chưa chấm";

            // 
            // DashboardControl
            // 
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.lblTitle);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1200, 700);

            this.mainLayout.ResumeLayout(false);
            this.cardsTable.ResumeLayout(false);
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.card3.ResumeLayout(false);
            this.card3.PerformLayout();
            this.card4.ResumeLayout(false);
            this.card4.PerformLayout();
            this.panelCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.topCoursesPanel.ResumeLayout(false);
            this.topCoursesPanel.PerformLayout();
            this.panelAssignments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.topAssignPanel.ResumeLayout(false);
            this.topAssignPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ============================================
        // EVENT HANDLERS
        // ============================================
        private void btnViewAllCourses_Click(object sender, EventArgs e)
        {
            // Tìm Form1 parent
            Form parentForm = this.FindForm();
            if (parentForm != null && parentForm is Form1)
            {
                ((Form1)parentForm).NavigateToCourseManagement();
            }
        }

        private void btnViewAllAssignments_Click(object sender, EventArgs e)
        {
            // Tìm Form1 parent
            Form parentForm = this.FindForm();
            if (parentForm != null && parentForm is Form1)
            {
                ((Form1)parentForm).NavigateToGradingWithFilter("Chưa chấm");
            }
        }

        private void btnViewAll_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(25, 118, 210);
        }

        private void btnViewAll_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(33, 150, 243);
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                e.Graphics.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
            }
        }
    }
}
