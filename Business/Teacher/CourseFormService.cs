using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    /// <summary>
    /// Service xử lý CRUD cho Course Form (Thêm/Sửa khóa học)
    /// </summary>
    public class CourseFormService
    {
        private DataProcess dataProcess;

        public CourseFormService()
        {
            dataProcess = new DataProcess();
        }

        // =============================================
        // CATEGORY OPERATIONS
        // =============================================

        /// <summary>
        /// Lấy danh sách tất cả Categories để hiển thị trong dropdown
        /// </summary>
        public DataTable GetAllCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
            return dataProcess.ReadData(query);
        }

        // =============================================
        // GET COURSE DETAILS
        // =============================================

        /// <summary>
        /// Lấy chi tiết khóa học để hiển thị khi chỉnh sửa
        /// CourseID là INT (IDENTITY) trong database
        /// </summary>
        public DataTable GetCourseDetails(int courseID)
        {
            string query = @"
                SELECT 
                    CourseName, 
                    Description, 
                    CategoryID, 
                    ImageCover, 
                    Status 
                FROM Courses 
                WHERE CourseID = @CourseID";

            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseID }
            };

            return dataProcess.ReadData(query, parameters);
        }

        // =============================================
        // CREATE COURSE
        // =============================================

        /// <summary>
        /// Tạo khóa học mới
        /// ✅ CategoryID: STRING (hoặc INT tùy database của bạn)
        /// ✅ TeacherID: STRING (VARCHAR(50) - AccountID)
        /// ✅ Status: Tự động = "Pending" (tiếng Anh)
        /// ✅ Trả về: INT (CourseID vừa tạo)
        /// </summary>
        public int CreateCourse(string categoryID, string courseName, string description,
            string teacherID, string imageCover)
        {
            // ===== VALIDATION =====
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("Tên khóa học không được để trống");

            if (string.IsNullOrWhiteSpace(categoryID))
                throw new ArgumentException("Phải chọn danh mục");

            if (string.IsNullOrWhiteSpace(teacherID))
                throw new ArgumentException("Thiếu thông tin giáo viên");

            try
            {
                string query = @"
                    INSERT INTO Courses
                    (CourseName, Description, CategoryID, TeacherID, ImageCover, Status, TotalLessons, CreatedAt)
                    VALUES (@CourseName, @Description, @CategoryID, @TeacherID, @ImageCover, @Status, 0, GETDATE());
                    
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new Dictionary<string, object>
                {
                    { "@CourseName", courseName },
                    { "@Description", string.IsNullOrWhiteSpace(description) ? "" : description },
                    { "@CategoryID", categoryID },
                    { "@TeacherID", teacherID },
                    { "@ImageCover", string.IsNullOrWhiteSpace(imageCover) ? (object)DBNull.Value : imageCover },
                    { "@Status", "Pending" }  // ✅ Database lưu tiếng Anh: "Pending"
                };

                DataTable dt = dataProcess.ReadData(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo khóa học: " + ex.Message, ex);
            }
        }

        // =============================================
        // UPDATE COURSE
        // =============================================

        /// <summary>
        /// Cập nhật khóa học
        /// ✅ CourseID: INT
        /// ✅ CategoryID: STRING (hoặc INT)
        /// ✅ TeacherID: STRING (VARCHAR(50))
        /// ✅ KHÔNG CẬP NHẬT Status - Giữ nguyên trạng thái hiện tại
        /// ✅ Chỉ Admin mới được sửa Status
        /// </summary>
        public bool UpdateCourse(int courseID, string categoryID, string courseName,
            string description, string teacherID, string imageCover)
        {
            // ===== VALIDATION =====
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("Tên khóa học không được để trống");

            if (string.IsNullOrWhiteSpace(categoryID))
                throw new ArgumentException("Phải chọn danh mục");

            if (string.IsNullOrWhiteSpace(teacherID))
                throw new ArgumentException("Thiếu thông tin giáo viên");

            try
            {
                // ✅ KHÔNG CÓ Status TRONG UPDATE
                // Giữ nguyên trạng thái hiện tại, chỉ Admin mới được sửa
                string query = @"
                    UPDATE Courses SET
                        CourseName = @CourseName,
                        Description = @Description,
                        CategoryID = @CategoryID,
                        ImageCover = @ImageCover
                    WHERE CourseID = @CourseID 
                      AND TeacherID = @TeacherID";

                var parameters = new Dictionary<string, object>
                {
                    { "@CourseID", courseID },
                    { "@CourseName", courseName },
                    { "@Description", string.IsNullOrWhiteSpace(description) ? "" : description },
                    { "@CategoryID", categoryID },
                    { "@TeacherID", teacherID },
                    { "@ImageCover", string.IsNullOrWhiteSpace(imageCover) ? (object)DBNull.Value : imageCover }
                };

                return dataProcess.ChangeData(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khóa học: " + ex.Message, ex);
            }
        }

        // =============================================
        // HELPER METHODS (TÙY CHỌN)
        // =============================================

        /// <summary>
        /// Kiểm tra xem khóa học có tồn tại và thuộc về giáo viên này không
        /// </summary>
        public bool IsCourseOwner(int courseID, string teacherID)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM Courses 
                    WHERE CourseID = @CourseID 
                      AND TeacherID = @TeacherID";

                var parameters = new Dictionary<string, object>
                {
                    { "@CourseID", courseID },
                    { "@TeacherID", teacherID }
                };

                DataTable dt = dataProcess.ReadData(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0]) > 0;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy trạng thái hiện tại của khóa học
        /// </summary>
        public string GetCourseStatus(int courseID)
        {
            try
            {
                string query = @"
                    SELECT Status 
                    FROM Courses 
                    WHERE CourseID = @CourseID";

                var parameters = new Dictionary<string, object>
                {
                    { "@CourseID", courseID }
                };

                DataTable dt = dataProcess.ReadData(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Status"].ToString();
                }

                return "Pending";
            }
            catch
            {
                return "Pending";
            }
        }
    }
}