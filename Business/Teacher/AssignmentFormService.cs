using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    public class AssignmentFormService
    {
        private DataProcess dataProcess;

        public AssignmentFormService()
        {
            dataProcess = new DataProcess();
        }

        public DataTable GetTeacherCourses(string teacherID)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };
            return dataProcess.ExecuteStoredProcedure("sp_GetTeacherCourses", parameters);
        }

        public DataTable GetAssignmentDetails(int assignmentID)
        {
            string query = @"
                SELECT AssignmentID, CourseID, Title, Description,
                       AssignedDate, DueDate, MaxScore, AttachmentPath
                FROM Assignments
                WHERE AssignmentID = @ID";
            var parameters = new Dictionary<string, object>
            {
                { "@ID", assignmentID }
            };
            return dataProcess.ReadData(query, parameters);
        }

        public int CreateAssignment(int courseID, string title, string description,
                                    DateTime assignedDate, DateTime dueDate, decimal maxScore,
                                    string attachmentPath)
        {
            string sql = @"
                INSERT INTO Assignments (CourseID, Title, Description, AssignedDate, DueDate, MaxScore, AttachmentPath)
                VALUES (@CourseID, @Title, @Description, @AssignedDate, @DueDate, @MaxScore, @AttachmentPath);
                SELECT CAST(scope_identity() AS int)";
            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseID },
                { "@Title", title },
                { "@Description", description },
                { "@AssignedDate", assignedDate },
                { "@DueDate", dueDate },
                { "@MaxScore", maxScore },
                { "@AttachmentPath", attachmentPath }
            };
            return (int)dataProcess.ReadData(sql, parameters).Rows[0][0];
        }

        public bool UpdateAssignment(int assignmentID, int courseID, string title,
                                    string description, DateTime assignedDate,
                                    DateTime dueDate, decimal maxScore,
                                    string attachmentPath)
        {
            string sql = @"
                UPDATE Assignments SET
                    CourseID = @CourseID,
                    Title = @Title,
                    Description = @Description,
                    AssignedDate = @AssignedDate,
                    DueDate = @DueDate,
                    MaxScore = @MaxScore,
                    AttachmentPath = @AttachmentPath
                WHERE AssignmentID = @AssignmentID";
            var parameters = new Dictionary<string, object>
            {
                { "@AssignmentID", assignmentID },
                { "@CourseID", courseID },
                { "@Title", title },
                { "@Description", description },
                { "@AssignedDate", assignedDate },
                { "@DueDate", dueDate },
                { "@MaxScore", maxScore },
                { "@AttachmentPath", attachmentPath }
            };
            return dataProcess.ChangeData(sql, parameters);
        }
    }
}