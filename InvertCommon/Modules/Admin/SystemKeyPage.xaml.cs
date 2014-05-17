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

namespace Invert911.InvertCommon.Modules.Admin
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SystemKeyPage : Page
    {
        public SystemKeyPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SystemKeyPage_Loaded);
        }

        void SystemKeyPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadedData();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadedData();
        }

        private void LoadedData()
        {
            //Need to Implement this
        }
    }
}
