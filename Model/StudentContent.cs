using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Data
{
    public class StudentContent
    {
        public string LoaiTaiNguyen { get; set; }  // Lesson / Assignment
        public int ResourceID { get; set; }        // LessonID hoặc AssignmentID
        public string TenTaiNguyen { get; set; }
        public string MoTa { get; set; }           // Nội dung của Lesson hoặc Description của Assignment

        // === Thông tin Liên kết (Links) ===

        public string LinkVideo { get; set; }
        public string LinkTaiLieu { get; set; }    // AttachmentUrl hoặc AttachmentPath
        public string LoaiChiTiet { get; set; }    // Video / Tài liệu / Video + Tài liệu

        // === Thông tin Khóa học và Chương ===

        public int CourseID { get; set; }
        public string TenKhoaHoc { get; set; }
        public string AnhKhoaHoc { get; set; }     // ImageCover
        public int? SectionID { get; set; }        // Có thể NULL nếu là Assignment
        public string TenChuong { get; set; }
        public string TenGiangVien { get; set; }

        // === Trạng thái và Sắp xếp ===

        public string TrangThai { get; set; }      // Ví dụ: Có sẵn, Đã chấm, Quá hạn
        public DateTime? NgayDang { get; set; }    // AssignedDate (cho Assignment) hoặc NULL (cho Lesson)

        // Thuộc tính để sắp xếp theo logic (Course, Section/Chapter, Order)
        public int ThuTuChuong { get; set; }
        public int ThuTu { get; set; }
    }
}
