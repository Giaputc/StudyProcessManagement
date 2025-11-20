using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    public class AssignmentService
    {
        private DataProcess dataProcess;

        public AssignmentService()
        {
            dataProcess = new DataProcess();
        }

        // Lấy danh sách khóa học của giáo viên
        public DataTable GetTeacherCourses(string teacherID)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };
            return dataProcess.ExecuteStoredProcedure("sp_GetTeacherCourses", parameters);
        }

        // Lấy danh sách bài tập
        public DataTable GetAssignments(string teacherID, string courseID = null)
        {
            string query = @"
                SELECT
                    a.AssignmentID,
                    a.Title,
                    c.CourseName,
                    a.DueDate,
                    a.AttachmentPath,
                    COUNT(s.SubmissionID) AS TotalSubmissions,
                    CASE
                        WHEN GETDATE() > a.DueDate THEN N'Đã đóng'
                        WHEN GETDATE() < a.AssignedDate THEN N'Chưa mở'
                        ELSE N'Đang mở'
                    END AS Status
                FROM Assignments a
                INNER JOIN Courses c ON a.CourseID = c.CourseID
                LEFT JOIN Submissions s ON a.AssignmentID = s.AssignmentID
                WHERE c.TeacherID = @TeacherID";
            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };
            if (!string.IsNullOrEmpty(courseID))
            {
                query += " AND a.CourseID = @CourseID";
                parameters.Add("@CourseID", courseID);
            }
            query += @"
                GROUP BY a.AssignmentID, a.Title, c.CourseName, a.DueDate, a.AssignedDate, a.AttachmentPath
                ORDER BY a.DueDate DESC";
            return dataProcess.ReadData(query, parameters);
        }

        // Xóa bài tập theo ID
        public bool DeleteAssignment(int assignmentID)
        {
            string sql = "DELETE FROM Assignments WHERE AssignmentID = @ID";
            var parameters = new Dictionary<string, object>
            {
                { "@ID", assignmentID }
            };
            return dataProcess.ChangeData(sql, parameters);
        }
    }
}
