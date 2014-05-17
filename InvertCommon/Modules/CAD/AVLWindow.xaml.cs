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

namespace Invert911.CAD
{
    /// <summary>
    /// Interaction logic for AVLPage.xaml
    /// </summary>
    public partial class AVLWindow : Window, IMDTModule
    {
        private string m_ModuleName = "AVL";

        public AVLWindow()
        {
            InitializeComponent();
        }

        //ILawRecordsModule Interface
        public string ModuleName
        {
            get { return m_ModuleName; }
        }
    }
}
