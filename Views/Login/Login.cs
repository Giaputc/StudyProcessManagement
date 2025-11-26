using StudyProcessManagement.Business.Admin;
using StudyProcessManagement.Views.Admin;
using StudyProcessManagement.Views.Teacher;
using StudyProcessManagement.Views.Student.main;
using System;
using System.Data;
using System.Windows.Forms;

// ⭐ BỔ SUNG: Imports cho logic Đăng nhập Sinh viên và Session
using StudyProcessManagement.Data; // Để sử dụng StudentInfoModel
using StudyProcessManagement.Business; // Để sử dụng DataProcess
using static StudyProcessManagement.Data.StudentSession; // Để truy cập StudentSession static

namespace StudyProcessManagement.Views.Login
{
    public partial class Login : Form
    {
        // Khởi tạo AccountService cho Admin/Teacher
        AccountService user = new AccountService();
        // Khởi tạo DataProcess cho Student
        private DataProcess dal = new DataProcess();

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtAccount.Focus();
        }

        // ⭐ BỔ SUNG: Hàm HashPassword giả định (Cần thay bằng hàm băm thực tế)
        private string HashPassword(string password)
        {
            // TODO: Thay thế bằng hàm băm mật khẩu thực tế (ví dụ: SHA256)
            return password;
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            var Email = TxtAccount.Text.Trim();
            var Password = TxtPassword.Text.Trim();

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Bước 1: Thử đăng nhập qua AccountService (Chủ yếu cho Admin/Teacher)
                DataRow Account = user.Login(Email, Password);

                if (Account != null)
                {
                    string role = Account["Role"].ToString();
                    string fullName = Account["FullName"].ToString();

                    this.Hide();

                    switch (role)
                    {
                        case "Admin":
                            {
                                MessageBox.Show($"Đăng nhập thành công! Chào mừng {fullName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm admin = new MainForm();
                                admin.ShowDialog();
                                break;
                            }
                        case "Teacher":
                            {
                                MessageBox.Show($"Đăng nhập thành công! Chào mừng {fullName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Form1 teacherForm = new Form1();
                                teacherForm.ShowDialog();
                                break;
                            }
                        case "Student":
                            {
                                // ⭐ LOGIC ĐĂNG NHẬP SINH VIÊN ĐẦY ĐỦ ⭐

                                // B2: Chuẩn bị mật khẩu và gọi DAL chuyên biệt
                                string passwordHash = HashPassword(Password);
                                StudentInfoModel student = dal.LoginAndGetStudentInfo(Email, passwordHash);

                                if (student != null)
                                {
                                    // B3: Thiết lập Session và mở Form chính
                                    CurrentUserID = student.UserID;
                                    CurrentStudent = student;

                                    MessageBox.Show($"Đăng nhập thành công! Chào mừng {student.FullName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // ⭐ ĐÃ SỬA: Thêm .ShowDialog()
                                    Views.Student.main.main mainForm = new Views.Student.main.main(student);
                                    mainForm.ShowDialog();
                                }
                                else
                                {
                                    // Nếu AccountService tìm thấy vai trò Student nhưng LoginAndGetStudentInfo thất bại (ví dụ: mật khẩu không khớp sau khi hash)
                                    MessageBox.Show("Email hoặc Mật khẩu không đúng. Vui lòng thử lại.", "Lỗi Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Show(); // Hiện lại form đăng nhập
                                }
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Vai trò không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show();
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ chung
                MessageBox.Show($"Đăng nhập thất bại. Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }
    }
}