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

namespace Invert911.Gang
{
    /// <summary>
    /// Interaction logic for IncidentWorkspace.xaml
    /// </summary>
    public partial class GangWorkspace : Page, IMDTModule
    {
        private string m_ModuleName = "GangWorkspace";

        public GangWorkspace()
        {
            InitializeComponent();
            MainGangMenu.NewGang += new GangMenu.NewGangDelegate(MainGangMenu_NewGang);
        }

        //ILawRecordsModule Interface
        public string ModuleName
        {
            get { return m_ModuleName; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void MainGangMenu_NewGang()
        {
            GangEntry ie = new GangEntry();
            TabItem ti = new TabItem();
            ti.Header = "New Gang";
            
            ti.Content = ie;
            ie.Visibility = Visibility.Visible;

            GangTabControl.Items.Add(ti);
            GangTabControl.SelectedItem = ti;

            ie.Width = Double.NaN;
            ie.Height = Double.NaN;
        }
    }
}
