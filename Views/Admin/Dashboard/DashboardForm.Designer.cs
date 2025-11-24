using System;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Admin.Dashboard
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelStats = new System.Windows.Forms.Panel();
            this.cardPending = new System.Windows.Forms.Panel();
            this.lblNumPending = new System.Windows.Forms.Label();
            this.lblTitlePending = new System.Windows.Forms.Label();
            this.lblIconPending = new System.Windows.Forms.Label();
            this.cardTeachers = new System.Windows.Forms.Panel();
            this.lblNumTeachers = new System.Windows.Forms.Label();
            this.lblTitleTeachers = new System.Windows.Forms.Label();
            this.lblIconTeachers = new System.Windows.Forms.Label();
            this.cardCourses = new System.Windows.Forms.Panel();
            this.lblNumCourses = new System.Windows.Forms.Label();
            this.lblTitleCourses = new System.Windows.Forms.Label();
            this.lblIconCourses = new System.Windows.Forms.Label();
            this.cardUsers = new System.Windows.Forms.Panel();
            this.lblNumUsers = new System.Windows.Forms.Label();
            this.lblTitleUsers = new System.Windows.Forms.Label();
            this.lblIconUsers = new System.Windows.Forms.Label();
            this.panelTables = new System.Windows.Forms.Panel();
            this.gbPendingCourses = new System.Windows.Forms.GroupBox();
            this.dgvPending = new System.Windows.Forms.DataGridView();
            this.gbRecentActivity = new System.Windows.Forms.GroupBox();
            this.dgvActivity = new System.Windows.Forms.DataGridView();
            this.panelStats.SuspendLayout();
            this.cardPending.SuspendLayout();
            this.cardTeachers.SuspendLayout();
            this.cardCourses.SuspendLayout();
            this.cardUsers.SuspendLayout();
            this.panelTables.SuspendLayout();
            this.gbPendingCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).BeginInit();
            this.gbRecentActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelStats.Controls.Add(this.cardPending);
            this.panelStats.Controls.Add(this.cardTeachers);
            this.panelStats.Controls.Add(this.cardCourses);
            this.panelStats.Controls.Add(this.cardUsers);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 0);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(10);
            this.panelStats.Size = new System.Drawing.Size(1000, 140);
            this.panelStats.TabIndex = 1;
            // 
            // cardPending
            // 
            this.cardPending.BackColor = System.Drawing.Color.White;
            this.cardPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPending.Controls.Add(this.lblNumPending);
            this.cardPending.Controls.Add(this.lblTitlePending);
            this.cardPending.Controls.Add(this.lblIconPending);
            this.cardPending.Dock = System.Windows.Forms.DockStyle.Left;
            this.cardPending.Location = new System.Drawing.Point(730, 10);
            this.cardPending.Margin = new System.Windows.Forms.Padding(10);
            this.cardPending.Name = "cardPending";
            this.cardPending.Size = new System.Drawing.Size(240, 120);
            this.cardPending.TabIndex = 3;
            // 
            // lblNumPending
            // 
            this.lblNumPending.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNumPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNumPending.Location = new System.Drawing.Point(80, 20);
            this.lblNumPending.Name = "lblNumPending";
            this.lblNumPending.Size = new System.Drawing.Size(150, 40);
            this.lblNumPending.TabIndex = 0;
            this.lblNumPending.Text = "0";
            // 
            // lblTitlePending
            // 
            this.lblTitlePending.AutoSize = true;
            this.lblTitlePending.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitlePending.ForeColor = System.Drawing.Color.Gray;
            this.lblTitlePending.Location = new System.Drawing.Point(85, 60);
            this.lblTitlePending.Name = "lblTitlePending";
            this.lblTitlePending.Size = new System.Drawing.Size(89, 23);
            this.lblTitlePending.TabIndex = 1;
            this.lblTitlePending.Text = "Chờ duyệt";
            // 
            // lblIconPending
            // 
            this.lblIconPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(229)))), ((int)(((byte)(245)))));
            this.lblIconPending.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblIconPending.Location = new System.Drawing.Point(10, 30);
            this.lblIconPending.Name = "lblIconPending";
            this.lblIconPending.Size = new System.Drawing.Size(60, 60);
            this.lblIconPending.TabIndex = 2;
            this.lblIconPending.Text = "✅";
            this.lblIconPending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardTeachers
            // 
            this.cardTeachers.BackColor = System.Drawing.Color.White;
            this.cardTeachers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTeachers.Controls.Add(this.lblNumTeachers);
            this.cardTeachers.Controls.Add(this.lblTitleTeachers);
            this.cardTeachers.Controls.Add(this.lblIconTeachers);
            this.cardTeachers.Dock = System.Windows.Forms.DockStyle.Left;
            this.cardTeachers.Location = new System.Drawing.Point(490, 10);
            this.cardTeachers.Name = "cardTeachers";
            this.cardTeachers.Size = new System.Drawing.Size(240, 120);
            this.cardTeachers.TabIndex = 4;
            // 
            // lblNumTeachers
            // 
            this.lblNumTeachers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNumTeachers.Location = new System.Drawing.Point(80, 20);
            this.lblNumTeachers.Name = "lblNumTeachers";
            this.lblNumTeachers.Size = new System.Drawing.Size(150, 40);
            this.lblNumTeachers.TabIndex = 0;
            this.lblNumTeachers.Text = "0";
            // 
            // lblTitleTeachers
            // 
            this.lblTitleTeachers.AutoSize = true;
            this.lblTitleTeachers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitleTeachers.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleTeachers.Location = new System.Drawing.Point(85, 60);
            this.lblTitleTeachers.Name = "lblTitleTeachers";
            this.lblTitleTeachers.Size = new System.Drawing.Size(91, 23);
            this.lblTitleTeachers.TabIndex = 1;
            this.lblTitleTeachers.Text = "Giảng viên";
            // 
            // lblIconTeachers
            // 
            this.lblIconTeachers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.lblIconTeachers.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblIconTeachers.Location = new System.Drawing.Point(10, 30);
            this.lblIconTeachers.Name = "lblIconTeachers";
            this.lblIconTeachers.Size = new System.Drawing.Size(60, 60);
            this.lblIconTeachers.TabIndex = 2;
            this.lblIconTeachers.Text = "👨‍🏫";
            this.lblIconTeachers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardCourses
            // 
            this.cardCourses.BackColor = System.Drawing.Color.White;
            this.cardCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardCourses.Controls.Add(this.lblNumCourses);
            this.cardCourses.Controls.Add(this.lblTitleCourses);
            this.cardCourses.Controls.Add(this.lblIconCourses);
            this.cardCourses.Dock = System.Windows.Forms.DockStyle.Left;
            this.cardCourses.Location = new System.Drawing.Point(250, 10);
            this.cardCourses.Name = "cardCourses";
            this.cardCourses.Size = new System.Drawing.Size(240, 120);
            this.cardCourses.TabIndex = 5;
            // 
            // lblNumCourses
            // 
            this.lblNumCourses.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNumCourses.Location = new System.Drawing.Point(80, 20);
            this.lblNumCourses.Name = "lblNumCourses";
            this.lblNumCourses.Size = new System.Drawing.Size(150, 40);
            this.lblNumCourses.TabIndex = 0;
            this.lblNumCourses.Text = "0";
            // 
            // lblTitleCourses
            // 
            this.lblTitleCourses.AutoSize = true;
            this.lblTitleCourses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitleCourses.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleCourses.Location = new System.Drawing.Point(85, 60);
            this.lblTitleCourses.Name = "lblTitleCourses";
            this.lblTitleCourses.Size = new System.Drawing.Size(82, 23);
            this.lblTitleCourses.TabIndex = 1;
            this.lblTitleCourses.Text = "Khóa học";
            // 
            // lblIconCourses
            // 
            this.lblIconCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblIconCourses.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblIconCourses.Location = new System.Drawing.Point(10, 30);
            this.lblIconCourses.Name = "lblIconCourses";
            this.lblIconCourses.Size = new System.Drawing.Size(60, 60);
            this.lblIconCourses.TabIndex = 2;
            this.lblIconCourses.Text = "📚";
            this.lblIconCourses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardUsers
            // 
            this.cardUsers.BackColor = System.Drawing.Color.White;
            this.cardUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardUsers.Controls.Add(this.lblNumUsers);
            this.cardUsers.Controls.Add(this.lblTitleUsers);
            this.cardUsers.Controls.Add(this.lblIconUsers);
            this.cardUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.cardUsers.Location = new System.Drawing.Point(10, 10);
            this.cardUsers.Name = "cardUsers";
            this.cardUsers.Size = new System.Drawing.Size(240, 120);
            this.cardUsers.TabIndex = 6;
            // 
            // lblNumUsers
            // 
            this.lblNumUsers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNumUsers.Location = new System.Drawing.Point(80, 20);
            this.lblNumUsers.Name = "lblNumUsers";
            this.lblNumUsers.Size = new System.Drawing.Size(150, 40);
            this.lblNumUsers.TabIndex = 0;
            this.lblNumUsers.Text = "0";
            this.lblNumUsers.Click += new System.EventHandler(this.lblNumUsers_Click);
            // 
            // lblTitleUsers
            // 
            this.lblTitleUsers.AutoSize = true;
            this.lblTitleUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitleUsers.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleUsers.Location = new System.Drawing.Point(85, 60);
            this.lblTitleUsers.Name = "lblTitleUsers";
            this.lblTitleUsers.Size = new System.Drawing.Size(143, 23);
            this.lblTitleUsers.TabIndex = 1;
            this.lblTitleUsers.Text = "Tổng người dùng";
            // 
            // lblIconUsers
            // 
            this.lblIconUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.lblIconUsers.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblIconUsers.Location = new System.Drawing.Point(10, 30);
            this.lblIconUsers.Name = "lblIconUsers";
            this.lblIconUsers.Size = new System.Drawing.Size(60, 60);
            this.lblIconUsers.TabIndex = 2;
            this.lblIconUsers.Text = "👥";
            this.lblIconUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTables
            // 
            this.panelTables.Controls.Add(this.gbPendingCourses);
            this.panelTables.Controls.Add(this.gbRecentActivity);
            this.panelTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTables.Location = new System.Drawing.Point(0, 140);
            this.panelTables.Name = "panelTables";
            this.panelTables.Padding = new System.Windows.Forms.Padding(10);
            this.panelTables.Size = new System.Drawing.Size(1000, 460);
            this.panelTables.TabIndex = 0;
            // 
            // gbPendingCourses
            // 
            this.gbPendingCourses.Controls.Add(this.dgvPending);
            this.gbPendingCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPendingCourses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPendingCourses.Location = new System.Drawing.Point(10, 260);
            this.gbPendingCourses.Name = "gbPendingCourses";
            this.gbPendingCourses.Size = new System.Drawing.Size(980, 190);
            this.gbPendingCourses.TabIndex = 0;
            this.gbPendingCourses.TabStop = false;
            this.gbPendingCourses.Text = "Khóa học chờ duyệt";
            // 
            // dgvPending
            // 
            this.dgvPending.AllowUserToAddRows = false;
            this.dgvPending.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPending.BackgroundColor = System.Drawing.Color.White;
            this.dgvPending.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPending.ColumnHeadersHeight = 29;
            this.dgvPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPending.Location = new System.Drawing.Point(3, 26);
            this.dgvPending.Name = "dgvPending";
            this.dgvPending.RowHeadersVisible = false;
            this.dgvPending.RowHeadersWidth = 51;
            this.dgvPending.Size = new System.Drawing.Size(974, 161);
            this.dgvPending.TabIndex = 0;
            // 
            // gbRecentActivity
            // 
            this.gbRecentActivity.Controls.Add(this.dgvActivity);
            this.gbRecentActivity.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRecentActivity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbRecentActivity.Location = new System.Drawing.Point(10, 10);
            this.gbRecentActivity.Name = "gbRecentActivity";
            this.gbRecentActivity.Size = new System.Drawing.Size(980, 250);
            this.gbRecentActivity.TabIndex = 1;
            this.gbRecentActivity.TabStop = false;
            this.gbRecentActivity.Text = "Hoạt động gần đây";
            // 
            // dgvActivity
            // 
            this.dgvActivity.AllowUserToAddRows = false;
            this.dgvActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActivity.BackgroundColor = System.Drawing.Color.White;
            this.dgvActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActivity.ColumnHeadersHeight = 29;
            this.dgvActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivity.Location = new System.Drawing.Point(3, 26);
            this.dgvActivity.Name = "dgvActivity";
            this.dgvActivity.RowHeadersVisible = false;
            this.dgvActivity.RowHeadersWidth = 51;
            this.dgvActivity.Size = new System.Drawing.Size(974, 221);
            this.dgvActivity.TabIndex = 0;
            // 
            // DashboardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelTables);
            this.Controls.Add(this.panelStats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.panelStats.ResumeLayout(false);
            this.cardPending.ResumeLayout(false);
            this.cardPending.PerformLayout();
            this.cardTeachers.ResumeLayout(false);
            this.cardTeachers.PerformLayout();
            this.cardCourses.ResumeLayout(false);
            this.cardCourses.PerformLayout();
            this.cardUsers.ResumeLayout(false);
            this.cardUsers.PerformLayout();
            this.panelTables.ResumeLayout(false);
            this.gbPendingCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).EndInit();
            this.gbRecentActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        // Các biến này sẽ hiển thị trong Code Logic để ông gán dữ liệu
        public System.Windows.Forms.Label lblNumUsers;     // <-- Quan trọng
        public System.Windows.Forms.Label lblNumCourses;   // <-- Quan trọng
        public System.Windows.Forms.Label lblNumTeachers;  // <-- Quan trọng
        public System.Windows.Forms.Label lblNumPending;   // <-- Quan trọng
        public System.Windows.Forms.DataGridView dgvActivity; // <-- Quan trọng
        public System.Windows.Forms.DataGridView dgvPending;  // <-- Quan trọng

        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel cardUsers;
        private System.Windows.Forms.Label lblTitleUsers;
        private System.Windows.Forms.Label lblIconUsers;
        private System.Windows.Forms.Panel cardCourses;
        private System.Windows.Forms.Label lblTitleCourses;
        private System.Windows.Forms.Label lblIconCourses;
        private System.Windows.Forms.Panel cardTeachers;
        private System.Windows.Forms.Label lblTitleTeachers;
        private System.Windows.Forms.Label lblIconTeachers;
        private System.Windows.Forms.Panel cardPending;
        private System.Windows.Forms.Label lblTitlePending;
        private System.Windows.Forms.Label lblIconPending;
        private System.Windows.Forms.Panel panelTables;
        private System.Windows.Forms.GroupBox gbRecentActivity;
        private System.Windows.Forms.GroupBox gbPendingCourses;
    }
}