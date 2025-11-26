using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyProcessManagement.Data;
namespace StudyProcessManagement.Data
{
    public static   class StudentSession
    {
        public static string CurrentUserID { get; set; } = null;

        // Lưu trữ toàn bộ đối tượng sinh viên hiện tại
        public static StudentInfoModel CurrentStudent { get; set; }
    }
    public class StudentInfoModel
    {

        public string UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; }

        // Sử dụng DateTime? là cách tốt nhất để xử lý ngày sinh có thể NULL trong DB
        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

    }
}
