
using System;
using System.Collections.Generic;
using System.Data;
namespace StudyProcessManagement.Business.Admin
{
    public class UserService
    {
        private DataProcess dt = new DataProcess();
        public DataTable GetUser(string command)
        {
            string sql = @"select u.UserID, u.FullName, a.Email,a.Role
            from Users u inner join Accounts a on u.AccountID = a.AccountID;";
            var parameters = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(command) && command != "Tìm kiếm người dùng...")
            {
                sql += " AND (u.FullName LIKE @Search OR a.Email LIKE @Search OR u.UserID LIKE @Search)";
                parameters.Add("@Search", "%" + command + "%");
            }
            return dt.ReadData(sql, parameters);
        }
        public bool DeleteUser(string userId)
        {
            // Lấy AccountID trước
            string getAccSql = "SELECT AccountID FROM Users WHERE UserID = @UserID";
            var paramGet = new Dictionary<string, object> { { "@UserID", userId } };
            DataTable Dt = dt.ReadData(getAccSql, paramGet);

            if (Dt.Rows.Count > 0)
            {
                string accountId = Dt.Rows[0]["AccountID"].ToString();

                // Xóa Account
                string delSql = "DELETE FROM Accounts WHERE AccountID = @AccountID";
                var paramDel = new Dictionary<string, object> { { "@AccountID", accountId } };

                return dt.UpdateData(delSql, paramDel);
            }
            return false;
        }
    }
}
