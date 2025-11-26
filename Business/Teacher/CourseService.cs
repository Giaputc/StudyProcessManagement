using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    public class CourseService
    {
        private DataProcessDAL dataProcess;

        public CourseService()
        {
            dataProcess = new DataProcessDAL();
        }

        // =============================================
        // CATEGORY OPERATIONS
        // =============================================

        /// <summary>
        /// Lấy danh sách tất cả Categories
        /// </summary>
        public DataTable GetAllCategories()
        {
            string sql = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
            return dataProcess.ReadData(sql);
        }

        // =============================================
        // COURSE OPERATIONS
        // =============================================

        /// <summary>
        /// Lấy danh sách khóa học của giáo viên (có filter và search)
        /// </summary>
        public DataTable GetTeacherCourses(string teacherID, string categoryID = "", string searchKeyword = "")
        {
            string query = @"
                SELECT 
                    c.CourseID,
                    c.CourseName,
                    ISNULL(cat.CategoryName, N'Chưa phân loại') AS CategoryName,
                    (SELECT COUNT(*) FROM Enrollments WHERE CourseID = c.CourseID) AS StudentCount,
                    ISNULL(c.TotalLessons, 0) AS LessonCount,
                    ISNULL(c.Status, N'Active') AS Status
                FROM Courses c
                LEFT JOIN Categories cat ON c.CategoryID = cat.CategoryID
                WHERE c.TeacherID = @TeacherID
                    AND (@CategoryID = '' OR c.CategoryID = @CategoryID)
                    AND (@Search = '' OR c.CourseName LIKE '%' + @Search + '%' OR c.Description LIKE '%' + @Search + '%')
                ORDER BY c.CreatedAt DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID },
                { "@CategoryID", categoryID ?? "" },
                { "@Search", searchKeyword ?? "" }
            };

            return dataProcess.ReadData(query, parameters);
        }

        /// <summary>
        /// Lấy thống kê tổng quan của giáo viên
        /// </summary>
        public DataTable GetTeacherSummary(string teacherID)
        {
            string query = @"
                SELECT 
                    COUNT(DISTINCT c.CourseID) AS TotalCourses,
                    COUNT(DISTINCT e.EnrollmentID) AS TotalStudents,
                    SUM(ISNULL(c.TotalLessons, 0)) AS TotalLessons
                FROM Courses c
                LEFT JOIN Enrollments e ON c.CourseID = e.CourseID
                WHERE c.TeacherID = @TeacherID";

            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };

            return dataProcess.ReadData(query, parameters);
        }

        /// <summary>
        /// Xóa khóa học
        /// </summary>
        public bool DeleteCourse(string courseID, string teacherID)
        {
            if (string.IsNullOrEmpty(courseID))
                throw new ArgumentException("ID khóa học không hợp lệ");

            string sql = "DELETE FROM Courses WHERE CourseID = @CourseID AND TeacherID = @TeacherID";
            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseID },
                { "@TeacherID", teacherID }
            };

            return dataProcess.ChangeData(sql, parameters);
        }
    }
}
