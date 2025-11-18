// StudyProcessManagement.Views.Admin.StudentManagement.UserManagement.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyProcessManagement.Views.Admin.Student.StudentManagement;
using StudyProcessManagement.Views.Admin.Teacher.TeacherMangement;
namespace StudyProcessManagement.Views.Admin.User
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
            // Cấu hình chung cho các nút menu
        }

        // Tải form: Nơi ông sẽ load dữ liệu từ database vào DataGridView
        private void UserManagement_Load(object sender, EventArgs e)
        {
            // Gán sự kiện cho các nút
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.Size = new System.Drawing.Size(1324, 673);
            // Tải dữ liệu
            LoadUserData();
        }

        // Hàm giả lập tải dữ liệu (thay bằng logic database của ông)
        private void LoadUserData()
        {
            // Xóa dữ liệu cũ (nếu có)
            dataGridViewUsers.Rows.Clear();

            // Thêm dữ liệu mẫu giống như file HTML
            dataGridViewUsers.Rows.Add("001", "Nguyễn Văn A", "nguyenvana@email.com", "Giảng viên", "Hoạt động");
            dataGridViewUsers.Rows.Add("002", "Trần Thị B", "tranthib@email.com", "Học viên", "Hoạt động");
            dataGridViewUsers.Rows.Add("003", "Lê Văn C", "levanc@email.com", "Giảng viên", "Đã khóa");
            dataGridViewUsers.Rows.Add("004", "Phạm Thị D", "phamthid@email.com", "Học viên", "Hoạt động");

            // Ông nên dùng DataTable hoặc List<User> gán vào DataSource
            // ví dụ: dataGridViewUsers.DataSource = GetUsersFromDatabase();
        }

        // Xử lý sự kiện khi click vào các nút "Xem", "Sửa", "Xóa" trong bảng
        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header
            if (e.RowIndex < 0) return;

            // Lấy ID của user ở hàng được click
            string userId = dataGridViewUsers.Rows[e.RowIndex].Cells["colId"].Value.ToString();

            // Kiểm tra xem đã click vào cột nút nào
            if (e.ColumnIndex == dataGridViewUsers.Columns["colView"].Index)
            {
                // Logic nút "Xem"
                MessageBox.Show($"Xem chi tiết người dùng ID: {userId}");
            }
            else if (e.ColumnIndex == dataGridViewUsers.Columns["colEdit"].Index)
            {
                // Logic nút "Sửa"
                // Đây là lúc gọi "Modal" (Form mới)
                OpenAddEditUserForm(userId);
            }
            else if (e.ColumnIndex == dataGridViewUsers.Columns["colDelete"].Index)
            {
                // Logic nút "Xóa"
                var result = MessageBox.Show($"Bạn có chắc muốn xóa người dùng ID: {userId}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện logic xóa...
                    MessageBox.Show($"Đã xóa người dùng ID: {userId}");
                    // Tải lại dữ liệu
                    LoadUserData();
                }
            }
        }

        // Sự kiện cho nút "Thêm người dùng"
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            OpenAddEditUserForm(null); // Gọi với ID null để báo là "thêm mới"
        }

        // Sự kiện cho nút "Xuất Excel"
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang thực hiện logic xuất Excel...");
            // Thêm logic xuất Excel của ông ở đây
        }


        // Hàm gọi "Modal" (Form mới)
        private void OpenAddEditUserForm(string userId = null)
        {
            // Ông sẽ cần tạo một Form mới tên là AddEditUserForm
            // AddEditUserForm modalForm = new AddEditUserForm(userId);

            // Dùng ShowDialog() để nó chặn form cha, giống hệt modal HTML
            // var result = modalForm.ShowDialog();

            // if (result == DialogResult.OK)
            // {
            //    // Nếu form kia lưu thành công thì tải lại dữ liệu
            //    LoadUserData();
            // }

            // Giả lập
            if (userId == null)
            {
                MessageBox.Show("Mở form THÊM MỚI người dùng...");
            }
            else
            {
                MessageBox.Show($"Mở form SỬA người dùng ID: {userId}...");
            }

            // Tải lại dữ liệu (để giả lập)
            // LoadUserData(); // Bỏ comment khi dùng form thật
        }

        // Xử lý logic placeholder cho ô tìm kiếm
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

        private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenuDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuUsers_Click(object sender, EventArgs e)
        {

        }

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

        private void btnMenuCourses_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void lblSidebarHeader_Click(object sender, EventArgs e)
        {

        }

        private void panelMainContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelToolbar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSearchIcon_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click_1(object sender, EventArgs e)
        {

        }

        private void panelTopbar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblBreadcrumb_Click(object sender, EventArgs e)
        {

        }
    }
}