using StudyProcessManagement.Business.Admin;
using StudyProcessManagement.Views.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyProcessManagement.Views.Teacher;
namespace StudyProcessManagement.Views.Login
{
    public partial class Login : Form
    {
        AccountService user = new AccountService();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtAccount.Focus();
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
           var Email = TxtAccount.Text.Trim();
           var Password = TxtPassword.Text.Trim();
            if(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try                
            { 
              DataRow Account =  user.Login(Email, Password);
              if(Account != null)
              {
                 string role = Account["Role"].ToString();
                 string fullName = Account["FullName"].ToString();
                 MessageBox.Show($"Đăng nhập thành công! Chào mừng {fullName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 this.Hide();
                    switch (role)
                    {
                        case "Admin":
                            {
                                MainForm admin = new MainForm();
                                admin.ShowDialog();
                                break;
                            }
                        case "Teacher":
                            {
                                Form1 teacherForm = new Form1();
                                teacherForm.ShowDialog();
                                break;
                            }
                        case "Student":
                            {
                              MessageBox.Show("Chức năng dành cho sinh viên hiện chưa được triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
