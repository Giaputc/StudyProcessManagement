using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Models
{
    public class Assignment
    {
        public string AssignmentID { get; set; }
        public string CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal MaxScore { get; set; }

        // Helper kiểm tra hạn nộp
        public bool IsOverdue => DateTime.Now > DueDate;
        public string StatusText => IsOverdue ? "Đã hết hạn" : "Đang mở";
    }
}
