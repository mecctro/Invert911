using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Invert911.InvertCommon.StandardGui;
using Invert911.InvertCommon.Modules;
using Invert911.Themes;

namespace Invert911.Admin
{
    /// <summary>
    /// Interaction logic for IncidentWorkspace.xaml
    /// </summary>
    public partial class SystemConfigurationsPage : Page, IMDTModule
    {
        private string m_ModuleName = "Settings";

        public SystemConfigurationsPage()
        {
            InitializeComponent();
        }

        //ILawRecordsModule Interface
        public string ModuleName
        {
            get { return m_ModuleName; }
        }

        private void DefaultStyle_Click(object sender, RoutedEventArgs e)
        {
            //Resources_Default oDefaultTheme = new Resources_Default();
            //Application.Current.Resources = oDefaultTheme;
        }

        private void NightModeStyleButton_Click(object sender, RoutedEventArgs e)
        {
            //Resources_NightTime oNightTimeTheme = new Resources_NightTime();
            //Application.Current.Resources = oNightTimeTheme;
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Resources = new SunnyOrange_Theme(); 
            //Application.Current.Resources = WPF.Themes.ThemeManager.GetThemeResourceDictionary(WPF.Themes.ThemeManager.GetThemes()[0]);
            //ThemeProperty
        }

        private void SetThemeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Application.Current.Resources = Invert911.Themes.ThemeManager.GetThemeResourceDictionary(ThemesComboBox.Text);

                ThemeType t = ThemeType.Royale;
                Enum.TryParse<ThemeType>(ThemesComboBox.Text, out t);
                Invert911.Themes.ThemeManager.ApplyTheme(Application.Current, t);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the themes
            if (ThemesComboBox.Items.Count <= 0)
            {
                foreach (string themeName in Themes.ThemeManager.GetThemes())
                {
                    //ThemeStackPanel.
                    ThemesComboBox.Items.Add(themeName);
                }
            }
        }
    }
}
