using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Business.Admin
{
    public class DashboardService
    {
        private  DataProcess dataProcess = new DataProcess();
        public Dictionary<string, int> GetDashboardStatus()
        {
            var stats = new Dictionary<string, int>();
            try
            {
                // Đếm tổng khóa học
                var dtCourse = dataProcess.ReadData("SELECT COUNT(*) FROM Courses");
                stats.Add("Courses", Convert.ToInt32(dtCourse.Rows[0][0]));
                // Đếm tổng gv (Dựa vào Role trong bảng Accounts)
                var dtTeacher = dataProcess.ReadData("SELECT COUNT(*) FROM Accounts WHERE Role = 'Teacher'");
                stats.Add("Teacher", Convert.ToInt32(dtTeacher.Rows[0][0]));
                // Đếm tổng users
                var dtUser = dataProcess.ReadData("SELECT COUNT(*) FROM Accounts");
                stats.Add("Users", Convert.ToInt32(dtUser.Rows[0][0]));
                // Đếm tổng khóa học chờ duyệt
                var dtPending = dataProcess.ReadData("SELECT COUNT(*) FROM Courses WHERE Status  = 'Pending'");
                stats.Add("PendingCourses", Convert.ToInt32(dtPending.Rows[0][0]));
            }
            catch
            {
                
                stats["Courses"] = 0;
                stats["Teacher"] = 0;
                stats["Users"] = 0;
                stats["PendingCourses"] = 0;
            }
            return stats;
        }
        public DataTable GetPendingCourses()
        {
           
            string sql = @"
                SELECT c.CourseName, u.FullName AS TeacherName 
                FROM Courses c
                LEFT JOIN Users u ON c.TeacherID = u.AccountID
                WHERE c.Status = 'Pending'";

            return dataProcess.ReadData(sql);
        }

        public DataTable GetRecentActivities()
        {
            string sql = @"
                SELECT TOP 5 
                    u.FullName AS UserName, 
                    a.Role, 
                    'Đăng ký khóa học' AS Action, 
                    FORMAT(e.EnrollmentDate, 'dd/MM HH:mm') AS Time
                FROM Enrollments e
                JOIN Users u ON e.StudentID = u.UserID
                JOIN Accounts a ON u.AccountID = a.AccountID
                ORDER BY e.EnrollmentDate DESC";

            return dataProcess.ReadData(sql);
        }

    }
}
