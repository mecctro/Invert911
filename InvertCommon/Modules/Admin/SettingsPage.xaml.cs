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
using Invert911.InvertCommon.Modules;

namespace Invert911.Admin
{
    /// <summary>
    /// Interaction logic for PersonnelPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //SettingsManager.Save();
            MessageBox.Show("Need to save this");
            ModuleManager.Instance.NavigateTo(this, "LoginPage");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleManager.Instance.NavigateTo(this, "LoginPage");
        }
    }
}
