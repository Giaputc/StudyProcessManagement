using System;
using System.Collections.Generic;
using System.Data;
using StudyProcessManagement.Models;

namespace StudyProcessManagement.Business.Admin
{
    public class CourseService
    {
        private DataProcessDAL dataProcess = new DataProcessDAL();

        // 1. Lấy danh sách (Sửa convert ID sang Int)

        public Dictionary<string, int> GetDashboardStats()
        {
            var stats = new Dictionary<string, int>();

            try
            {
                // Đếm tổng khóa học
                DataTable dtCourse = dataProcess.ReadData("SELECT COUNT(*) FROM Courses");
                stats.Add("Courses", Convert.ToInt32(dtCourse.Rows[0][0]));

                // Đếm tổng học viên (Dựa vào Role trong bảng Accounts)
                DataTable dtStudent = dataProcess.ReadData("SELECT COUNT(*) FROM Accounts WHERE Role = 'Student'");
                stats.Add("Students", Convert.ToInt32(dtStudent.Rows[0][0]));

                // Đếm tổng bài học
                DataTable dtLesson = dataProcess.ReadData("SELECT COUNT(*) FROM Lessons");
                stats.Add("Lessons", Convert.ToInt32(dtLesson.Rows[0][0]));
            }
            catch
            {
                // Nếu lỗi thì trả về 0 hết để không crash app
                stats["Courses"] = 0;
                stats["Students"] = 0;
                stats["Lessons"] = 0;
            }

            return stats;
        }
        public List<Course> GetAllCourses(string keyword = "")
        {
            List<Course> list = new List<Course>();

            // SQL Mới: TeacherID trong Courses trỏ sang Accounts(AccountID)
            // Nên ta phải JOIN: Courses -> Accounts -> Users (để lấy FullName)
            string sql = @"
                SELECT 
                    c.CourseID, c.CourseName, c.Description, c.TotalLessons, c.Status,
                    u.FullName AS TeacherName,
                    cat.CategoryName
                FROM Courses c
                LEFT JOIN Accounts a ON c.TeacherID = a.AccountID -- JOIN sang bảng Account trước
                LEFT JOIN Users u ON a.AccountID = u.AccountID    -- Rồi mới JOIN sang User lấy tên
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
                    // Ép kiểu sang int
                    CourseID = Convert.ToInt32(row["CourseID"]),
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

        // 2. Thêm khóa học (BỎ TỰ SINH ID)
        public bool AddCourse(string name, string desc, int lessons, string status, string teacherId, int catId)
        {
            // Không tạo ID nữa, SQL tự tăng
            string sql = @"
                INSERT INTO Courses (CourseName, Description, TotalLessons, Status, TeacherID, CategoryID, CreatedAt)
                VALUES (@Name, @Desc, @Lessons, @Status, @TeacherID, @CatID, GETDATE())";

            var param = new Dictionary<string, object> {
                { "@Name", name }, { "@Desc", desc }, { "@Lessons", lessons },
                { "@Status", status }, { "@TeacherID", teacherId }, { "@CatID", catId }
            };
            return dataProcess.UpdateData(sql, param);
        }

        // 3. Sửa/Xóa (Dùng ID là int)
        // Lưu ý: Tham số truyền vào đổi thành int
        public bool DeleteCourse(string  id)
        {
            string sql = "DELETE FROM Courses WHERE CourseID = @ID";
            var param = new Dictionary<string, object> { { "@ID", id } };
            return dataProcess.UpdateData(sql, param);
        }

        // Cập nhật hàm UpdateCourse và GetCourseById tương tự: đổi tham số string id -> int id
    }
}