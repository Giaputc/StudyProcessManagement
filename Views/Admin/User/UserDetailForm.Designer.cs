namespace StudyProcessManagement.Views.Admin.User
{
    partial class UserDetailForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.gbProfile = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.lblDob = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.gbProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(684, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(684, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN NGƯỜI DÙNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.chkActive);
            this.gbAccount.Controls.Add(this.cboRole);
            this.gbAccount.Controls.Add(this.lblRole);
            this.gbAccount.Controls.Add(this.txtPassword);
            this.gbAccount.Controls.Add(this.lblPassword);
            this.gbAccount.Controls.Add(this.txtEmail);
            this.gbAccount.Controls.Add(this.lblEmail);
            this.gbAccount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbAccount.Location = new System.Drawing.Point(20, 80);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(310, 300);
            this.gbAccount.TabIndex = 1;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Thông tin đăng nhập";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(20, 250);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(163, 27);
            this.chkActive.TabIndex = 6;
            this.chkActive.Text = "Đang hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(20, 195);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(270, 31);
            this.cboRole.TabIndex = 5;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(20, 170);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(76, 23);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Vai trò *";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(20, 125);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(270, 30);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 100);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(99, 23);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Mật khẩu *";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(20, 55);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(270, 30);
            this.txtEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 30);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(67, 23);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email *";
            // 
            // gbProfile
            // 
            this.gbProfile.Controls.Add(this.txtAddress);
            this.gbProfile.Controls.Add(this.lblAddress);
            this.gbProfile.Controls.Add(this.dtpDob);
            this.gbProfile.Controls.Add(this.lblDob);
            this.gbProfile.Controls.Add(this.txtPhone);
            this.gbProfile.Controls.Add(this.lblPhone);
            this.gbProfile.Controls.Add(this.txtName);
            this.gbProfile.Controls.Add(this.lblName);
            this.gbProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbProfile.Location = new System.Drawing.Point(350, 80);
            this.gbProfile.Name = "gbProfile";
            this.gbProfile.Size = new System.Drawing.Size(310, 300);
            this.gbProfile.TabIndex = 2;
            this.gbProfile.TabStop = false;
            this.gbProfile.Text = "Thông tin cá nhân";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(20, 265);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(270, 30);
            this.txtAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 240);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 23);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // dtpDob
            // 
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(20, 195);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(270, 30);
            this.dtpDob.TabIndex = 5;
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Location = new System.Drawing.Point(20, 170);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(89, 23);
            this.lblDob.TabIndex = 4;
            this.lblDob.Text = "Ngày sinh";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(20, 125);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(270, 30);
            this.txtPhone.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 100);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(116, 23);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Số điện thoại";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(20, 55);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 30);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ và tên *";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(460, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "💾 LƯU LẠI";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(310, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // UserDetailForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbProfile);
            this.Controls.Add(this.gbAccount);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết người dùng";
            this.pnlHeader.ResumeLayout(false);
            this.gbAccount.ResumeLayout(false);
            this.gbAccount.PerformLayout();
            this.gbProfile.ResumeLayout(false);
            this.gbProfile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.GroupBox gbProfile;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}