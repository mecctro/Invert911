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

namespace Invert911.Incident
{
    /// <summary>
    /// Interaction logic for IncidentWorkspace.xaml
    /// </summary>
    public partial class IncidentWorkspace : Page, IMDTModule
    {
        private string m_ModuleName = "IncidentWorkspace";

        public IncidentWorkspace()
        {
            InitializeComponent();
            MainIncidentMenu.NewIncident += new IncidentMenu.NewIncidentDelegate(MainIncidentMenu_NewIncident);
            MainIncidentMenu.EditIncident += new IncidentMenu.EditIncidentDelegate(MainIncidentMenu_EditIncident);
            MainIncidentMenu.ParrentPage = this;
        }

        //ILawRecordsModule Interface
        public string ModuleName
        {
            get { return m_ModuleName; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = Double.NaN;
            this.Height = Double.NaN;
        }

        private void MainIncidentMenu_EditIncident(string i9EventID)
        {
            OpenLawIncident(i9EventID);
        }

        private void MainIncidentMenu_NewIncident()
        {
            OpenLawIncident(null);
        }

        public void OpenLawIncident(string i9EventID)
        {
            
            if (string.IsNullOrEmpty(i9EventID) == false)
            {
                foreach (TabItem tab in IncidentTabControl.Items)
                {
                    if (tab.Content.GetType() == typeof(IncidentEntry))
                    {
                        IncidentEntry i = (IncidentEntry)tab.Content;
                        if (i.i9EventID == i9EventID)
                        {
                            tab.Focus();
                            return;
                        }
                    }
                }
            }

            IncidentEntry ie = new IncidentEntry(i9EventID);
            ie.CloseIncident += new IncidentEntry.CloseIncidentDelegate(IncidentEntry_CloseIncident); 

            TabItem ti = new TabItem();
            if (string.IsNullOrEmpty(i9EventID))
                ti.Header = "New Law Incident";
            else
                ti.Header = "Edit Law Incident";

            ti.Content = ie;
            ie.Visibility = Visibility.Visible;

            IncidentTabControl.Items.Add(ti);
            IncidentTabControl.SelectedItem = ti;

            ie.Width = Double.NaN;
            ie.Height = Double.NaN;
        }

        private void IncidentEntry_CloseIncident(string i9EventID, string i9Guid)
        {
            if (string.IsNullOrEmpty(i9Guid) == false)
            {
                foreach (TabItem tab in IncidentTabControl.Items)
                {
                    if (tab.Content.GetType() == typeof(IncidentEntry))
                    {
                        IncidentEntry i = (IncidentEntry)tab.Content;
                        if (i.i9Guid == i9Guid)
                        {
                            if((MessageBox.Show("Close Incident Entry","Incident Entry",MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes))
                                IncidentTabControl.Items.Remove(tab);
                            return;
                        }
                    }
                }
            }
        }

        private void MainIncidentMenu_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
