using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Data
{

    public class StudentCourseViewModel
    {
        // Thông tin Khóa học
        public string CourseID { get; set; }
        public string TenKhoaHoc { get; set; }
        public string AnhBia { get; set; }
        public string MoTa { get; set; }

        // Danh mục
        public string DanhMuc { get; set; }
        public string CategoryID { get; set; }

        // Giảng viên
        public string TenGiangVien { get; set; }
        public string AnhGiangVien { get; set; }

        // Tiến độ học (Số)
        public int TienDoHoc { get; set; }           // ProgressPercent
        public int SoBaiHoanThanh { get; set; }      // CompletedLessons
        public int TongSoBaiHoc { get; set; }        // TotalLessons
        public int SoBaiConLai { get; set; }         // Calculated field

        // Tiến độ học (Text)
        public string TienDoText { get; set; }       // "9/12 bài"
        public string PhanTramText { get; set; }      // "75%"
        public string ProgressColor { get; set; }    // Màu sắc cho UI

        // Trạng thái & Điểm
        public string TrangThai { get; set; }        // Status (Learning, Completed, Suspended)
        public string TrangThaiText { get; set; }    // Text Tiếng Việt
        public DateTime? NgayDangKy { get; set; }     // EnrollmentDate
        public decimal DiemTrungBinh { get; set; }   // AverageScore
    }
}
