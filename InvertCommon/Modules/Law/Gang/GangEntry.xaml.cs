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

using Invert911.InvertCommon.Modules;

namespace Invert911.Gang
{
    /// <summary>
    /// Interaction logic for IncidentForm.xaml
    /// </summary>
    public partial class GangEntry : UserControl, IMDTModule
    {
        private string m_ModuleName = "GangWorkspace";

        public GangEntry()
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
