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
    /// Interaction logic for PersonSMTs.xaml
    /// </summary>
    public partial class PersonSMTs : UserControl
    {
        DataSet mDataSet;
        DataView dv;
        public Guid PersonSMTi9PersonID { set; get; }

        public PersonSMTs()
        {
            InitializeComponent();
            PersonSMTi9PersonID = Guid.Empty;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;

            //Filer on i9personID
            dv = new DataView(lDataSet.Tables["i9PersonSMT"]);
            dv.RowFilter = " i9PersonID = '" + PersonSMTi9PersonID + "'";

            this.DataContext = dv;
            
            MainPersonSMTDynControl.DataBind(dv, "Incident.Person.SMT", "i9PersonSMT");
        }

        private void AddPersonSMTButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonSMTi9PersonID == Guid.Empty)
                return;

            Guid i9EventID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
            Guid i9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

            //Add PersonSMT incident 
            DataRow dr = mDataSet.Tables["i9PersonSMT"].NewRow();
            dr["i9EventID"] = i9EventID;
            dr["i9PersonSMTID"] = Guid.NewGuid();
            if (PersonSMTi9PersonID != Guid.Empty)
            {
                dr["i9PersonID"] = PersonSMTi9PersonID;
            }
            mDataSet.Tables["i9PersonSMT"].Rows.Add(dr);            
        }

        private void RemovePersonSMTButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonSMTi9PersonID == Guid.Empty)
                return;

            try
            {
                if (mDataSet.Tables["i9PersonSMT"] != null)
                {
                    if (PersonSMTListView.SelectedItem != null)
                    {
                        ICollectionView cv = CollectionViewSource.GetDefaultView(PersonSMTListView.ItemsSource);
                        mDataSet.Tables["i9PersonSMT"].DefaultView.Delete(cv.CurrentPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting SMT:  ", ex);
                MessageBox.Show("Error deleting SMT " + ex.Message);
            }
        }
    }
}
