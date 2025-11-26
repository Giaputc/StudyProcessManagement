namespace StudyProcessManagement.Views.Admin
{
    partial class MainForm
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
            this.flowLayoutPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenuDashboard = new System.Windows.Forms.Button();
            this.btnMenuUsers = new System.Windows.Forms.Button();
            this.btnMenuTeachers = new System.Windows.Forms.Button();
            this.btnMenuStudents = new System.Windows.Forms.Button();
            this.btnMenuCourses = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblSidebarHeader = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.flowLayoutPanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelSidebar.Controls.Add(this.flowLayoutPanelMenu);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.lblSidebarHeader);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(272, 626);
            this.panelSidebar.TabIndex = 1;
            // 
            // flowLayoutPanelMenu
            // 
            this.flowLayoutPanelMenu.Controls.Add(this.btnMenuDashboard);
            this.flowLayoutPanelMenu.Controls.Add(this.btnMenuUsers);
            this.flowLayoutPanelMenu.Controls.Add(this.btnMenuTeachers);
            this.flowLayoutPanelMenu.Controls.Add(this.btnMenuStudents);
            this.flowLayoutPanelMenu.Controls.Add(this.btnMenuCourses);
            this.flowLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMenu.Location = new System.Drawing.Point(0, 60);
            this.flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            this.flowLayoutPanelMenu.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelMenu.Size = new System.Drawing.Size(272, 516);
            this.flowLayoutPanelMenu.TabIndex = 1;
            // 
            // btnMenuDashboard
            // 
            this.btnMenuDashboard.Location = new System.Drawing.Point(13, 13);
            this.btnMenuDashboard.Name = "btnMenuDashboard";
            this.btnMenuDashboard.Size = new System.Drawing.Size(75, 23);
            this.btnMenuDashboard.TabIndex = 0;
            this.btnMenuDashboard.Text = "📊 Dashboard";
            this.btnMenuDashboard.Click += new System.EventHandler(this.btnMenuDashboard_Click_1);
            // 
            // btnMenuUsers
            // 
            this.btnMenuUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnMenuUsers.Location = new System.Drawing.Point(13, 42);
            this.btnMenuUsers.Name = "btnMenuUsers";
            this.btnMenuUsers.Size = new System.Drawing.Size(75, 23);
            this.btnMenuUsers.TabIndex = 1;
            this.btnMenuUsers.Text = "👥 Tất cả người dùng";
            this.btnMenuUsers.UseVisualStyleBackColor = false;
            this.btnMenuUsers.Click += new System.EventHandler(this.btnMenuUsers_Click);
            // 
            // btnMenuTeachers
            // 
            this.btnMenuTeachers.Location = new System.Drawing.Point(13, 71);
            this.btnMenuTeachers.Name = "btnMenuTeachers";
            this.btnMenuTeachers.Size = new System.Drawing.Size(75, 23);
            this.btnMenuTeachers.TabIndex = 2;
            this.btnMenuTeachers.Text = "👨‍🏫 Giảng viên";
            this.btnMenuTeachers.Click += new System.EventHandler(this.btnMenuTeachers_Click_1);
            // 
            // btnMenuStudents
            // 
            this.btnMenuStudents.Location = new System.Drawing.Point(13, 100);
            this.btnMenuStudents.Name = "btnMenuStudents";
            this.btnMenuStudents.Size = new System.Drawing.Size(75, 23);
            this.btnMenuStudents.TabIndex = 3;
            this.btnMenuStudents.Text = "🎓 Học viên";
            this.btnMenuStudents.Click += new System.EventHandler(this.btnMenuStudents_Click_1);
            // 
            // btnMenuCourses
            // 
            this.btnMenuCourses.Location = new System.Drawing.Point(13, 129);
            this.btnMenuCourses.Name = "btnMenuCourses";
            this.btnMenuCourses.Size = new System.Drawing.Size(75, 23);
            this.btnMenuCourses.TabIndex = 4;
            this.btnMenuCourses.Text = "📚 Danh sách khóa học";
            this.btnMenuCourses.Click += new System.EventHandler(this.btnMenuCourses_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 576);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(272, 50);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblSidebarHeader
            // 
            this.lblSidebarHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSidebarHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSidebarHeader.ForeColor = System.Drawing.Color.White;
            this.lblSidebarHeader.Location = new System.Drawing.Point(0, 0);
            this.lblSidebarHeader.Name = "lblSidebarHeader";
            this.lblSidebarHeader.Padding = new System.Windows.Forms.Padding(10);
            this.lblSidebarHeader.Size = new System.Drawing.Size(272, 60);
            this.lblSidebarHeader.TabIndex = 3;
            this.lblSidebarHeader.Text = "📚 LMS Admin";
            this.lblSidebarHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(272, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1034, 626);
            this.panelContent.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1306, 626);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.flowLayoutPanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMenu;
        private System.Windows.Forms.Button btnMenuDashboard;
        private System.Windows.Forms.Button btnMenuUsers;
        private System.Windows.Forms.Button btnMenuTeachers;
        private System.Windows.Forms.Button btnMenuStudents;
        private System.Windows.Forms.Button btnMenuCourses;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblSidebarHeader;
        private System.Windows.Forms.Panel panelContent;
    }
}