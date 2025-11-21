using System;
using System.Data;
using System.Collections.Generic;

namespace StudyProcessManagement.Business.Admin
{
    public class ContentService
    {
        private DataProcess dataProcess = new DataProcess();

        // Lấy Chương
        public DataTable GetSections(string courseId)
        {
            string sql = "SELECT * FROM Sections WHERE CourseID = @ID ORDER BY SectionOrder";
            var param = new Dictionary<string, object> { { "@ID", courseId } };
            return dataProcess.ReadData(sql, param);
        }

        // Lấy Bài học
        public DataTable GetLessons(string sectionId)
        {
            string sql = "SELECT * FROM Lessons WHERE SectionID = @ID ORDER BY LessonOrder";
            var param = new Dictionary<string, object> { { "@ID", sectionId } };
            return dataProcess.ReadData(sql, param);
        }

        // Lấy chi tiết bài học
        public DataRow GetLessonDetail(string lessonId)
        {
            string sql = "SELECT * FROM Lessons WHERE LessonID = @ID";
            var param = new Dictionary<string, object> { { "@ID", lessonId } };
            DataTable dt = dataProcess.ReadData(sql, param);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // DUYỆT KHÓA HỌC
        public bool ApproveCourse(string courseId)
        {
            string sql = "UPDATE Courses SET Status = 'Approved' WHERE CourseID = @ID";
            var param = new Dictionary<string, object> { { "@ID", courseId } };
            return dataProcess.UpdateData(sql, param);
        }
    }
}