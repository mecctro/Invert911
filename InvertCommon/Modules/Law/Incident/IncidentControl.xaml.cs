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

using Invert911.InvertCommon.DataTypes;
using System.Data;
using Invert911.InvertCommon.Framework;

namespace Invert911.Incident
{
    /// <summary>
    /// Interaction logic for IncidentControl.xaml
    /// </summary>
    public partial class IncidentControl : UserControl
    {
        public IncidentControl()
        {
            InitializeComponent();
        }

        public void DataBind(DataSet lDataSet)
        {
            
            this.DataContext = lDataSet.Tables["i9LawIncident"];

            MainIncidentDynControl.DataBind(lDataSet.Tables["i9LawIncident"].DefaultView, "Incident.General", "i9LawIncident");

            DataView IncidentLocationDV = new DataView( lDataSet.Tables["i9Location"]);
            IncidentLocationDV.RowFilter = "i9ModuleSectionID = '" + i9ModuleSection.LawIncidentLocation.ToString() + "'";

            MainLocationDynControl.DataBind(IncidentLocationDV, "Location", "i9Location");
            //IncidentLocation.DataBind(lDataSet);
            
            IncidentCADServiceCall.DataBind(lDataSet);
            LoadSupplements();
            LoadSolvabilityFactors();
            
        }

        private void LoadSolvabilityFactors()
        {
            
        }

        private void LoadSupplements()
        {
            
        }

        //private void OldCode()
        //{
        //    this.ReportNumberTextBox.SetBinding(TextBox.TextProperty, "IncidentNumber");
        //    this.SupplementNoTextBox.SetBinding(TextBox.TextProperty, "SupplementNumber");
        //    this.StatusTextBox.SetBinding(TextBox.TextProperty, "StatusCode");

        //    this.ReportNumberTextBox.DataContext = lDataSet.Tables["i9LawIncident"];  //.Rows[0]["IncidentNumber"];
        //    this.ReportedDateTextBox.DataContext = _LawIncidentMaster;
        //    this.AgencyTextBox.DataContext = _LawIncidentMaster._LawIncidentSupplement;

        //    this.NatureOfCallTextBox.DataContext = _LawIncidentMaster._LawIncidentSupplement;
        //    //this.BeginDateTextBox.DataContext = _LawIncidentMaster._LawIncidentSupplement.;

        //    NatureOfCallTextBox.SetBinding(TextBox.TextProperty, "NatureOfCallCode");
        //}
    }
}
