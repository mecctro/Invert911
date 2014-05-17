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
using System.Windows.Shapes;
using System.Data;
using System.IO;

using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.DataTypes;
using Invert911.InvertCommon.Modules;
//using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Messages.Law;
using Invert911.InvertCommon.Reports;
using Invert911.InvertCommon.Reports.LawIncident;

namespace Invert911.InvertCommon.Modules.Law.PolicePad
{
    /// <summary>
    /// Interaction logic for IncidentForm.xaml
    /// </summary>
    public partial class PolicePadEntry : UserControl, IMDTModule
    {
        public delegate void CloseIncidentDelegate(string i9EventID, string i9Guid);
        public event CloseIncidentDelegate CloseIncident;

        private string m_ModuleName = "IncidentWorkspace";
        private LawIncidentType m_LawIncidentType;

        public string i9EventID { get; set; } 
        public string i9Guid { get; set; }  
        
        public PolicePadEntry(string li9EventID)
        {
            InitializeComponent();

            this.i9Guid = Guid.NewGuid().ToString();
            this.i9EventID = li9EventID;
            this.Loaded += new RoutedEventHandler(IncidentEntry_Loaded);
        }

        void IncidentEntry_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_LawIncidentType != null)
                return;

            ClearReportViewer();
            
            //m_LawIncidentType.oDataSet = responseMsg.MsgBodyDataSet;
            DataBindIncident(); 
        }

        private void DataBindIncident()
        {
            ////, "Incident.General", "i9LawIncident"
            //IncidentControlUC.DataBind(m_LawIncidentType.oDataSet);  
            //IncidentPersons.DataBind(m_LawIncidentType.oDataSet);
            //IncidentVehicles.DataBind(m_LawIncidentType.oDataSet);
            //IncidentProperties.DataBind(m_LawIncidentType.oDataSet);

            //SummaryNarrative.DataBind(m_LawIncidentType.oDataSet, true);
            //MainNarrative.DataBind(m_LawIncidentType.oDataSet, false);

            //IncidentAttachments.DataBind(m_LawIncidentType.oDataSet);
            //IncidentLinks.DataBind(m_LawIncidentType.oDataSet);

            ////IncidentMO.DataBind(m_LawIncidentType.oDataSet);
            //LawIncidentAssociations.DataBind(m_LawIncidentType.oDataSet);
        }

        //ILawRecordsModule Interface
        public string ModuleName
        {
            get { return m_ModuleName; }
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex == 0)
                MainTabControl.SelectedIndex = MainTabControl.Items.Count - 1;
            else
                MainTabControl.SelectedIndex -= 1;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex >= MainTabControl.Items.Count - 1)
                MainTabControl.SelectedIndex = 0;
            else
                MainTabControl.SelectedIndex += 1;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.m_LawIncidentType.oDataSet.HasChanges())
            {
                //i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Incident, LawType.Incident_Save, "incidentEntry", this.m_LawIncidentType.oDataSet);
                //if (responseMsg.ErrorStatus.IsError)
                //{
                //    MessageBox.Show("Error Saving Incident", "Error Saving", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
                //else
                //{
                //    this.m_LawIncidentType.oDataSet.AcceptChanges();
                //    MessageBox.Show("Successful Saving Incident", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
                //}
            }
            else
            {
                MessageBox.Show("No changes to save");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.m_LawIncidentType.oDataSet.RejectChanges();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //TabItem ti = (TabItem)
                MainTabControl.SelectedIndex = ReportTabItem.TabIndex;
                //if (ti.Visibility == System.Windows.Visibility.Visible)
                //{
                //    MainTabControl.SelectedItem = ti;
                //}
            }
            catch //(Exception ex)
            {

            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (CloseIncident != null)
                CloseIncident(this.i9EventID, this.i9Guid);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
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
            //    if (CloseIncident != null)
            //        CloseIncident(this.i9EventID, this.i9Guid);
            //}
        }

        private void PrintReportBrowser_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {

        }

        private void PrintReportBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void MediaIncidentButton_Click(object sender, RoutedEventArgs e)
        {
            ReportUtility ru = new ReportUtility();
            PrintReportBrowser.NavigateToString(ru.PrintVerticalDataSet(m_LawIncidentType.oDataSet));
        }

        private void ExportDataReport_Click(object sender, RoutedEventArgs e)
        {
            StringWriter sw = new StringWriter();
            m_LawIncidentType.oDataSet.WriteXml(sw);
            string XMLResult = sw.ToString();
            string XMLHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>   ";
            PrintReportBrowser.NavigateToString(XMLHeader + XMLResult);
        }

        private void StandardReportButton_Click(object sender, RoutedEventArgs e)
        {
            LawIncidentStandardReport ru = new LawIncidentStandardReport();
            PrintReportBrowser.NavigateToString(ru.PrintReport(m_LawIncidentType.oDataSet));
        }

        private void ExportSchemaReport_Click(object sender, RoutedEventArgs e)
        {
            StringWriter sw = new StringWriter();
            m_LawIncidentType.oDataSet.WriteXmlSchema(sw);
            string XMLResult = sw.ToString();

            //string XMLHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>   ";
            XMLResult = XMLResult.Replace("encoding=\"utf-16\"?>", "encoding=\"utf-8\" standalone=\"yes\"?>");
            PrintReportBrowser.NavigateToString( XMLResult);
        }

        private void ClearReportViewer()
        {
            string HTMLString = "<BR><BR><BR><H1><Center>Invert911<BR>Law Incident Reports</Center></H1>";

            PrintReportBrowser.NavigateToString(HTMLString);
        }

        private void DeltaIncidentButton_Click(object sender, RoutedEventArgs e)
        {
            string PDFFileLocation = @"C:\Dev\Invert911\Invert911_RMS\InvertCommon\Reports\LawIncident\DeltaReports\IncidentReport.pdf";
            PDFUtility p = new PDFUtility();
            Dictionary<string, string> d = p.ReadAllFields(PDFFileLocation);

            string s = d.ToString();

            PrintReportBrowser.Navigate(PDFFileLocation);
        }
    }
}
