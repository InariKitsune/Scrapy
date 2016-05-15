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
        private bool VentanaRegistrarEmpeñoAbierta = false;
        private bool VentanaEditarEmpeñoAbierta = false;
        RegistrarEmpeño ventanaEmp;
        EditPawn ventanaEdt;
        DBAccess m_dba;
        public MainWindow()
        {
            InitializeComponent();
            m_dba = null;
            ventanaEmp = null;
            ventanaEdt = null; 
            MostrarEmpeños();
            MostrarPrendas();
            MostrarClientes();                       
        }
        /*
         *SHOW TABLES FROM DB
         */
        void MostrarEmpeños()
        {
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Empenio", false, false, 0);
            EmpeñosDataGrid.ItemsSource = m_dt.DefaultView;
            m_dba = null;
        }
        private void MostrarClientes()
        {
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Cliente", false, false, 0);
            ClientesDataGrid.ItemsSource = m_dt.DefaultView;
            m_dba = null;
        }
        void MostrarPrendas()
        {
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Prenda", false, false, 0);
            PrendasDataGrid.ItemsSource = m_dt.DefaultView;
            m_dba = null;
        }        
        /*
         *OTHER WINDOWS
         */
        private void BotonRegistrarEmpeños_Click(object sender, RoutedEventArgs e)
        {
            if (!VentanaRegistrarEmpeñoAbierta)
            {
                VentanaRegistrarEmpeñoAbierta = true;
                ventanaEmp = new RegistrarEmpeño();
                ventanaEmp.Closed += new EventHandler(RegistrarEmpeño_Closed);
                ventanaEmp.Show();
            }               
        }
        private void EditSPawn_Click(object sender, RoutedEventArgs e)
        {
            if (!VentanaEditarEmpeñoAbierta)
            {
                DataRowView drv = (DataRowView)EmpeñosDataGrid.SelectedItem;
                String result = (drv["Id"]).ToString();//here we select a pawn's id from the datagrid
                VentanaEditarEmpeñoAbierta = true;
                ventanaEdt = new EditPawn(result);
                ventanaEdt.Closed += new EventHandler(EditPawn_Closed);
                ventanaEdt.Show();
            }
        }
        private void EditPledge_Copy_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditCustomer_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditPawn_Closed(object sender, EventArgs e)
        {
            VentanaEditarEmpeñoAbierta = false;
            ventanaEdt = null;
            MostrarEmpeños();
        }
        private void RegistrarEmpeño_Closed(object sender, EventArgs e)
        {
            VentanaRegistrarEmpeñoAbierta = false;
            ventanaEmp = null;
            MostrarEmpeños();
        }        
        /*
         *DELETE
         */
        private void DeleteButton_Click(object sender, RoutedEventArgs e)//code for delete pawns
        {
            m_dba = new DBAccess();
            DataRowView drv = (DataRowView)EmpeñosDataGrid.SelectedItem;                    
            m_dba.DeleteFromTable("Empenio", (drv["Id"]).ToString());                       
            m_dba = null;
            MostrarEmpeños();
        }
        private void DeletePledge_Click(object sender, RoutedEventArgs e)
        {
            m_dba = new DBAccess();
            DataRowView drv = (DataRowView)PrendasDataGrid.SelectedItem;            
            m_dba.DeleteFromTable("Prenda", (drv["Id"]).ToString());
            m_dba = null;
            MostrarPrendas();
        }        
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            m_dba = new DBAccess();
            DataRowView drv = (DataRowView)ClientesDataGrid.SelectedItem;
            m_dba.DeleteFromTable("Cliente", (drv["Id"]).ToString());
            m_dba = null;
            MostrarClientes();
        }
        /*
         *SEARCH
         */
        private void pawnSearchButton_Click(object sender, RoutedEventArgs e)
        {
            string category="";
            switch(pawnSearchCategory.SelectedIndex)
            {
                case 0:
                    category = "Id";
                    break;
                case 1:
                    category = "idCliente";
                    break;
                case 2:
                    category = "idPrenda";
                    break;
                case 3:
                    category = "Monto";
                    break;
                case 4:
                    category = "Tipo";
                    break;                
                case 5:
                    category = "Estado";
                    break;                
            }
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Empenio", false, true, 0, category, pawnSearchCriteria.Text);
            EmpeñosDataGrid.ItemsSource = m_dt.DefaultView;
            m_dba = null;
        }
        private void pledgeSearchButton_Click(object sender, RoutedEventArgs e)
        {
            string category = "";
            switch (pledgeSearchCaterogy.SelectedIndex)
            {
                case 0:
                    category = "Id";
                    break;
                case 1:
                    category = "Nombre";
                    break;
                case 2:
                    category = "Ubicacion";
                    break;                
            }
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Prenda", false, true, 0, category, pledgeSearchCriteria.Text);
            PrendasDataGrid.ItemsSource = m_dt.DefaultView;
            m_dba = null;
        }
        private void customerSearchButton_Click(object sender, RoutedEventArgs e)
        {
            string category = "";
            switch (customerSearchCategory.SelectedIndex)
            {
                case 0:
                    category = "Id";
                    break;
                case 1:
                    category = "Nombre";
                    break;
                case 2:
                    category = "ApellidoP";
                    break;               
            }
            m_dba = new DBAccess();
            DataTable m_dt = m_dba.SelectFromTable("Cliente", false, true, 0, category, customerSearchCriteria.Text);
            ClientesDataGrid.ItemsSource = m_dt.DefaultView;
            m_dba = null;
        }
        /*
         *TAB CONTROL
         */
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
        /*
         *THEME SELECTOR
         */
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
