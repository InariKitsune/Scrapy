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
                if (int.TryParse(CiTextBox.Text, out i) && int.TryParse(IdEmpeñoTextBox.Text, out i) && int.TryParse(IdPrendaTextBox.Text, out i) && ((int.TryParse(TelefonoTextBox.Text, out i) && int.TryParse(MontoTextBox.Text, out i)) || TelefonoTextBox.Text == "" || MontoTextBox.Text == ""))
                {
                    m_dba = new DBAccess();
                    /*registrando cliente*/
                    if (!customerExist)
                    {
                        try
                        {
                            m_dba.InsertIntoTable("Cliente", "Id", "Nombre", "ApellidoP", "ApellidoM", "Direccion", "Telefono", CiTextBox.Text, NombreTextBox.Text, ApellidoPaternoTextBox.Text, ApellidoMaternoTextBox.Text, DireccionTextBox.Text, TelefonoTextBox.Text);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            
                        }
                    }                       
                    /*registrando prenda*/
                    try
                    {
                        m_dba.InsertIntoTable("Prenda", "Id", "Nombre", "Ubicacion", "Descripcion", IdPrendaTextBox.Text, NombrePrendaTextBox.Text, WarehouseComboBox.Text, DescripcionTextBox.Text);
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Ya se ha registrado una prenda con el mismo numero. Por favor, cambie el valor del campo -Id Prenda- e intentelo nuevamente");
                        m_dba = null;
                        return;
                    }             
                    /*registrando empeño*/
                    try
                    {
                        m_dba.InsertIntoTable("Empenio", "Id", "IdCliente", "IdPrenda", "Monto", "Tipo", "Fecha", "Estado", IdEmpeñoTextBox.Text, CiTextBox.Text, IdPrendaTextBox.Text, MontoTextBox.Text, TipoTextBox.Text, DateTime.ParseExact(FechaTextBox.SelectedDate.ToString(), (Application.Current as PrestamixC.App).currentDateTimeFormat, CultureInfo.InvariantCulture).ToString("M/d/yyyy h:mm:ss tt"), "Vigente");
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Ya se ha registrado un empeño con el mismo numero. Por favor, cambie el valor del campo -Id Empeño- e intentelo nuevamente");
                        m_dba.DeleteFromTable("Prenda", IdPrendaTextBox.Text);
                        m_dba = null;
                        return;
                    }
                    Close();
                }
                else
                    MessageBox.Show("Los campos -C.I.-,-Id Prenda-, -Id Empeño-, -Monto- y -Teléfono- deben ser numéricos");
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
