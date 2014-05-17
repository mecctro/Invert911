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

namespace Invert911.Citation
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CitationMenu : UserControl
    {
        public delegate void NewCitationDelegate();
        public event NewCitationDelegate NewCitation;

        public CitationMenu()
        {
            InitializeComponent();
        }
        
        private void NewButtom_Click(object sender, RoutedEventArgs e)
        {
            if (NewCitation != null)
                NewCitation();
        }
    }
}
