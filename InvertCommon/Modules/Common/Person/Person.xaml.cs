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

using Invert911.InvertCommon.DataTypes;
using System.ComponentModel;

namespace Invert911.InvertCommon.Modules.Person
{
    /// <summary>
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class Person : UserControl
    {
        DataSet mDataSet;
        DataView mDataView;

        public Person()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //per:PersonDetailDynControlper:PersonDetailDynControl
            //MainPersonDetailDynControl
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;
            //if (mDataView != null)
            //    mDataView.Dispose();

            mDataView = lDataSet.Tables["i9Person"].DefaultView;
            
            //mDataView = new DataView( lDataSet.Tables["i9Person"]);
            //mDataView.ListChanged += new ListChangedEventHandler(mDataView_ListChanged);

            //MainLocations.PersistId =
            //ICollectionView cv = CollectionViewSource.GetDefaultView(mDataView.Tables["i9Person"]);
            //mDataSet.Tables["i9Person"].DefaultView.Delete(cv.CurrentPosition);

            //General binding
            this.DataContext = mDataView;

            //Bind sub user controls:
            MainPersonDetailDynControl.DataBind(mDataView, "Incident.Person.Name", "i9Person");
            MainLocations.DataBind(mDataSet);
            MainPersonAKAs.DataBind(mDataSet);
            MainPersonSMTs.DataBind(mDataSet);
        }

        internal void SelectionChanged(Guid Selectedi9PersonID)
        {
            MainLocations.Locationi9PersonID = Selectedi9PersonID;
            MainLocations.DataBind(mDataSet);

            MainPersonAKAs.PersonAKAi9PersonID = Selectedi9PersonID;
            MainPersonAKAs.DataBind(mDataSet);

            MainPersonSMTs.PersonSMTi9PersonID = Selectedi9PersonID;
            MainPersonSMTs.DataBind(mDataSet);
        }
    }
}
