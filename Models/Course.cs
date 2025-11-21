using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string ImageCover { get; set; }
        public int TotalLessons { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; } // Lấy từ bảng Categories
        public string TeacherID { get; set; }
        public string TeacherName { get; set; }  // Lấy từ bảng Users
        public string Status { get; set; }       // Pending, Approved
        public DateTime CreatedAt { get; set; }

        // Thuộc tính phụ cho giao diện
        public bool IsApproved => Status == "Approved";
        public string DisplayStatus => IsApproved ? "Đã duyệt" : "Chờ duyệt";
    }
}
