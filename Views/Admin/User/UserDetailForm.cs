using System;
using System.Windows.Forms;
using StudyProcessManagement.Business.Admin;
using StudyProcessManagement.Models;

namespace StudyProcessManagement.Views.Admin.User
{
    public partial class UserDetailForm : Form
    {
        // KHAI BÁO, TUYỆT ĐỐI KHÔNG "NEW" Ở ĐÂY
        private UserService userService;
        private string _userId;
        private bool _isViewOnly;

        public UserDetailForm(string userId = null, bool isViewOnly = false)
        {
            InitializeComponent();

  
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }

            // 2. KHỞI TẠO DỊCH VỤ
            userService = new UserService();
            _userId = userId;
            _isViewOnly = isViewOnly;

            // 3. KHỞI TẠO DỮ LIỆU GIAO DIỆN
            InitializeFormData();

            // 4. GÁN SỰ KIỆN
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void InitializeFormData()
        {
            // Đổ dữ liệu vào ComboBox Vai trò
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new string[] { "Admin", "Teacher", "Student" });
            cboRole.SelectedIndex = 2; // Mặc định là Student

            dtpDob.Value = DateTime.Now.AddYears(-18); // Mặc định 18 tuổi

            if (_userId == null)
            {
                // --- THÊM MỚI ---
                lblTitle.Text = "THÊM NGƯỜI DÙNG MỚI";
                chkActive.Visible = false; // Mặc định là Active, ẩn đi cho gọn
            }
            else
            {
                // --- CÓ ID -> LOAD DATA ---
                LoadUserData();

                if (_isViewOnly)
                {
                    // --- XEM CHI TIẾT ---
                    lblTitle.Text = "CHI TIẾT NGƯỜI DÙNG";
                    SetViewOnlyMode();
                }
                else
                {
                    
                    lblTitle.Text = "CẬP NHẬT THÔNG TIN";
                    txtEmail.Enabled = false; // Không cho sửa Email
                   
                }
            }
        }

        private void LoadUserData()
        {
            var user = userService.GetUserById(_userId);
            if (user != null)
            {
                txtName.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.PhoneNumber;
                cboRole.SelectedItem = user.Role;
                chkActive.Checked = user.IsActive;

                // Bổ sung 2 dòng này:
                txtAddress.Text = user.Address;
                if (user.DateOfBirth.HasValue)
                {
                    dtpDob.Value = user.DateOfBirth.Value;
                }
            }
        }

        private void SetViewOnlyMode()
        {
            gbAccount.Enabled = false;
            gbProfile.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Text = "Đóng";
            txtPassword.Visible = false;
            lblPassword.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên và Email!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var userModel = new Users()
            {
                UserID = _userId,
                FullName = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Role = cboRole.Text,
                IsActive = chkActive.Checked,
                Address = txtAddress.Text.Trim(),
                DateOfBirth = dtpDob.Value
            };
            bool success = false;
            try
            {
                if (_userId == null)
                {
                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu!"); return;
                    }
                    success = userService.AddUser(userModel, txtPassword.Text);
                }
                else
                {
                    success = userService.UpdateUser(userModel);
                }

                if (success)
                {
                    MessageBox.Show("Thao tác thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


    }
}