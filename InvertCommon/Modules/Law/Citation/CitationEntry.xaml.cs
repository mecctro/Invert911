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
using System.Windows.Shapes;

//using Hix.Resources;

namespace Invert911.Citation
{
    /// <summary>
    /// Interaction logic for CitationForm.xaml
    /// </summary>
    public partial class CitationEntry : UserControl
    {
        private string m_ModuleName = "CitationEntry";

        public CitationEntry()
        {
            InitializeComponent();
        }

        public string ModuleName
        {
            get { return m_ModuleName; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void PersonButton_Checked(object sender, RoutedEventArgs e)
        {
            SetPartyInvolvedType();
        }

        private void OrganizationButton_Checked(object sender, RoutedEventArgs e)
        {
            SetPartyInvolvedType();
        }

        private void SetPartyInvolvedType()
        {

        }
    }
}
