using System;
using System.Collections.Generic;
using System.Data;
using StudyProcessManagement.Models;

namespace StudyProcessManagement.Business.Admin
{
    public class TeacherService
    {
        private DataProcess dataProcess = new DataProcess();

        public List<Users> GetAllTeachers(string keyword = "")
        {
            List<Users> teacherList = new List<Users>();

            string sql = @"
            SELECT u.UserID, u.FullName, a.Email, a.Role, a.IsActive
            FROM Users u 
            INNER JOIN Accounts a ON u.AccountID = a.AccountID
            WHERE a.Role LIKE '%Teacher%'";
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(keyword) && keyword != "Tìm kiếm giảng viên...")
            {
                sql += " AND (u.FullName LIKE @Search OR a.Email LIKE @Search OR u.UserID LIKE @Search)";
                parameters.Add("@Search", "%" + keyword + "%");
            }

            DataTable dt = dataProcess.ReadData(sql, parameters);

            foreach (DataRow row in dt.Rows)
            {
                teacherList.Add(new Users()
                {
                    UserID = row["UserID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    Role = row["Role"].ToString(),
                    IsActive = Convert.ToBoolean(row["IsActive"])
                });
            }
            return teacherList;
        }

        public bool DeleteTeacher(string userId)
        {
            UserService userSv = new UserService();
            return userSv.DeleteUser(userId);
        }
    }
}