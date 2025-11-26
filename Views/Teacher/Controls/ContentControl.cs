using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using StudyProcessManagement.Business.Teacher; // ✅ Import Service

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public class ContentControl : UserControl
    {
        // =============================================
        // FIELDS
        // =============================================
        private Panel headerPanel;
        private Label lblTitle;
        private Label lblBreadcrumb;
        private ComboBox cboCourse;
        private Button btnAddSection;
        private Panel mainContentPanel;
        private Panel treeContainerPanel;
        private TreeView tvContent;
        private Panel detailPanel;
        private Label lblDetailTitle;
        private Label lblLessonName;
        private TextBox txtLessonName;
        private Label lblLessonDesc;
        private RichTextBox txtLessonDescription;
        private Label lblVideoUrl;
        private TextBox txtVideoUrl;
        private Label lblMaterials;
        private TextBox txtMaterials;
        private Panel buttonPanel;
        private Button btnSave;
        private Button btnAddLesson;
        private Button btnDelete;

        // ✅ Thay vì connectionString, dùng Service
        private CourseContentService courseContentService;
        private string currentTeacherID = "USR002"; // TODO: Lấy từ session/login
        private string selectedCourseID = "";
        private string selectedSectionID = "";
        private string selectedLessonID = "";
        private bool isEditingLesson = false;

        // =============================================
        // CONSTRUCTOR
        // =============================================
        public ContentControl()
        {
            InitializeComponent();

            // ✅ Khởi tạo Service
            courseContentService = new CourseContentService();

            // ✅ GÁN CÁC EVENT HANDLERS
            if (!DesignMode)
            {
                this.Load += ContentControl_Load;
                this.Resize += ContentControl_Resize;
                cboCourse.SelectedIndexChanged += CboCourse_SelectedIndexChanged;
                btnAddSection.Click += BtnAddSection_Click;
                btnAddSection.MouseEnter += BtnAddSection_MouseEnter;
                btnAddSection.MouseLeave += BtnAddSection_MouseLeave;
                tvContent.AfterSelect += TvContent_AfterSelect;
                btnSave.Click += BtnSave_Click;
                btnSave.MouseEnter += BtnSave_MouseEnter;
                btnSave.MouseLeave += BtnSave_MouseLeave;
                btnAddLesson.Click += BtnAddLesson_Click;
                btnAddLesson.MouseEnter += BtnAddLesson_MouseEnter;
                btnAddLesson.MouseLeave += BtnAddLesson_MouseLeave;
                btnDelete.Click += BtnDelete_Click;
                btnDelete.MouseEnter += BtnDelete_MouseEnter;
                btnDelete.MouseLeave += BtnDelete_MouseLeave;
                txtMaterials.Click += TxtMaterials_Click;
                treeContainerPanel.Paint += TreeContainerPanel_Paint;
                detailPanel.Paint += DetailPanel_Paint;
            }
        }

        // =============================================
        // INITIALIZE COMPONENT (AUTO-GENERATED UI CODE)
        // =============================================
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBreadcrumb = new System.Windows.Forms.Label();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblLessonName = new System.Windows.Forms.Label();
            this.txtLessonName = new System.Windows.Forms.TextBox();
            this.lblLessonDesc = new System.Windows.Forms.Label();
            this.txtLessonDescription = new System.Windows.Forms.RichTextBox();
            this.lblVideoUrl = new System.Windows.Forms.Label();
            this.txtVideoUrl = new System.Windows.Forms.TextBox();
            this.lblMaterials = new System.Windows.Forms.Label();
            this.txtMaterials = new System.Windows.Forms.TextBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddLesson = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.treeContainerPanel = new System.Windows.Forms.Panel();
            this.tvContent = new System.Windows.Forms.TreeView();
            this.headerPanel.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.detailPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.treeContainerPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblBreadcrumb);
            this.headerPanel.Controls.Add(this.cboCourse);
            this.headerPanel.Controls.Add(this.btnAddSection);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(30, 20);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1005, 130);
            this.headerPanel.TabIndex = 1;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Nội dung";

            // 
            // lblBreadcrumb
            // 
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblBreadcrumb.Location = new System.Drawing.Point(0, 40);
            this.lblBreadcrumb.Name = "lblBreadcrumb";
            this.lblBreadcrumb.Size = new System.Drawing.Size(215, 15);
            this.lblBreadcrumb.TabIndex = 1;
            this.lblBreadcrumb.Text = "Trang chủ / Nội dung / Quản lý bài học";

            // 
            // cboCourse
            // 
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCourse.Location = new System.Drawing.Point(0, 75);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(280, 25);
            this.cboCourse.TabIndex = 2;

            // 
            // btnAddSection
            // 
            this.btnAddSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAddSection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSection.FlatAppearance.BorderSize = 0;
            this.btnAddSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddSection.ForeColor = System.Drawing.Color.White;
            this.btnAddSection.Location = new System.Drawing.Point(300, 75);
            this.btnAddSection.Name = "btnAddSection";
            this.btnAddSection.Size = new System.Drawing.Size(160, 40);
            this.btnAddSection.TabIndex = 3;
            this.btnAddSection.Text = "➕ Thêm chương";
            this.btnAddSection.UseVisualStyleBackColor = false;

            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainContentPanel.Controls.Add(this.detailPanel);
            this.mainContentPanel.Controls.Add(this.treeContainerPanel);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(30, 150);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(1005, 556);
            this.mainContentPanel.TabIndex = 0;

            // 
            // detailPanel
            // 
            this.detailPanel.BackColor = System.Drawing.Color.White;
            this.detailPanel.Controls.Add(this.lblDetailTitle);
            this.detailPanel.Controls.Add(this.lblLessonName);
            this.detailPanel.Controls.Add(this.txtLessonName);
            this.detailPanel.Controls.Add(this.lblLessonDesc);
            this.detailPanel.Controls.Add(this.txtLessonDescription);
            this.detailPanel.Controls.Add(this.lblVideoUrl);
            this.detailPanel.Controls.Add(this.txtVideoUrl);
            this.detailPanel.Controls.Add(this.lblMaterials);
            this.detailPanel.Controls.Add(this.txtMaterials);
            this.detailPanel.Controls.Add(this.buttonPanel);
            this.detailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailPanel.Location = new System.Drawing.Point(510, 0);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Padding = new System.Windows.Forms.Padding(15);
            this.detailPanel.Size = new System.Drawing.Size(495, 556);
            this.detailPanel.TabIndex = 1;

            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(25, 25);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(207, 32);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "Chi tiết bài học";

            // 
            // lblLessonName
            // 
            this.lblLessonName.AutoSize = true;
            this.lblLessonName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLessonName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblLessonName.Location = new System.Drawing.Point(25, 80);
            this.lblLessonName.Name = "lblLessonName";
            this.lblLessonName.Size = new System.Drawing.Size(83, 19);
            this.lblLessonName.TabIndex = 1;
            this.lblLessonName.Text = "Tên bài học";

            // 
            // txtLessonName
            // 
            this.txtLessonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLessonName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLessonName.Location = new System.Drawing.Point(25, 105);
            this.txtLessonName.Name = "txtLessonName";
            this.txtLessonName.Size = new System.Drawing.Size(445, 25);
            this.txtLessonName.TabIndex = 2;

            // 
            // lblLessonDesc
            // 
            this.lblLessonDesc.AutoSize = true;
            this.lblLessonDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLessonDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblLessonDesc.Location = new System.Drawing.Point(25, 145);
            this.lblLessonDesc.Name = "lblLessonDesc";
            this.lblLessonDesc.Size = new System.Drawing.Size(47, 19);
            this.lblLessonDesc.TabIndex = 3;
            this.lblLessonDesc.Text = "Mô tả";

            // 
            // txtLessonDescription
            // 
            this.txtLessonDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLessonDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLessonDescription.Location = new System.Drawing.Point(25, 170);
            this.txtLessonDescription.Name = "txtLessonDescription";
            this.txtLessonDescription.Size = new System.Drawing.Size(445, 100);
            this.txtLessonDescription.TabIndex = 4;
            this.txtLessonDescription.Text = "";

            // 
            // lblVideoUrl
            // 
            this.lblVideoUrl.AutoSize = true;
            this.lblVideoUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVideoUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblVideoUrl.Location = new System.Drawing.Point(25, 285);
            this.lblVideoUrl.Name = "lblVideoUrl";
            this.lblVideoUrl.Size = new System.Drawing.Size(101, 19);
            this.lblVideoUrl.TabIndex = 5;
            this.lblVideoUrl.Text = "Link video bài";

            // 
            // txtVideoUrl
            // 
            this.txtVideoUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoUrl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVideoUrl.Location = new System.Drawing.Point(25, 310);
            this.txtVideoUrl.Name = "txtVideoUrl";
            this.txtVideoUrl.Size = new System.Drawing.Size(445, 25);
            this.txtVideoUrl.TabIndex = 6;

            // 
            // lblMaterials
            // 
            this.lblMaterials.AutoSize = true;
            this.lblMaterials.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaterials.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblMaterials.Location = new System.Drawing.Point(25, 350);
            this.lblMaterials.Name = "lblMaterials";
            this.lblMaterials.Size = new System.Drawing.Size(96, 19);
            this.lblMaterials.TabIndex = 7;
            this.lblMaterials.Text = "Tài liệu đính";

            // 
            // txtMaterials
            // 
            this.txtMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaterials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMaterials.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaterials.Location = new System.Drawing.Point(25, 375);
            this.txtMaterials.Name = "txtMaterials";
            this.txtMaterials.ReadOnly = true;
            this.txtMaterials.Size = new System.Drawing.Size(445, 25);
            this.txtMaterials.TabIndex = 8;
            this.txtMaterials.Text = "Chọn file...";

            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanel.Controls.Add(this.btnSave);
            this.buttonPanel.Controls.Add(this.btnAddLesson);
            this.buttonPanel.Controls.Add(this.btnDelete);
            this.buttonPanel.Location = new System.Drawing.Point(25, 420);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(445, 50);
            this.buttonPanel.TabIndex = 9;

            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.UseVisualStyleBackColor = false;

            // 
            // btnAddLesson
            // 
            this.btnAddLesson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnAddLesson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLesson.FlatAppearance.BorderSize = 0;
            this.btnAddLesson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLesson.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddLesson.ForeColor = System.Drawing.Color.White;
            this.btnAddLesson.Location = new System.Drawing.Point(110, 0);
            this.btnAddLesson.Name = "btnAddLesson";
            this.btnAddLesson.Size = new System.Drawing.Size(140, 40);
            this.btnAddLesson.TabIndex = 1;
            this.btnAddLesson.Text = "➕ Thêm bài";
            this.btnAddLesson.UseVisualStyleBackColor = false;

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(260, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;

            // 
            // treeContainerPanel
            // 
            this.treeContainerPanel.BackColor = System.Drawing.Color.White;
            this.treeContainerPanel.Controls.Add(this.tvContent);
            this.treeContainerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.treeContainerPanel.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.treeContainerPanel.Name = "treeContainerPanel";
            this.treeContainerPanel.Padding = new System.Windows.Forms.Padding(15, 15, 8, 15);
            this.treeContainerPanel.Size = new System.Drawing.Size(495, 556);
            this.treeContainerPanel.TabIndex = 0;

            // 
            // tvContent
            // 
            this.tvContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tvContent.Location = new System.Drawing.Point(15, 15);
            this.tvContent.Name = "tvContent";
            this.tvContent.Size = new System.Drawing.Size(472, 526);
            this.tvContent.TabIndex = 0;

            // 
            // ContentControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "ContentControl";
            this.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.Size = new System.Drawing.Size(1065, 726);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.detailPanel.ResumeLayout(false);
            this.detailPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.treeContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // =============================================
        // ✅ LOAD DATA - GỌI SERVICE
        // =============================================
        private void ContentControl_Load(object sender, EventArgs e)
        {
            LoadTeacherCourses();
        }

        private void LoadTeacherCourses()
        {
            try
            {
                // ✅ Gọi Service
                DataTable dt = courseContentService.GetTeacherCourses(currentTeacherID);

                cboCourse.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cboCourse.Items.Add(new ComboBoxItem
                    {
                        Text = row["CourseName"].ToString(),
                        Value = row["CourseID"].ToString()
                    });
                }

                if (cboCourse.Items.Count > 0)
                {
                    cboCourse.DisplayMember = "Text";
                    cboCourse.ValueMember = "Value";
                    cboCourse.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khóa học: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCourse.SelectedItem != null)
            {
                ComboBoxItem selected = (ComboBoxItem)cboCourse.SelectedItem;
                selectedCourseID = selected.Value;
                LoadCourseStructure(selectedCourseID);
                ClearLessonForm();
            }
        }

        private void LoadCourseStructure(string courseID)
        {
            try
            {
                tvContent.Nodes.Clear();

                // ✅ Load Sections từ Service
                DataTable dtSections = courseContentService.GetCourseSections(courseID);

                foreach (DataRow sectionRow in dtSections.Rows)
                {
                    TreeNode sectionNode = new TreeNode(sectionRow["SectionTitle"].ToString());
                    sectionNode.Tag = new { Type = "Section", ID = sectionRow["SectionID"].ToString() };
                    tvContent.Nodes.Add(sectionNode);

                    // ✅ Load Lessons cho Section này
                    string sectionID = sectionRow["SectionID"].ToString();
                    DataTable dtLessons = courseContentService.GetSectionLessons(sectionID);

                    foreach (DataRow lessonRow in dtLessons.Rows)
                    {
                        TreeNode lessonNode = new TreeNode(lessonRow["LessonTitle"].ToString());
                        lessonNode.Tag = new { Type = "Lesson", ID = lessonRow["LessonID"].ToString() };
                        sectionNode.Nodes.Add(lessonNode);
                    }
                }

                tvContent.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải cấu trúc khóa học: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // EVENT HANDLERS
        // =============================================
        private void TvContent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;

            dynamic nodeData = e.Node.Tag;
            string type = nodeData.Type;
            string id = nodeData.ID;

            if (type == "Section")
            {
                selectedSectionID = id;
                selectedLessonID = "";
                ClearLessonForm();
            }
            else if (type == "Lesson")
            {
                LoadLessonDetails(id);
            }
        }

        private void LoadLessonDetails(string lessonID)
        {
            try
            {
                // ✅ Gọi Service
                DataTable dt = courseContentService.GetLessonDetails(lessonID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtLessonName.Text = row["LessonTitle"].ToString();
                    txtLessonDescription.Text = row["Content"].ToString();
                    txtVideoUrl.Text = row["VideoUrl"].ToString();
                    txtMaterials.Text = row["AttachmentUrl"].ToString();
                    selectedLessonID = lessonID;
                    selectedSectionID = row["SectionID"].ToString();
                    isEditingLesson = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết bài học: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddSection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCourseID))
            {
                MessageBox.Show("Vui lòng chọn khóa học trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sectionTitle = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên chương mới:", "Thêm chương", "", -1, -1);

            if (string.IsNullOrWhiteSpace(sectionTitle)) return;

            try
            {
                // ✅ Gọi Service
                courseContentService.AddSection(selectedCourseID, sectionTitle);
                MessageBox.Show("Thêm chương thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCourseStructure(selectedCourseID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chương: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddLesson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSectionID))
            {
                MessageBox.Show("Vui lòng chọn chương trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClearLessonForm();
            isEditingLesson = false;
            txtLessonName.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLessonName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bài học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedSectionID))
            {
                MessageBox.Show("Vui lòng chọn chương!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (isEditingLesson && !string.IsNullOrEmpty(selectedLessonID))
                {
                    // ✅ Update existing lesson
                    courseContentService.UpdateLesson(
                        selectedLessonID,
                        txtLessonName.Text,
                        txtLessonDescription.Text,
                        txtVideoUrl.Text,
                        txtMaterials.Text
                    );
                    MessageBox.Show("Cập nhật bài học thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ✅ Insert new lesson
                    courseContentService.AddLesson(
                        selectedCourseID,
                        selectedSectionID,
                        txtLessonName.Text,
                        txtLessonDescription.Text,
                        txtVideoUrl.Text,
                        txtMaterials.Text
                    );
                    MessageBox.Show("Thêm bài học thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadCourseStructure(selectedCourseID);
                ClearLessonForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu bài học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (tvContent.SelectedNode == null || tvContent.SelectedNode.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn mục cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic nodeData = tvContent.SelectedNode.Tag;
            string type = nodeData.Type;
            string id = nodeData.ID;

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa {(type == "Section" ? "chương" : "bài học")} này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            try
            {
                if (type == "Section")
                {
                    // ✅ Gọi Service xóa Section
                    courseContentService.DeleteSection(id);
                }
                else if (type == "Lesson")
                {
                    // ✅ Gọi Service xóa Lesson
                    courseContentService.DeleteLesson(id);
                }

                MessageBox.Show("Xóa thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCourseStructure(selectedCourseID);
                ClearLessonForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtMaterials_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*|PDF Files|*.pdf|Word Files|*.docx;*.doc";
            openFileDialog.Title = "Chọn file tài liệu";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtMaterials.Text = openFileDialog.FileName;
            }
        }

        private void ClearLessonForm()
        {
            txtLessonName.Text = "";
            txtLessonDescription.Text = "";
            txtVideoUrl.Text = "";
            txtMaterials.Text = "Chọn file...";
            isEditingLesson = false;
            selectedLessonID = "";
        }

        // =============================================
        // RESIZE EVENT - Maintain 50-50 split
        // =============================================
        private void ContentControl_Resize(object sender, EventArgs e)
        {
            if (mainContentPanel != null && mainContentPanel.Width > 30)
            {
                int spacing = 15;
                int availableWidth = mainContentPanel.Width - spacing;
                int halfWidth = availableWidth / 2;
                treeContainerPanel.Width = halfWidth;
            }
        }

        // =============================================
        // UI PAINT EVENTS
        // =============================================
        private void TreeContainerPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int radius = 8;
                var rect = new Rectangle(0, 0, this.treeContainerPanel.Width - 1, this.treeContainerPanel.Height - 1);
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
        }

        private void DetailPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int radius = 8;
                var rect = new Rectangle(0, 0, this.detailPanel.Width - 1, this.detailPanel.Height - 1);
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
        }

        // =============================================
        // HOVER EFFECTS
        // =============================================
        private void BtnAddSection_MouseEnter(object sender, EventArgs e)
        {
            this.btnAddSection.BackColor = Color.FromArgb(56, 142, 60);
        }

        private void BtnAddSection_MouseLeave(object sender, EventArgs e)
        {
            this.btnAddSection.BackColor = Color.FromArgb(76, 175, 80);
        }

        private void BtnSave_MouseEnter(object sender, EventArgs e)
        {
            this.btnSave.BackColor = Color.FromArgb(56, 142, 60);
        }

        private void BtnSave_MouseLeave(object sender, EventArgs e)
        {
            this.btnSave.BackColor = Color.FromArgb(76, 175, 80);
        }

        private void BtnAddLesson_MouseEnter(object sender, EventArgs e)
        {
            this.btnAddLesson.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void BtnAddLesson_MouseLeave(object sender, EventArgs e)
        {
            this.btnAddLesson.BackColor = Color.FromArgb(33, 150, 243);
        }

        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            this.btnDelete.BackColor = Color.FromArgb(229, 57, 53);
        }

        private void BtnDelete_MouseLeave(object sender, EventArgs e)
        {
            this.btnDelete.BackColor = Color.FromArgb(244, 67, 54);
        }

        // =============================================
        // HELPER CLASS
        // =============================================
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
    }
}
