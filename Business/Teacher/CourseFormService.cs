using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    public class CourseFormService
    {
        private DataProcess dataProcess;

        public CourseFormService()
        {
            dataProcess = new DataProcess();
        }

        // =============================================
        // CATEGORY DROPDOWN
        // =============================================

        public DataTable GetAllCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
            return dataProcess.ReadData(query);
        }

        // =============================================
        // COURSE CRUD
        // =============================================

        /// <summary>
        /// ✅ CourseID là INT (IDENTITY)
        /// </summary>
        public DataTable GetCourseDetails(int courseID)
        {
            string query = @"
                SELECT CourseName, Description, CategoryID, ImageCover, Status 
                FROM Courses 
                WHERE CourseID = @CourseID";

            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseID }
            };

            return dataProcess.ReadData(query, parameters);
        }

        /// <summary>
        /// ✅ CategoryID là VARCHAR(50), TeacherID là VARCHAR(50)
        /// ✅ Trả về INT (CourseID vừa tạo)
        /// </summary>
        public int CreateCourse(string categoryID, string courseName, string description,
            string teacherID, string imageCover, string status)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("Tên khóa học không được để trống");

            if (string.IsNullOrWhiteSpace(categoryID))
                throw new ArgumentException("Phải chọn danh mục");

            string query = @"
                INSERT INTO Courses
                (CourseName, Description, CategoryID, TeacherID, ImageCover, Status, TotalLessons, CreatedAt)
                VALUES (@CourseName, @Description, @CategoryID, @TeacherID, @ImageCover, @Status, 0, GETDATE());
                
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parameters = new Dictionary<string, object>
            {
                { "@CourseName", courseName },
                { "@Description", description ?? "" },
                { "@CategoryID", categoryID },           // ✅ STRING
                { "@TeacherID", teacherID },             // ✅ STRING
                { "@ImageCover", string.IsNullOrWhiteSpace(imageCover) ? (object)DBNull.Value : imageCover },
                { "@Status", status ?? "Active" }
            };

            DataTable dt = dataProcess.ReadData(query, parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        /// <summary>
        /// ✅ CourseID là INT, CategoryID và TeacherID là VARCHAR(50)
        /// </summary>
        public bool UpdateCourse(int courseID, string categoryID, string courseName,
            string description, string teacherID, string imageCover, string status)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("Tên khóa học không được để trống");

            if (string.IsNullOrWhiteSpace(categoryID))
                throw new ArgumentException("Phải chọn danh mục");

            string query = @"
                UPDATE Courses SET
                    CourseName = @CourseName,
                    Description = @Description,
                    CategoryID = @CategoryID,
                    ImageCover = @ImageCover,
                    Status = @Status
                WHERE CourseID = @CourseID AND TeacherID = @TeacherID";

            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseID },               // ✅ INT
                { "@CourseName", courseName },
                { "@Description", description ?? "" },
                { "@CategoryID", categoryID },           // ✅ STRING
                { "@TeacherID", teacherID },             // ✅ STRING
                { "@ImageCover", string.IsNullOrWhiteSpace(imageCover) ? (object)DBNull.Value : imageCover },
                { "@Status", status ?? "Active" }
            };

            return dataProcess.ChangeData(query, parameters);
        }
    }
}
