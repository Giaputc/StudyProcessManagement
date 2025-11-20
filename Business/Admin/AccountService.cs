using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProcessManagement.Business.Admin
{
    public class AccountService
    {
        private DataProcess dataProcess = new DataProcess();

        // Hàm kiểm tra đăng nhập
        // Trả về DataRow chứa thông tin user nếu đúng, trả về null nếu sai
        public DataRow Login(string email, string password)
        {
            string sql = @"
                SELECT 
                    A.AccountID, 
                    A.Role, 
                    U.FullName,
                    U.UserID
                FROM Accounts A
                JOIN Users U ON A.AccountID = U.AccountID
                WHERE A.Email = @Email 
                  AND A.PasswordHash = @Pass 
                  AND A.IsActive = 1";
            var parameters = new Dictionary<string, object>
            {
                { "@Email", email },
                { "@Pass", password }
            };

            DataTable dt = dataProcess.ReadData(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]; 
            }

            return null; 
        }
    }
}
