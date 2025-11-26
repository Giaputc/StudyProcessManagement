using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Data
{
    public class CourseSummary
    {
        public string CourseID { get; set; }
        public string KhoaHoc { get; set; } // Đổi từ CourseName
        public int SoBaiDaCham { get; set; } // Đổi từ TotalGraded
        public decimal DiemTB { get; set; } // Đổi từ AverageScore
        public decimal DiemCaoNhat { get; set; } // Đổi từ HighestScore
        public decimal DiemThapNhat { get; set; } // Đổi từ LowestScore
    }

    public class DetailedScore
    {
        public string KhoaHoc { get; set; } // c.CourseName
        public string BaiTap { get; set; } // a.Title
        public decimal Diem { get; set; } // s.Score
        public decimal DiemToiDa { get; set; } // a.MaxScore

        public string NgayCham { get; set; } // Kết quả format chuỗi từ SQL
        public string NhanXet { get; set; } // s.TeacherFeedback
        public string TrangThai { get; set; }

        public int SubmissionID { get; set; }
        public string AssignmentID { get; set; }
    }
    public class StudentOverallStats
    {
       
            public decimal DiemTBTong { get; set; }
            public decimal DiemCaoNhat { get; set; }
            public int SoBaiDaCham { get; set; }
            public int TongSoBaiNop { get; set; } // Thêm
            public string XepLoai { get; set; } // Thêm
        
    }
    internal class GradesDataAccess
    {
    }
}
