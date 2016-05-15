using System;
using System.Collections.Generic;
using System.Data;
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
using PrestamixC.dao;

namespace PrestamixC
{
    /// <summary>
    /// Interaction logic for RegistrarEmpeño.xaml
    /// </summary>
    public partial class RegistrarEmpeño : MetroWindow
    {
        private DBAccess m_dba;
        public RegistrarEmpeño()
        {
            InitializeComponent();
            FechaTextBox.SelectedDate = DateTime.Today;
        }

        private void ConfirmarEmpeñoBoton_Click(object sender, RoutedEventArgs e)
        {
            m_dba = new DBAccess();          
            m_dba.InsertIntoTable("Cliente", "Id", "Nombre", "ApellidoP", "ApellidoM", "Direccion", "Telefono", CiTextBox.Text, NombreTextBox.Text, ApellidoPaternoTextBox.Text, ApellidoMaternoTextBox.Text, DireccionTextBox.Text, TelefonoTextBox.Text);
            m_dba.InsertIntoTable("Empenio", "Id", "IdCliente", "IdPrenda", "Monto", "Tipo", "Fecha", "Estado", IdEmpeñoTextBox.Text, CiTextBox.Text, IdPrendaTextBox.Text, MontoTextBox.Text, TipoTextBox.Text, FechaTextBox.SelectedDate.ToString(), "Vigente");
            m_dba.InsertIntoTable("Prenda", "Id", "Nombre", "Ubicacion", "Descripcion", IdPrendaTextBox.Text, NombrePrendaTextBox.Text, UbicacionTextBox.Text, DescripcionTextBox.Text);
            m_dba = null;
            Close();
        }
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
