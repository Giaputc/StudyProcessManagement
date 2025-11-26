namespace StudyProcessManagement.Views.Teacher.Forms
{
    partial class GradeSubmissionForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblLateWarning = new System.Windows.Forms.Label();
            this.lblDueDateValue = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblSubmitDateValue = new System.Windows.Forms.Label();
            this.lblSubmitDate = new System.Windows.Forms.Label();
            this.lblAssignmentValue = new System.Windows.Forms.Label();
            this.lblAssignment = new System.Windows.Forms.Label();
            this.lblCourseValue = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblStudentValue = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.panelAssignment = new System.Windows.Forms.Panel();
            this.txtAssignmentDescription = new System.Windows.Forms.RichTextBox();
            this.lblAssignmentReq = new System.Windows.Forms.Label();
            this.panelSubmission = new System.Windows.Forms.Panel();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblAttachmentValue = new System.Windows.Forms.Label();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.txtSubmissionText = new System.Windows.Forms.RichTextBox();
            this.lblSubmissionTitle = new System.Windows.Forms.Label();
            this.panelGrading = new System.Windows.Forms.Panel();
            this.lblGradedAtValue = new System.Windows.Forms.Label();
            this.txtFeedback = new System.Windows.Forms.RichTextBox();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.lblMaxScoreValue = new System.Windows.Forms.Label();
            this.numScore = new System.Windows.Forms.NumericUpDown();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblGradingTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelAssignment.SuspendLayout();
            this.panelSubmission.SuspendLayout();
            this.panelGrading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblFormTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelHeader.Size = new System.Drawing.Size(1274, 86);
            this.panelHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(27, 25);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(1220, 36);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "CHẤM ĐIỂM BÀI NỘP";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelInfo.Controls.Add(this.lblLateWarning);
            this.panelInfo.Controls.Add(this.lblDueDateValue);
            this.panelInfo.Controls.Add(this.lblDueDate);
            this.panelInfo.Controls.Add(this.lblSubmitDateValue);
            this.panelInfo.Controls.Add(this.lblSubmitDate);
            this.panelInfo.Controls.Add(this.lblAssignmentValue);
            this.panelInfo.Controls.Add(this.lblAssignment);
            this.panelInfo.Controls.Add(this.lblCourseValue);
            this.panelInfo.Controls.Add(this.lblCourse);
            this.panelInfo.Controls.Add(this.lblStudentValue);
            this.panelInfo.Controls.Add(this.lblStudent);
            this.panelInfo.Location = new System.Drawing.Point(27, 105);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(4);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.panelInfo.Size = new System.Drawing.Size(1147, 160);
            this.panelInfo.TabIndex = 1;
            // 
            // lblLateWarning
            // 
            this.lblLateWarning.AutoSize = true;
            this.lblLateWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLateWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblLateWarning.Location = new System.Drawing.Point(867, 111);
            this.lblLateWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLateWarning.Name = "lblLateWarning";
            this.lblLateWarning.Size = new System.Drawing.Size(0, 20);
            this.lblLateWarning.TabIndex = 10;
            this.lblLateWarning.Visible = false;
            // 
            // lblDueDateValue
            // 
            this.lblDueDateValue.AutoSize = true;
            this.lblDueDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDueDateValue.Location = new System.Drawing.Point(693, 111);
            this.lblDueDateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDueDateValue.Name = "lblDueDateValue";
            this.lblDueDateValue.Size = new System.Drawing.Size(0, 20);
            this.lblDueDateValue.TabIndex = 9;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDueDate.Location = new System.Drawing.Point(600, 111);
            this.lblDueDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(72, 20);
            this.lblDueDate.TabIndex = 8;
            this.lblDueDate.Text = "Hạn nộp:";
            // 
            // lblSubmitDateValue
            // 
            this.lblSubmitDateValue.AutoSize = true;
            this.lblSubmitDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubmitDateValue.Location = new System.Drawing.Point(160, 111);
            this.lblSubmitDateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubmitDateValue.Name = "lblSubmitDateValue";
            this.lblSubmitDateValue.Size = new System.Drawing.Size(0, 20);
            this.lblSubmitDateValue.TabIndex = 7;
            // 
            // lblSubmitDate
            // 
            this.lblSubmitDate.AutoSize = true;
            this.lblSubmitDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubmitDate.Location = new System.Drawing.Point(20, 111);
            this.lblSubmitDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubmitDate.Name = "lblSubmitDate";
            this.lblSubmitDate.Size = new System.Drawing.Size(81, 20);
            this.lblSubmitDate.TabIndex = 6;
            this.lblSubmitDate.Text = "Ngày nộp:";
            // 
            // lblAssignmentValue
            // 
            this.lblAssignmentValue.AutoSize = true;
            this.lblAssignmentValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAssignmentValue.Location = new System.Drawing.Point(160, 80);
            this.lblAssignmentValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAssignmentValue.Name = "lblAssignmentValue";
            this.lblAssignmentValue.Size = new System.Drawing.Size(0, 20);
            this.lblAssignmentValue.TabIndex = 5;
            // 
            // lblAssignment
            // 
            this.lblAssignment.AutoSize = true;
            this.lblAssignment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAssignment.Location = new System.Drawing.Point(20, 80);
            this.lblAssignment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAssignment.Name = "lblAssignment";
            this.lblAssignment.Size = new System.Drawing.Size(62, 20);
            this.lblAssignment.TabIndex = 4;
            this.lblAssignment.Text = "Bài tập:";
            // 
            // lblCourseValue
            // 
            this.lblCourseValue.AutoSize = true;
            this.lblCourseValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCourseValue.Location = new System.Drawing.Point(160, 49);
            this.lblCourseValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourseValue.Name = "lblCourseValue";
            this.lblCourseValue.Size = new System.Drawing.Size(0, 20);
            this.lblCourseValue.TabIndex = 3;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCourse.Location = new System.Drawing.Point(20, 49);
            this.lblCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(78, 20);
            this.lblCourse.TabIndex = 2;
            this.lblCourse.Text = "Khóa học:";
            // 
            // lblStudentValue
            // 
            this.lblStudentValue.AutoSize = true;
            this.lblStudentValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudentValue.Location = new System.Drawing.Point(160, 18);
            this.lblStudentValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentValue.Name = "lblStudentValue";
            this.lblStudentValue.Size = new System.Drawing.Size(0, 20);
            this.lblStudentValue.TabIndex = 1;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStudent.Location = new System.Drawing.Point(20, 18);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(73, 20);
            this.lblStudent.TabIndex = 0;
            this.lblStudent.Text = "Học viên:";
            // 
            // panelAssignment
            // 
            this.panelAssignment.BackColor = System.Drawing.Color.White;
            this.panelAssignment.Controls.Add(this.txtAssignmentDescription);
            this.panelAssignment.Controls.Add(this.lblAssignmentReq);
            this.panelAssignment.Location = new System.Drawing.Point(27, 283);
            this.panelAssignment.Margin = new System.Windows.Forms.Padding(4);
            this.panelAssignment.Name = "panelAssignment";
            this.panelAssignment.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.panelAssignment.Size = new System.Drawing.Size(1147, 148);
            this.panelAssignment.TabIndex = 2;
            // 
            // txtAssignmentDescription
            // 
            this.txtAssignmentDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAssignmentDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAssignmentDescription.Location = new System.Drawing.Point(20, 55);
            this.txtAssignmentDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtAssignmentDescription.Name = "txtAssignmentDescription";
            this.txtAssignmentDescription.ReadOnly = true;
            this.txtAssignmentDescription.Size = new System.Drawing.Size(1107, 74);
            this.txtAssignmentDescription.TabIndex = 1;
            this.txtAssignmentDescription.Text = "";
            // 
            // lblAssignmentReq
            // 
            this.lblAssignmentReq.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAssignmentReq.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAssignmentReq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblAssignmentReq.Location = new System.Drawing.Point(20, 18);
            this.lblAssignmentReq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAssignmentReq.Name = "lblAssignmentReq";
            this.lblAssignmentReq.Size = new System.Drawing.Size(1107, 31);
            this.lblAssignmentReq.TabIndex = 0;
            this.lblAssignmentReq.Text = "📋 YÊU CẦU BÀI TẬP";
            // 
            // panelSubmission
            // 
            this.panelSubmission.BackColor = System.Drawing.Color.White;
            this.panelSubmission.Controls.Add(this.btnOpenFile);
            this.panelSubmission.Controls.Add(this.lblAttachmentValue);
            this.panelSubmission.Controls.Add(this.lblAttachment);
            this.panelSubmission.Controls.Add(this.txtSubmissionText);
            this.panelSubmission.Controls.Add(this.lblSubmissionTitle);
            this.panelSubmission.Location = new System.Drawing.Point(27, 449);
            this.panelSubmission.Margin = new System.Windows.Forms.Padding(4);
            this.panelSubmission.Name = "panelSubmission";
            this.panelSubmission.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.panelSubmission.Size = new System.Drawing.Size(1147, 222);
            this.panelSubmission.TabIndex = 3;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFile.FlatAppearance.BorderSize = 0;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenFile.ForeColor = System.Drawing.Color.White;
            this.btnOpenFile.Location = new System.Drawing.Point(1000, 160);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(127, 34);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "📂 Mở file";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // lblAttachmentValue
            // 
            this.lblAttachmentValue.AutoSize = true;
            this.lblAttachmentValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAttachmentValue.Location = new System.Drawing.Point(147, 166);
            this.lblAttachmentValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttachmentValue.Name = "lblAttachmentValue";
            this.lblAttachmentValue.Size = new System.Drawing.Size(0, 20);
            this.lblAttachmentValue.TabIndex = 3;
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAttachment.Location = new System.Drawing.Point(20, 166);
            this.lblAttachment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(106, 20);
            this.lblAttachment.TabIndex = 2;
            this.lblAttachment.Text = "File đính kèm:";
            // 
            // txtSubmissionText
            // 
            this.txtSubmissionText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubmissionText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSubmissionText.Location = new System.Drawing.Point(20, 55);
            this.txtSubmissionText.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubmissionText.Name = "txtSubmissionText";
            this.txtSubmissionText.ReadOnly = true;
            this.txtSubmissionText.Size = new System.Drawing.Size(1105, 98);
            this.txtSubmissionText.TabIndex = 1;
            this.txtSubmissionText.Text = "";
            // 
            // lblSubmissionTitle
            // 
            this.lblSubmissionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubmissionTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubmissionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblSubmissionTitle.Location = new System.Drawing.Point(20, 18);
            this.lblSubmissionTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubmissionTitle.Name = "lblSubmissionTitle";
            this.lblSubmissionTitle.Size = new System.Drawing.Size(1107, 31);
            this.lblSubmissionTitle.TabIndex = 0;
            this.lblSubmissionTitle.Text = "📝 BÀI LÀM CỦA HỌC VIÊN";
            // 
            // panelGrading
            // 
            this.panelGrading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.panelGrading.Controls.Add(this.lblGradedAtValue);
            this.panelGrading.Controls.Add(this.txtFeedback);
            this.panelGrading.Controls.Add(this.lblFeedback);
            this.panelGrading.Controls.Add(this.lblMaxScoreValue);
            this.panelGrading.Controls.Add(this.numScore);
            this.panelGrading.Controls.Add(this.lblScore);
            this.panelGrading.Controls.Add(this.lblGradingTitle);
            this.panelGrading.Location = new System.Drawing.Point(27, 689);
            this.panelGrading.Margin = new System.Windows.Forms.Padding(4);
            this.panelGrading.Name = "panelGrading";
            this.panelGrading.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.panelGrading.Size = new System.Drawing.Size(1147, 246);
            this.panelGrading.TabIndex = 4;
            // 
            // lblGradedAtValue
            // 
            this.lblGradedAtValue.AutoSize = true;
            this.lblGradedAtValue.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblGradedAtValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblGradedAtValue.Location = new System.Drawing.Point(20, 209);
            this.lblGradedAtValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGradedAtValue.Name = "lblGradedAtValue";
            this.lblGradedAtValue.Size = new System.Drawing.Size(0, 19);
            this.lblGradedAtValue.TabIndex = 6;
            this.lblGradedAtValue.Visible = false;
            // 
            // txtFeedback
            // 
            this.txtFeedback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFeedback.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFeedback.Location = new System.Drawing.Point(20, 129);
            this.txtFeedback.Margin = new System.Windows.Forms.Padding(4);
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(1105, 73);
            this.txtFeedback.TabIndex = 5;
            this.txtFeedback.Text = "";
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFeedback.Location = new System.Drawing.Point(20, 105);
            this.lblFeedback.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(74, 20);
            this.lblFeedback.TabIndex = 4;
            this.lblFeedback.Text = "Phản hồi:";
            // 
            // lblMaxScoreValue
            // 
            this.lblMaxScoreValue.AutoSize = true;
            this.lblMaxScoreValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxScoreValue.Location = new System.Drawing.Point(207, 59);
            this.lblMaxScoreValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxScoreValue.Name = "lblMaxScoreValue";
            this.lblMaxScoreValue.Size = new System.Drawing.Size(47, 25);
            this.lblMaxScoreValue.TabIndex = 3;
            this.lblMaxScoreValue.Text = "/ 10";
            // 
            // numScore
            // 
            this.numScore.DecimalPlaces = 1;
            this.numScore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.numScore.Location = new System.Drawing.Point(93, 55);
            this.numScore.Margin = new System.Windows.Forms.Padding(4);
            this.numScore.Name = "numScore";
            this.numScore.Size = new System.Drawing.Size(107, 32);
            this.numScore.TabIndex = 2;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(20, 62);
            this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(50, 20);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Điểm:";
            // 
            // lblGradingTitle
            // 
            this.lblGradingTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGradingTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGradingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblGradingTitle.Location = new System.Drawing.Point(20, 18);
            this.lblGradingTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGradingTitle.Name = "lblGradingTitle";
            this.lblGradingTitle.Size = new System.Drawing.Size(1107, 31);
            this.lblGradingTitle.TabIndex = 0;
            this.lblGradingTitle.Text = "⭐ CHẤM ĐIỂM VÀ PHẢN HỒI";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Location = new System.Drawing.Point(27, 954);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1147, 62);
            this.panelButtons.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1000, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 49);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "✖ Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(853, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 49);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GradeSubmissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1295, 862);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelGrading);
            this.Controls.Add(this.panelSubmission);
            this.Controls.Add(this.panelAssignment);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GradeSubmissionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chấm điểm bài nộp";
            this.panelHeader.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelAssignment.ResumeLayout(false);
            this.panelSubmission.ResumeLayout(false);
            this.panelSubmission.PerformLayout();
            this.panelGrading.ResumeLayout(false);
            this.panelGrading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblStudentValue;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblCourseValue;
        private System.Windows.Forms.Label lblAssignment;
        private System.Windows.Forms.Label lblAssignmentValue;
        private System.Windows.Forms.Label lblSubmitDate;
        private System.Windows.Forms.Label lblSubmitDateValue;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblDueDateValue;
        private System.Windows.Forms.Label lblLateWarning;
        private System.Windows.Forms.Panel panelAssignment;
        private System.Windows.Forms.Label lblAssignmentReq;
        private System.Windows.Forms.RichTextBox txtAssignmentDescription;
        private System.Windows.Forms.Panel panelSubmission;
        private System.Windows.Forms.Label lblSubmissionTitle;
        private System.Windows.Forms.RichTextBox txtSubmissionText;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Label lblAttachmentValue;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Panel panelGrading;
        private System.Windows.Forms.Label lblGradingTitle;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.NumericUpDown numScore;
        private System.Windows.Forms.Label lblMaxScoreValue;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.RichTextBox txtFeedback;
        private System.Windows.Forms.Label lblGradedAtValue;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
