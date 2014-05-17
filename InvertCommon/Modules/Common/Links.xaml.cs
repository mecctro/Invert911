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

namespace Invert911.InvertCommon.Modules
{
    /// <summary>
    /// Interaction logic for URLLinks.xaml
    /// </summary>
    public partial class Links : UserControl
    {
        public Links()
        {
            InitializeComponent();
        }

        private DataView mDataView;
        private DataSet mDataSet;
        private string mTableName = "i9AttachmentLink";
        private ICollectionView mCollectionView;

        public void DataBind(DataSet lDataSet)
        {
            this.mDataSet = lDataSet;
            //mDataView = this.mDataSet.Tables[mTableName].DefaultView;
            ////mDataView.RowFilter = "i9ModuleSectionID = '" + i9ModuleSection.LawIncidentLocation.ToString() + "'";

            this.DataContext = mDataView;
            this.mCollectionView = CollectionViewSource.GetDefaultView(mDataView);

            //if (mDataView.Count <= 0)
            //{
            //    //DisableUI();
            //}
        }

        private void DisableUI()
        {
            this.IsEnabled = false;
        }
    }
}
