using System;

namespace StudyProcessManagement.Data
{
    public class AssignmentViewModel
    {
        // Thông tin bài tập
        public int AssignmentID { get; set; }
        public string TenBaiTap { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayGiao { get; set; }
        public DateTime HanNop { get; set; }
        public decimal DiemToiDa { get; set; }
        public string TaiLieuDinhKem { get; set; }

        // Thông tin Khóa học (Bổ sung CourseID và Ảnh)
        public int CourseID { get; set; }          // BỔ SUNG
        public string TenKhoaHoc { get; set; }
        //public string AnhKhoaHoc { get; set; }     // BỔ SUNG (ImageCover)

        // Thông tin Giảng viên (Bổ sung Avatar)
        public string TenGiangVien { get; set; }
        //public string AnhGiangVien { get; set; }   // BỔ SUNG (AvatarUrl)

        // Thông tin Bài nộp
        public int? SubmissionID { get; set; }
        public decimal? DiemDat { get; set; }
        public DateTime? NgayNop { get; set; }
        public string FileBaiNop { get; set; }     // BỔ SUNG (FileUrl)
        public string GhiChuSinhVien { get; set; }  // BỔ SUNG (StudentNote)
        public string NhanXetGiaoVien { get; set; }

        // Trạng thái & Thời gian
        public string TrangThai { get; set; }
        public string StatusColor { get; set; }
        public string ThoiGianConLai { get; set; }
        public int SoNgayConLai { get; set; }
        public int SoGioConLai { get; set; }       // BỔ SUNG

        // Cờ Boolean & Điểm
        public bool DaNopTre { get; set; }
        public bool DaHoanThanh { get; set; }
        public decimal? PhanTramDiem { get; set; }  // BỔ SUNG

        // Ngày tháng Format
        public string NgayGiaoFormat { get; set; }  // BỔ SUNG
        public string HanNopFormat { get; set; }    // BỔ SUNG
        public string NgayNopFormat { get; set; }   // BỔ SUNG
    }
}