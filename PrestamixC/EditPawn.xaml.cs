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

namespace PrestamixC
{
    /// <summary>
    /// Interaction logic for EditPawn.xaml
    /// </summary>
    public partial class EditPawn : Window
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
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            String sql = string.Format("SELECT Monto, Tipo, Fecha, Estado FROM Empenio WHERE Id = @thisId");
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@thisId", m_ID);

            SqlDataReader reader = command.ExecuteReader();

            DataTable TablaDatos = new DataTable(); // CREAMOS UN VALOR datatable PARA IMPRIMIR
            TablaDatos.Load(reader); // CARGA EL READER ANTERIORMENTE CREADO
            DataRow row = TablaDatos.Rows[0];
            SumTextBox.Text = row["Monto"].ToString();
            typeTextBox.Text = row["Tipo"].ToString();
            mDateP.SelectedDate = DateTime.Parse(row["Fecha"].ToString());
            StatusTextBox.Text = row["Estado"].ToString();

            connection.Close();
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
