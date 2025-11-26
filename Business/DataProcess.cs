using Microsoft.IdentityModel.Protocols; // <--- Giữ lại (Từ teacher-final)
using System;
using System.Collections.Generic;
using System.Configuration; // <--- Giữ lại (Từ teacher-final)
using System.Data;
using System.Data.SqlClient;

namespace StudyProcessManagement.Business
{
    public class DataProcessDAL
    {
        // ✅ GIỮ BẢN TỪ App.config (Teacher-final) để lấy chuỗi kết nối từ file cấu hình
        private string ConnectString = ConfigurationManager.ConnectionStrings["StudyProcessConnection"].ConnectionString;
        private SqlConnection sqlConnect = null;

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
                sqlConnect.Dispose();
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

        // ✅ READ DATA VỚI PARAMETERS (Gộp logic của cả hai bên)
        public DataTable ReadData(string sql, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnect();
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            // Dùng logic cũ của teacher-final, thêm DBNull.Value (từ master)
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
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

        // ❌ BỎ UpdateData/ChangeData của master, giữ ChangeData của teacher-final và đặt UpdateData làm Alias
        public bool ChangeData(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                OpenConnect();
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value); // Thêm DBNull từ master
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi lệnh: " + ex.Message);
            }
            finally
            {
                CloseConnect();
            }
        }

        // ✅ Alias cho tương thích code cũ (service gọi UpdateData như ChangeData)
        public bool UpdateData(string sql, Dictionary<string, object> parameters)
        {
            return ChangeData(sql, parameters);
        }

        // ✅ Method mới cho StoredProcedure (Lấy từ teacher-final)
        public DataTable ExecuteStoredProcedure(string spName, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnect();
                using (SqlCommand cmd = new SqlCommand(spName, sqlConnect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value); // Thêm DBNull từ master
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
                throw new Exception("Lỗi thực thi stored procedure: " + ex.Message);
            }
            finally
            {
                CloseConnect();
            }
            return dt;
        }
    }
}