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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using MahApps.Metro;
using MahApps.Metro.Controls;
using PrestamixC.dao;


namespace PrestamixC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string connectionString = App.connectionString;
        private bool VentanaRegistrarEmpeñoAbierta = false;
        private bool VentanaEditarEmpeñoAbierta = false;
        public MainWindow()
        {
            InitializeComponent();
            MostrarEmpeños();
            MostrarPrendas();
            MostrarClientes();
        }
        void MostrarEmpeños()
        {
            DBAccess m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Empenio", false, false, 0);
            EmpeñosDataGrid.ItemsSource = m_dt.DefaultView;         
        }
        private void MostrarClientes()
        {
            DBAccess m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Cliente", false, false, 0);
            ClientesDataGrid.ItemsSource = m_dt.DefaultView;            
        }
        void MostrarPrendas()
        {
            DBAccess m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Prenda", false, false, 0);
            PrendasDataGrid.ItemsSource = m_dt.DefaultView;         
        }
        //////////////////////////////////////////
        ////////////////////////////////////////// 
        private void BotonRegistrarEmpeños_Click(object sender, RoutedEventArgs e)
        {
            if (!VentanaRegistrarEmpeñoAbierta)
            {
                VentanaRegistrarEmpeñoAbierta = true;
                RegistrarEmpeño ventanaEmp = new RegistrarEmpeño();
                ventanaEmp.Closed += new EventHandler(RegistrarEmpeño_Closed);
                ventanaEmp.Show();
            }
        }
        private void EditPawn_Closed(object sender, EventArgs e)
        {
            VentanaEditarEmpeñoAbierta = false;
            MostrarEmpeños();
        }
        private void RegistrarEmpeño_Closed(object sender, EventArgs e)
        {
            VentanaRegistrarEmpeñoAbierta = false;
            MostrarEmpeños();
        } 
        private void DeleteButton_Click(object sender, RoutedEventArgs e)//code for delete pawns
        {
            DataRowView drv = (DataRowView)EmpeñosDataGrid.SelectedItem;
            String result = (drv["Id"]).ToString();//here we select a pawn's id from the datagrid          
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            String sql1 = string.Format("DELETE FROM Empenio WHERE Id=@result");           
            SqlCommand command1 = new SqlCommand(sql1, connection);                      
            command1.Parameters.AddWithValue("@result", result);        
            command1.ExecuteNonQuery();       
            connection.Close();
            MostrarEmpeños();
        }
        private void EditSPawn_Click(object sender, RoutedEventArgs e)
        {
            if (!VentanaEditarEmpeñoAbierta)
            {
                DataRowView drv = (DataRowView)EmpeñosDataGrid.SelectedItem;
                String result = (drv["Id"]).ToString();//here we select a pawn's id from the datagrid
                VentanaEditarEmpeñoAbierta = true;
                EditPawn ventanaEdt = new EditPawn(result);
                ventanaEdt.Closed += new EventHandler(EditPawn_Closed);
                ventanaEdt.Show();
            }
        }
        //////////////////////////////////////////
        //////////////////////////////////////////
        private void DeletePledge_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)PrendasDataGrid.SelectedItem;
            String result = (drv["Id"]).ToString();//here we select a pledge's id from the datagrid
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            String sql1 = string.Format("DELETE FROM Prenda WHERE Id=@result");
            SqlCommand command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@result", result);
            command1.ExecuteNonQuery();
            connection.Close();
            MostrarPrendas();
        }
        //////////////////////////////////////////
        //////////////////////////////////////////
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)ClientesDataGrid.SelectedItem;
            String result = (drv["Id"]).ToString();//here we select a pawn's id from the datagrid
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            String sql1 = string.Format("DELETE FROM Cliente WHERE Id=@result");
            SqlCommand command1 = new SqlCommand(sql1, connection);
            command1.Parameters.AddWithValue("@result", result);
            command1.ExecuteNonQuery();
            connection.Close();
            MostrarClientes();
        }        
        //////////////////////////////////////////
        ////////////////////////////////////////// 
        private void customersTab_Selected(object sender, RoutedEventArgs e)
        {
            MostrarClientes();
        }

        private void pledgetab_Selected(object sender, RoutedEventArgs e)
        {            
            MostrarPrendas();            
        }

        private void pawnsTab_Selected(object sender, RoutedEventArgs e)
        {
            MostrarEmpeños();            
        }

        private void themeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Uri uri1, uri2;  
            switch (ThemeButton.SelectedIndex)
            {
                case 0:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Red.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Red.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Red"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Red"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 1:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Green.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Green.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Emerald"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Emerald"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 2:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Blue.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Cobalt"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Cobalt"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 3:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Pink.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Pink"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Pink"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 4:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Yellow.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Yellow.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Yellow"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Yellow"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addDark.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeDark.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editDark.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchDark.png", UriKind.Relative));
                    break;
                case 5:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Purple.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Purple.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Violet"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Violet"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 6:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Orange.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Orange.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Orange"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Orange"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addDark.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeDark.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editDark.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchDark.png", UriKind.Relative));
                    break;
                case 7:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Brown.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Indigo.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Brown"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Brown"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 8:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Lime.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Lime"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Lime"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addDark.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeDark.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editDark.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchDark.png", UriKind.Relative));
                    break;
                case 9:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Teal.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Teal"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Teal"), ThemeManager.GetAppTheme("BaseLight"));
                    /*addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));*/
                    break;
                case 10:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Grey.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Indigo.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Steel"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Steel"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addDark.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeDark.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editDark.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchDark.png", UriKind.Relative));
                    break;
                case 11:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Indigo.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Indigo.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Indigo"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Indigo"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 12:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Cyan.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Cyan.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Cyan"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Cyan"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 13:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.BlueGrey.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Indigo.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Steel"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Steel"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 14:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.LightBlue.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.LightBlue.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Blue"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Blue"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 15:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.LightGreen.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.LightGreen.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Green"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Green"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addDark.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeDark.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editDark.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchDark.png", UriKind.Relative));
                    break;
                case 16:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepOrange.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.DeepOrange.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Sienna"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Sienna"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                case 17:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml", UriKind.Relative);                    
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.DeepPurple.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Purple"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Purple"), ThemeManager.GetAppTheme("BaseLight"));
                    addImage.Source = new BitmapImage(new Uri("img/addLight.png", UriKind.Relative));
                    deleteImage.Source = new BitmapImage(new Uri("img/closeLight.png", UriKind.Relative));
                    editImage.Source = new BitmapImage(new Uri("img/editLight.png", UriKind.Relative));
                    searchImage.Source = new BitmapImage(new Uri("img/searchLight.png", UriKind.Relative));
                    break;
                default:
                    uri1 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.LightGreen.xaml", UriKind.Relative);
                    uri2 = new Uri(@"/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.LightGreen.xaml", UriKind.Relative);
                    ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Emerald"), ThemeManager.GetAppTheme("BaseLight"));
                    ThemeManager.ChangeAppStyle((App)Application.Current, ThemeManager.GetAccent("Emerald"), ThemeManager.GetAppTheme("BaseLight"));
                    break;                    
            }
           
            ((App)Application.Current).ChangeTheme(uri1, uri2);            
        }        
    }
}
