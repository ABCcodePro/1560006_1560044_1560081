using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Phong_Mach_Tu.DTO;

namespace Phong_Mach_Tu.DAO
{
    class DataProvider
    {
        static string connectString = @"Data Source=WIN7-PC\MSSQLSEVER02;Initial Catalog=QLNhaThuocTu;Integrated Security=True";

        static SqlConnection connection = null;

        public static void OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectString);
            }

            if (connection != null && connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public static void ExecNonQuery(string sql)
        {
            // Mo ket noi
            OpenConnection();

            // Thuc thi truy van
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            // Dong ket noi
            CloseConnection();
        }

        public static DbAck ExecNonQuery(string sql, Dictionary<string, object> dic)
        {
            try
            {
                // Mo ket noi
                OpenConnection();

                // Thuc thi truy van
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = sql;

                foreach (string key in dic.Keys)
                {
                    command.Parameters.AddWithValue(key, dic[key]);
                }
                command.ExecuteNonQuery();


                // Dong ket noi
                CloseConnection();

                return DbAck.Ok;
            }
            catch { }

            return DbAck.Unknown;
        }

        public static DataTable ExecQuery(string sql)
        {
            DataTable result = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectString);
            adapter.Fill(result);

            return result;
        }
    }
}
