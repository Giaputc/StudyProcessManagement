using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Models
{
    public class Users
    {
        public string UserID { get; set; }
        public string AccountID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }       // Admin, Teacher, Student
        public string AvatarUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }

        // Thuộc tính phụ (Helper properties) - Dùng để hiển thị lên Grid
        public string StatusText => IsActive ? "Hoạt động" : "Đã khóa";

        // Tự động lấy ảnh mặc định nếu Avatar null
        public string DisplayAvatar => string.IsNullOrEmpty(AvatarUrl) ? "default_user.png" : AvatarUrl;
    }
}
