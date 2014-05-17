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

namespace Invert911.Gang
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class GangMenu : UserControl
    {
        public delegate void NewGangDelegate();
        public event NewGangDelegate NewGang;
        //public event NewGangDelegate TEST;

        public GangMenu()
        {
            InitializeComponent();
        }

        private void NewButtom_Click(object sender, RoutedEventArgs e)
        {
            if (NewGang != null)
                NewGang();
        }
    }
}
