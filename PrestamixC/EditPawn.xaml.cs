using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
    /// Interaction logic for EditPawn.xaml
    /// </summary>
    public partial class EditPawn : MetroWindow
    {
        private string m_ID = "-1";
        private DBAccess m_dba;
        public EditPawn(string id)
        {
            InitializeComponent();
            m_ID = id;
            m_dba = null;
            showPawnData();
        }
        void showPawnData()
        {
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Empenio", true, true, 4, "Monto", "Tipo", "Fecha", "Estado", "Id", m_ID, "=");           
            DataRow row = m_dt.Rows[0];
            SumTextBox.Text = row["Monto"].ToString();
            typeTextBox.Text = row["Tipo"].ToString();
            mDateP.SelectedDate = DateTime.Parse(row["Fecha"].ToString());
            StatusTextBox.Text = row["Estado"].ToString();
            m_dba = null;
        }

        private void confirmB_Click(object sender, RoutedEventArgs e)
        {
            m_dba = new DBAccess();
            m_dba.UpdateTable("Empenio", 4, "Monto", "Tipo", "Fecha", "Estado", "Id", SumTextBox.Text, typeTextBox.Text, DateTime.ParseExact(mDateP.SelectedDate.ToString(), (Application.Current as PrestamixC.App).currentDateTimeFormat, CultureInfo.InvariantCulture).ToString("M/d/yyyy h:mm:ss tt"), StatusTextBox.Text, m_ID, "="); 
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
