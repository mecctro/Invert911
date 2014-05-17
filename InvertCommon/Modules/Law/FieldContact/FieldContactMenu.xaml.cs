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

namespace Invert911.FieldContact
{
    
    public partial class FieldContactMenu : UserControl
    {
        public delegate void NewFieldContactDelegate();
        public event NewFieldContactDelegate NewFieldContact;
        
        public FieldContactMenu()
        {
            InitializeComponent();
        }

        private void NewButtom_Click(object sender, RoutedEventArgs e)
        {
            if (NewFieldContact != null)
                NewFieldContact();
        }
    }
}
