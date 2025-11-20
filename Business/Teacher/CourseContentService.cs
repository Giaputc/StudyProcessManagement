using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Teacher
{
    public class CourseContentService
    {
        private DataProcess dataProcess;

        public CourseContentService()
        {
            dataProcess = new DataProcess();
        }

        // =============================================
        // COURSE OPERATIONS
        // =============================================

        /// <summary>
        /// Lấy danh sách khóa học của giáo viên
        /// </summary>
        public DataTable GetTeacherCourses(string teacherID)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@TeacherID", teacherID }
            };
            return dataProcess.ExecuteStoredProcedure("sp_GetTeacherCourses", parameters);
        }

        // =============================================
        // SECTION OPERATIONS
        // =============================================

        /// <summary>
        /// Lấy danh sách Sections của khóa học
        /// </summary>
        public DataTable GetCourseSections(string courseID)
        {
            string sql = @"
                SELECT SectionID, SectionTitle, SectionOrder 
                FROM Sections 
                WHERE CourseID = @CourseID 
                ORDER BY SectionOrder";

            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseID }
            };

            return dataProcess.ReadData(sql, parameters);
        }

        /// <summary>
        /// Thêm Section mới
        /// </summary>
        public bool AddSection(string courseID, string sectionTitle)
        {
            if (string.IsNullOrWhiteSpace(sectionTitle))
                throw new ArgumentException("Tên chương không được để trống");

            try
            {
                // Get next section order
                string sqlOrder = "SELECT ISNULL(MAX(SectionOrder), 0) + 1 FROM Sections WHERE CourseID = @CourseID";
                var paramOrder = new Dictionary<string, object> { { "@CourseID", courseID } };
                DataTable dtOrder = dataProcess.ReadData(sqlOrder, paramOrder);
                int nextOrder = Convert.ToInt32(dtOrder.Rows[0][0]);

                // Generate new SectionID
                string newSectionID = "SEC" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();

                // Insert new section
                string sqlInsert = @"
                    INSERT INTO Sections (SectionID, CourseID, SectionTitle, SectionOrder) 
                    VALUES (@SectionID, @CourseID, @SectionTitle, @SectionOrder)";

                var parameters = new Dictionary<string, object>
                {
                    { "@SectionID", newSectionID },
                    { "@CourseID", courseID },
                    { "@SectionTitle", sectionTitle },
                    { "@SectionOrder", nextOrder }
                };

                return dataProcess.ChangeData(sqlInsert, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chương: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa Section
        /// </summary>
        public bool DeleteSection(string sectionID)
        {
            if (string.IsNullOrEmpty(sectionID))
                throw new ArgumentException("ID chương không hợp lệ");

            string sql = "DELETE FROM Sections WHERE SectionID = @SectionID";
            var parameters = new Dictionary<string, object>
            {
                { "@SectionID", sectionID }
            };

            return dataProcess.ChangeData(sql, parameters);
        }

        // =============================================
        // LESSON OPERATIONS
        // =============================================

        /// <summary>
        /// Lấy danh sách Lessons của Section
        /// </summary>
        public DataTable GetSectionLessons(string sectionID)
        {
            string sql = @"
                SELECT LessonID, LessonTitle, LessonOrder 
                FROM Lessons 
                WHERE SectionID = @SectionID 
                ORDER BY LessonOrder";

            var parameters = new Dictionary<string, object>
            {
                { "@SectionID", sectionID }
            };

            return dataProcess.ReadData(sql, parameters);
        }

        /// <summary>
        /// Lấy chi tiết bài học
        /// </summary>
        public DataTable GetLessonDetails(string lessonID)
        {
            string sql = "SELECT * FROM Lessons WHERE LessonID = @LessonID";
            var parameters = new Dictionary<string, object>
            {
                { "@LessonID", lessonID }
            };

            return dataProcess.ReadData(sql, parameters);
        }

        /// <summary>
        /// Thêm Lesson mới
        /// </summary>
        public bool AddLesson(string courseID, string sectionID, string lessonTitle,
            string content, string videoUrl, string attachmentUrl)
        {
            if (string.IsNullOrWhiteSpace(lessonTitle))
                throw new ArgumentException("Tên bài học không được để trống");

            if (string.IsNullOrEmpty(sectionID))
                throw new ArgumentException("Phải chọn chương trước khi thêm bài học");

            try
            {
                // Get next lesson order
                string sqlOrder = "SELECT ISNULL(MAX(LessonOrder), 0) + 1 FROM Lessons WHERE SectionID = @SectionID";
                var paramOrder = new Dictionary<string, object> { { "@SectionID", sectionID } };
                DataTable dtOrder = dataProcess.ReadData(sqlOrder, paramOrder);
                int nextOrder = Convert.ToInt32(dtOrder.Rows[0][0]);

                // Generate new LessonID
                string newLessonID = "LES" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();

                // Insert new lesson
                string sqlInsert = @"
                    INSERT INTO Lessons (LessonID, CourseID, SectionID, LessonTitle, LessonOrder, 
                                        Content, VideoUrl, AttachmentUrl) 
                    VALUES (@LessonID, @CourseID, @SectionID, @Title, @Order, 
                           @Content, @VideoUrl, @Attachment)";

                var parameters = new Dictionary<string, object>
                {
                    { "@LessonID", newLessonID },
                    { "@CourseID", courseID },
                    { "@SectionID", sectionID },
                    { "@Title", lessonTitle },
                    { "@Order", nextOrder },
                    { "@Content", content ?? "" },
                    { "@VideoUrl", videoUrl ?? "" },
                    { "@Attachment", attachmentUrl ?? "" }
                };

                return dataProcess.ChangeData(sqlInsert, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm bài học: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật Lesson
        /// </summary>
        public bool UpdateLesson(string lessonID, string lessonTitle, string content,
            string videoUrl, string attachmentUrl)
        {
            if (string.IsNullOrWhiteSpace(lessonTitle))
                throw new ArgumentException("Tên bài học không được để trống");

            if (string.IsNullOrEmpty(lessonID))
                throw new ArgumentException("ID bài học không hợp lệ");

            string sql = @"
                UPDATE Lessons 
                SET LessonTitle = @Title, 
                    Content = @Content, 
                    VideoUrl = @VideoUrl, 
                    AttachmentUrl = @Attachment 
                WHERE LessonID = @LessonID";

            var parameters = new Dictionary<string, object>
            {
                { "@LessonID", lessonID },
                { "@Title", lessonTitle },
                { "@Content", content ?? "" },
                { "@VideoUrl", videoUrl ?? "" },
                { "@Attachment", attachmentUrl ?? "" }
            };

            return dataProcess.ChangeData(sql, parameters);
        }

        /// <summary>
        /// Xóa Lesson
        /// </summary>
        public bool DeleteLesson(string lessonID)
        {
            if (string.IsNullOrEmpty(lessonID))
                throw new ArgumentException("ID bài học không hợp lệ");

            string sql = "DELETE FROM Lessons WHERE LessonID = @LessonID";
            var parameters = new Dictionary<string, object>
            {
                { "@LessonID", lessonID }
            };

            return dataProcess.ChangeData(sql, parameters);
        }
    }
}
