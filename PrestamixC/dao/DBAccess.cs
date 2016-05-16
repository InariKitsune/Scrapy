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
        private static string connectionString;
        public DBAccess()
        {
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFileName=G:\PrestamixCv2.1\PrestamixCv2.1\PrestamixC\DB\Database1.mdf;Integrated Security=True;";
        }
        public DataTable SelectFromTable(string tablename, bool selectRows, bool selectCondition, int numberOfRows, params string [] values)
        {
            string query = "";
            if (selectRows)
            {
                query = "SELECT ";
                for (int i = 0; i < numberOfRows; i++)
                {
                    query = query + values[i];
                    if (i < (numberOfRows - 1))
                        query = query + ",";
                }                                        
                query = query + " FROM " + tablename;   
            }
            else
                query = "SELECT * FROM " + tablename;
            if (selectCondition)
                query = query + " WHERE "+values[numberOfRows]+"=@condition";
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();                     
            String sql = string.Format(query);
            SqlCommand command = new SqlCommand(sql, connection);
            if (selectCondition)
                command.Parameters.AddWithValue("@condition", values[numberOfRows + 1]);           
            SqlDataReader reader = command.ExecuteReader();
            DataTable m_dt = new DataTable();
            m_dt.Load(reader);
            connection.Close();            
            return m_dt;
        }
        /************************************************************************************
         * ejemplos de entrada para la funcion SelectFromTable():
         *      1.- SelectFromTable("tablename", false, false, 0)
         *          ----La sentencia SQL que ejecuta es : SELECT * FROM tablename
         *      2.- SelectFromTable("tablename", false, true, 0, "Id", "7989234")
         *          ----La sentencia SQL que ejecuta es : SELECT * FROM tablename WHERE Id = "7989234"
         *      3.- SelectFromTable("tablename", true, false, 2, "Monto", "Tipo")
         *          ----La sentencia SQL que ejecuta es : SELECT Monto, Tipo FROM tablename
         *      4.- SelectFromTable("tablename", true, true, 2, "Monto", "Tipo", "Id", "7989234")
         *          ----La sentencia SQL que ejecuta es : SELECT Monto, Tipo FROM tablename WHERE Id = "7989234"
         ************************************************************************************/
        public void InsertIntoTable(string tablename, params string[] values)
        {
            string query = "INSERT INTO " + tablename + " (";
            int i;
            for (i = 0; i < values.Length/2; i++)
            {
                query = query + values[i];
                if (i < (values.Length/2) - 1)
                    query = query + ", ";
            }
            query = query + " ) VALUES ( ";
            for (i = values.Length / 2; i < values.Length; i++)
            {
                query = query + "@inn"+ i;
                if (i < (values.Length) - 1)
                    query = query + ", ";
            }
            query = query + " )";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            String sql = string.Format(query);
            SqlCommand command = new SqlCommand(sql, connection);
            for (i = values.Length/2; i < values.Length; i++)
            {
                string inParam = "@inn" + i;
                command.Parameters.AddWithValue(inParam, values[i]);
            }
            command.ExecuteNonQuery();           
            connection.Close();    
        }
        public void DeleteFromTable(string tablename, string id)
        {
            string query = "DELETE FROM " + tablename + " WHERE Id=@cond";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            String sql1 = string.Format(query);
            SqlCommand command = new SqlCommand(sql1, connection);
            command.Parameters.AddWithValue("@cond", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateTable(string tablename, int nColums, params string[] values)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE " +tablename+ " SET ";
            for (int i = 0; i < nColums; i++)
            {
                query = query + values[i] + "=@dat" + i;
                if (i < nColums - 1)
                    query = query + ", ";
            }
            query = query + " WHERE Id=@conn";            
            connection.Open();
            String sql1 = string.Format(query);
            SqlCommand command = new SqlCommand(sql1, connection);
            int j = 0;
            for (int i = nColums; i < nColums*2; i++)
            {
                string inParam = "@dat" + j;
                j++;
                command.Parameters.AddWithValue(inParam, values[i]);
            }
            command.Parameters.AddWithValue("@conn", values[values.Length - 1]);
            command.ExecuteNonQuery();
        }
        public bool tableIsEmpty(string tablename)
        {
            string query = "SELECT COUNT(*) FROM " + tablename;            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            String sql = string.Format(query);
            SqlCommand command = new SqlCommand(sql, connection);            
            int reader = Convert.ToInt32(command.ExecuteScalar());            
            connection.Close();            
            return reader == 0;
        }
    }
}
