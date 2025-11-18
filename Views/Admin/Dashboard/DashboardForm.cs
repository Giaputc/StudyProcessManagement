using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Admin.Dashboard
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            LoadDashboardData(); // Chỉ cần gọi hàm này
        }

        // Hàm này là nơi ông sẽ viết code Backend sau này
        private void LoadDashboardData()
        {
            // --- PHẦN 1: ĐỔ SỐ LIỆU THỐNG KÊ ---
            // Sau này ông thay số cứng bằng: db.Users.Count().ToString();
            lblNumUsers.Text = "2,547";
            lblNumCourses.Text = "142";
            lblNumTeachers.Text = "85";
            lblNumPending.Text = "12";

            // --- PHẦN 2: ĐỔ DỮ LIỆU BẢNG (DATAGRIDVIEW) ---
            // Sau này ông gán: dgvActivity.DataSource = db.GetActivities();

            // Setup cột cho bảng Activity
            dgvActivity.Columns.Clear();
            dgvActivity.Columns.Add("User", "Người dùng");
            dgvActivity.Columns.Add("Role", "Vai trò");
            dgvActivity.Columns.Add("Action", "Hoạt động");
            dgvActivity.Columns.Add("Time", "Thời gian");

            // Thêm dữ liệu giả
            dgvActivity.Rows.Add("Nguyễn Văn A", "Giảng viên", "Tạo khóa học Web", "2 giờ trước");
            dgvActivity.Rows.Add("Trần Thị B", "Học viên", "Đăng ký Python", "5 giờ trước");

            // Setup cột cho bảng Pending
            dgvPending.Columns.Clear();
            dgvPending.Columns.Add("Course", "Tên khóa học");
            dgvPending.Columns.Add("Teacher", "Giảng viên");

            // Thêm nút Duyệt
            DataGridViewButtonColumn btnApprove = new DataGridViewButtonColumn();
            btnApprove.HeaderText = "Thao tác";
            btnApprove.Text = "Duyệt";
            btnApprove.UseColumnTextForButtonValue = true;
            dgvPending.Columns.Add(btnApprove);

            // Thêm dữ liệu giả
            dgvPending.Rows.Add("Lập trình Web React", "Nguyễn Văn A");
            dgvPending.Rows.Add("Tiếng Anh Giao Tiếp", "Trần Văn B");
        }
    }
}