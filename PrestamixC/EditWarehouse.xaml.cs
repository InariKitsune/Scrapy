﻿using System;
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
    /// Interaction logic for EditWarehouse.xaml
    /// </summary>
    public partial class EditWarehouse : MetroWindow
    {
        private string m_ID = "-1";
        private DBAccess m_dba;
        public EditWarehouse(string id)
        {
            InitializeComponent();
            m_ID = id;
            this.Title = "Editando almacen n°: " + m_ID; 
            m_dba = null;
            showWarehouseData();
        }
        private void showWarehouseData()
        {
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Warehouse", true, true, 3, "Nombre", "Direccion", "Descripcion", "Id", m_ID, "=");
            DataRow row = m_dt.Rows[0];
            NameTextBox.Text = row["Nombre"].ToString();
            LocationTextBox.Text = row["Direccion"].ToString();          
            DescriptionTextBox.Text = row["Descripcion"].ToString();
            m_dba = null;
        }
        private void confirmB_Click(object sender, RoutedEventArgs e)
        {
            m_dba = new DBAccess();
            m_dba.UpdateTable("Warehouse", 3, "Nombre", "Direccion", "Descripcion", "Id",NameTextBox.Text, LocationTextBox.Text, DescriptionTextBox.Text, m_ID, "=");
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
