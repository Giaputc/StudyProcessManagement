using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    public class StudentService
    {
        private DataProcess dataProcess;

        public StudentService()
        {
            dataProcess = new DataProcess();
        }

        // =============================================
        // COURSE FILTER
        // =============================================

        /// <summary>
        /// Lấy danh sách khóa học của giáo viên cho filter
        /// </summary>
        public DataTable GetTeacherCourses(string teacherID)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };
            return dataProcess.ExecuteStoredProcedure("sp_GetTeacherCourses", parameters);
        }

        // =============================================
        // STUDENT OPERATIONS
        // =============================================

        /// <summary>
        /// Lấy danh sách học viên (có filter theo khóa học, trạng thái, search)
        /// </summary>
        public DataTable GetStudents(string teacherID, string courseID = "", string statusFilter = "Tất cả trạng thái", string searchKeyword = "")
        {
            string query = @"
                SELECT 
                    e.StudentID AS UserID,
                    u.FullName,
                    a.Email,
                    c.CourseName,
                    e.EnrollmentDate,
                    ISNULL(e.ProgressPercent, 0) AS ProgressPercent,
                    ISNULL(e.Status, N'Learning') AS Status
                FROM Enrollments e
                INNER JOIN Users u ON e.StudentID = u.UserID
                INNER JOIN Accounts a ON u.AccountID = a.AccountID
                INNER JOIN Courses c ON e.CourseID = c.CourseID
                WHERE c.TeacherID = @TeacherID
                    AND (@CourseID = '' OR e.CourseID = @CourseID)
                    AND (@Search = '' OR u.FullName LIKE '%' + @Search + '%' OR a.Email LIKE '%' + @Search + '%')
                    AND (@Status = N'Tất cả trạng thái' OR e.Status = @Status)
                ORDER BY e.EnrollmentDate DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID },
                { "@CourseID", courseID ?? "" },
                { "@Search", searchKeyword ?? "" },
                { "@Status", statusFilter ?? "Tất cả trạng thái" }
            };

            return dataProcess.ReadData(query, parameters);
        }

        /// <summary>
        /// Lấy thống kê tổng quan học viên
        /// </summary>
        public DataTable GetStudentSummary(string teacherID, string courseID = "")
        {
            string query = @"
                SELECT 
                    COUNT(*) AS Total,
                    SUM(CASE WHEN e.Status = 'Learning' THEN 1 ELSE 0 END) AS Active,
                    SUM(CASE WHEN e.Status = 'Completed' THEN 1 ELSE 0 END) AS Completed
                FROM Enrollments e
                INNER JOIN Courses c ON e.CourseID = c.CourseID
                WHERE c.TeacherID = @TeacherID
                    AND (@CourseID = '' OR e.CourseID = @CourseID)";

            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID },
                { "@CourseID", courseID ?? "" }
            };

            return dataProcess.ReadData(query, parameters);
        }

        /// <summary>
        /// Lấy chi tiết học viên trong khóa học
        /// </summary>
        public DataTable GetStudentDetail(string studentID, string courseID)
        {
            string query = @"
                SELECT 
                    u.UserID,
                    u.FullName,
                    a.Email,
                    a.PhoneNumber,
                    c.CourseName,
                    e.EnrollmentDate,
                    e.ProgressPercent,
                    e.Status,
                    e.CompletionDate,
                    (SELECT AVG(s.Score) 
                     FROM Submissions s
                     INNER JOIN Assignments a ON s.AssignmentID = a.AssignmentID
                     WHERE s.StudentID = @StudentID AND a.CourseID = @CourseID AND s.Score IS NOT NULL) AS AverageScore
                FROM Users u
                INNER JOIN Accounts a ON u.AccountID = a.AccountID
                INNER JOIN Enrollments e ON u.UserID = e.StudentID
                INNER JOIN Courses c ON e.CourseID = c.CourseID
                WHERE u.UserID = @StudentID AND c.CourseID = @CourseID";

            var parameters = new Dictionary<string, object>
            {
                { "@StudentID", studentID },
                { "@CourseID", courseID }
            };

            return dataProcess.ReadData(query, parameters);
        }
    }
}
