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

namespace Invert911.Citation
{
    /// <summary>
    /// Interaction logic for IncidentWorkspace.xaml
    /// </summary>
    public partial class CitationWorkspace : Page, IMDTModule
    {
        private string m_ModuleName = "CitationWorkspace";

        public CitationWorkspace()
        {
            InitializeComponent();
            MainCitationMenu.NewCitation += new CitationMenu.NewCitationDelegate(MainCitationMenu_NewIncident);
        }

        //ILawRecordsModule Interface
        public string ModuleName
        {
            get { return m_ModuleName; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void MainCitationMenu_NewIncident()
        {
            CitationEntry c = new CitationEntry();
            TabItem ti = new TabItem();
            ti.Header = "New Citation";
            
            ti.Content = c;
            c.Visibility = Visibility.Visible;

            MainTabControl.Items.Add(ti);
            MainTabControl.SelectedItem = ti;

            c.Width = Double.NaN;
            c.Height = Double.NaN;
        }
    }
}
