namespace StudyProcessManagement.Views.Teacher.Forms
{
    partial class AssignmentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.lblAssignmentTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblAssignedDate = new System.Windows.Forms.Label();
            this.dtpAssignedDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblMaxScore = new System.Windows.Forms.Label();
            this.numMaxScore = new System.Windows.Forms.NumericUpDown();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.txtAttachment = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxScore)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN BÀI TẬP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCourse
            // 
            this.lblCourse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourse.Location = new System.Drawing.Point(20, 65);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(560, 25);
            this.lblCourse.TabIndex = 1;
            this.lblCourse.Text = "Khóa học *";
            // 
            // cboCourse
            // 
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(20, 95);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(560, 25);
            this.cboCourse.TabIndex = 2;
            // 
            // lblAssignmentTitle
            // 
            this.lblAssignmentTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAssignmentTitle.Location = new System.Drawing.Point(20, 135);
            this.lblAssignmentTitle.Name = "lblAssignmentTitle";
            this.lblAssignmentTitle.Size = new System.Drawing.Size(560, 25);
            this.lblAssignmentTitle.TabIndex = 3;
            this.lblAssignmentTitle.Text = "Tên bài tập *";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(20, 165);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(560, 25);
            this.txtTitle.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(20, 205);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(560, 25);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Mô tả bài tập";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(20, 235);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(560, 100);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.Text = "";
            // 
            // lblAssignedDate
            // 
            this.lblAssignedDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAssignedDate.Location = new System.Drawing.Point(20, 345);
            this.lblAssignedDate.Name = "lblAssignedDate";
            this.lblAssignedDate.Size = new System.Drawing.Size(270, 25);
            this.lblAssignedDate.TabIndex = 7;
            this.lblAssignedDate.Text = "Ngày giao *";
            // 
            // dtpAssignedDate
            // 
            this.dtpAssignedDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpAssignedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssignedDate.Location = new System.Drawing.Point(20, 375);
            this.dtpAssignedDate.Name = "dtpAssignedDate";
            this.dtpAssignedDate.Size = new System.Drawing.Size(270, 25);
            this.dtpAssignedDate.TabIndex = 8;
            // 
            // lblDueDate
            // 
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDueDate.Location = new System.Drawing.Point(310, 345);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(270, 25);
            this.lblDueDate.TabIndex = 9;
            this.lblDueDate.Text = "Hạn nộp *";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(310, 375);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(270, 25);
            this.dtpDueDate.TabIndex = 10;
            // 
            // lblMaxScore
            // 
            this.lblMaxScore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaxScore.Location = new System.Drawing.Point(20, 415);
            this.lblMaxScore.Name = "lblMaxScore";
            this.lblMaxScore.Size = new System.Drawing.Size(270, 25);
            this.lblMaxScore.TabIndex = 11;
            this.lblMaxScore.Text = "Điểm tối đa *";
            // 
            // numMaxScore
            // 
            this.numMaxScore.DecimalPlaces = 1;
            this.numMaxScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMaxScore.Location = new System.Drawing.Point(20, 445);
            this.numMaxScore.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxScore.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxScore.Name = "numMaxScore";
            this.numMaxScore.Size = new System.Drawing.Size(270, 25);
            this.numMaxScore.TabIndex = 12;
            this.numMaxScore.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblAttachment
            // 
            this.lblAttachment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAttachment.Location = new System.Drawing.Point(310, 415);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(270, 25);
            this.lblAttachment.TabIndex = 13;
            this.lblAttachment.Text = "File đính kèm (docx, txt)";
            // 
            // txtAttachment
            // 
            this.txtAttachment.BackColor = System.Drawing.Color.White;
            this.txtAttachment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAttachment.Location = new System.Drawing.Point(310, 445);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.ReadOnly = true;
            this.txtAttachment.Size = new System.Drawing.Size(180, 23);
            this.txtAttachment.TabIndex = 14;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(495, 445);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(85, 25);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "📎 Chọn";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(340, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(450, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "✖ Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Location = new System.Drawing.Point(20, 495);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(560, 50);
            this.panelButtons.TabIndex = 18;
            // 
            // AssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 580);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtAttachment);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.numMaxScore);
            this.Controls.Add(this.lblMaxScore);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpAssignedDate);
            this.Controls.Add(this.lblAssignedDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAssignmentTitle);
            this.Controls.Add(this.cboCourse);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignmentForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý bài tập";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxScore)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Label lblAssignmentTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblAssignedDate;
        private System.Windows.Forms.DateTimePicker dtpAssignedDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblMaxScore;
        private System.Windows.Forms.NumericUpDown numMaxScore;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.TextBox txtAttachment;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelButtons;

        private void btnSave_MouseEnter(object sender, System.EventArgs e)
        {
            btnSave.BackColor = System.Drawing.Color.FromArgb(56, 142, 60);
        }

        private void btnSave_MouseLeave(object sender, System.EventArgs e)
        {
            btnSave.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        }

        private void btnCancel_MouseEnter(object sender, System.EventArgs e)
        {
            btnCancel.BackColor = System.Drawing.Color.FromArgb(117, 117, 117);
        }

        private void btnCancel_MouseLeave(object sender, System.EventArgs e)
        {
            btnCancel.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
        }
    }
}
