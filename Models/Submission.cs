using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Models
{
    public class Submission
    {
        public string SubmissionID { get; set; }
        public string AssignmentID { get; set; }
        public string AssignmentTitle { get; set; } // Tên bài tập
        public string StudentID { get; set; }
        public string StudentName { get; set; }     // Tên học viên
        public DateTime SubmissionDate { get; set; }
        public string FileUrl { get; set; }
        public string StudentNote { get; set; }
        public decimal? Score { get; set; }         // Có thể null (chưa chấm)
        public string TeacherFeedback { get; set; }
        public string Status { get; set; }          // Submitted, Graded

        // Helper hiển thị điểm
        public string DisplayScore => Score.HasValue ? Score.Value.ToString("0.0") : "Chưa chấm";
    }
}
