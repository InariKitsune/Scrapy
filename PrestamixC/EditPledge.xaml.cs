using System;
using System.Collections.Generic;
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
using System.Data;
using MahApps.Metro;
using MahApps.Metro.Controls;
using PrestamixC.dao;

namespace PrestamixC
{
    /// <summary>
    /// Interaction logic for EditPledge.xaml
    /// </summary>
    public partial class EditPledge : MetroWindow
    {
        private string m_ID = "-1";
        private DBAccess m_dba;
        public EditPledge(string id)
        {
            InitializeComponent();            
            m_ID = id;
            this.Title = "Editando prenda n°: " + m_ID;
            m_dba = null;
            showPledgeData();
        }
        private void showPledgeData()
        {
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Prenda", true, true, 3, "Nombre", "Ubicacion", "Descripcion", "Id", m_ID, "=");
            DataRow row = m_dt.Rows[0];
            NameTextBox.Text = row["Nombre"].ToString();
            LocationTextBox.Text = row["Ubicacion"].ToString();
            DescriptionTextBox.Text = row["Descripcion"].ToString();          
            m_dba = null;
        }
        private void confirmB_Click(object sender, RoutedEventArgs e)
        {
            m_dba = new DBAccess();
            m_dba.UpdateTable("Prenda", 3, "Nombre", "Ubicacion", "Descripcion", "Id", NameTextBox.Text, LocationTextBox.Text, DescriptionTextBox.Text, m_ID, "=");
            m_dba = null;
            Close();
        }
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            m_ID = "-1";
            Close();
        }
    }
}
