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
using Invert911.InvertCommon.Utilities;

namespace Invert911.InvertCommon.Modules.Property
{
    /// <summary>
    /// Interaction logic for Properties.xaml
    /// </summary>
    public partial class Properties : UserControl
    {
        DataSet mDataSet;
        DataView mDataView;
        ICollectionView mCollectionView;

        public Properties()
        {
            InitializeComponent();
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;
            mDataView = mDataSet.Tables["i9Property"].DefaultView;

            mCollectionView = CollectionViewSource.GetDefaultView(mDataSet.Tables["i9Property"]);
            MainProperty.DataBind(mDataSet);

            this.DataContext = mDataView;
        }

        private void PropertyAdd_Click(object sender, RoutedEventArgs e)
        {
            Guid i9Event = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
            Guid i9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

            //Add Property to incident 
            DataRow dr = mDataSet.Tables["i9Property"].NewRow();
            dr["i9PropertyID"] = Guid.NewGuid();
            dr["i9EventID"] = i9Event;
            dr["i9AgencyID"] = i9AgencyID; 
            dr["PropertyMPI"] = 0;
            dr["PropertyDescription"] = "New";
            
            mDataSet.Tables["i9Property"].Rows.Add(dr);            
        }

        private void PropertyRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mDataSet.Tables["i9Property"] != null)
                {
                    if (PropertyListView.SelectedItem != null)
                    {
                        mDataView.Delete(mCollectionView.CurrentPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting property:  ", ex);
                MessageBox.Show("Error deleting property " + ex.Message);
            }
        }

        private void PropertyCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PropertyPaste_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
