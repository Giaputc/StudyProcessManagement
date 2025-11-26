using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using StudyProcessManagement.Views.Login;
using StudyProcessManagement.Data;
using StudyProcessManagement.Business;
using System.Collections.Generic;
using System.Linq;
using static StudyProcessManagement.Data.StudentSession;
using StudyProcessManagement.Data;
namespace StudyProcessManagement.Views.Student.assignments
{

    public partial class assignments : Form
    {
        public WebView2 webView;
        private DataProcess dal = new DataProcess();
        StudyProcessManagement.Views.Student.assignments.assignments assignmentForm;
        // 2. Khởi tạo Form Điểm số (CẦN THÊM DÒNG NÀY)
        StudyProcessManagement.Views.Student.grades.student_grades gradesForm;
        public StudentInfoModel LoggedInStudent { get; set; }
        public assignments()
        {
            InitializeComponent();
            this.Load += assignments_Load;
        }
        public async Task InitializeWebViewAsync()
        {
            try
            {
                // ** KHỞI TẠO VÀ THÊM CONTROL **
                // Thêm WebView2 vào Controls nếu nó chưa được thêm
                if (webView == null)
                {
                    webView = new WebView2 { Dock = DockStyle.Fill };
                    this.Controls.Add(webView);
                    webView.BringToFront();
                }

                // ** KHỞI TẠO ENVIRONMENT RIÊNG (Đã tối ưu) **
                string userDataPath = Path.Combine(Path.GetTempPath(), "AssignmentWebView2Data");
                var environment = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(null, userDataPath);

                await webView.EnsureCoreWebView2Async(environment);
                // ** KẾT THÚC KHỞI TẠO **

                var htmlRelative = Path.Combine("Views", "Student", "assignments", "student-assignments.html");
                var htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, htmlRelative);

                if (!File.Exists(htmlPath))
                {
                    MessageBox.Show($"Lỗi: Không tìm thấy file HTML: {htmlPath}...", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
                    webView.NavigationCompleted += WebView_NavigationCompleted;

                    // Điều hướng tới file cục bộ
                    webView.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khởi tạo WebView2 Form Assignment thất bại: {ex.Message}", "WebView2 error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void assignments_Load(object sender, EventArgs e)
        {
            
        }
        private async void WebView_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            // Chúng ta chỉ tải dữ liệu khi trang HTML đã tải xong (NavigationCompleted)
            if (e.IsSuccess && webView.CoreWebView2 != null)
            {
                // 1. TRUY XUẤT USERID ĐÃ LƯU TRỮ
                string studentId = CurrentUserID;

                if (string.IsNullOrEmpty(studentId))
                {
                    MessageBox.Show("Lỗi: Không tìm thấy ID sinh viên. Vui lòng đăng nhập lại.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // 2. Dùng studentId để gọi Business Layer
                    List<AssignmentViewModel> assignments = dal.GetStudentAssignments(studentId);

                    // 3. Serialize và gửi sang JavaScript
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(assignments);
                    string script = $"updateAssignmentCard({jsonString})";
                    await webView.CoreWebView2.ExecuteScriptAsync(script);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi truy vấn DB hoặc thực thi JS: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void CoreWebView2_WebMessageReceived(object sender,
        Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
                string targetFileName = e.TryGetWebMessageAsString();
                if (targetFileName == "LOGOUT")
                {
                    // 🔥 ĐÃ SỬA: Gói thao tác UI vào Invoke để an toàn và quản lý luồng đóng Form
                    this.Invoke((MethodInvoker)delegate
                    {
                        StudyProcessManagement.Views.Login.Login loginForm = new StudyProcessManagement.Views.Login.Login();
                        this.Hide(); // Ẩn Form hiện tại
                        loginForm.ShowDialog(); // Hiển thị Form Login
                        this.Close(); // Đóng Form Assignment sau khi Form Login đóng
                    });
                }

                else if (targetFileName == "student-discover.html")
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        // 1. Xây dựng đường dẫn tương đối đến file đích
                        // LƯU Ý: Đã sửa thư mục từ "SinhVien" thành "Student" (nhất quán với các Form khác)
                        string targetRelativePath = Path.Combine("Views", "Student", "discover", targetFileName);

                        // 2. Xây dựng đường dẫn tuyệt đối
                        string targetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, targetRelativePath);

                        if (File.Exists(targetPath))
                        {
                            // 3. Thực hiện điều hướng
                            webView.CoreWebView2.Navigate(new Uri(targetPath).AbsoluteUri);
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi: Không tìm thấy file HTML đích: {targetPath}", "Lỗi Điều hướng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }

            }

       

        // Các phương thức được tạo bởi Designer
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}