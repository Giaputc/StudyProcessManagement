using System;
using System.Collections.Generic;
using System.Data;
using StudyProcessManagement.Models;
using StudyProcessManagement.Business.Admin;

namespace StudyProcessManagement.Business.Admin
{
    public class StudentService
    {
        private DataProcessDAL dataProcess = new DataProcessDAL();

        // Hàm lấy danh sách Student THẬT
        public List<Users> GetAllStudents(string keyword = "")
        {
            List<Users> studentList = new List<Users>();

            // Dùng DISTINCT để loại bỏ dữ liệu trùng lặp (nếu có)
            string sql = @"
                SELECT DISTINCT u.UserID, u.FullName, u.PhoneNumber, a.Email, a.Role, a.IsActive
                FROM Users u 
                INNER JOIN Accounts a ON u.AccountID = a.AccountID
                WHERE a.Role LIKE '%Student%'";

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(keyword) && keyword != "Tìm kiếm học viên...")
            {
                sql += " AND (u.FullName LIKE @Search OR a.Email LIKE @Search OR u.UserID LIKE @Search)";
                parameters.Add("@Search", "%" + keyword + "%");
            }

            DataTable dt = dataProcess.ReadData(sql, parameters);

            foreach (DataRow row in dt.Rows)
            {
                studentList.Add(new Users()
                {
                    UserID = row["UserID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    Role = row["Role"].ToString(),
                    PhoneNumber = row["PhoneNumber"] != DBNull.Value ? row["PhoneNumber"].ToString() : "",
                    IsActive = Convert.ToBoolean(row["IsActive"])
                });
            }
            return studentList;
        }

        public bool DeleteStudent(string userId)
        {
            UserService userSv = new UserService();
            return userSv.DeleteUser(userId);
        }
    }
}