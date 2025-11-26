using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StudyProcessManagement.Business.Admin;
using StudyProcessManagement.Models;
using StudyProcessManagement.Views.Admin.User;

namespace StudyProcessManagement.Views.Admin.Teacher.TeacherMangement
{
    public partial class TeacherMangement : Form
    {
       
        private TeacherService teacherService = new TeacherService();

        public TeacherMangement()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1324, 673);

            // Tải dữ liệu ngay khi mở
            LoadTeacherData();
        }

        private void TeacherMangement_Load(object sender, EventArgs e)
        {
            
        }

        
        private void LoadTeacherData()
        {
            try
            {
                dataGridViewUsers.Rows.Clear();
                string keyword = txtSearch.Text.Trim();
                if (keyword == "Tìm kiếm người dùng...") keyword = "";

                // Gọi Service lấy danh sách Teacher
                List<Users> list = teacherService.GetAllTeachers(keyword);

                // (Đoạn kiểm tra rỗng này có thể bỏ nếu muốn form luôn hiện trống khi ko có data)
                // if (list.Count == 0 && !string.IsNullOrEmpty(keyword)) { ... }

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
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // 1. NÚT THÊM MỚI
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserDetailForm form = new UserDetailForm(null, false);

           
            form.cboRole.SelectedItem = "Teacher";
            form.cboRole.Enabled = false;

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTeacherData(); 
            }
        }
        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewUsers.Rows.Count) return;

            DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];

            // Lấy ID và Tên (Dùng chỉ số cột 0 và 1 cho chắc ăn)
            string userId = row.Cells[0].Value?.ToString();
            string userName = row.Cells[1].Value?.ToString();

            if (string.IsNullOrEmpty(userId)) return;

            // --- XÓA ---
            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (MessageBox.Show($"Bạn có chắc muốn xóa giảng viên '{userName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (teacherService.DeleteTeacher(userId)) // Gọi TeacherService
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadTeacherData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi");
                    }
                }
            }
         
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colEdit")
            {
                OpenDetailForm(userId);
            }
           
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "colView")
            {
                UserDetailForm form = new UserDetailForm(userId, true);
                form.ShowDialog();
            }
        }

       
        private void OpenDetailForm(string userId)
        {
            UserDetailForm form = new UserDetailForm(userId, false);

            // Khi sửa cũng khóa Role lại luôn cho chắc
            form.cboRole.Enabled = false;

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTeacherData();
            }
        }

       
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Tìm kiếm người dùng...") LoadTeacherData();
        }

        private void lblSearchIcon_Click(object sender, EventArgs e)
        {
            LoadTeacherData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadTeacherData();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        // Placeholder
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm người dùng...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm người dùng...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e) { }
    }
}