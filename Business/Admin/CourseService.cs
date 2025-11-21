using System;
using System.Collections.Generic;
using System.Data;
using StudyProcessManagement.Models;

namespace StudyProcessManagement.Business.Admin
{
    public class CourseService
    {
        private DataProcess dataProcess = new DataProcess();

        // 1. Lấy thống kê cho 3 ô màu trên Dashboard
        public Dictionary<string, int> GetDashboardStats()
        {
            var stats = new Dictionary<string, int>();

            try
            {
                // Tổng khóa học
                DataTable dtCourse = dataProcess.ReadData("SELECT COUNT(*) FROM Courses");
                stats.Add("Courses", Convert.ToInt32(dtCourse.Rows[0][0]));

                // Tổng học viên (Role = Student)
                DataTable dtStudent = dataProcess.ReadData("SELECT COUNT(*) FROM Accounts WHERE Role = 'Student'");
                stats.Add("Students", Convert.ToInt32(dtStudent.Rows[0][0]));

                // Tổng bài học
                DataTable dtLesson = dataProcess.ReadData("SELECT COUNT(*) FROM Lessons");
                stats.Add("Lessons", Convert.ToInt32(dtLesson.Rows[0][0]));
            }
            catch
            {
                stats.Add("Courses", 0); stats.Add("Students", 0); stats.Add("Lessons", 0);
            }

            return stats;
        }

        // 2. Lấy danh sách khóa học (Kèm tên GV và Danh mục)
        public List<Course> GetAllCourses(string keyword = "")
        {
            List<Course> list = new List<Course>();

            string sql = @"
                SELECT c.CourseID, c.CourseName, c.Description, c.TotalLessons, c.Status,
                       u.FullName AS TeacherName,
                       cat.CategoryName
                FROM Courses c
                LEFT JOIN Users u ON c.TeacherID = u.AccountID 
                LEFT JOIN Categories cat ON c.CategoryID = cat.CategoryID
                WHERE 1=1";

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(keyword) && keyword != "Tìm kiếm khóa học...")
            {
                sql += " AND (c.CourseName LIKE @Search OR u.FullName LIKE @Search)";
                parameters.Add("@Search", "%" + keyword + "%");
            }

            DataTable dt = dataProcess.ReadData(sql, parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Course()
                {
                    CourseID = row["CourseID"].ToString(),
                    CourseName = row["CourseName"].ToString(),
                    Description = row["Description"].ToString(),
                    TotalLessons = row["TotalLessons"] != DBNull.Value ? Convert.ToInt32(row["TotalLessons"]) : 0,
                    Status = row["Status"].ToString(),
                    TeacherName = row["TeacherName"].ToString(),
                    CategoryName = row["CategoryName"].ToString()
                });
            }
            return list;
        }

        // 3. Xóa khóa học
        public bool DeleteCourse(string id)
        {
            string sql = "DELETE FROM Courses WHERE CourseID = @ID";
            var param = new Dictionary<string, object> { { "@ID", id } };
            return dataProcess.UpdateData(sql, param);
        }
    }
}