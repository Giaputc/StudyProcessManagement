using Microsoft.Web.WebView2.WinForms;
using StudyProcessManagement.Business;
using StudyProcessManagement.Data;
using StudyProcessManagement.Views.Login;
using StudyProcessManagement.Views.Student.main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudyProcessManagement.Data.StudentSession;

namespace StudyProcessManagement.Views.Student.main
{
    public partial class main : Form
    {
        private WebView2 webView;
        private StudentInfoModel LoggedInStudent { get; set; }

        // 1. Constructor: Nhận thông tin sinh viên khi khởi tạo
        public main(StudentInfoModel studentInfo)
        {
            InitializeComponent();
            this.LoggedInStudent = studentInfo;

            // Cập nhật thông tin sinh viên vào lớp tĩnh StudentSession
            CurrentStudent = studentInfo;
            CurrentUserID = studentInfo.UserID;

            this.Load += main_Load;
            this.FormClosing += new FormClosingEventHandler(main_FormClosing);
        }

        // Constructor mặc định (cần thiết cho Designer hoặc khởi tạo không có dữ liệu)
        public main() : this(null) { }

        // 2. Xử lý sự kiện đóng Form (Đăng xuất/Thoát ứng dụng)
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn đóng ứng dụng và đăng xuất không?",
                    "Xác nhận đóng ứng dụng",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        // 3. Xử lý sự kiện tải Form (Khởi tạo WebView2 và điều hướng ban đầu)
        private async void main_Load(object sender, EventArgs e)
        {
            if (this.LoggedInStudent == null)
            {
                MessageBox.Show("Không có dữ liệu sinh viên. Vui lòng đăng nhập lại.", "Lỗi Khởi tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Khởi tạo và thêm Control
                webView = new WebView2 { Dock = DockStyle.Fill };
                this.Controls.Add(webView);
                webView.BringToFront();

                // Sử dụng UserID để tạo đường dẫn cache riêng cho từng sinh viên
                string studentCacheDir = this.LoggedInStudent.UserID.Replace("/", "_").Replace("\\", "_");
                string userDataPath = Path.Combine(Path.GetTempPath(), "StudyProcessWebView2Data", studentCacheDir);

                // Đảm bảo thư mục tồn tại
                Directory.CreateDirectory(userDataPath);

                var environment = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(null, userDataPath);
                await webView.EnsureCoreWebView2Async(environment);

                if (webView.CoreWebView2 == null)
                {
                    MessageBox.Show("Lỗi: CoreWebView2 vẫn là null.", "WebView2 Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gắn sự kiện và Điều hướng ban đầu đến trang thông tin
                webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
                webView.NavigationCompleted += WebView_NavigationCompleted;

                // Điều hướng đến trang thông tin sinh viên (Đây là trang mặc định)
                var initialRelative = Path.Combine("Views", "Student", "information", "studient-information.html");
                var initialPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, initialRelative);

                if (File.Exists(initialPath))
                {
                    webView.CoreWebView2.Navigate(new Uri(initialPath).AbsoluteUri);
                }
                else
                {
                    MessageBox.Show($"Lỗi: Không tìm thấy file HTML mặc định: {initialPath}", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khởi tạo WebView2 thất bại: {ex.Message}", "WebView2 error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Logic tải dữ liệu sau khi Điều hướng Hoàn tất (C# -> JS)
        private async void WebView_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess || webView.CoreWebView2 == null) return;

            string currentUri = webView.CoreWebView2.Source;
            string scriptToSend = null;
            DataProcess dal = new DataProcess();

            // 1. Logic tải Dữ liệu Thông tin Cá nhân
            if (currentUri.Contains("studient-information.html"))
            {
                StudentInfoModel studentInfo = this.LoggedInStudent;

                if (studentInfo != null)
                {
                    var dataToSend = new
                    {
                        AccountID = studentInfo.UserID,
                        FullName = studentInfo.FullName,
                        ContactEmail = studentInfo.Email,
                        Address = studentInfo.Address,
                        DateOfBirth = studentInfo.DateOfBirth.HasValue
                                            ? studentInfo.DateOfBirth.Value.ToString("yyyy-MM-dd")
                                            : "",
                        PhoneNumber = studentInfo.PhoneNumber,
                        UserName = studentInfo.FullName,
                        AvatarUrl = studentInfo.AvatarUrl,
                        TestStatus = 1,
                    };

                    string jsonString = System.Text.Json.JsonSerializer.Serialize(dataToSend);
                    scriptToSend = $"updateStudentInfo({jsonString})";
                }
            }
            // 2. Logic tải Dữ liệu Khóa học
            else if (currentUri.Contains("student-my-courses.html"))
            {
                string studentId = this.LoggedInStudent.UserID;
                List<StudentCourseViewModel> myCourses = dal.GetMyCourses(studentId);
                string coursesJson = System.Text.Json.JsonSerializer.Serialize(myCourses);

                string safeCoursesJson = coursesJson
                    .Replace("\\", "\\\\").Replace("\n", " ").Replace("\r", " ").Replace("'", "\\'").Replace("\"", "\\\"");

                scriptToSend = $"window.updateMyCourses('{safeCoursesJson}')";
            }
            // 3. Logic tải Dữ liệu Tài nguyên (Lessons/Assignments)
            else if (currentUri.Contains("student-content.html"))
            {
                string studentId = this.LoggedInStudent.UserID;
                List<StudentContent> studentContentList = dal.GetAllResources(studentId);
                string contentJson = System.Text.Json.JsonSerializer.Serialize(studentContentList);

                string safeContentJson = contentJson
                    .Replace("\\", "\\\\").Replace("\n", " ").Replace("\r", " ").Replace("'", "\\'").Replace("\"", "\\\"");

                scriptToSend = $"window.renderResources('{safeContentJson}')";
            }
            // 4. Logic tải Dữ liệu Điểm số - **FIXED CACHE ISSUE**
            else if (currentUri.Contains("student-grades.html"))
            {
                // **THÊM DELAY ĐỂ ĐẢM BẢO DOM ĐÃ RESET**
                await Task.Delay(100);

                string studentId = this.LoggedInStudent.UserID;
                StudentOverallStats overallStats = dal.GetOverallStats(studentId);
                List<CourseSummary> courseSummaries = dal.GetCourseSummary(studentId);

                var dataForGrades = new { Overall = overallStats, Courses = courseSummaries };

                var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string gradesJson = System.Text.Json.JsonSerializer.Serialize(dataForGrades, jsonOptions);

                // **ESCAPE JSON AN TOÀN HƠN**
                string safeJson = gradesJson
                    .Replace("\\", "\\\\")
                    .Replace("\n", "\\n")
                    .Replace("\r", "\\r")
                    .Replace("'", "\\'")
                    .Replace("\"", "\\\"");

                scriptToSend = $"window.updateGradesAndSummary('{safeJson}')";

                // **LOG ĐỂ DEBUG**
                System.Diagnostics.Debug.WriteLine($"[GRADES] Sending data: {gradesJson.Substring(0, Math.Min(200, gradesJson.Length))}...");
            }
            // 5. Logic tải Dữ liệu Bài tập
            else if (currentUri.Contains("student-assignments.html"))
            {
                string studentId = this.LoggedInStudent.UserID;
                List<AssignmentViewModel> assignments = dal.GetStudentAssignments(studentId);

                var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string assignmentsJson = System.Text.Json.JsonSerializer.Serialize(assignments, jsonOptions);

                string safeJson = assignmentsJson
                    .Replace("\\", "\\\\").Replace("\n", " ").Replace("\r", " ").Replace("'", "\\'").Replace("\"", "\\\"");

                scriptToSend = $"window.updateAssignments('{safeJson}')";
            }

            // Thực thi script nếu có
            if (scriptToSend != null)
            {
                try
                {
                    await webView.CoreWebView2.ExecuteScriptAsync(scriptToSend);
                    System.Diagnostics.Debug.WriteLine($"[SUCCESS] Script executed for: {currentUri}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi thực thi JS: {ex.Message}", "WebView2 Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // **CẢI TIẾN HÀM ClearCache - XÓA CACHE MẠNH MẼ HƠN**
        private async Task ClearWebViewCacheAsync()
        {
            if (webView?.CoreWebView2 != null)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("[CACHE] Clearing WebView2 cache...");

                    await webView.CoreWebView2.Profile.ClearBrowsingDataAsync(
                        Microsoft.Web.WebView2.Core.CoreWebView2BrowsingDataKinds.AllDomStorage |
                        Microsoft.Web.WebView2.Core.CoreWebView2BrowsingDataKinds.CacheStorage |
                        Microsoft.Web.WebView2.Core.CoreWebView2BrowsingDataKinds.DiskCache |
                        Microsoft.Web.WebView2.Core.CoreWebView2BrowsingDataKinds.IndexedDb
                    );

                    System.Diagnostics.Debug.WriteLine("[CACHE] Cache cleared successfully");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[CACHE ERROR] {ex.Message}");
                }
            }
        }

        // HÀM XỬ LÝ NỘP BÀI (Giữ nguyên)
        // HÀM XỬ LÝ NỘP BÀI (ĐÃ CẬP NHẬT ĐƯỜNG DẪN LƯU TRỮ AN TOÀN)
        private async Task HandleLocalFileSubmission(AssignmentSubmissionData data)
        {
            // Kiểm tra tính hợp lệ cơ bản
            if (string.IsNullOrEmpty(data.FileBase64) || string.IsNullOrEmpty(data.FileName))
            {
                System.Diagnostics.Debug.WriteLine("[SUBMISSION ERROR] Base64 content or file name is empty.");
                await webView.CoreWebView2.ExecuteScriptAsync($"window.handleSubmissionResponse({data.AssignmentID}, false, 'Lỗi: Thiếu nội dung hoặc tên file.')");
                return;
            }

            // ⭐ 1. XÁC ĐỊNH ĐƯỜNG DẪN LƯU TRỮ CUỐI CÙNG (DÙNG ProgramData) ⭐

            // Sử dụng ProgramData (Vị trí ổn định: C:\ProgramData\StudyProcessManagement\Submissions)
            string baseSubmissionDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "StudyProcessManagement", // Tên thư mục ứng dụng của bạn
                "Submissions"
            );

            // Bỏ qua data.RootPath để đảm bảo tính nhất quán
            System.Diagnostics.Debug.WriteLine($"[DEBUG PATH] Base Submission Dir Used: {baseSubmissionDir}");

            // Chuẩn hóa tên khóa học để đảm bảo an toàn I/O
            string safeCourseName = data.CourseName;
            char[] invalidChars = Path.GetInvalidFileNameChars().Concat(Path.GetInvalidPathChars()).Distinct().ToArray();

            foreach (char c in invalidChars)
            {
                // Làm sạch tên thư mục con
                safeCourseName = safeCourseName.Replace(c.ToString(), "_");
            }

            // Tạo đường dẫn thư mục khóa học: C:\ProgramData\StudyProcessManagement\Submissions\Tên_Khóa_Học\
            string courseDir = Path.Combine(baseSubmissionDir, safeCourseName);

            try
            {
                Directory.CreateDirectory(courseDir); // Đảm bảo thư mục khóa học tồn tại
                System.Diagnostics.Debug.WriteLine($"[SUCCESS DIR] Directory created: {courseDir}");
            }
            catch (Exception ex)
            {
                // Ghi lỗi nếu không tạo được thư mục
                System.Diagnostics.Debug.WriteLine($"[SUBMISSION ERROR] Could not create directory {courseDir}: {ex.Message}");
                await webView.CoreWebView2.ExecuteScriptAsync($"window.handleSubmissionResponse({data.AssignmentID}, false, 'Lỗi tạo thư mục lưu trữ: {ex.Message.Replace("'", "`")}')");
                return;
            }

            // Tạo tên file duy nhất (UserID_AssignmentID_FileName)
            string safeStudentId = this.LoggedInStudent.UserID.Replace("/", "_").Replace("\\", "_");
            // Đảm bảo chỉ lấy tên file cuối cùng
            string finalFileName = Path.GetFileName(data.FileName);
            string uniqueFileName = $"{safeStudentId}_{data.AssignmentID}_{finalFileName}";

            // ⭐ ĐƯỜNG DẪN CUỐI CÙNG LƯU FILE VÀ TRUYỀN VÀO SQL ⭐
            string filePath = Path.Combine(courseDir, uniqueFileName);

            // 2. Chuyển đổi Base64 thành byte array
            byte[] fileBytes;
            try
            {
                string base64Data = data.FileBase64.Split(',').Last();
                fileBytes = Convert.FromBase64String(base64Data);
                System.Diagnostics.Debug.WriteLine($"[DEBUG FILE SIZE] Decoded byte array length: {fileBytes.Length} bytes");

                if (fileBytes.Length == 0) throw new Exception("Base64 decoding resulted in 0 bytes.");
            }
            catch (FormatException ex)
            {
                System.Diagnostics.Debug.WriteLine($"[SUBMISSION ERROR] Invalid Base64 string: {ex.Message}");
                await webView.CoreWebView2.ExecuteScriptAsync($"window.handleSubmissionResponse({data.AssignmentID}, false, 'Lỗi chuyển đổi Base64.')");
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[SUBMISSION ERROR] Empty file content: {ex.Message}");
                await webView.CoreWebView2.ExecuteScriptAsync($"window.handleSubmissionResponse({data.AssignmentID}, false, 'Lỗi: Nội dung file trống.')");
                return;
            }

            // 3. Lưu file vật lý
            bool fileSaved = false;
            try
            {
                // Task.Run để không chặn UI thread trong quá trình ghi file
                await Task.Run(() => File.WriteAllBytes(filePath, fileBytes));
                System.Diagnostics.Debug.WriteLine($"[SUCCESS] File saved to: {filePath}");
                fileSaved = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[FILE SAVE ERROR] Could not save file to {filePath}: {ex.Message}");
                await webView.CoreWebView2.ExecuteScriptAsync($"window.handleSubmissionResponse({data.AssignmentID}, false, 'Lỗi lưu file: {ex.Message.Replace("'", "`")}')");
                return;
            }

            // 4. Cập nhật thông tin nộp bài vào Database (Giữ nguyên)
            if (fileSaved)
            {
                try
                {
                    DataProcess dal = new DataProcess();
                    int submissionId = dal.InsertSubmission(
                        data.AssignmentID,
                        this.LoggedInStudent.UserID,
                        filePath, // Lưu đường dẫn mới (ProgramData) vào SQL
                        data.StudentNote
                    );
                    if (submissionId > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DB SUCCESS] Assignment ID {data.AssignmentID} updated in DB. Submission ID: {submissionId}");
                        await webView.CoreWebView2.ExecuteScriptAsync($"window.handleSubmissionResponse({data.AssignmentID}, true, 'Nộp bài thành công. Mã nộp bài: {submissionId}')");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[DB FAILED] Failed to update assignment submission for ID {data.AssignmentID}.");
                        await webView.CoreWebView2.ExecuteScriptAsync($"window.handleSubmissionResponse({data.AssignmentID}, false, 'Lỗi: Cập nhật CSDL thất bại.')");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[DB ERROR] Database update failed: {ex.Message}");
                    await webView.CoreWebView2.ExecuteScriptAsync($"window.handleSubmissionResponse({data.AssignmentID}, false, 'Lỗi: Kết nối CSDL bị lỗi: {ex.Message.Replace("'", "`")}')");
                }
            }
        }
        // 5. Xử lý Thông điệp từ Web (JS -> C#)
        private async void CoreWebView2_WebMessageReceived(object sender,
            Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            string message = e.TryGetWebMessageAsString();
            string targetRelativePath = null;
            DataProcess dal = new DataProcess();

            // Xử lý các tin nhắn chuỗi đơn giản (Điều hướng Menu)
            if (message == "LOGOUT")
            {
                this.Invoke((MethodInvoker)delegate
                {
                    StudyProcessManagement.Views.Login.Login loginForm = new StudyProcessManagement.Views.Login.Login();
                    this.Hide();
                    loginForm.ShowDialog();
                    this.Close();
                });
                return;
            }
            else if (message == "INFORMATION" || message == "PROFILE")
            {
                targetRelativePath = Path.Combine("Views", "Student", "information", "studient-information.html");
            }
            else if (message == "GRADES")
            {
                // **QUAN TRỌNG: XÓA CACHE TRƯỚC KHI ĐIỀU HƯỚNG**
                await ClearWebViewCacheAsync();
                await Task.Delay(50);

                targetRelativePath = Path.Combine("Views", "Student", "grades", "student-grades.html");
            }
            else if (message == "MY_COURSES")
            {
                targetRelativePath = Path.Combine("Views", "Student", "courses", "student-my-courses.html");
            }
            else if (message == "CONTENT")
            {
                targetRelativePath = Path.Combine("Views", "Student", "content", "student-content.html");
            }
            else if (message == "DISCOVER")
            {
                targetRelativePath = Path.Combine("Views", "Student", "discover", "student-discover.html");
            }
            else if (message == "ASSIGNMENT")
            {
                targetRelativePath = Path.Combine("Views", "Student", "assignments", "student-assignments.html");
            }

            // 💥 KHỐI XỬ LÝ THÔNG ĐIỆP JSON (Submission và các lệnh khác)
            try
            {
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                // Thử Deserialize thành AssignmentSubmissionData để lấy toàn bộ dữ liệu (kể cả Base64)
                var messageData = System.Text.Json.JsonSerializer.Deserialize<AssignmentSubmissionData>(message, jsonOptions);

                if (messageData != null && !string.IsNullOrEmpty(messageData.Action))
                {
                    if (messageData.Action == "SUBMIT_ASSIGNMENT_SAVE_LOCAL")
                    {
                        // 🚀 Xử lý NỘP BÀI TẬP (Lưu vào C:\Submissions)
                        await HandleLocalFileSubmission(messageData);
                        return;
                    }
                    else if (messageData.Action == "OPEN_URL")
                    {
                        if (!string.IsNullOrEmpty(messageData.URL))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(messageData.URL) { UseShellExecute = true });
                        }
                        return;
                    }
                    else if (messageData.Action == "OPEN_ASSIGNMENT_DETAIL")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Bạn vừa nhấn vào Bài tập ID: {messageData.AssignmentID}. (Logic chi tiết)",
                                            "Chi tiết Bài tập",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        });
                        return;
                    }
                }
            }
            catch (System.Text.Json.JsonException ex)
            {
                // Debug log cho trường hợp chuỗi không phải JSON hợp lệ, tiếp tục xử lý điều hướng
                System.Diagnostics.Debug.WriteLine($"[JSON ERROR] Message is not valid JSON or structure mismatch: {ex.Message}");
            }

            // Khối logic điều hướng chung (áp dụng cho các tin nhắn chuỗi đơn giản)
            if (targetRelativePath != null)
            {
                string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, targetRelativePath);

                this.Invoke((MethodInvoker)delegate
                {
                    if (File.Exists(htmlPath))
                    {
                        // **THÊM CACHE BUSTER VÀO URL**
                        string cacheBuster = DateTime.Now.Ticks.ToString();
                        string finalUri = $"{new Uri(htmlPath).AbsoluteUri}?v={cacheBuster}";

                        System.Diagnostics.Debug.WriteLine($"[NAV] Navigating to: {finalUri}");
                        webView.CoreWebView2.Navigate(finalUri);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi: Không tìm thấy file HTML: {htmlPath}", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                });
            }
        }
    }
}

// Giữ nguyên các lớp này bên ngoài lớp 'main'
public class WebViewMessage
{
    public string Action { get; set; }
    public string URL { get; set; }
    public string AssignmentID { get; set; }
}

public class AssignmentSubmissionData : WebViewMessage
{
    // Cần là int để khớp với AssignmentID trong model của bạn
    public new int AssignmentID { get; set; }
    public string FileName { get; set; }
    public string FileBase64 { get; set; } // Chứa nội dung file đã mã hóa Base64
    public string StudentNote { get; set; }
    public string CourseName { get; set; } // Được thêm vào từ JS

    // ⭐ THÊM TRƯỜNG NÀY ĐỂ NHẬN ĐƯỜNG DẪN GỐC TỪ JS ⭐
    public string RootPath { get; set; }
}