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

namespace Invert911.InvertCommon.Modules.Person
{
    /// <summary>
    /// Interaction logic for Persons.xaml
    /// </summary>
    public partial class Persons : UserControl
    {
        DataSet mDataSet;
        DataView mDataView;
        ICollectionView mCollectionView;

        public Persons()
        {
            InitializeComponent();
            PersonListView.SelectionChanged += new SelectionChangedEventHandler(PersonListView_SelectionChanged);
        }

        void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (mCollectionView == null) //binding problem
            //    return;

            Guid Selectedi9PersonID = Guid.Empty;
            if(PersonListView.SelectedIndex >= 0)
            {
                Selectedi9PersonID = (Guid)mDataView[mCollectionView.CurrentPosition]["i9PersonID"];
            }

            MainPeron.SelectionChanged(Selectedi9PersonID);
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;
            mDataView = mDataSet.Tables["i9Person"].DefaultView;

            //mCollectionView = CollectionViewSource.GetDefaultView(PersonListView.ItemsSource);
            mCollectionView = CollectionViewSource.GetDefaultView(mDataSet.Tables["i9Person"]);
            
            MainPeron.DataBind(mDataSet);
            
            this.DataContext = mDataView;
            
            //Guid Currenti9PersonID = (Guid)mDataView.Table.Rows[mCollectionView.CurrentPosition]["i9PersonID"];
        }

        private void PersonRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mDataSet.Tables["i9Person"] != null)
                {
                    if (PersonListView.SelectedItem != null)
                    {
                        //ICollectionView cv = CollectionViewSource.GetDefaultView(mDataSet.Tables["i9Person"]);
                        //mDataSet.Tables["i9Person"].DefaultView.Delete(cv.CurrentPosition);

                        //ICollectionView cv = CollectionViewSource.GetDefaultView(PersonListView.ItemsSource);
                        mDataView.Delete(mCollectionView.CurrentPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting person:  ", ex);
                MessageBox.Show("Error deleting person " + ex.Message);
            }
        }

        private void PersonAdd_Click(object sender, RoutedEventArgs e)
        {
            Guid i9Event = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
            Guid i9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

            //Add Person incident 
            DataRow dr = mDataSet.Tables["i9Person"].NewRow();
            dr["i9EventID"] = i9Event;
            dr["i9PersonID"] = Guid.NewGuid();
            dr["PersonMNI"] = 0;
            dr["SequenceNumber"] = mDataSet.Tables["i9Person"].Rows.Count + 1;
            dr["LastName"] = "New person";
            dr["i9AgencyID"] = i9AgencyID;
            dr["i9ModuleSectionID"] = "LawIncidentPerson";
            mDataSet.Tables["i9Person"].Rows.Add(dr);            
        }

        private void PersonCopy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PersonPaste_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
