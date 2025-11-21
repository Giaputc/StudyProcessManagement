namespace StudyProcessManagement.Views.Admin.Course
{
    partial class CourseVerificationForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tvContent = new System.Windows.Forms.TreeView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblLessonName = new System.Windows.Forms.Label();
            this.txtLessonName = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblVideo = new System.Windows.Forms.Label();
            this.txtVideo = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnApprove);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DUYỆT KHÓA HỌC";
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(830, 10);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(150, 40);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "✅ DUYỆT NGAY";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 60);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tvContent);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlDetail);
            this.splitContainer.Size = new System.Drawing.Size(1000, 540);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.TabIndex = 1;
            // 
            // tvContent
            // 
            this.tvContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tvContent.Location = new System.Drawing.Point(0, 0);
            this.tvContent.Name = "tvContent";
            this.tvContent.Size = new System.Drawing.Size(300, 540);
            this.tvContent.TabIndex = 0;
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.Controls.Add(this.txtVideo);
            this.pnlDetail.Controls.Add(this.lblVideo);
            this.pnlDetail.Controls.Add(this.txtContent);
            this.pnlDetail.Controls.Add(this.lblDesc);
            this.pnlDetail.Controls.Add(this.txtLessonName);
            this.pnlDetail.Controls.Add(this.lblLessonName);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDetail.Size = new System.Drawing.Size(696, 540);
            this.pnlDetail.TabIndex = 0;
            // 
            // lblLessonName
            // 
            this.lblLessonName.AutoSize = true;
            this.lblLessonName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLessonName.Location = new System.Drawing.Point(20, 20);
            this.lblLessonName.Name = "lblLessonName";
            this.lblLessonName.Size = new System.Drawing.Size(80, 15);
            this.lblLessonName.TabIndex = 0;
            this.lblLessonName.Text = "Tên bài học:";
            // 
            // txtLessonName
            // 
            this.txtLessonName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLessonName.Location = new System.Drawing.Point(20, 45);
            this.txtLessonName.Name = "txtLessonName";
            this.txtLessonName.ReadOnly = true;
            this.txtLessonName.Size = new System.Drawing.Size(650, 25);
            this.txtLessonName.TabIndex = 1;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesc.Location = new System.Drawing.Point(20, 90);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(66, 15);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Nội dung:";
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContent.Location = new System.Drawing.Point(20, 115);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(650, 250);
            this.txtContent.TabIndex = 3;
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVideo.Location = new System.Drawing.Point(20, 385);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(70, 15);
            this.lblVideo.TabIndex = 4;
            this.lblVideo.Text = "Link Video:";
            // 
            // txtVideo
            // 
            this.txtVideo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVideo.Location = new System.Drawing.Point(20, 410);
            this.txtVideo.Name = "txtVideo";
            this.txtVideo.ReadOnly = true;
            this.txtVideo.Size = new System.Drawing.Size(650, 25);
            this.txtVideo.TabIndex = 5;
            // 
            // CourseVerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlHeader);
            this.Name = "CourseVerificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Course Verification";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLessonName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView tvContent;
        private System.Windows.Forms.TextBox txtLessonName;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtVideo;
    }
}