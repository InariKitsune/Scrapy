using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PrestamixC.dao
{
    class DBAccess
    {
        public static string connectionString;
        public DBAccess()
        {
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFileName=G:\PrestamixCv2.1\PrestamixCv2.1\PrestamixC\DB\Database1.mdf;Integrated Security=True;";
        }
        public DataTable SelectAllFromTable(string tablename)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "SELECT * FROM " + tablename;
            String sql = string.Format(query);
            SqlCommand command = new SqlCommand(sql, connection);           
            SqlDataReader reader = command.ExecuteReader();
            DataTable m_dt = new DataTable();
            m_dt.Load(reader); // CARGA EL READER ANTERIORMENTE CREADO
            connection.Close();
            
            return m_dt;
        }
    }
}
