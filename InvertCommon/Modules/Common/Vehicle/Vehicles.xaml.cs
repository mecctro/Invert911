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

namespace Invert911.InvertCommon.Modules.Vehicle
{
    /// <summary>
    /// Interaction logic for Vehicles.xaml
    /// </summary>
    public partial class Vehicles : UserControl
    {
        DataSet mDataSet;
        DataView mDataView;
        ICollectionView mCollectionView;


        public Vehicles()
        {
            InitializeComponent();
            VehicleListView.SelectionChanged += new SelectionChangedEventHandler(VehicleListView_SelectionChanged);
        }

        void VehicleListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Guid Selectedi9VehicleID = Guid.Empty;
            if (VehicleListView.SelectedIndex >= 0)
            {
                Selectedi9VehicleID = (Guid)mDataView[mCollectionView.CurrentPosition]["i9VehicleID"];
            }

            MainVehicle.SelectionChanged(Selectedi9VehicleID);
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;
            mDataView = mDataSet.Tables["i9Vehicle"].DefaultView;
            mCollectionView = CollectionViewSource.GetDefaultView(mDataSet.Tables["i9Vehicle"]);
            
            MainVehicle.DataBind(mDataSet);

            this.DataContext = mDataView;
        }

        private void VehicleAdd_Click(object sender, RoutedEventArgs e)
        {
            Guid i9Event = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
            Guid i9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

            //Add Incident Vehicle
            DataRow dr = mDataSet.Tables["i9Vehicle"].NewRow();
            dr["i9EventID"] = i9Event;
            dr["i9VehicleID"] = Guid.NewGuid();
            dr["VehicleMVI"] = 0;
            dr["i9AgencyID"] = i9AgencyID;
            dr["ModelYear"] = DateTime.Now.Year.ToString();
            mDataSet.Tables["i9Vehicle"].Rows.Add(dr);            
        }

        private void VehicleRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mDataSet.Tables["i9Vehicle"] != null)
                {
                    if (VehicleListView.SelectedItem != null)
                    {
                        mDataView.Delete(mCollectionView.CurrentPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting vehicle:  ", ex);
                MessageBox.Show("Error deleting vehicle " + ex.Message);
            }
        }

        private void VehicleCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VehiclePaste_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
