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
using MahApps.Metro;
using MahApps.Metro.Controls;
using PrestamixC.dao;

namespace PrestamixC
{
    /// <summary>
    /// Interaction logic for AddWarehouse.xaml
    /// </summary>
    public partial class AddWarehouse : MetroWindow
    {
        private DBAccess m_dba;
        public AddWarehouse()
        {
            InitializeComponent();
            m_dba = null;
        }
        private void ConfirmarEmpeñoBoton_Click(object sender, RoutedEventArgs e)
        {
            int i;
            if (IdAlmacen.Text != "")
            {
                if(int.TryParse(IdAlmacen.Text, out i))
                {
                    m_dba = new DBAccess();
                    m_dba.InsertIntoTable("Warehouse", "Id", "Nombre", "Direccion", "Estado", "Descripcion", IdAlmacen.Text, NombreAlmacen.Text, DireccionTextBox.Text, "Vacio", DescripcionTextBox.Text);
                    m_dba = null;
                    Close();
                }
                else                
                    MessageBox.Show("El valor ingresado en el campo -Número de almacen- es inválido");                              
            }
            else
                MessageBox.Show("El campo -Número del almacen- no puede ser vacio");
        }
        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}