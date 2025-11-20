using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StudyProcessManagement.Business
{
    public class DataProcess
    {
        string ConnectString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=StudyProcess;Integrated Security=True;Encrypt=False";
        SqlConnection sqlConnect = null;

        private void OpenConnect()
        {
            
            if (sqlConnect == null)
            {
                sqlConnect = new SqlConnection(ConnectString);
            }
          
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }

        private void CloseConnect()
        {
          
            if (sqlConnect != null && sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose(); // Giải phóng tài nguyên
                sqlConnect = null;
            }
        }

      
        public DataTable ReadData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnect();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnect))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đọc dữ liệu: " + ex.Message);
            }
            finally
            {
                CloseConnect();
            }
            return dt;
        }

       
        public DataTable ReadData(string sql, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnect();
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
                {
                    // Thêm tham số vào câu lệnh để bảo mật
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đọc dữ liệu: " + ex.Message);
            }
            finally
            {
                CloseConnect();
            }
            return dt;
        }


        public bool UpdateData(string sql, Dictionary<string, object> parameters)
        {
            bool isSuccess = false;
            try
            {
                OpenConnect();
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                        }
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    isSuccess = rowsAffected > 0; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật dữ liệu: " + ex.Message);
            }
            finally
            {
                CloseConnect();
            }
            return isSuccess;
        }
    }
}