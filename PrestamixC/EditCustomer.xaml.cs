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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : MetroWindow
    {
        private string m_ID = "-1";
        private DBAccess m_dba;
        public EditCustomer(string id)
        {
            InitializeComponent();
            m_ID = id;
            m_dba = null;
            showCustomerData();
        }
        private void showCustomerData()
        {
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Cliente", true, true, 5, "Nombre", "ApellidoP", "ApellidoM", "Direccion", "Telefono", "Id", m_ID);
            DataRow row = m_dt.Rows[0];
            nameTextBox.Text = row["Nombre"].ToString();
            fTextBox.Text = row["ApellidoP"].ToString();
            mTextBox.Text = row["ApellidoM"].ToString();
            addressTextBox.Text = row["Direccion"].ToString();
            phoneTextBox.Text = row["Telefono"].ToString();
            m_dba = null;
        }
        private void confirmB_Click(object sender, RoutedEventArgs e)
        {
            m_dba = new DBAccess();
            m_dba.UpdateTable("Cliente", 5, "Nombre", "ApellidoP", "ApellidoM", "Direccion", "Telefono", "Id", nameTextBox.Text, fTextBox.Text, mTextBox.Text, addressTextBox.Text, phoneTextBox.Text, m_ID);
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
