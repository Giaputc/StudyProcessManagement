using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Models
{
    public class Enrollment
    {
        public string EnrollmentID { get; set; }
        public string StudentID { get; set; }
        public string CourseID { get; set; }
        public string CourseName { get; set; }   // Lấy từ bảng Courses
        public DateTime EnrollmentDate { get; set; }
        public int ProgressPercent { get; set; } // 0 - 100
        public int CompletedLessons { get; set; }
        public string Status { get; set; }       // Learning, Completed

        // Helper để hiện thanh tiến độ
        public string ProgressText => $"{ProgressPercent}% hoàn thành";
    }
}
