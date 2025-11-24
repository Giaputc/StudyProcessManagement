namespace StudyProcessManagement.Views.Admin.Course
{
    partial class CourseManagement
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblStatLessons = new System.Windows.Forms.Label();
            this.lblStatStudents = new System.Windows.Forms.Label();
            this.lblStatCourses = new System.Windows.Forms.Label();
            this.flowCourses = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHeader.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblSearchIcon);
            this.panelHeader.Controls.Add(this.txtSearch);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 70);
            this.panelHeader.TabIndex = 2;
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSearchIcon.Location = new System.Drawing.Point(768, 26);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(39, 28);
            this.lblSearchIcon.TabIndex = 2;
            this.lblSearchIcon.Text = "🔍";
            this.lblSearchIcon.Click += new System.EventHandler(this.lblSearchIcon_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(362, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 32);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Tìm kiếm khóa học...";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Quản lý Khóa học";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelStats.Controls.Add(this.lblStatLessons);
            this.panelStats.Controls.Add(this.lblStatStudents);
            this.panelStats.Controls.Add(this.lblStatCourses);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 70);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelStats.Size = new System.Drawing.Size(1100, 80);
            this.panelStats.TabIndex = 1;
            // 
            // lblStatLessons
            // 
            this.lblStatLessons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblStatLessons.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStatLessons.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatLessons.ForeColor = System.Drawing.Color.White;
            this.lblStatLessons.Location = new System.Drawing.Point(780, 10);
            this.lblStatLessons.Name = "lblStatLessons";
            this.lblStatLessons.Size = new System.Drawing.Size(300, 60);
            this.lblStatLessons.TabIndex = 0;
            this.lblStatLessons.Text = "Loading...";
            this.lblStatLessons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatStudents
            // 
            this.lblStatStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblStatStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatStudents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatStudents.ForeColor = System.Drawing.Color.White;
            this.lblStatStudents.Location = new System.Drawing.Point(320, 10);
            this.lblStatStudents.Name = "lblStatStudents";
            this.lblStatStudents.Size = new System.Drawing.Size(760, 60);
            this.lblStatStudents.TabIndex = 1;
            this.lblStatStudents.Text = "Loading...";
            this.lblStatStudents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatCourses
            // 
            this.lblStatCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblStatCourses.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatCourses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatCourses.ForeColor = System.Drawing.Color.White;
            this.lblStatCourses.Location = new System.Drawing.Point(20, 10);
            this.lblStatCourses.Name = "lblStatCourses";
            this.lblStatCourses.Size = new System.Drawing.Size(300, 60);
            this.lblStatCourses.TabIndex = 2;
            this.lblStatCourses.Text = "Loading...";
            this.lblStatCourses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatCourses.Click += new System.EventHandler(this.lblStatCourses_Click);
            // 
            // flowCourses
            // 
            this.flowCourses.AutoScroll = true;
            this.flowCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.flowCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowCourses.Location = new System.Drawing.Point(0, 150);
            this.flowCourses.Name = "flowCourses";
            this.flowCourses.Padding = new System.Windows.Forms.Padding(20);
            this.flowCourses.Size = new System.Drawing.Size(1100, 550);
            this.flowCourses.TabIndex = 0;
            this.flowCourses.Paint += new System.Windows.Forms.PaintEventHandler(this.flowCourses_Paint);
            // 
            // CourseManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.flowCourses);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseManagement";
            this.Text = "CourseManagement";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CourseManagement_KeyDown);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblStatCourses, lblStatStudents, lblStatLessons;
        public System.Windows.Forms.FlowLayoutPanel flowCourses;
        private System.Windows.Forms.Label lblSearchIcon;
    }
}