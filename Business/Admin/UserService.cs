using System;
using System.Collections.Generic;
using System.Data;
using StudyProcessManagement.Models;
namespace StudyProcessManagement.Business.Admin
{
    public class UserService
    {
        private DataProcess dataProcess = new DataProcess();

        // Đổi kiểu trả về: DataTable -> List<User>
        public List<Users> GetAllUsers(string keyword = "")
        {
            List<Users> userList = new List<Users>();

            string sql = @"
                SELECT u.UserID, u.FullName, a.Email, a.Role, a.IsActive
                FROM Users u 
                INNER JOIN Accounts a ON u.AccountID = a.AccountID
                WHERE 1=1";

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(keyword) && keyword != "Tìm kiếm người dùng...")
            {
                sql += " AND (u.FullName LIKE @Search OR a.Email LIKE @Search OR u.UserID LIKE @Search)";
                parameters.Add("@Search", "%" + keyword + "%");
            }

            // Lấy DataTable từ lớp DataProcess
            DataTable dt = dataProcess.ReadData(sql, parameters);

            // CHUYỂN ĐỔI (MAPPING): DataTable -> List<User>
            foreach (DataRow row in dt.Rows)
            {
                userList.Add(new Users()
                {
                    UserID = row["UserID"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Email = row["Email"].ToString(),
                    Role = row["Role"].ToString(),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    // Nếu bảng Users có thêm cột nào thì map tiếp vào đây
                });
            }

            return userList;
        }

        public bool DeleteUser(string userId)
        {
            // Bước 1: Lấy thông tin User để biết nó thuộc Account nào
            Users user = GetUserById(userId);
            if (user == null) return false; // Không tìm thấy thì nghỉ

            // Bước 2: Xóa thằng CON trước (Xóa trong bảng Users)
            string sqlDelUser = "DELETE FROM Users WHERE UserID = @UserID";
            var paramUser = new Dictionary<string, object> { { "@UserID", userId } };

            // Thực hiện xóa User
            // (Dù thành công hay không vẫn đi tiếp để xóa Account, phòng trường hợp User đã mất nhưng Account còn sót)
            dataProcess.UpdateData(sqlDelUser, paramUser);

            // Bước 3: Xóa thằng CHA sau (Xóa trong bảng Accounts)
            string sqlDelAcc = "DELETE FROM Accounts WHERE AccountID = @AccountID";
            var paramAcc = new Dictionary<string, object> { { "@AccountID", user.AccountID } };

            return dataProcess.UpdateData(sqlDelAcc, paramAcc);
        }
        public Users GetUserById(string userId)
        {
            string sql = @"
            SELECT u.UserID, u.FullName, u.PhoneNumber, u.Address, u.DateOfBirth, 
                   a.AccountID, a.Email, a.Role, a.IsActive 
            FROM Users u
            JOIN Accounts a ON u.AccountID = a.AccountID
            WHERE u.UserID = @UserID";

            var param = new Dictionary<string, object> { { "@UserID", userId } };
            DataTable dt = dataProcess.ReadData(sql, param);

            if (dt.Rows.Count > 0) return ConvertDataRowToUser(dt.Rows[0]);
            return null;
        }
        public bool AddUser(Users user, string password)
        {
            string accId = "ACC" + DateTime.Now.Ticks.ToString().Substring(10);
            //string usrId = "USR" + DateTime.Now.Ticks.ToString().Substring(10);

            // Thêm Account
            string sqlAcc = "INSERT INTO Accounts (AccountID, Email, PasswordHash, Role, IsActive) VALUES (@ID, @Email, @Pass, @Role, 1)";
            var pAcc = new Dictionary<string, object> {
                 { "@ID", accId }, { "@Email", user.Email }, { "@Pass", password }, { "@Role", user.Role }
            };

            if (dataProcess.UpdateData(sqlAcc, pAcc))
            {
                // Thêm User (Bổ sung Address, DOB)
                string sqlUsr = @"INSERT INTO Users (AccountID, FullName, PhoneNumber, Address, DateOfBirth) 
                          VALUES (@AccID, @Name, @Phone, @Address, @Dob)";

                var pUsr = new Dictionary<string, object> {
                    { "@AccID", accId },
                    { "@Name", user.FullName },
                    { "@Phone", user.PhoneNumber },
                    { "@Address", user.Address },
                    { "@Dob", user.DateOfBirth ?? (object)DBNull.Value }
                 };
                return dataProcess.UpdateData(sqlUsr, pUsr);
            }
            return false;
        }
        public bool UpdateUser(Users user)
        {
            Users oldUser = GetUserById(user.UserID);
            if (oldUser == null) return false;

            // Update Users (Bổ sung Address, DOB)
            string sqlUsr = @"UPDATE Users 
                      SET FullName = @Name, PhoneNumber = @Phone, Address = @Address, DateOfBirth = @Dob 
                      WHERE UserID = @UserID";

            var pUsr = new Dictionary<string, object> {
                { "@Name", user.FullName },
                { "@Phone", user.PhoneNumber },
                { "@Address", user.Address },
                { "@Dob", user.DateOfBirth ?? (object)DBNull.Value },
                { "@UserID", user.UserID }
             };
            dataProcess.UpdateData(sqlUsr, pUsr);

            // Update Accounts
            string sqlAcc = "UPDATE Accounts SET Role = @Role, IsActive = @Active WHERE AccountID = @AccID";
            var pAcc = new Dictionary<string, object> {
                { "@Role", user.Role }, { "@Active", user.IsActive }, { "@AccID", oldUser.AccountID }
            };

            return dataProcess.UpdateData(sqlAcc, pAcc);
        }
        private Users ConvertDataRowToUser(DataRow row)
        {
            return new Users()
            {
                UserID = row["UserID"].ToString(),
                AccountID = row["AccountID"].ToString(),
                FullName = row["FullName"].ToString(),
                Email = row["Email"].ToString(),
                Role = row["Role"].ToString(),
                PhoneNumber = row["PhoneNumber"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : "",
                DateOfBirth = row["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(row["DateOfBirth"]) : (DateTime?)null
            };
        }
        //public bool DeleteUser(string userId)
        //{
        //    Users user = GetUserById(userId);
        //    if (user == null) return false;

        //    string sql = "DELETE FROM Accounts WHERE AccountID = @ID";
        //    var param = new Dictionary<string, object> { { "@ID", user.AccountID } };

        //    return dataProcess.UpdateData(sql, param);
        //}
    }
}