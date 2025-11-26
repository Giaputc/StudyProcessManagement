using StudyProcessManagement.Business.Teacher;
using StudyProcessManagement.Views.Teacher.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Teacher.Controls
{
    public class AssessmentControl : UserControl
    {
        // =============================================
        // FIELDS
        // =============================================
        private TableLayoutPanel mainLayout;
        private Panel headerPanel;
        private Label lblTitle;
        private ComboBox cboCourse;
        private Button btnCreate;
        private Panel contentPanel;
        private DataGridView dgvAssignments;
        private int hoverRow = -1;
        private string hoverButton = "";

        private FlowLayoutPanel rightPanel;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn colDueDate;
        private DataGridViewTextBoxColumn colSubmitted;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colAction;
        private DataGridViewTextBoxColumn colID;

        // ✅ Thay vì connectionString, dùng Service
        private AssignmentService assignmentService;
        private string currentTeacherID = "USR002"; // TODO: Lấy từ session/login

        // =============================================
        // CONSTRUCTOR
        // =============================================
        public AssessmentControl()
        {
            InitializeComponent();

            // ✅ Khởi tạo Service
            assignmentService = new AssignmentService();

            // ✅ GÁN CÁC EVENT HANDLERS
            if (!DesignMode)
            {
                this.Load += AssessmentControl_Load;

                // ComboBox events
                cboCourse.SelectedIndexChanged += CboCourse_SelectedIndexChanged;

                // Button events
                btnCreate.Click += BtnCreate_Click;
                btnCreate.MouseEnter += BtnCreate_MouseEnter;
                btnCreate.MouseLeave += BtnCreate_MouseLeave;

                // DataGridView events
                dgvAssignments.CellPainting += DgvAssignments_CellPainting;
                dgvAssignments.CellMouseEnter += DgvAssignments_CellMouseEnter;
                dgvAssignments.CellMouseLeave += DgvAssignments_CellMouseLeave;
                dgvAssignments.CellClick += DgvAssignments_CellClick;
            }
        }

        // =============================================
        // INITIALIZE COMPONENT (AUTO-GENERATED UI CODE)
        // =============================================
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubmitted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.SuspendLayout();

            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.contentPanel, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(8);
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1065, 726);
            this.mainLayout.TabIndex = 0;

            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.rightPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(11, 11);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(8);
            this.headerPanel.Size = new System.Drawing.Size(1043, 64);
            this.headerPanel.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(8, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý Bài tập";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // rightPanel
            // 
            this.rightPanel.AutoSize = true;
            this.rightPanel.Controls.Add(this.cboCourse);
            this.rightPanel.Controls.Add(this.btnCreate);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(675, 8);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.rightPanel.Size = new System.Drawing.Size(360, 48);
            this.rightPanel.TabIndex = 1;
            this.rightPanel.WrapContents = false;

            // 
            // cboCourse
            // 
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCourse.Location = new System.Drawing.Point(5, 13);
            this.cboCourse.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(200, 25);
            this.cboCourse.TabIndex = 0;

            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(215, 10);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(140, 38);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "➕ Tạo mới";
            this.btnCreate.UseVisualStyleBackColor = false;

            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.dgvAssignments);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(12, 82);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(1);
            this.contentPanel.Size = new System.Drawing.Size(1041, 632);
            this.contentPanel.TabIndex = 1;

            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            this.dgvAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAssignments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAssignments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAssignments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAssignments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAssignments.ColumnHeadersHeight = 45;
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAssignments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.colDueDate,
            this.colSubmitted,
            this.colStatus,
            this.colAction});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssignments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssignments.EnableHeadersVisualStyles = false;
            this.dgvAssignments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvAssignments.Location = new System.Drawing.Point(1, 1);
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.ReadOnly = true;
            this.dgvAssignments.RowHeadersVisible = false;
            this.dgvAssignments.RowTemplate.Height = 50;
            this.dgvAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignments.Size = new System.Drawing.Size(1039, 630);
            this.dgvAssignments.TabIndex = 0;
            this.dgvAssignments.AutoGenerateColumns = false;

            // 
            // colID
            // 
            this.colID.DataPropertyName = "AssignmentID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;

            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn1.FillWeight = 120F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên bài tập";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;

            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CourseName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Khóa học";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;

            // 
            // colDueDate
            // 
            this.colDueDate.DataPropertyName = "DueDate";
            this.colDueDate.FillWeight = 80F;
            this.colDueDate.HeaderText = "Hạn nộp";
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.ReadOnly = true;

            // 
            // colSubmitted
            // 
            this.colSubmitted.DataPropertyName = "TotalSubmissions";
            this.colSubmitted.FillWeight = 60F;
            this.colSubmitted.HeaderText = "Đã nộp";
            this.colSubmitted.Name = "colSubmitted";
            this.colSubmitted.ReadOnly = true;

            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.FillWeight = 70F;
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;

            // 
            // colAction
            // 
            this.colAction.FillWeight = 80F;
            this.colAction.HeaderText = "Thao tác";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;

            // 
            // AssessmentControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.mainLayout);
            this.Name = "AssessmentControl";
            this.Size = new System.Drawing.Size(1065, 726);
            this.mainLayout.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.ResumeLayout(false);
        }

        // =============================================
        // ✅ LOAD DATA - GỌI SERVICE
        // =============================================
        private void AssessmentControl_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                // ✅ Gọi Service thay vì viết SQL trực tiếp
                DataTable dt = assignmentService.GetTeacherCourses(currentTeacherID);

                cboCourse.Items.Clear();
                cboCourse.Items.Add(new ComboBoxItem { Text = "-- Tất cả khóa học --", Value = "" });

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
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            try
            {
                string selectedCourseID = "";
                if (cboCourse.SelectedItem != null)
                {
                    ComboBoxItem selected = (ComboBoxItem)cboCourse.SelectedItem;
                    selectedCourseID = selected.Value;
                }

                // ✅ Gọi Service
                DataTable dt = assignmentService.GetAssignments(currentTeacherID, selectedCourseID);
                dgvAssignments.DataSource = dt;

                // Format DueDate column
                if (dgvAssignments.Columns["DueDate"] != null)
                {
                    dgvAssignments.Columns["DueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bài tập: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =============================================
        // EVENT HANDLERS
        // =============================================
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // Mở form tạo bài tập mới
            using (var form = new AssignmentForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAssignments(); // Reload danh sách
                }
            }
        }

        private void DgvAssignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAssignments.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                string assignmentIDStr = dgvAssignments.Rows[e.RowIndex].Cells["colID"].Value?.ToString();
                string assignmentTitle = dgvAssignments.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value?.ToString();

                if (string.IsNullOrEmpty(assignmentIDStr))
                {
                    MessageBox.Show("Không tìm thấy ID bài tập!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Parse về INT vì AssignmentID là INT IDENTITY
                if (!int.TryParse(assignmentIDStr, out int assignmentID))
                {
                    MessageBox.Show("ID bài tập không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cellRect = dgvAssignments.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var mousePos = dgvAssignments.PointToClient(Cursor.Position);
                var relativeX = mousePos.X - cellRect.X;

                if (relativeX < cellRect.Width / 2)
                {
                    // Sửa - Edit button
                    using (var form = new AssignmentForm(assignmentID))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadAssignments(); // reload grid
                        }
                    }
                }
                else
                {
                    // Xóa - Delete button
                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa bài tập '{assignmentTitle}'?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteAssignment(assignmentID);
                    }
                }
            }
        }

        // Gọi Service để xóa Assignment
        private void DeleteAssignment(int assignmentID)
        {
            try
            {
                bool success = assignmentService.DeleteAssignment(assignmentID);
                if (success)
                {
                    MessageBox.Show("Xóa bài tập thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssignments();
                }
                else
                {
                    MessageBox.Show("Không thể xóa bài tập!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bài tập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // =============================================
        // DATAGRIDVIEW CUSTOM PAINTING
        // =============================================
        private void DgvAssignments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvAssignments.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                // Define button areas
                int buttonWidth = 70;
                int buttonHeight = 30;
                int spacing = 5;
                int totalWidth = (buttonWidth * 2) + spacing;
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
                int startY = e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2;

                var editRect = new Rectangle(startX, startY, buttonWidth, buttonHeight);
                var deleteRect = new Rectangle(startX + buttonWidth + spacing, startY, buttonWidth, buttonHeight);

                // Determine hover state
                bool isEditHover = (e.RowIndex == hoverRow && hoverButton == "edit");
                bool isDeleteHover = (e.RowIndex == hoverRow && hoverButton == "delete");

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw Edit button
                DrawRoundedButton(e.Graphics, editRect,
                    isEditHover ? Color.FromArgb(25, 118, 210) : Color.FromArgb(33, 150, 243),
                    "Sửa", Color.White);

                // Draw Delete button
                DrawRoundedButton(e.Graphics, deleteRect,
                    isDeleteHover ? Color.FromArgb(229, 57, 53) : Color.FromArgb(244, 67, 54),
                    "Xóa", Color.White);

                e.Handled = true;
            }
        }

        private void DrawRoundedButton(Graphics g, Rectangle rect, Color bgColor, string text, Color textColor)
        {
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int radius = 5;
                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseFigure();

                using (var brush = new SolidBrush(bgColor))
                {
                    g.FillPath(brush, path);
                }
            }

            using (var textBrush = new SolidBrush(textColor))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(text, new Font("Segoe UI", 9F), textBrush, rect, sf);
            }
        }

        private void DgvAssignments_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAssignments.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                dgvAssignments.Cursor = Cursors.Hand;
                hoverRow = e.RowIndex;

                // Determine which button is hovered
                var cellRect = dgvAssignments.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var mousePos = dgvAssignments.PointToClient(Cursor.Position);
                var relativeX = mousePos.X - cellRect.X;

                if (relativeX < cellRect.Width / 2)
                    hoverButton = "edit";
                else
                    hoverButton = "delete";

                dgvAssignments.InvalidateCell(e.ColumnIndex, e.RowIndex);
            }
        }

        private void DgvAssignments_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAssignments.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                dgvAssignments.Cursor = Cursors.Default;
                hoverRow = -1;
                hoverButton = "";
                dgvAssignments.InvalidateCell(e.ColumnIndex, e.RowIndex);
            }
        }

        // =============================================
        // HOVER EFFECTS
        // =============================================
        private void BtnCreate_MouseEnter(object sender, EventArgs e)
        {
            btnCreate.BackColor = Color.FromArgb(56, 142, 60);
        }

        private void BtnCreate_MouseLeave(object sender, EventArgs e)
        {
            btnCreate.BackColor = Color.FromArgb(76, 175, 80);
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