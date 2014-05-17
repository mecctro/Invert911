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
using System.ComponentModel;

using Invert911.InvertCommon.Framework;

namespace Invert911.InvertCommon.Modules.CAD
{
    /// <summary>
    /// Interaction logic for CADServiceCall.xaml
    /// </summary>
    public partial class CADServiceCall : UserControl
    {
        private DataView mDataView;
        private DataSet mDataSet;
        private string mTableName = "i9CADServiceCall";
        private ICollectionView mCollectionView;


        public CADServiceCall()
        {
            InitializeComponent();
        }

        public void DataBind(DataSet lDataSet)
        {
            this.mDataSet = lDataSet;
            mDataView = this.mDataSet.Tables[mTableName].DefaultView;
            //mDataView.RowFilter = "i9ModuleSectionID = '" + i9ModuleSection.LawIncidentLocation.ToString() + "'";
            

            this.DataContext = mDataView;
            this.mCollectionView = CollectionViewSource.GetDefaultView(mDataView);

            if (mDataView.Count <= 0)
            {
                DisableUI();
            }
        }

        private void DisableUI()
        {
            this.IsEnabled = false;
        }
    }
}
