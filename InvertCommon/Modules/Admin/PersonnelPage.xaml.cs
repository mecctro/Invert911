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
using Invert911.InvertCommon.Framework.ClientData;

namespace Invert911.InvertCommon.Modules.Admin
{
    /// <summary>
    /// Interaction logic for PersonnelPage.xaml
    /// </summary>
    public partial class PersonnelPage : Page
    {

        DataSet PersonnelDetailDS = null;
        private DataView m_PersonnelListViewDV;

        public PersonnelPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if(PersonnelDetailDS != null)
                PersonnelDetailDS.RejectChanges();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPersonnel();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            RefreshPersonnel();
        }

        private void RefreshSecurityGrid(string i9SysPersonnelID)
        {
            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Security, SecurityType.Security_PersonnelGroupTaskGet, "", typeof(string), i9SysPersonnelID);
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                //AppCommand.SendCommand(AppCommandType.Error, AppSubCommandType.DisplayError, "");
                MessageBox.Show("Unable to get personnel, please try again.", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            ModuleNamesListView.ItemsSource = responseMsg.MsgBodyDataSet.Tables["ModuleName"].DefaultView;

            TaskNameListView.ItemsSource = responseMsg.MsgBodyDataSet.Tables["ModuleName"].DefaultView;
        }

        private void RefreshPersonnel()
        {
            //***********************************************************************************************
            // load Security Groups
            //***********************************************************************************************

            //if (SecurityGroupsListView.Items.Count <= 0)
            //{
            //    string sql = "Select * FROM i9SecurityGroup ORDER BY SecurityGroupName ASC";
            //    ClientDataAccess cda = new ClientDataAccess();
            //    DataTable i9SecurityGroupDT = cda.GetDataTable(sql, "i9SecurityGroup");

            //    //Add a new column for the UI List View Check List
            //    if (i9SecurityGroupDT.Columns.Contains("Enabled") == false)
            //    {
            //        i9SecurityGroupDT.Columns.Add("Enabled", typeof(string));
            //    }

            //    //Clear Check List
            //    foreach (DataRow drv in i9SecurityGroupDT.Rows)
            //    {
            //        drv["Enabled"] = "False";
            //    }

            //    SecurityGroupsListView.ItemsSource = i9SecurityGroupDT.DefaultView;
            //}

            
            //***********************************************************************************************
            // Get codes from server dataset
            //***********************************************************************************************
            string i9SysPersonnelID = SettingManager.Instance.LoginDataSet.Tables["i9SysPersonnel"].Rows[0]["i9SysPersonnelID"].ToString();

            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.SysPer_GetList, "", typeof(string), i9SysPersonnelID);
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                //AppCommand.SendCommand(AppCommandType.Error, AppSubCommandType.DisplayError, "");
                MessageBox.Show("Unable to get personnel, please try again.", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DataSet SysPerListDataSet = responseMsg.MsgBodyDataSet;
            if (SysPerListDataSet == null)
            {    
                AppCommand.SendCommand(AppCommandType.Error, AppSubCommandType.DisplayError, "Unable to retrieve data");
                //Error message.
                MessageBox.Show("Unable to get personnel, please try again.", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Load Security Tasks
                RefreshSecurityGrid(i9SysPersonnelID);

                if (SysPerListDataSet.Tables.Count > 0)
                {
                    if (AgencyComboBox.Items.Count <= 0)
                    {
                        AgencyComboBox.Items.Clear();
                        foreach (DataRow dr in SysPerListDataSet.Tables["i9Agency"].Rows)
                        {
                            ComboBoxItem cbi = new ComboBoxItem();
                            cbi.Content = dr["AgencyName"].ToString();
                            cbi.Tag = dr["i9AgencyID"].ToString();
                            int i = AgencyComboBox.Items.Add(cbi);
                        }
                    }

                    if (AgencyComboBox.Items.Count > 0)
                    {
                        if (AgencyComboBox.SelectedItem == null)
                        {
                            AgencyComboBox.IsEnabled = false;
                            AgencyComboBox.SelectedIndex = 0;
                            AgencyComboBox.IsEnabled = true;
                        }

                        ComboBoxItem SelectCbi = (ComboBoxItem)AgencyComboBox.SelectedItem;
                        string i9AgencyID = SelectCbi.Tag.ToString();

                        m_PersonnelListViewDV = SysPerListDataSet.Tables["i9SysPersonnel"].DefaultView;
                        m_PersonnelListViewDV.RowFilter = "i9AgencyID = '" + i9AgencyID + "'";

                        PersonnelListView.ItemsSource = m_PersonnelListViewDV;
                        PersonnelListView.UnselectAll(); 
                    }
                    else
                    {
                        PersonnelListView.ItemsSource = null;
                    }
                }
            }
            
        }

        //private void UpdatePersonnelGrid()
        //{
        //    if (PersonnelListView.SelectedItem == null)
        //        return;

        //    DataRowView SelectedDrv = (DataRowView)PersonnelListView.SelectedItem;
        //    UpdatePersonnelGrid(SelectedDrv);
        //}

        private void UpdatePersonnelGrid()  //DataRowView SelectedDrv
        {
            foreach (DataRowView drv in m_PersonnelListViewDV)
            {
                foreach(DataRow dr in PersonnelDetailDS.Tables["i9SysPersonnel"].Rows)
                {

                
                    if (drv["i9SysPersonnelID"].ToString() == dr["i9SysPersonnelID"].ToString())
                    {
                        drv["BadgeNumber"] = dr["BadgeNumber"];
                        drv["FirstName"] = dr["FirstName"];
                        drv["MiddleName"] = dr["MiddleName"];
                        drv["LastName"] = dr["LastName"];
                        drv["Enabled"] = dr["Enabled"];
                        drv["OfficerORI"] = dr["OfficerORI"];
                        break;
                    }
                }
            }
        }

        private void PersonnelListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PersonnelDetailDS != null)
            {
                if (PersonnelDetailDS.HasChanges())
                {
                    if (MessageBox.Show("Save changes?", "Save?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (SaveData())
                        {
                            if (e.RemovedItems.Count > 0)
                            {
                                //UpdatePersonnelGrid((DataRowView)e.RemovedItems[0]);
                                UpdatePersonnelGrid();
                            }
                        }
                        else
                        {      
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }

            if (PersonnelListView.SelectedValue == null)
            {
                this.DataContext = null;
            }
            else
            {
                DataRowView SelectedDrv = (DataRowView)PersonnelListView.SelectedItem;
                string i9SysPersonnelID = SelectedDrv["i9SysPersonnelID"].ToString();
                LoadPersonnelDetailData(i9SysPersonnelID);
            }
        }

        private void LoadPersonnelDetailData(string PersonnelID)
        {
            i9Message RequestMessage = new i9Message();
            RequestMessage.MsgBody = PersonnelID;
            RequestMessage.ToBizLayer = MobileMessageType.Admin;
            RequestMessage.ToBizLayerMsgType = AdminType.SysPer_PersonGet;

            i9Message responseMsg = i9MessageManager.SendMessage(RequestMessage);
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                MessageBox.Show("Unable to get peronnel, please try again.", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);

                this.DataContext = null;
                return;
            }

            if (responseMsg.HasTables())
            {
                PersonnelDetailDS = responseMsg.MsgBodyDataSet;
                this.DataContext = PersonnelDetailDS.Tables["i9SysPersonnel"].DefaultView;
            }
            else
            {
                this.DataContext = null;
            }
        }

        private bool SaveData()
        {
            if (PersonnelDetailDS != null)
            {
                if (PersonnelDetailDS.HasChanges() == false)
                    return true;

                // Validation of application 
                PersonValidate(PersonnelDetailDS);

                //Peronnel Data Table
                i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.SysPer_PersonSave, "PersonnelPage", PersonnelDetailDS);
                if (responseMsg.ErrorStatus.IsError)
                {
                    LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                    MessageBox.Show("Unable to save personnel detail, please try again.", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else
                {
                   
                    PersonnelDetailDS.AcceptChanges();
                }
                
                
                UpdatePersonnelGrid();
            }
            return true;
        }

        private void PersonValidate(DataSet PersonnelDetailDS)
        {
            //throw new NotImplementedException();
        }

        private void AgencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshPersonnel();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AgencyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an Agency.", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            ComboBoxItem SelectCbi = (ComboBoxItem)AgencyComboBox.SelectedItem;
            string i9AgencyID = SelectCbi.Tag.ToString();

            //string TestAgencyID = AgencyComboBox.SelectedValue.ToString();
            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.SysPer_PersonAdd, "PersonnelPage", typeof(string), i9AgencyID);
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                MessageBox.Show("Unable to add a personnel, please try again.", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                RefreshPersonnel();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonnelListView.SelectedValue == null)
            {
                return;
            }

            DataRowView SelectedDrv = (DataRowView)PersonnelListView.SelectedItem;
            string PersonnelID = SelectedDrv["i9SysPersonnelID"].ToString();

            i9Message RequestMessage = new i9Message();
            RequestMessage.MsgBody = PersonnelID;
            RequestMessage.ToBizLayer = MobileMessageType.Admin;
            RequestMessage.ToBizLayerMsgType = AdminType.SysPer_PersonDelete;

            i9Message responseMsg = i9MessageManager.SendMessage(RequestMessage);
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                MessageBox.Show("Unable to delete peronnel, please try again.", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);

                this.DataContext = null;
                return;
            }

            RefreshPersonnel();
        }

        private void EmailTestButton_Click(object sender, RoutedEventArgs e)
        {
            //EmailUtility
        }

        
    }
}
