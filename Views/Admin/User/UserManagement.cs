using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StudyProcessManagement.Business.Admin;
using StudyProcessManagement.Models;
using StudyProcessManagement.Views.Admin.Student.StudentManagement;
using StudyProcessManagement.Views.Admin.Teacher.TeacherMangement;

namespace StudyProcessManagement.Views.Admin.User
{
    public partial class UserManagement : Form
    {
        private UserService userService = new UserService();

        public UserManagement()
        {
            InitializeComponent();
            // Set cứng kích thước form
            this.Size = new System.Drawing.Size(1324, 673);
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            // Đăng ký sự kiện
            //this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            //this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            //this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            //this.dataGridViewUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellContentClick_1);

            // Tải dữ liệu lên bảng
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                dataGridViewUsers.Rows.Clear();
                string keyword = txtSearch.Text.Trim();
                if (keyword == "Tìm kiếm người dùng...") keyword = "";

                List<Users> list = userService.GetAllUsers(keyword);
                if (list.Count == 0)
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        MessageBox.Show($"Không tìm thấy người dùng nào với từ khóa: '{keyword}'",
                                        "Kết quả tìm kiếm",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    return;
                }
                foreach (var u in list)
                {
                    int index = dataGridViewUsers.Rows.Add(
                        u.UserID,
                        u.FullName,
                        u.Email,
                        u.Role,
                        u.StatusText
                    );

                    if (u.IsActive)
                        dataGridViewUsers.Rows[index].Cells["colStatus"].Style.ForeColor = Color.Green;
                    else
                        dataGridViewUsers.Rows[index].Cells["colStatus"].Style.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

   
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            OpenDetailForm(null);
        }

        private void dataGridViewUsers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewUsers.Rows.Count) return;

            // 2. Lấy dòng hiện tại
            DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];

            // 3. Lấy ID và Tên (DÙNG SỐ THỨ TỰ CỘT THAY VÌ TÊN)
    
            string userId = row.Cells[0].Value?.ToString();
            string userName = row.Cells[1].Value?.ToString();

            // Kiểm tra nếu ID null (dòng lỗi) thì bỏ qua
            if (string.IsNullOrEmpty(userId)) return;

            // --- XỬ LÝ NÚT XÓA ---
            // Kiểm tra xem có phải bấm vào cột nút Xóa không?
   
            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa user '{userName}' (ID: {userId})?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (userService.DeleteUser(userId))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadUserData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // --- XỬ LÝ NÚT SỬA ---
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colEdit")
            {
                // Gọi form sửa
                OpenDetailForm(userId);
            }
            // --- XỬ LÝ NÚT XEM ---
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colView")
            {
                UserDetailForm form = new UserDetailForm(userId, true);
                form.ShowDialog();
            }
        }

        // Hàm mở Form chi tiết (Dùng chung cho Thêm & Sửa)
        private void OpenDetailForm(string userId)
        {
            UserDetailForm form = new UserDetailForm(userId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUserData();
            }
        }

        // Tìm kiếm
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Các hàm placeholder UI
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm người dùng...") { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Tìm kiếm người dùng..."; txtSearch.ForeColor = Color.Gray; }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang phát triển...");
        }

        // Chuyển trang (Menu)
        private void btnMenuTeachers_Click(object sender, EventArgs e)
        {
            var teacher = new TeacherMangement();
            this.Hide();
            teacher.Show();
        }

        private void btnMenuStudents_Click(object sender, EventArgs e)
        {
            var studentForm = new StudentManagement();
            this.Hide();
            studentForm.Show();
        }

        private void lblSearchIcon_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadUserData();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
          
        }
    }
}