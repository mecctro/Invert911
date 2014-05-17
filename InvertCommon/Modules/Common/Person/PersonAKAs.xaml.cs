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

namespace Invert911.InvertCommon.Modules.Person
{
    /// <summary>
    /// Interaction logic for PersonAKAs.xaml
    /// </summary>
    public partial class PersonAKAs : UserControl
    {
        DataSet mDataSet;
        DataView dv;
        public Guid PersonAKAi9PersonID{set; get;}

        public PersonAKAs()
        {
            InitializeComponent();
            PersonAKAi9PersonID = Guid.Empty;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;

            //Filer on i9ModuleSectionID and i9personID
            dv = new DataView(lDataSet.Tables["i9PersonAKA"]);
            dv.RowFilter = "i9ModuleSectionID = '" + i9ModuleSection.LawIncidentPersonAKA.ToString() + "' AND i9PersonAKAID = '" + PersonAKAi9PersonID + "'";
            //dv.RowFilter = "i9PersonAKAID = '" + PersonAKAi9PersonID + "'";
            this.DataContext = dv;
            MainPersonAKADynControl.DataBind(dv, "Incident.Person.AKA", "i9PersonAKA");
        }

        private void AddPersonAKAButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonAKAi9PersonID == Guid.Empty)
                return;

            Guid i9EventID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
            Guid i9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

            //Add PersonAKA incident 
            DataRow dr = mDataSet.Tables["i9PersonAKA"].NewRow();
            dr["i9EventID"] = i9EventID;
            dr["i9AgencyID"] = i9AgencyID;
            dr["i9PersonID"] = Guid.NewGuid();
            dr["PersonMNI"] = 0;
            dr["SequenceNumber"] = mDataSet.Tables["i9PersonAKA"].Rows.Count + 1;
            dr["LastName"] = "New AKA";

            if (PersonAKAi9PersonID != Guid.Empty)
            {
                dr["i9PersonAKAID"] = PersonAKAi9PersonID;
            }

            dr["i9ModuleSectionID"] = i9ModuleSection.LawIncidentPersonAKA.ToString();
            mDataSet.Tables["i9PersonAKA"].Rows.Add(dr);            
        }

        private void RemovePersonAKAButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonAKAi9PersonID == Guid.Empty)
                return;

            try
            {
                if (mDataSet.Tables["i9PersonAKA"] != null)
                {
                    if (PersonAKAListView.SelectedItem != null)
                    {
                        ICollectionView cv = CollectionViewSource.GetDefaultView(PersonAKAListView.ItemsSource);
                        mDataSet.Tables["i9PersonAKA"].DefaultView.Delete(cv.CurrentPosition);
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
