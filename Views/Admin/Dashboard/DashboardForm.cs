
using StudyProcessManagement.Business.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace StudyProcessManagement.Views.Admin.Dashboard
{
    public partial class DashboardForm : Form
    {
        private DashboardService dashboardService = new DashboardService();
        public DashboardForm()
        {
            InitializeComponent();
            LoadDashboardData(); // Chỉ cần gọi hàm này
        }

        // Hàm này là nơi ông sẽ viết code Backend sau này
        private void LoadDashboardData()
        {
            try
            { // --- PHẦN 1: ĐỔ SỐ LIỆU THỐNG KÊ --- 
                var status = dashboardService.GetDashboardStatus();
                lblNumUsers.Text = status["Users"].ToString();
                lblNumCourses.Text = status["Courses"].ToString();
                lblNumTeachers.Text = status["Teacher"].ToString();
                lblNumPending.Text = status["PendingCourses"].ToString();

                // --- PHẦN 2: ĐỔ DỮ LIỆU BẢNG (DATAGRIDVIEW) ---


                // Setup cột cho bảng Activity
                DataTable dtActivity = dashboardService.GetRecentActivities();

                dgvActivity.Columns.Clear();
                dgvActivity.Columns.Add("User", "Người dùng");
                dgvActivity.Columns.Add("Role", "Vai trò");
                dgvActivity.Columns.Add("Action", "Hoạt động");
                dgvActivity.Columns.Add("Time", "Thời gian");

                foreach (DataRow row in dtActivity.Rows)
                {
                    dgvActivity.Rows.Add(row["UserName"], row["Role"], row["Action"], row["Time"]);
                }

                // Setup cột cho bảng Pending
                DataTable dtPending = dashboardService.GetPendingCourses();

                dgvPending.Columns.Clear();
                dgvPending.Columns.Add("Course", "Tên khóa học");
                dgvPending.Columns.Add("Teacher", "Giảng viên");

                // Thêm cột nút Duyệt
                //DataGridViewButtonColumn btnApprove = new DataGridViewButtonColumn();
             
                //btnApprove.UseColumnTextForButtonValue = true;
                //dgvPending.Columns.Add(btnApprove);

                foreach (DataRow row in dtPending.Rows)
                {
                    dgvPending.Rows.Add(row["CourseName"], row["TeacherName"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bảng điều khiển: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }


        private void lblNumUsers_Click(object sender, EventArgs e)
        {

        }
    }
}