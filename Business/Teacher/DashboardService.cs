using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    public class DashboardService
    {
        private DataProcessDAL dataProcess;

        public DashboardService()
        {
            dataProcess = new DataProcessDAL();
        }

        // =============================================
        // STATISTICS CARDS
        // =============================================

        /// <summary>
        /// Lấy thống kê tổng quan cho Dashboard (4 cards)
        /// </summary>
        public DataTable GetDashboardStatistics(string teacherID)
        {
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM Courses WHERE TeacherID = @TeacherID) AS TotalCourses,
                    (SELECT COUNT(DISTINCT e.StudentID)
                     FROM Enrollments e
                     INNER JOIN Courses c ON e.CourseID = c.CourseID
                     WHERE c.TeacherID = @TeacherID) AS TotalStudents,
                    (SELECT COUNT(*)
                     FROM Submissions s
                     INNER JOIN Assignments a ON s.AssignmentID = a.AssignmentID
                     INNER JOIN Courses c ON a.CourseID = c.CourseID
                     WHERE c.TeacherID = @TeacherID AND s.Score IS NULL) AS PendingGrades,
                    (SELECT ISNULL(AVG(s.Score), 0)
                     FROM Submissions s
                     INNER JOIN Assignments a ON s.AssignmentID = a.AssignmentID
                     INNER JOIN Courses c ON a.CourseID = c.CourseID
                     WHERE c.TeacherID = @TeacherID AND s.Score IS NOT NULL) AS AverageScore";

            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };

            return dataProcess.ReadData(query, parameters);
        }

        // =============================================
        // RECENT COURSES
        // =============================================

        /// <summary>
        /// Lấy 5 khóa học gần đây nhất
        /// </summary>
        public DataTable GetRecentCourses(string teacherID)
        {
            string query = @"
                SELECT TOP 5
                    c.CourseID,
                    c.CourseName,
                    ISNULL(cat.CategoryName, N'N/A') AS CategoryName,
                    COUNT(DISTINCT e.EnrollmentID) AS TotalStudents,
                    ISNULL(c.Status, N'N/A') AS Status,
                    c.CreatedAt
                FROM Courses c
                LEFT JOIN Categories cat ON c.CategoryID = cat.CategoryID
                LEFT JOIN Enrollments e ON c.CourseID = e.CourseID
                WHERE c.TeacherID = @TeacherID
                GROUP BY c.CourseID, c.CourseName, cat.CategoryName, c.Status, c.CreatedAt
                ORDER BY c.CreatedAt DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };

            return dataProcess.ReadData(query, parameters);
        }

        // =============================================
        // PENDING SUBMISSIONS
        // =============================================

        /// <summary>
        /// Lấy 5 bài tập có bài nộp chưa chấm
        /// </summary>
        public DataTable GetPendingSubmissions(string teacherID)
        {
            string query = @"
                SELECT TOP 5
                    a.AssignmentID,
                    a.Title AS AssignmentTitle,
                    c.CourseName,
                    COUNT(s.SubmissionID) AS TotalSubmissions,
                    COUNT(DISTINCT e.StudentID) AS TotalStudents,
                    a.DueDate
                FROM Assignments a
                INNER JOIN Courses c ON a.CourseID = c.CourseID
                LEFT JOIN Submissions s ON a.AssignmentID = s.AssignmentID AND s.Score IS NULL
                LEFT JOIN Enrollments e ON c.CourseID = e.CourseID
                WHERE c.TeacherID = @TeacherID
                GROUP BY a.AssignmentID, a.Title, c.CourseName, a.DueDate
                HAVING COUNT(s.SubmissionID) > 0
                ORDER BY a.DueDate ASC";

            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };

            return dataProcess.ReadData(query, parameters);
        }
    }
}
