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
using Invert911.InvertCommon.Framework;

namespace Invert911.InvertCommon.Modules.Location
{
    /// <summary>
    /// Interaction logic for Locations.xaml
    /// </summary>
    public partial class Locations : UserControl
    {
        DataSet mDataSet;
        DataView dv;
        public Guid Locationi9PersonID{set; get;}  

        public Locations()
        {
            InitializeComponent();
            Locationi9PersonID = Guid.Empty;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;

            //if (Locationi9PersonID == Guid.Empty)
            //{
            //    //Filer on i9ModuleSectionID
            //    dv = new DataView(lDataSet.Tables["i9Location"]);
            //    //dv.RowFilter = "i9ModuleSectionID = '" + i9ModuleSection.LawIncidentPersonLocation.ToString() + "'";
            //}
            //else
            //{
                //Filer on i9ModuleSectionID and i9personID
                dv = new DataView(lDataSet.Tables["i9Location"]);
                dv.RowFilter = "i9ModuleSectionID = '" + i9ModuleSection.LawIncidentPersonLocation.ToString() + "' AND i9PersonID = '" + Locationi9PersonID + "'";
            //}
            
            this.DataContext = dv;
            MainLocationDynControl.DataBind(dv, "Location", "i9Location");
        }

        private void AddLocationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Locationi9PersonID == Guid.Empty)
                return;

            Guid i9EventID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
            Guid i9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

            //ICollectionView cv = CollectionViewSource.GetDefaultView(mDataSet.Tables["i9Person"]);
            //mDataSet.Tables["i9Person"].DefaultView.ro(cv.CurrentPosition);

            //Add location incident 
            DataRow dr = mDataSet.Tables["i9Location"].NewRow();
            dr["i9EventID"] = i9EventID;
            dr["i9AgencyID"] = i9AgencyID;
            dr["i9LocationID"] = Guid.NewGuid();

            if (Locationi9PersonID != Guid.Empty)
            {
                dr["i9PersonID"] = Locationi9PersonID;
            }
            
            dr["LocationMVI"] = 0;
            dr["StreetName"] = "New Location";
            dr["i9ModuleSectionID"] = i9ModuleSection.LawIncidentPersonLocation.ToString();
            mDataSet.Tables["i9Location"].Rows.Add(dr);            
        }

        private void RemoveLocationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Locationi9PersonID == Guid.Empty)
                return;

            try
            {
                if (mDataSet.Tables["i9Location"] != null)
                {
                    if (LocationListView.SelectedItem != null)
                    {
                        //ICollectionView cv = CollectionViewSource.GetDefaultView(mDataSet.Tables["i9Location"]);
                        ICollectionView cv = CollectionViewSource.GetDefaultView(LocationListView.ItemsSource);
                        
                        mDataSet.Tables["i9Location"].DefaultView.Delete(cv.CurrentPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting person:  ", ex);
                MessageBox.Show("Error deleting person " + ex.Message);
            }
        }
    }
}
