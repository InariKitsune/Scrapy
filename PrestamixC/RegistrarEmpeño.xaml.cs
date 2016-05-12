using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

namespace PrestamixC
{
    /// <summary>
    /// Interaction logic for RegistrarEmpeño.xaml
    /// </summary>
    public partial class RegistrarEmpeño : MetroWindow
    {
        private string connectionString = App.connectionString;
        public RegistrarEmpeño()
        {
            InitializeComponent();
        }

        private void ConfirmarEmpeñoBoton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            String sql1 = string.Format("INSERT INTO Cliente (Id,Nombre,ApellidoP,ApellidoM,Direccion,Telefono) VALUES (@Id,@Nombre,@ApellidoP,@ApellidoM,@Direccion,@Telefono)");
            String sql2 = string.Format("INSERT INTO Prenda (Id,Nombre,Ubicacion,Descripcion) VALUES (@Id,@Nombre,@Ubicacion,@Descripcion)");
            String sql3 = string.Format("INSERT INTO Empenio (Id,IdCliente,IdPrenda,Monto,Tipo,Fecha,Estado) VALUES (@Id,@IdCliente,@IdPrenda,@Monto, @Tipo,@Fecha,@Estado)");
            SqlCommand command1 = new SqlCommand(sql1, connection);
            SqlCommand command2 = new SqlCommand(sql2, connection);
            SqlCommand command3 = new SqlCommand(sql3, connection);

            string Id = CiTextBox.Text;
            string Nombre = NombreTextBox.Text;
            string ApellidoP = ApellidoPaternoTextBox.Text;
            string ApellidoM = ApellidoMaternoTextBox.Text;
            string Direccion = DireccionTextBox.Text;
            string Telefono = TelefonoTextBox.Text;

            string NombrePrenda = NombrePrendaTextBox.Text;
            string IdPrenda = IdPrendaTextBox.Text;
            string Descripcion = DescripcionTextBox.Text;
            string Ubicacion = UbicacionTextBox.Text;

            string IdEmp = IdEmpeñoTextBox.Text;
            string IdCliente = CiTextBox.Text;
            string IdPren = IdPrendaTextBox.Text;
            string Monto = MontoTextBox.Text;
            string Tipo = TipoTextBox.Text;
            DateTime? Fecha = FechaTextBox.SelectedDate;

            command1.Parameters.AddWithValue("@Id", Id);
            command1.Parameters.AddWithValue("@Nombre", Nombre);
            command1.Parameters.AddWithValue("@ApellidoP", ApellidoP);
            command1.Parameters.AddWithValue("@ApellidoM", ApellidoM);
            command1.Parameters.AddWithValue("@Direccion", Direccion);
            command1.Parameters.AddWithValue("@Telefono", Telefono);
            
            command2.Parameters.AddWithValue("@Id", IdPrenda);
            command2.Parameters.AddWithValue("@Nombre", NombrePrenda);
            command2.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            command2.Parameters.AddWithValue("@Descripcion", Descripcion);

            command3.Parameters.AddWithValue("@Id", Id);
            command3.Parameters.AddWithValue("@IdCliente", IdCliente);
            command3.Parameters.AddWithValue("@IdPrenda", IdPrenda);
            command3.Parameters.AddWithValue("@Monto", Monto);
            command3.Parameters.AddWithValue("@Tipo", Tipo);
            command3.Parameters.AddWithValue("@Fecha", Fecha);
            command3.Parameters.AddWithValue("@Estado", "Vigente");

            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();

            connection.Close();
            Close();
        }
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
