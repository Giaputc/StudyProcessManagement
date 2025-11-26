using StudyProcessManagement.Views.Student.assignments;
using StudyProcessManagement.Views.Student.information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using StudyProcessManagement.Data; // Để sử dụng StudentInfoModel
using StudyProcessManagement.Business; // Để sử dụng DataProcess
// ...
namespace StudyProcessManagement.Views.Login
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
           

            // TẠM DÙNG HARDCODE ĐỂ TEST (nếu bạn chưa kết nối TextBoxes)
            string email = "student002@lms.com";
            string password = "hashed_password";

           
            string passwordHash = HashPassword(password);

            // 3. Khởi tạo đối tượng Business và thực hiện đăng nhập
            DataProcess dal = new DataProcess();

            // 🔥 KHAI BÁO BIẾN 'student' TẠI ĐÂY
            StudentInfoModel student = dal.LoginAndGetStudentInfo(email, passwordHash);

            // 4. Kiểm tra kết quả đăng nhập và chuyển Form
            if (student != null)
            {
                StudentSession.CurrentUserID = student.UserID;
                StudentSession.CurrentStudent = student;
                // Đăng nhập thành công
                Views.Student.main.main mainForm =
                    new Views.Student.main.main(student);

                this.Hide();
                mainForm.Show();
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Email hoặc Mật khẩu không đúng. Vui lòng thử lại.", "Lỗi Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string HashPassword(string password)
        {
            // TODO: Thay thế bằng hàm băm mật khẩu thực tế của bạn
            return password;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
