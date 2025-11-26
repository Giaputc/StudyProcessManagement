using System.Windows.Forms;
using StudyProcessManagement.Data;

namespace StudyProcessManagement.Views.Student.information
{
    public partial class studient_information : Form
    {
        // Giữ lại constructor để có thể khởi tạo nếu cần, nhưng không có logic cụ thể
        public studient_information(StudentInfoModel studentInfo)
        {
            InitializeComponent();
            // Có thể thêm logic khởi tạo cơ bản khác ở đây nếu Form này vẫn còn được dùng
        }

        // Constructor mặc định (cần cho Designer)
        public studient_information()
        {
            InitializeComponent();
        }
    }
}