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

using Invert911.InvertCommon.Modules;
//using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Messages.Law;


namespace Invert911.InvertCommon.Modules.Law.PolicePad
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PolicePadMenu : UserControl
    {
        public delegate void NewIncidentDelegate();
        public event NewIncidentDelegate NewIncident;

        public delegate void EditIncidentDelegate(string i9EventID);
        public event EditIncidentDelegate EditIncident;

        public Page ParrentPage;
        DataTable SearchResultsDataTable = null;

        public PolicePadMenu()
        {
            InitializeComponent();
            IncidentListView.MouseDoubleClick += new MouseButtonEventHandler(IncidentListView_MouseDoubleClick);
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewIncident != null)
                NewIncident();
        }

        //private void ShowSearchButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (SearchGroupBox.Visibility == System.Windows.Visibility.Visible)
        //        SearchGroupBox.Visibility = System.Windows.Visibility.Collapsed;
        //    else
        //        SearchGroupBox.Visibility = System.Windows.Visibility.Visible;
        //}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //SearchGroupBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleManager.Instance.NavigateTo(this.ParrentPage, "MainPage");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Incident, LawType.Incident_Search, "incidentMenu");
            //if (responseMsg.ErrorStatus.IsError)
            //{
            //    MessageBox.Show("Error searching for Incidents, please try again");
            //}
            //else
            //{

            //    SearchResultsDataTable = responseMsg.MsgBodyDataSet.Tables["i9LawIncident"];
            //    IncidentListView.DataContext = SearchResultsDataTable.DefaultView;
            //}
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditReport();
        }

        private void IncidentListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditReport();
        }

        private void EditReport()
        {
            if (IncidentListView.SelectedItems.Count <= 0)
                return;

            DataRowView selectedStockObject = IncidentListView.SelectedItems[0] as DataRowView;
            if (selectedStockObject != null)
            {
                DataRow dr = selectedStockObject.Row;
                string i9EventID = dr["i9EventID"].ToString();
                
                if (EditIncident != null)
                    EditIncident(i9EventID);
                
                return;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchResultsDataTable == null)
                return;

            if (IncidentListView.SelectedItems.Count <= 0)
                return;

            DataRowView selectedStockObject = IncidentListView.SelectedItems[0] as DataRowView;
            if (selectedStockObject == null)
            {
                //don't delete incident report
                return;
            }

            DataRow dr = selectedStockObject.Row;
            string i9EventID = dr["i9EventID"].ToString();

            if (MessageBox.Show("Delete Law Incident Report?", "Delete?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No) != MessageBoxResult.Yes)
            {
                //don't delete report
                return;
            }

            ////Send a message to the server to delete the report:
            //i9Message Msg = new i9Message();
            //Msg.ToBizLayer = MobileMessageType.Incident;
            //Msg.ToBizLayerMsgType = LawType.Incident_Delete;
            //Msg.From = "IncidentEntry";

            //LawIncidentMessage incidentMsg = new LawIncidentMessage();
            //incidentMsg.i9EventID = i9EventID;
            //Msg.MsgBody = i9Message.XMLSerializeMessage(incidentMsg.GetType(), incidentMsg);

            //i9Message responseMsg = i9MessageManager.SendMessage(Msg);
            //if (responseMsg.ErrorStatus.IsError)
            //{
            //    MessageBox.Show("Error deleting law incident");
            //    return;
            //}
            //else
            //{
            //    ICollectionView cv = CollectionViewSource.GetDefaultView(SearchResultsDataTable);
            //    SearchResultsDataTable.DefaultView.Delete(cv.CurrentPosition);
            //}
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
