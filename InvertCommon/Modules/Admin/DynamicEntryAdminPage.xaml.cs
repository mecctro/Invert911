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

using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Utilities;
using Invert911.InvertCommon.Framework.Utilities;
using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Framework.ClientData;
using Invert911.InvertCommon.StandardGui;

namespace Invert911.InvertCommon.Modules.Admin
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DynamicEntryAdminPage : Page
    {
        public DataSet DynamicEntryDS = new DataSet();
        private DataView mi9DynamicEntryConfig_DV;

        public DynamicEntryAdminPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(DynamicEntryAdminPage_Loaded);
            this.DynamicEntryControlsListBox.SelectionChanged += new SelectionChangedEventHandler(DynamicEntryControlsListBox_SelectionChanged);
        }

        void DynamicEntryControlsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DynamicEntryControlsListBox.SelectedItem == null)
            {
                //DynamicEntryColumnsListView.Items.Clear(); // Need to test this code.
                return;
            }

            string DynamicEntryModule =  (DynamicEntryControlsListBox.SelectedItem as ListBoxItem).Content.ToString();
            string DynamicEntryTable = "";
            
            //Get the data table assoiciated with the DynamicEntry module.
            DataRow[] dr = this.DynamicEntryDS.Tables["i9DynamicEntry"].Select("ModuleSection = '" + DynamicEntryModule + "'");
            if(dr.Length > 0)
                DynamicEntryTable = dr[0]["DynamicEntryTable"].ToString();

            //Filter i9DynamicEntryConfig for current settings
            mi9DynamicEntryConfig_DV = new DataView();
            mi9DynamicEntryConfig_DV.Table = this.DynamicEntryDS.Tables["i9DynamicEntryConfig"];
            mi9DynamicEntryConfig_DV.RowFilter = " ModuleSection = '" + DynamicEntryModule + "' ";
            mi9DynamicEntryConfig_DV.Sort = "ColumnName";

            //********************************************************************************
            // Get Config settings for this Module Section:
            //********************************************************************************
            i9Message ReturnMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, 
                                            AdminType.DynamicEntry_GetTableColumns, 
                                            "DynamicEntryAdminPage", 
                                            typeof(string), 
                                            DynamicEntryModule + "," + DynamicEntryTable);

            if (ReturnMsg.ErrorStatus.IsError)
            {
                //TODO: Need to display error message.
                LogManager.Instance.LogMessage("DynamicEntryAdminPage", "LoadData", "Error:  " + ReturnMsg.ErrorStatus.ErrorMsg);
                return;
            }

            DataSet TableSchemaDS = ReturnMsg.MsgBodyDataSet;

            //********************************************************************************
            // Remove any i9DynamicEntryConfig columns that are not in the table schema
            //********************************************************************************
            List<DataRow> DataRowDelete = new List<DataRow>();
            foreach (DataRowView dDynEnRow in mi9DynamicEntryConfig_DV)
            {
                // i9TableSchema **************************************************
                //TableName, ColumnName, DataType, MaxLength, IsPrimaryKey

                bool DeleteRow = true;

                if (dDynEnRow["ColumnName"].ToString().ToUpper().EndsWith("ID"))
                {
                    DeleteRow = true;
                }
                else
                {
                    foreach (DataRow dIncRow in TableSchemaDS.Tables["i9TableSchema"].Rows)
                    {
                        if (dIncRow["ColumnName"].ToString().ToLower() == dDynEnRow["ColumnName"].ToString().ToLower())
                        {
                            DeleteRow = false;
                            break;
                        }
                    }
                }

                if (DeleteRow)
                    DataRowDelete.Add(dDynEnRow.Row);
            }

            foreach (DataRow DeleteDR in DataRowDelete)
                mi9DynamicEntryConfig_DV.Table.Rows.Remove(DeleteDR);

            //********************************************************************************
            // Add any i9DynamicEntryConfig columns that are in the given table schema
            //********************************************************************************
            List<DataRow> DataRowAdd = new List<DataRow>();
            foreach (DataRow dIncRow in TableSchemaDS.Tables["i9TableSchema"].Rows)
            {
                bool Found = false;

                if (dIncRow["ColumnName"].ToString().ToUpper().EndsWith("ID"))
                {
                    Found = true;
                }
                else
                {
                    foreach (DataRowView dDynEnRow2 in mi9DynamicEntryConfig_DV)
                    {
                        if (dIncRow["ColumnName"].ToString().ToLower() == dDynEnRow2["ColumnName"].ToString().ToLower())
                        {
                            Found = true;
                            break;
                        }
                    }
                }

                if (Found == false)
                    DataRowAdd.Add(dIncRow);
            }

            //***********************************************************************************
            // add i9TableSchema data row to the mi9DynamicEntryConfig_DV that are not in there
            //***********************************************************************************
            foreach (DataRow drADD in DataRowAdd)
            {
                // i9DynamicEntryConfig *******************************************
                //ModuleSection, Enabled, Acency, LabelText, CtrlWidth, CtrlHeight
                //CtrlFont, CtrlForGroundColor, CtrlBackGroundColor, PrintEnabled
                //TableName, ColumnName, i9DynamicEntryConfigID, i9AgencyID

                DataRow NewDataRow = mi9DynamicEntryConfig_DV.Table.NewRow(); // ds.Tables["i9DynamicEntryConfig"].NewRow();
                NewDataRow["TableName"] = drADD["TableName"];
                NewDataRow["ColumnName"] = drADD["ColumnName"];
                NewDataRow["LabelText"] = drADD["ColumnName"];
                NewDataRow["MaxLength"] = drADD["MaxLength"];
                NewDataRow["Enabled"] = 0;
                NewDataRow["PrintEnabled"] = 1;
                NewDataRow["CtrlTypeName"] = "i9TextBox";
                NewDataRow["ModuleSection"] = DynamicEntryModule;
                NewDataRow["i9AgencyID"] = SettingManager.Instance.AgencyID;
                //NewDataRow["i9DynamicEntryConfigID"] = KeyGenerator.Instance.NextClientTableKey("i9DynamicEntryConfig", true);
                NewDataRow["i9DynamicEntryConfigID"] = KeyGenerator.Instance.NewGuid();
                //NewDataRow["IsPrimaryKey"] = drADD["IsPrimaryKey"];
                NewDataRow["DataType"] = drADD["DataType"];
                NewDataRow["IsReadOnly"] = 0;
                mi9DynamicEntryConfig_DV.Table.Rows.Add(NewDataRow);
            }

            //Old Code: ------------------------------------------------------------------------
            //DynamicEntryColumnsListView.DataContext = ReturnMsg.MsgBodyDataSet.Tables["i9DynamicEntryConfig"].DefaultView;
            //DynamicEntryColumnsListView.DataContext = dv.Table.DefaultView;
            
            //New Code: ------------------------------------------------------------------------
            MainDockPanel.DataContext = mi9DynamicEntryConfig_DV; //.Table.DefaultView;
        }

        void DynamicEntryAdminPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (DynamicEntryControlsListBox.Items.Count > 0)
                return;

            //i9DynamicEntry
            DynamicEntryControlsListBox.Items.Clear();

            i9Message ReturnMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.DynamicEntry_GetDynamicEntryAdmin, "DynamicEntryAdminPage");
            if (ReturnMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage("DynamicEntryAdminPage", "LoadData", "Error:  " + ReturnMsg.ErrorStatus.ErrorMsg);
            }
            else
            {
                this.DynamicEntryDS = ReturnMsg.MsgBodyDataSet;
                foreach (DataRow dr in this.DynamicEntryDS.Tables["i9DynamicEntry"].Rows)
                {
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.Content = dr["ModuleSection"].ToString();
                    DynamicEntryControlsListBox.Items.Add(lbi);
                }
            }
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleManager.Instance.NavigateTo(this, "MainPage");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {

            if (this.DynamicEntryDS.HasChanges() == false)
            {
                ErrorMsgLabel.Content = "No changes to save";
                return;
            }

            //********************************************************************************
            // Save i9DynamicEntryConfig:
            //********************************************************************************
            i9Message ReturnMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.DynamicEntry_SaveDynamicEntryAdmin, "DynamicEntryAdminPage", this.DynamicEntryDS);
            if (ReturnMsg.ErrorStatus.IsError)
            {
                //Display error message to user.
                ErrorMsgLabel.Content = "Error Saving data." + ReturnMsg.ErrorStatus.ErrorMsg;
                //ErrorMsgLabel.Foreground = Brush.
                
                //Log error message to user.
                LogManager.Instance.LogMessage("DynamicEntryAdminPage", "SaveData", "Error:  " + ReturnMsg.ErrorStatus.ErrorMsg);
                return;
            }
            else
            {
                this.DynamicEntryDS.AcceptChanges();
                ErrorMsgLabel.Content = "Changes to saved";
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DynamicEntryDS.RejectChanges();
            //LoadData();
        }

        private void UnSelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView drv in mi9DynamicEntryConfig_DV)
            {
                drv["Enabled"] = 0;
            }
        }

        private void SelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(DataRowView drv in mi9DynamicEntryConfig_DV)
            {
                drv["Enabled"] = 1;
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            //ClientDataSync cds = new ClientDataSync();
            //if (cds.Sync() == false)
            //{
            //    //SetStatus("Sync download had problems initializing");
            //    return;
            //}
        }

        private void ControlTypeComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (ControlTypeComboBox.Items.Count <= 0)
            {
                ClientDataAccess cda = new ClientDataAccess();
                DataTable dt = cda.GetDataTable("SELECT CtrlTypeName, CtrlTypeDesc FROM i9DynamicEntryCtrlType ", "i9DynamicEntryCtrlType");
                i9ComboBox.PopulateCombobox(ControlTypeComboBox, dt, "CtrlTypeName");        
            }
        }

        private void CodeSetNameComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (CodeSetNameComboBox.Items.Count <= 0)
            {
                CodeSetNameComboBox.DisplayMemberPath = "CodeSetName";
                CodeSetNameComboBox.SelectedValue = "CodeSetName";
                CodeSetNameComboBox.SelectedValuePath = "CodeSetName";

                ClientDataAccess cda = new ClientDataAccess();
                DataTable dt = cda.GetDataTable("SELECT CodeSetName FROM i9Code Group By CodeSetName Order By CodeSetName ", "i9Code");
                i9ComboBox.PopulateCombobox(CodeSetNameComboBox, dt, "CodeSetName");
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char ch in e.Text)
            {
                if (!(Char.IsDigit(ch) || ch.Equals('.')))
                {
                    e.Handled = true;
                }
            }

        }
    }
}
