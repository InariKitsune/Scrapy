using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrestamixC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFileName=G:\PrestamixCv2.1\PrestamixCv2.1\PrestamixC\DB\Database1.mdf;Integrated Security=True;";
        public void ChangeTheme(Uri newUri, Uri newUri2)
        {
            ResourceDictionary resourceDict1 = Application.LoadComponent(new Uri(@"/MahApps.Metro;component/Styles/Controls.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary resourceDict2 = Application.LoadComponent(new Uri(@"MahApps.Metro;component/Styles/Fonts.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary resourceDict3 = Application.LoadComponent(new Uri(@"/MahApps.Metro;component/Styles/Colors.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary resourceDict4 = Application.LoadComponent(new Uri(@"/MahApps.Metro;component/Styles/Accents/BaseLight.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary resourceDict5 = Application.LoadComponent(new Uri(@"/MahApps.Metro;component/Styles/Controls.AnimatedTabControl.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary resourceDict6 = Application.LoadComponent(new Uri(@"/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary resourceDict7 = Application.LoadComponent(new Uri(@"/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary resourceDict8 = Application.LoadComponent(newUri) as ResourceDictionary;
            ResourceDictionary resourceDict9 = Application.LoadComponent(newUri2) as ResourceDictionary;
            
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict1);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict2);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict3);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict4);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict5);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict6);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict7);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict8);
            Application.Current.Resources.MergedDictionaries.Add(resourceDict9);          
        }        
    }
}
