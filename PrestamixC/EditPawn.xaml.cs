using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro;
using MahApps.Metro.Controls;
using PrestamixC.dao;

namespace PrestamixC
{
    /// <summary>
    /// Interaction logic for EditPawn.xaml
    /// </summary>
    public partial class EditPawn : MetroWindow
    {
        private string connectionString = App.connectionString;
        private string m_ID = "-1"; 
        public EditPawn(string id)
        {
            InitializeComponent();
            m_ID = id;
            showPawnData();
        }
        void showPawnData()
        {
            DBAccess m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Empenio", true, true, 4, "Monto", "Tipo", "Fecha", "Estado", "Id", m_ID);           
            DataRow row = m_dt.Rows[0];
            SumTextBox.Text = row["Monto"].ToString();
            typeTextBox.Text = row["Tipo"].ToString();
            mDateP.SelectedDate = DateTime.Parse(row["Fecha"].ToString());
            StatusTextBox.Text = row["Estado"].ToString();           
        }

        private void confirmB_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            String sql = string.Format("UPDATE Empenio SET Monto = @mSum, Tipo = @mType, Fecha = @mDate, Estado = @mStatus WHERE Id = @thisId");
            SqlCommand command = new SqlCommand(sql, connection);           
            string mSum = SumTextBox.Text;
            string mType = typeTextBox.Text;
            string mStatus = StatusTextBox.Text;
            DateTime? Fecha = mDateP.SelectedDate;
            command.Parameters.AddWithValue("@mSum", mSum);
            command.Parameters.AddWithValue("@mType", mType);
            command.Parameters.AddWithValue("@mDate", Fecha);
            command.Parameters.AddWithValue("@mStatus", mStatus);
            command.Parameters.AddWithValue("@thisId", m_ID);
            command.ExecuteNonQuery();
            Close();
        }

        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            m_ID = "-1";
            Close();
        }
    }
}
