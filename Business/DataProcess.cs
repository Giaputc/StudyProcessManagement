using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice24._10
{
    internal class DataProcess
    {
        string ConnectString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BooksManagements;Integrated Security=True;Encrypt=False";
        SqlConnection sqlConnect = null;

        private void OpenConnect()
        {
            sqlConnect = new SqlConnection(ConnectString);
            if (sqlConnect.State != System.Data.ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        private void CloseConnect()
        {
            sqlConnect = new SqlConnection(ConnectString);
            if (sqlConnect.State != System.Data.ConnectionState.Closed)
            {
                sqlConnect.Close();
            }
        }

        public DataTable ReadData(string sql)
        {
            DataTable dt = new DataTable();
            OpenConnect();
            SqlDataAdapter adapter = new SqlDataAdapter(sql,sqlConnect);
            adapter.Fill(dt);
            CloseConnect();
            return dt;
        }

        public void UpdateData(string sql, Dictionary<string,object>parameter)
        {
            OpenConnect();
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
            {
                foreach(var p in parameter)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                }
                cmd.ExecuteNonQuery();
            }
            CloseConnect();
        }
    }
}
