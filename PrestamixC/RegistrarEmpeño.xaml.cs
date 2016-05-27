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
using System.Globalization;
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
        private bool customerExist;
        public RegistrarEmpeño()
        {
            InitializeComponent();
            FechaTextBox.SelectedDate = DateTime.Today;
            loadWhComboBox();
        }
        private void loadWhComboBox()
        {
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Warehouse", true, false, 1, "Nombre");
            WarehouseComboBox.ItemsSource = m_dt.Rows;
            WarehouseComboBox.DisplayMemberPath = ".[Nombre]";
            m_dba = null;
        }
        private void ConfirmarEmpeñoBoton_Click(object sender, RoutedEventArgs e)
        {
            int i;
            if (CiTextBox.Text != "" || IdEmpeñoTextBox.Text != "" || IdPrendaTextBox.Text != "")
            {
                if (int.TryParse(CiTextBox.Text, out i) && int.TryParse(IdEmpeñoTextBox.Text, out i) && int.TryParse(IdPrendaTextBox.Text, out i))
                {
                    m_dba = new DBAccess();
                    if(!customerExist)
                        m_dba.InsertIntoTable("Cliente", "Id", "Nombre", "ApellidoP", "ApellidoM", "Direccion", "Telefono", CiTextBox.Text, NombreTextBox.Text, ApellidoPaternoTextBox.Text, ApellidoMaternoTextBox.Text, DireccionTextBox.Text, TelefonoTextBox.Text);
                    m_dba.InsertIntoTable("Empenio", "Id", "IdCliente", "IdPrenda", "Monto", "Tipo", "Fecha", "Estado", IdEmpeñoTextBox.Text, CiTextBox.Text, IdPrendaTextBox.Text, MontoTextBox.Text, TipoTextBox.Text, DateTime.ParseExact(FechaTextBox.SelectedDate.ToString(), (Application.Current as PrestamixC.App).currentDateTimeFormat, CultureInfo.InvariantCulture).ToString("M/d/yyyy h:mm:ss tt"), "Vigente");
                    m_dba.InsertIntoTable("Prenda", "Id", "Nombre", "Ubicacion", "Descripcion", IdPrendaTextBox.Text, NombrePrendaTextBox.Text, WarehouseComboBox.Text, DescripcionTextBox.Text);
                    m_dba = null;
                    Close();
                }
                else
                    MessageBox.Show("Los campos -C.I.-,-Id Prenda- e -Id Empeño- deben ser numéricos");
            }
            else
                MessageBox.Show("Los campos -C.I.-,-Id Prenda- e -Id Empeño- no pueden ser vacios");
        }
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            Close();            
        }

        private void CiTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            if (int.TryParse(CiTextBox.Text, out i))
            {
                m_dba = new DBAccess();
                DataTable m_dt = m_dba.SelectFromTable("Cliente", true, true, 5, "Nombre", "ApellidoP", "ApellidoM", "Direccion", "Telefono", "Id", CiTextBox.Text, "=");
                if (m_dt.Rows.Count > 0)
                {
                    DataRow row = m_dt.Rows[0];
                    NombreTextBox.Text = row["Nombre"].ToString();
                    ApellidoPaternoTextBox.Text = row["ApellidoP"].ToString();
                    ApellidoMaternoTextBox.Text = row["ApellidoM"].ToString();
                    DireccionTextBox.Text = row["Direccion"].ToString();
                    TelefonoTextBox.Text = row["Telefono"].ToString();
                    m_dba = null;
                    customerExist = true;
                }
                else
                {
                    NombreTextBox.Text = "";
                    ApellidoPaternoTextBox.Text = "";
                    ApellidoMaternoTextBox.Text = "";
                    DireccionTextBox.Text = "";
                    TelefonoTextBox.Text = "";
                    customerExist = false;
                }                    
            }
        }
    }
}
