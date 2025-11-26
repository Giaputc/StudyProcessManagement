using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StudyProcessManagement.Business.Admin;
using StudyProcessManagement.Models;
using StudyProcessManagement.Views.Admin.Teacher.TeacherMangement; 
using StudyProcessManagement.Views.Admin.User; 

namespace StudyProcessManagement.Views.Admin.Student.StudentManagement
{
    public partial class StudentManagement : Form
    {
        // Khởi tạo Service
        private StudentService studentService = new StudentService();

        public StudentManagement()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1324, 673);

            // Tải dữ liệu ngay khi mở form
            LoadStudentData();
        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {
            // Không cần làm gì thêm
        }

        // --- HÀM TẢI DỮ LIỆU ---
        private void LoadStudentData()
        {
            try
            {
                dataGridViewUsers.Rows.Clear();
                string keyword = txtSearch.Text.Trim();
                if (txtSearch.ForeColor == Color.Gray)
                {
                    keyword = "";
                }

                // Gọi Service
                List<Users> list = studentService.GetAllStudents(keyword);
                if (keyword == "Tìm kiếm học viên...") keyword = "";

                foreach (var u in list)
                {
                    int index = dataGridViewUsers.Rows.Add(
                        u.UserID,
                        u.FullName,
                        u.Email,
                        u.Role,
                        u.StatusText
                    );

                    // Tô màu trạng thái
                    if (u.IsActive)
                        dataGridViewUsers.Rows[index].Cells["colStatus"].Style.ForeColor = Color.Green;
                    else
                        dataGridViewUsers.Rows[index].Cells["colStatus"].Style.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // --- 1. NÚT THÊM HỌC VIÊN ---
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserDetailForm form = new UserDetailForm(null, false);

            // Thiết lập mặc định: Role là Student và Khóa lại không cho sửa
            form.cboRole.SelectedItem = "Student";
            form.cboRole.Enabled = false;

            if (form.ShowDialog() == DialogResult.OK) LoadStudentData();
        }

        // --- 2. XỬ LÝ SỰ KIỆN TRÊN BẢNG (XÓA / SỬA / XEM) ---
        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua header
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewUsers.Rows.Count) return;

            DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];
            string userId = row.Cells[0].Value?.ToString();
            string userName = row.Cells[1].Value?.ToString();

            if (string.IsNullOrEmpty(userId)) return;

            // XÓA
            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa học viên '{userName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (studentService.DeleteStudent(userId))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadStudentData();
                    }
                    else MessageBox.Show("Xóa thất bại!", "Lỗi");
                }
            }
            // SỬA
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colEdit")
            {
                OpenDetailForm(userId);
            }
            // XEM CHI TIẾT
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colView")
            {
                UserDetailForm form = new UserDetailForm(userId, true);
                form.ShowDialog();
            }
        }

        // Hàm phụ trợ mở form sửa
        private void OpenDetailForm(string userId)
        {
            UserDetailForm form = new UserDetailForm(userId, false);
            form.cboRole.Enabled = false; // Khóa role khi sửa luôn (Student thì mãi là Student)
            if (form.ShowDialog() == DialogResult.OK) LoadStudentData();
        }

        // --- 3. TÌM KIẾM ---
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Tìm kiếm học viên...") LoadStudentData();
        }

        private void lblSearchIcon_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadStudentData();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        // --- 4. PLACEHOLDER UI ---
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm học viên...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm học viên...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng đang phát triển...");
        }

        // Chuyển trang sang Teacher (nếu cần)
        private void btnMenuTeachers_Click(object sender, EventArgs e)
        {
            var teacher = new TeacherMangement();
            this.Hide();
            teacher.Show();
        }
    }
}