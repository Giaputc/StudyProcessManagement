using System;
using System.Data;
using System.Collections.Generic;
using StudyProcessManagement.Business;

namespace StudyProcessManagement.Business.Teacher
{
    public class GradingService
    {
        private DataProcessDAL dataProcess;

        public GradingService()
        {
            dataProcess = new DataProcessDAL();
        }

        /// <summary>
        /// Lấy danh sách tất cả bài nộp cho giáo viên (Kèm filter nếu muốn)
        /// </summary>
        public DataTable GetAllSubmissions(string teacherID, string courseFilter = null, string statusFilter = null)
        {
            string sql = @"
                SELECT 
                    s.SubmissionID,
                    u.FullName AS StudentName,
                    a.Title AS AssignmentTitle,
                    c.CourseName,
                    s.SubmissionDate,
                    a.DueDate,
                    s.Score,
                    a.MaxScore,
                    s.FileUrl,
                    s.StudentNote,
                    s.TeacherFeedback,
                    CASE
                        WHEN s.Score IS NOT NULL THEN N'Đã chấm'
                        WHEN s.SubmissionDate > a.DueDate THEN N'Nộp trễ'
                        ELSE N'Chưa chấm'
                    END AS Status
                FROM Submissions s
                INNER JOIN Assignments a ON s.AssignmentID = a.AssignmentID
                INNER JOIN Courses c ON a.CourseID = c.CourseID
                INNER JOIN Users u ON s.StudentID = u.UserID
                WHERE c.TeacherID = @TeacherID";

            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };

            // Optional: Filter theo course hoặc trạng thái nếu truyền vào
            if (!string.IsNullOrEmpty(courseFilter))
            {
                sql += " AND c.CourseName = @CourseName";
                parameters["@CourseName"] = courseFilter;
            }

            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Tất cả")
            {
                if (statusFilter == "Đã chấm")
                {
                    sql += " AND s.Score IS NOT NULL";
                }
                else if (statusFilter == "Chưa chấm")
                {
                    sql += " AND s.Score IS NULL AND s.SubmissionDate <= a.DueDate";
                }
                else if (statusFilter == "Nộp trễ")
                {
                    sql += " AND s.Score IS NULL AND s.SubmissionDate > a.DueDate";
                }
            }

            sql += " ORDER BY s.SubmissionDate DESC";

            return dataProcess.ReadData(sql, parameters);
        }

        /// <summary>
        /// Lấy chi tiết 1 bài nộp theo SubmissionID
        /// </summary>
        public DataTable GetSubmissionDetails(string submissionID)
        {
            string sql = @"
                SELECT 
                    s.SubmissionID,
                    u.FullName AS StudentName,
                    a.Title AS AssignmentTitle,
                    c.CourseName,
                    s.SubmissionDate,
                    a.DueDate,
                    s.Score,
                    a.MaxScore,
                    s.FileUrl,
                    s.StudentNote,
                    s.TeacherFeedback,
                    CASE
                        WHEN s.Score IS NOT NULL THEN N'Đã chấm'
                        WHEN s.SubmissionDate > a.DueDate THEN N'Nộp trễ'
                        ELSE N'Chưa chấm'
                    END AS Status
                FROM Submissions s
                INNER JOIN Assignments a ON s.AssignmentID = a.AssignmentID
                INNER JOIN Courses c ON a.CourseID = c.CourseID
                INNER JOIN Users u ON s.StudentID = u.UserID
                WHERE s.SubmissionID = @SubmissionID";

            var parameters = new Dictionary<string, object>
            {
                { "@SubmissionID", submissionID }
            };

            return dataProcess.ReadData(sql, parameters);
        }

        /// <summary>
        /// Chấm điểm và feedback cho bài nộp
        /// </summary>
        public bool UpdateSubmissionScore(string submissionID, decimal score, string feedback)
        {
            string sql = "EXEC spGradeSubmission @SubmissionID, @Score, @TeacherFeedback";

            var parameters = new Dictionary<string, object>
            {
                { "@SubmissionID", submissionID },
                { "@Score", score },
                { "@TeacherFeedback", feedback }
            };

            return dataProcess.UpdateData(sql, parameters);
        }
    }
}
