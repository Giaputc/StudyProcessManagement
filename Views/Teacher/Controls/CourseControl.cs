using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using StudyProcessManagement.Business.Teacher; // ✅ Import Service

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public partial class CourseControl : UserControl
    {
        // ============================================
        // PRIVATE FIELDS
        // ============================================
        private Panel headerPanel;
        private Label lblTitle;
        private Label lblBreadcrumb;
        private Panel filterPanel;
        private ComboBox cboCategory;
        private TextBox txtSearch;
        private Button btnAddCourse;
        private Button btnToggleView;
        private Panel summaryPanel;
        private Label lblTotalCourses;
        private Label lblTotalStudents;
        private Label lblTotalLessons;
        private FlowLayoutPanel flowLayoutCourses;
        private Panel tablePanel;
        private DataGridView dgvCourses;
        private bool isCardView = true;

        // ✅ Thay vì connectionString, dùng Service
        private CourseService courseService;
        private string currentTeacherID = "USR002"; // TODO: Lấy từ session/login

        // ============================================
        // CONSTRUCTOR
        // ============================================
        public CourseControl()
        {
            InitializeComponent();

            // ✅ Khởi tạo Service
            courseService = new CourseService();

            if (!DesignMode)
            {
                LoadCategories();
                LoadCourses();
                LoadSummary();
            }
        }

        // ============================================
        // INITIALIZE COMPONENT (AUTO-GENERATED UI CODE)
        // ============================================
        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.lblBreadcrumb = new Label();
            this.filterPanel = new Panel();
            this.cboCategory = new ComboBox();
            this.txtSearch = new TextBox();
            this.btnAddCourse = new Button();
            this.btnToggleView = new Button();
            this.summaryPanel = new Panel();
            this.lblTotalCourses = new Label();
            this.lblTotalStudents = new Label();
            this.lblTotalLessons = new Label();
            this.flowLayoutCourses = new FlowLayoutPanel();
            this.tablePanel = new Panel();
            this.dgvCourses = new DataGridView();

            this.headerPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.summaryPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();

            // headerPanel
            this.headerPanel.BackColor = Color.White;
            this.headerPanel.Controls.Add(this.lblBreadcrumb);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Padding = new Padding(30, 20, 30, 20);
            this.headerPanel.Size = new Size(1000, 100);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(45, 45, 48);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Text = "Quản lý khóa học";

            // lblBreadcrumb
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new Font("Segoe UI", 9F);
            this.lblBreadcrumb.ForeColor = Color.FromArgb(117, 117, 117);
            this.lblBreadcrumb.Location = new Point(33, 60);
            this.lblBreadcrumb.Text = "Trang chủ > Quản lý khóa học > Danh sách khóa học";

            // filterPanel
            this.filterPanel.BackColor = Color.White;
            this.filterPanel.Controls.Add(this.btnToggleView);
            this.filterPanel.Controls.Add(this.btnAddCourse);
            this.filterPanel.Controls.Add(this.txtSearch);
            this.filterPanel.Controls.Add(this.cboCategory);
            this.filterPanel.Dock = DockStyle.Top;
            this.filterPanel.Location = new Point(0, 100);
            this.filterPanel.Padding = new Padding(30, 15, 30, 15);
            this.filterPanel.Size = new Size(1000, 70);

            // cboCategory
            this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new Font("Segoe UI", 10F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new Point(30, 20);
            this.cboCategory.Size = new Size(200, 25);
            this.cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;

            // txtSearch
            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new Point(250, 20);
            this.txtSearch.Size = new Size(250, 25);
            this.txtSearch.Text = "🔍 Tìm kiếm khóa học...";
            this.txtSearch.ForeColor = Color.Gray;
            this.txtSearch.Enter += txtSearch_Enter;
            this.txtSearch.Leave += txtSearch_Leave;
            this.txtSearch.TextChanged += txtSearch_TextChanged;

            // btnToggleView
            this.btnToggleView.BackColor = Color.FromArgb(158, 158, 158);
            this.btnToggleView.Cursor = Cursors.Hand;
            this.btnToggleView.FlatAppearance.BorderSize = 0;
            this.btnToggleView.FlatStyle = FlatStyle.Flat;
            this.btnToggleView.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnToggleView.ForeColor = Color.White;
            this.btnToggleView.Location = new Point(670, 17);
            this.btnToggleView.Size = new Size(100, 32);
            this.btnToggleView.Text = "📋 Bảng";
            this.btnToggleView.Click += btnToggleView_Click;

            // btnAddCourse
            this.btnAddCourse.BackColor = Color.FromArgb(76, 175, 80);
            this.btnAddCourse.Cursor = Cursors.Hand;
            this.btnAddCourse.FlatAppearance.BorderSize = 0;
            this.btnAddCourse.FlatStyle = FlatStyle.Flat;
            this.btnAddCourse.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddCourse.ForeColor = Color.White;
            this.btnAddCourse.Location = new Point(820, 17);
            this.btnAddCourse.Size = new Size(150, 32);
            this.btnAddCourse.Text = "➕ Tạo khóa học mới";
            this.btnAddCourse.Click += btnAddCourse_Click;

            // summaryPanel
            this.summaryPanel.BackColor = Color.FromArgb(245, 245, 245);
            this.summaryPanel.Controls.Add(this.lblTotalLessons);
            this.summaryPanel.Controls.Add(this.lblTotalStudents);
            this.summaryPanel.Controls.Add(this.lblTotalCourses);
            this.summaryPanel.Dock = DockStyle.Top;
            this.summaryPanel.Location = new Point(0, 170);
            this.summaryPanel.Padding = new Padding(30, 20, 30, 20);
            this.summaryPanel.Size = new Size(1000, 100);

            // lblTotalCourses
            this.lblTotalCourses.BackColor = Color.FromArgb(33, 150, 243);
            this.lblTotalCourses.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalCourses.ForeColor = Color.White;
            this.lblTotalCourses.Location = new Point(30, 20);
            this.lblTotalCourses.Size = new Size(280, 60);
            this.lblTotalCourses.Text = "📚 Tổng khóa học: 0";
            this.lblTotalCourses.TextAlign = ContentAlignment.MiddleCenter;

            // lblTotalStudents
            this.lblTotalStudents.BackColor = Color.FromArgb(76, 175, 80);
            this.lblTotalStudents.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalStudents.ForeColor = Color.White;
            this.lblTotalStudents.Location = new Point(330, 20);
            this.lblTotalStudents.Size = new Size(280, 60);
            this.lblTotalStudents.Text = "👥 Tổng học viên: 0";
            this.lblTotalStudents.TextAlign = ContentAlignment.MiddleCenter;

            // lblTotalLessons
            this.lblTotalLessons.BackColor = Color.FromArgb(255, 152, 0);
            this.lblTotalLessons.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalLessons.ForeColor = Color.White;
            this.lblTotalLessons.Location = new Point(630, 20);
            this.lblTotalLessons.Size = new Size(280, 60);
            this.lblTotalLessons.Text = "📖 Tổng bài học: 0";
            this.lblTotalLessons.TextAlign = ContentAlignment.MiddleCenter;

            // flowLayoutCourses (Card View)
            this.flowLayoutCourses.AutoScroll = true;
            this.flowLayoutCourses.BackColor = Color.FromArgb(245, 245, 245);
            this.flowLayoutCourses.Dock = DockStyle.Fill;
            this.flowLayoutCourses.Padding = new Padding(20, 20, 20, 20);
            this.flowLayoutCourses.Visible = true;

            // tablePanel (Table View)
            this.tablePanel.BackColor = Color.White;
            this.tablePanel.Controls.Add(this.dgvCourses);
            this.tablePanel.Dock = DockStyle.Fill;
            this.tablePanel.Padding = new Padding(30);
            this.tablePanel.Visible = false;

            // dgvCourses
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.BackgroundColor = Color.White;
            this.dgvCourses.BorderStyle = BorderStyle.None;
            this.dgvCourses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCourses.ColumnHeadersHeight = 40;
            this.dgvCourses.Dock = DockStyle.Fill;
            this.dgvCourses.EnableHeadersVisualStyles = false;
            this.dgvCourses.GridColor = Color.FromArgb(230, 230, 230);
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.RowHeadersVisible = false;
            this.dgvCourses.RowTemplate.Height = 50;
            this.dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(250, 250, 250);
            headerStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(117, 117, 117);
            this.dgvCourses.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9F);
            cellStyle.ForeColor = Color.FromArgb(45, 45, 48);
            cellStyle.SelectionBackColor = Color.FromArgb(229, 243, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(45, 45, 48);
            cellStyle.Padding = new Padding(10, 5, 10, 5);
            this.dgvCourses.DefaultCellStyle = cellStyle;

            this.dgvCourses.Columns.Add("colCourseID", "Mã khóa học");
            this.dgvCourses.Columns.Add("colCourseName", "Tên khóa học");
            this.dgvCourses.Columns.Add("colCategory", "Danh mục");
            this.dgvCourses.Columns.Add("colStudentCount", "Số học viên");
            this.dgvCourses.Columns.Add("colLessonCount", "Số bài học");
            this.dgvCourses.Columns.Add("colStatus", "Trạng thái");
            this.dgvCourses.Columns.Add("colAction", "Thao tác");

            this.dgvCourses.Columns[0].Width = 120;
            this.dgvCourses.Columns[1].Width = 230;
            this.dgvCourses.Columns[2].Width = 130;
            this.dgvCourses.Columns[3].Width = 100;
            this.dgvCourses.Columns[4].Width = 100;
            this.dgvCourses.Columns[5].Width = 100;
            this.dgvCourses.Columns[6].Width = 170;

            this.dgvCourses.CellPainting += dgvCourses_CellPainting;
            this.dgvCourses.CellClick += dgvCourses_CellClick;

            // CourseControl
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.flowLayoutCourses);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
        }

        // ============================================
        // ✅ LOAD DATA - GỌI SERVICE
        // ============================================
        private void LoadCategories()
        {
            try
            {
                // ✅ Gọi Service
                DataTable dt = courseService.GetAllCategories();

                cboCategory.Items.Clear();
                cboCategory.Items.Add(new CategoryItem { CategoryID = "", CategoryName = "-- Tất cả danh mục --" });

                foreach (DataRow row in dt.Rows)
                {
                    cboCategory.Items.Add(new CategoryItem
                    {
                        CategoryID = row["CategoryID"].ToString(),
                        CategoryName = row["CategoryName"].ToString()
                    });
                }

                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryID";
                cboCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourses()
        {
            try
            {
                string searchKeyword = txtSearch.Text;
                if (searchKeyword == "🔍 Tìm kiếm khóa học...")
                    searchKeyword = "";

                string selectedCategoryID = cboCategory.SelectedItem != null
                    ? ((CategoryItem)cboCategory.SelectedItem).CategoryID
                    : "";

                // ✅ Gọi Service
                DataTable dt = courseService.GetTeacherCourses(currentTeacherID, selectedCategoryID, searchKeyword);

                if (isCardView)
                {
                    LoadCardView(dt);
                }
                else
                {
                    LoadTableView(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khóa học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCardView(DataTable dt)
        {
            flowLayoutCourses.Controls.Clear();

            Color[] cardColors = new Color[]
            {
                Color.FromArgb(103, 58, 183),  // Purple
                Color.FromArgb(0, 150, 136),   // Teal
                Color.FromArgb(233, 30, 99),   // Pink
                Color.FromArgb(255, 152, 0),   // Orange
                Color.FromArgb(63, 81, 181),   // Indigo
                Color.FromArgb(76, 175, 80)    // Green
            };

            string[] icons = new string[] { "💻", "🎨", "📱", "⚡", "📊", "🤖", "🎯", "🚀" };
            int colorIndex = 0;

            foreach (DataRow row in dt.Rows)
            {
                Panel cardPanel = CreateCourseCard(
                    row["CourseID"].ToString(),
                    row["CourseName"].ToString(),
                    row["CategoryName"].ToString(),
                    Convert.ToInt32(row["StudentCount"]),
                    Convert.ToInt32(row["LessonCount"]),
                    row["Status"].ToString(),
                    cardColors[colorIndex % cardColors.Length],
                    icons[colorIndex % icons.Length]
                );

                flowLayoutCourses.Controls.Add(cardPanel);
                colorIndex++;
            }
        }

        private Panel CreateCourseCard(string courseID, string courseName, string category,
            int studentCount, int lessonCount, string status, Color cardColor, string icon)
        {
            Panel card = new Panel();
            card.Size = new Size(280, 340);
            card.BackColor = Color.White;
            card.Margin = new Padding(10);

            // Top colored section
            Panel topPanel = new Panel();
            topPanel.Size = new Size(280, 140);
            topPanel.BackColor = cardColor;
            topPanel.Dock = DockStyle.Top;

            Label lblIcon = new Label();
            lblIcon.Text = icon;
            lblIcon.Font = new Font("Segoe UI", 48F);
            lblIcon.ForeColor = Color.White;
            lblIcon.Size = new Size(100, 100);
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblIcon.Location = new Point(90, 20);
            topPanel.Controls.Add(lblIcon);

            // Bottom info section
            Label lblCategory = new Label();
            lblCategory.Text = "📂 " + category;
            lblCategory.Font = new Font("Segoe UI", 8F);
            lblCategory.ForeColor = Color.FromArgb(117, 117, 117);
            lblCategory.Location = new Point(15, 150);
            lblCategory.AutoSize = true;

            Label lblCourseName = new Label();
            lblCourseName.Text = courseName;
            lblCourseName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCourseName.ForeColor = Color.FromArgb(45, 45, 48);
            lblCourseName.Location = new Point(15, 175);
            lblCourseName.Size = new Size(250, 50);

            Label lblStudents = new Label();
            lblStudents.Text = $"👥 {studentCount} học viên";
            lblStudents.Font = new Font("Segoe UI", 9F);
            lblStudents.ForeColor = Color.FromArgb(117, 117, 117);
            lblStudents.Location = new Point(15, 235);
            lblStudents.AutoSize = true;

            Label lblLessons = new Label();
            lblLessons.Text = $"📖 {lessonCount} bài";
            lblLessons.Font = new Font("Segoe UI", 9F);
            lblLessons.ForeColor = Color.FromArgb(117, 117, 117);
            lblLessons.Location = new Point(155, 235);
            lblLessons.AutoSize = true;

            // Buttons
            Button btnDetail = new Button();
            btnDetail.Text = "📊 Chi tiết";
            btnDetail.BackColor = Color.FromArgb(33, 150, 243);
            btnDetail.ForeColor = Color.White;
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.FlatAppearance.BorderSize = 0;
            btnDetail.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDetail.Size = new Size(80, 28);
            btnDetail.Location = new Point(15, 270);
            btnDetail.Cursor = Cursors.Hand;
            btnDetail.Tag = courseID;
            btnDetail.Click += (s, e) => ShowStudentList(courseID, courseName);

            Button btnEdit = new Button();
            btnEdit.Text = "✏ Sửa";
            btnEdit.BackColor = Color.FromArgb(255, 193, 7);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnEdit.Size = new Size(65, 28);
            btnEdit.Location = new Point(105, 270);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Tag = courseID;
            btnEdit.Click += (s, e) => EditCourse(Convert.ToInt32(courseID));

            Button btnDelete = new Button();
            btnDelete.Text = "🗑";
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Size = new Size(45, 28);
            btnDelete.Location = new Point(180, 270);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Tag = courseID;
            btnDelete.Click += (s, e) => DeleteCourse(courseID, courseName);

            // Status badge
            Label lblStatus = new Label();
            lblStatus.Text = MapStatusToVietnamese(status);
            lblStatus.BackColor = GetStatusBadgeColor(status);
            lblStatus.ForeColor = Color.White;
            lblStatus.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            lblStatus.Size = new Size(80, 20);  // ✅ Tăng độ rộng để hiển thị đủ text
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Location = new Point(195, 305);  // ✅ Dịch sang trái một chút

            card.Controls.Add(topPanel);
            card.Controls.Add(lblCategory);
            card.Controls.Add(lblCourseName);
            card.Controls.Add(lblStudents);
            card.Controls.Add(lblLessons);
            card.Controls.Add(btnDetail);
            card.Controls.Add(btnEdit);
            card.Controls.Add(btnDelete);
            card.Controls.Add(lblStatus);

            return card;
        }

        private void LoadTableView(DataTable dt)
        {
            dgvCourses.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dgvCourses.Rows.Add(
                    row["CourseID"],
                    row["CourseName"],
                    row["CategoryName"],
                    row["StudentCount"],
                    row["LessonCount"],
                    row["Status"],
                    ""
                );
            }
        }

        private void LoadSummary()
        {
            try
            {
                // ✅ Gọi Service
                DataTable dt = courseService.GetTeacherSummary(currentTeacherID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblTotalCourses.Text = $"📚 Tổng khóa học: {row["TotalCourses"]}";
                    lblTotalStudents.Text = $"👥 Tổng học viên: {row["TotalStudents"]}";
                    lblTotalLessons.Text = $"📖 Tổng bài học: {row["TotalLessons"]}";
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
        private void btnToggleView_Click(object sender, EventArgs e)
        {
            isCardView = !isCardView;
            if (isCardView)
            {
                flowLayoutCourses.Visible = true;
                tablePanel.Visible = false;
                btnToggleView.Text = "📋 Bảng";
            }
            else
            {
                flowLayoutCourses.Visible = false;
                tablePanel.Visible = true;
                btnToggleView.Text = "🎴 Thẻ";
            }
            LoadCourses();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "🔍 Tìm kiếm khóa học...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "🔍 Tìm kiếm khóa học...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.ForeColor != Color.Gray)
            {
                LoadCourses();
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            using (var form = new Forms.CourseForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCourses();
                    LoadSummary();
                }
            }
        }

        private void ShowStudentList(string courseID, string courseName)
        {
            using (var form = new Forms.StudentListForm(courseID, courseName))
            {
                form.ShowDialog();
            }
        }

        private void EditCourse(int courseID)
        {
            using (var form = new Forms.CourseForm(courseID))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCourses();
                    LoadSummary();
                }
            }
        }

        private void DeleteCourse(string courseID, string courseName)
        {
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa khóa học:\n\n{courseName}\n\nLưu ý: Tất cả dữ liệu liên quan sẽ bị xóa!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // ✅ Gọi Service
                    bool success = courseService.DeleteCourse(courseID, currentTeacherID);

                    if (success)
                    {
                        MessageBox.Show("Xóa khóa học thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCourses();
                        LoadSummary();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khóa học!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa khóa học: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvCourses.Columns["colAction"].Index)
            {
                string courseID = dgvCourses.Rows[e.RowIndex].Cells["colCourseID"].Value.ToString();
                string courseName = dgvCourses.Rows[e.RowIndex].Cells["colCourseName"].Value.ToString();

                Rectangle cellBounds = dgvCourses.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point clickPoint = dgvCourses.PointToClient(Cursor.Position);
                int relativeX = clickPoint.X - cellBounds.X;

                if (relativeX >= 5 && relativeX <= 60)
                {
                    ShowStudentList(courseID, courseName);
                }
                else if (relativeX >= 65 && relativeX <= 115)
                {
                    EditCourse(Convert.ToInt32(courseID));
                }
                else if (relativeX >= 120 && relativeX <= 165)
                {
                    DeleteCourse(courseID, courseName);
                }
            }
        }

        private void dgvCourses_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvCourses.Columns["colStatus"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string status = dgvCourses.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString();
                if (!string.IsNullOrEmpty(status))
                {
                    Color badgeColor = GetStatusBadgeColor(status);

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
                        e.Graphics.DrawString(MapStatusToVietnamese(status), font, textBrush, badgeRect, sf);
                    }
                }
            }

            if (e.ColumnIndex == dgvCourses.Columns["colAction"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                // Button Chi tiết
                Rectangle detailRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + (e.CellBounds.Height - 28) / 2, 55, 28);
                using (GraphicsPath path = GetRoundedRectPath(detailRect, 4))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(33, 150, 243)))
                    e.Graphics.FillPath(brush, path);
                using (Font font = new Font("Segoe UI", 7F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                    e.Graphics.DrawString("📊 Chi tiết", font, textBrush, detailRect,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                // Button Sửa
                Rectangle editRect = new Rectangle(e.CellBounds.X + 65, e.CellBounds.Y + (e.CellBounds.Height - 28) / 2, 50, 28);
                using (GraphicsPath path = GetRoundedRectPath(editRect, 4))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 193, 7)))
                    e.Graphics.FillPath(brush, path);
                using (Font font = new Font("Segoe UI", 7F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                    e.Graphics.DrawString("✏ Sửa", font, textBrush, editRect,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                // Button Xóa
                Rectangle deleteRect = new Rectangle(e.CellBounds.X + 120, e.CellBounds.Y + (e.CellBounds.Height - 28) / 2, 45, 28);
                using (GraphicsPath path = GetRoundedRectPath(deleteRect, 4))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(244, 67, 54)))
                    e.Graphics.FillPath(brush, path);
                using (Font font = new Font("Segoe UI", 10F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                    e.Graphics.DrawString("🗑", font, textBrush, deleteRect,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
        }

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
        // STATUS MAPPING HELPER
        // ============================================

        /// <summary>
        /// Mapping Status từ tiếng Anh sang tiếng Việt
        /// </summary>
        private string MapStatusToVietnamese(string statusInDB)
        {
            if (string.IsNullOrEmpty(statusInDB))
                return "Chờ duyệt";

            switch (statusInDB.Trim().ToLower())
            {
                case "pending":
                    return "Chờ duyệt";

                case "approved":
                case "active":
                    return "Hoạt động";  // ✅ Cả Approved và Active đều hiển thị "Hoạt động"

                case "inactive":
                    return "Tạm dừng";

                case "draft":
                    return "Nháp";

                case "suspended":
                    return "Đã đình chỉ";

                default:
                    return statusInDB;
            }
        }

        /// <summary>
        /// Lấy màu sắc cho badge Status
        /// </summary>
        private Color GetStatusBadgeColor(string statusInDB)
        {
            if (string.IsNullOrEmpty(statusInDB))
                return Color.FromArgb(255, 152, 0); // Orange

            switch (statusInDB.Trim().ToLower())
            {
                case "pending":
                    return Color.FromArgb(255, 152, 0);   // Orange

                case "approved":
                case "active":
                    return Color.FromArgb(76, 175, 80);   // Green

                case "inactive":
                case "suspended":
                    return Color.FromArgb(158, 158, 158); // Gray

                case "draft":
                    return Color.FromArgb(33, 150, 243);  // Blue

                default:
                    return Color.FromArgb(158, 158, 158); // Gray
            }
        }

        // ============================================
        // HELPER CLASS
        // ============================================
        private class CategoryItem
        {
            public string CategoryID { get; set; }
            public string CategoryName { get; set; }
        }
    }
}
