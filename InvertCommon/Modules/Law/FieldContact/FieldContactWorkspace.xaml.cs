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

namespace Invert911.FieldContact
{
    /// <summary>
    /// Interaction logic for IncidentWorkspace.xaml
    /// </summary>
    public partial class FieldContactWorkspace : Page, IMDTModule
    {
        private string m_ModuleName = "FieldContactWorkspace";

        public FieldContactWorkspace()
        {
            InitializeComponent();
            MainFieldInverviewMenu.NewFieldContact += new FieldContactMenu.NewFieldContactDelegate(MainFieldInverviewMenu_NewFieldInverview);
        }

        public string ModuleName
        {
            get { return m_ModuleName; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void MainFieldInverviewMenu_NewFieldInverview()
        {
            FieldContactEntry ie = new FieldContactEntry();
            TabItem ti = new TabItem();
            ti.Header = "New";
            
            ti.Content = ie;
            ie.Visibility = Visibility.Visible;

            IncidentTabControl.Items.Add(ti);
            IncidentTabControl.SelectedItem = ti;

            ie.Width = Double.NaN;
            ie.Height = Double.NaN;
        }
    }
}
