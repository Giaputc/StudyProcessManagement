using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    /// <summary>
    /// Service riêng cho StudentListForm (popup danh sách học viên của khóa học)
    /// </summary>
    public class StudentListFormService
    {
        private DataProcessDAL dataProcess;

        public StudentListFormService()
        {
            dataProcess = new DataProcessDAL();
        }

        // =============================================
        // STUDENT LIST
        // =============================================

        /// <summary>
        /// Lấy danh sách học viên đã đăng ký khóa học (có STT tự động)
        /// </summary>
        public DataTable GetEnrolledStudents(string courseID)
        {
            string query = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY e.EnrollmentDate DESC) AS STT,
                    e.StudentID,
                    u.FullName,
                    a.Email,
                    e.EnrollmentDate,
                    ISNULL(e.ProgressPercent, 0) AS ProgressPercent,
                    ISNULL(e.Status, N'Learning') AS Status
                FROM Enrollments e
                INNER JOIN Users u ON e.StudentID = u.UserID
                INNER JOIN Accounts a ON u.AccountID = a.AccountID
                WHERE e.CourseID = @CourseID
                ORDER BY e.EnrollmentDate DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseID }
            };

            return dataProcess.ReadData(query, parameters);
        }

        /// <summary>
        /// Đếm tổng số học viên trong khóa học
        /// </summary>
        public int GetStudentCount(string courseID)
        {
            string query = "SELECT COUNT(*) FROM Enrollments WHERE CourseID = @CourseID";

            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseID }
            };

            DataTable dt = dataProcess.ReadData(query, parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }
    }
}
