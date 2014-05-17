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
using System.Data;

namespace Invert911.InvertCommon.Modules.Property
{
    /// <summary>
    /// Interaction logic for Property.xaml
    /// </summary>
    public partial class Property : UserControl
    {
        private DataSet mDataSet;
        private DataView mDataView;


        public Property()
        {
            InitializeComponent();
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;
            mDataView = lDataSet.Tables["i9Property"].DefaultView;

            //mi9EventID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
            //mi9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

            this.DataContext = mDataView;

            MainPropertyDynControl.DataBind(mDataView, "Incident.Property.General", "i9Property");
        }
    }
}
