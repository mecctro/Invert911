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

namespace Invert911.FieldContact
{
    /// <summary>
    /// Interaction logic for IncidentForm.xaml
    /// </summary>
    public partial class FieldContactEntry : UserControl//, IMDTModule
    {
        private string m_ModuleName = "FieldContactWorkspace";

        public FieldContactEntry()
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
