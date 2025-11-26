using System;
using System.Collections.Generic;
using System.Data;
using StudyProcessManagement.Business;  // Thêm using cho DataProcess

namespace StudyProcessManagement.Business.Teacher
{
    public class GradeSubmissionFormService
    {
        private DataProcess dataProcess;

        public GradeSubmissionFormService()
        {
            // Khởi tạo đúng biến dataProcess
            dataProcess = new DataProcess();
        }

        public DataTable GetSubmissionDetails(string submissionID)
        {
            string query = @"
                SELECT 
                    s.SubmissionID,
                    s.SubmissionDate,
                    s.StudentNote AS StudentNote,
                    s.FileUrl AS FileUrl,
                    s.Score,
                    s.TeacherFeedback AS TeacherFeedback,
                    u.FullName AS StudentName,
                    a.Title AS AssignmentTitle,
                    a.Description AS AssignmentDescription,
                    a.MaxScore,
                    a.DueDate,
                    c.CourseName
                FROM Submissions s
                INNER JOIN Users u ON s.StudentID = u.UserID
                INNER JOIN Assignments a ON s.AssignmentID = a.AssignmentID
                INNER JOIN Courses c ON a.CourseID = c.CourseID
                WHERE s.SubmissionID = @SubmissionID";

            var parameters = new Dictionary<string, object>()
            {
                { "@SubmissionID", submissionID }
            };

            return dataProcess.ReadData(query, parameters);
        }

        public bool GradeSubmission(string submissionID, decimal score, string feedback)
        {
            string sql = "EXEC spGradeSubmission @SubmissionID, @Score, @TeacherFeedback";

            var parameters = new Dictionary<string, object>()
            {
                { "@SubmissionID", submissionID },
                { "@Score", score },
                { "@TeacherFeedback", feedback }
            };

            return dataProcess.UpdateData(sql, parameters);
        }
    }
}
