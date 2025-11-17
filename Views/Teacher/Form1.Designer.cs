using System.Drawing;

namespace StudyProcessManagement.Views.Teacher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSidebarTop = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnAssignments = new System.Windows.Forms.Button();
            this.btnGrading = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.panelLogout = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelSidebarTop.SuspendLayout();
            this.panelLogout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelSidebar.Controls.Add(this.btnStudents);
            this.panelSidebar.Controls.Add(this.btnGrading);
            this.panelSidebar.Controls.Add(this.btnAssignments);
            this.panelSidebar.Controls.Add(this.btnCourses);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.panelSidebarTop);
            this.panelSidebar.Controls.Add(this.panelLogout);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(260, 626);
            this.panelSidebar.TabIndex = 0;
            // 
            // panelSidebarTop
            // 
            this.panelSidebarTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(60)))));
            this.panelSidebarTop.Controls.Add(this.lblAppName);
            this.panelSidebarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidebarTop.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarTop.Name = "panelSidebarTop";
            this.panelSidebarTop.Size = new System.Drawing.Size(260, 80);
            this.panelSidebarTop.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(16, 27);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(45, 28);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "LMS";
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(84)))), ((int)(((byte)(104)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 80);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(260, 50);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnCourses
            // 
            this.btnCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCourses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCourses.FlatAppearance.BorderSize = 0;
            this.btnCourses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(84)))), ((int)(((byte)(104)))));
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCourses.ForeColor = System.Drawing.Color.White;
            this.btnCourses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourses.Location = new System.Drawing.Point(0, 130);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCourses.Size = new System.Drawing.Size(260, 50);
            this.btnCourses.TabIndex = 2;
            this.btnCourses.Text = "Quản lý khóa học";
            this.btnCourses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourses.UseVisualStyleBackColor = true;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // btnAssignments
            // 
            this.btnAssignments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAssignments.FlatAppearance.BorderSize = 0;
            this.btnAssignments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(84)))), ((int)(((byte)(104)))));
            this.btnAssignments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAssignments.ForeColor = System.Drawing.Color.White;
            this.btnAssignments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignments.Location = new System.Drawing.Point(0, 180);
            this.btnAssignments.Name = "btnAssignments";
            this.btnAssignments.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnAssignments.Size = new System.Drawing.Size(260, 50);
            this.btnAssignments.TabIndex = 3;
            this.btnAssignments.Text = "Quản lý nội dung";
            this.btnAssignments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignments.UseVisualStyleBackColor = true;
            this.btnAssignments.Click += new System.EventHandler(this.btnAssignments_Click);
            // 
            // btnGrading
            // 
            this.btnGrading.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrading.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrading.FlatAppearance.BorderSize = 0;
            this.btnGrading.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(84)))), ((int)(((byte)(104)))));
            this.btnGrading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrading.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGrading.ForeColor = System.Drawing.Color.White;
            this.btnGrading.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrading.Location = new System.Drawing.Point(0, 230);
            this.btnGrading.Name = "btnGrading";
            this.btnGrading.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnGrading.Size = new System.Drawing.Size(260, 50);
            this.btnGrading.TabIndex = 4;
            this.btnGrading.Text = "Chấm điểm & Phản hồi";
            this.btnGrading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrading.UseVisualStyleBackColor = true;
            this.btnGrading.Click += new System.EventHandler(this.btnGrading_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(84)))), ((int)(((byte)(104)))));
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.Location = new System.Drawing.Point(0, 280);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnStudents.Size = new System.Drawing.Size(260, 50);
            this.btnStudents.TabIndex = 5;
            this.btnStudents.Text = "Quản lý học viên";
            this.btnStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // panelLogout
            // 
            this.panelLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelLogout.Controls.Add(this.btnLogout);
            this.panelLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLogout.Location = new System.Drawing.Point(0, 516);
            this.panelLogout.Name = "panelLogout";
            this.panelLogout.Size = new System.Drawing.Size(260, 110);
            this.panelLogout.TabIndex = 6;
            this.panelLogout.Padding = new System.Windows.Forms.Padding(0);
            // 
            // Custom paint for avatar and user info
            this.panelLogout.Paint += (s, e) =>
            {
                // Draw avatar circle
                var avatarRect = new Rectangle(20, 8, 40, 40);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (var brush = new SolidBrush(Color.FromArgb(76, 175, 80)))
                {
                    e.Graphics.FillEllipse(brush, avatarRect);
                }

                // Draw initial "T"
                using (var font = new Font("Segoe UI", 16F, FontStyle.Bold))
                using (var textBrush = new SolidBrush(Color.White))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString("T", font, textBrush, new Rectangle(avatarRect.X, avatarRect.Y, avatarRect.Width, avatarRect.Height), sf);
                }

                // Draw "Teacher" text
                using (var font = new Font("Segoe UI", 10.5F, FontStyle.Bold))
                using (var textBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.DrawString("Teacher", font, textBrush, 68, 11);
                }

                // Draw "Giảng viên" text
                using (var font = new Font("Segoe UI", 8.5F))
                using (var textBrush = new SolidBrush(Color.FromArgb(180, 180, 180)))
                {
                    e.Graphics.DrawString("Giảng viên", font, textBrush, 68, 30);
                }
            };
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(69)))), ((int)(((byte)(57)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(16, 66);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(228, 36);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.MouseEnter += (s, e) =>
            {
                this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            };
            this.btnLogout.MouseLeave += (s, e) =>
            {
                this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(69)))), ((int)(((byte)(57)))));
            };
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(260, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1046, 626);
            this.panelContent.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 626);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Name = "Form1";
            this.Text = "Quản Lý Học Tập - LMS";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebarTop.ResumeLayout(false);
            this.panelSidebarTop.PerformLayout();
            this.panelLogout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelSidebarTop;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnAssignments;
        private System.Windows.Forms.Button btnGrading;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Panel panelLogout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelContent;
    }
}
