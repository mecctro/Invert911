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

using Invert911.InvertCommon.Framework.Utilities;
using Invert911.InvertCommon.Modules.Admin;
using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Utilities;

namespace Invert911.Admin
{
    /// <summary>
    /// Interaction logic for ConfidentialityPage.xaml
    /// </summary>
    public partial class SecurityPage : Page
    {
        //DataSets
        private DataSet mSecurityDS = null;

        //DataViews
        private DataView m_SecurityGroupsDV = null;
        private DataView mi9ModuleDV = null;
        private DataView mi9SecurityTaskDV = null;

        public SecurityPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save Existing Data
            if (SecurityGroupsListBox.SelectedItem != null)
            {
                DataRowView SelectedDrv = (DataRowView)SecurityGroupsListBox.SelectedItem;
                string i9SecurityGroupName = SelectedDrv["SecurityGroupName"].ToString();
                string i9AgencyID = SelectedDrv["i9AgencyID"].ToString();

                SaveData(i9SecurityGroupName, i9AgencyID);
            }

            //Save All Changes to the database
            if (mSecurityDS != null)
            {
                if (mSecurityDS.HasChanges() == false)
                    return;

                // Validation of application 
                //Validate(SecurityListDS);

                //Security Group Data Table
                i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Security, SecurityType.Security_SecurityGroupSave, "SecurityPage", mSecurityDS);
                if (responseMsg.ErrorStatus.IsError)
                {
                    LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                    MessageBox.Show("Unable to save Security information, please try again.", "Security", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    mSecurityDS.AcceptChanges();
                    MessageBox.Show("Save Successful.", "Security", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            return;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (mSecurityDS != null)
            {
                mSecurityDS.RejectChanges();
                MessageBox.Show("Canceled changes.", "Security", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataRow[] dRows = mSecurityDS.Tables["i9SecurityGroup"].Select();
            if (dRows.Length > 0)
            {
                dRows[0].Delete();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AgencyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an agency","Invert911");
                return;
            }

            ComboBoxItem SelectCbi = (ComboBoxItem)AgencyComboBox.SelectedItem;
            string i9AgencyID = SelectCbi.Tag.ToString();

            DataRow dr = mSecurityDS.Tables["i9SecurityGroup"].NewRow();
            dr["i9AgencyID"] = i9AgencyID;
            dr["i9SecurityGroupID"] = Guid.NewGuid();
            dr["SecurityGroupName"] = "New Security";

            mSecurityDS.Tables["i9SecurityGroup"].Rows.Add(dr);
        }

        private void AgencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if( AgencyComboBox.IsEnabled )
                RefreshData();
        }

        private void RefreshData()
        {
            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Security, SecurityType.Security_SecurityGroupsGet, "SecurityPage");
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                MessageBox.Show("Unable to get Security Groups list, please try again.", "Security Groups", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            mSecurityDS = responseMsg.MsgBodyDataSet;

            //Load Agency ComboBox
            if (AgencyComboBox.Items.Count <= 0)
            {
                AgencyComboBox.Items.Clear();
                foreach (DataRow dr in mSecurityDS.Tables["i9Agency"].Rows)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = dr["AgencyName"].ToString();
                    cbi.Tag = dr["i9AgencyID"].ToString();
                    int i = AgencyComboBox.Items.Add(cbi);
                }
            }

            //Populate modules list box
            if (ModulesListView.Items.Count <= 0)
            {
                //Add a new column for the UI List View Check List
                if ( mSecurityDS.Tables["i9Module"].Columns.Contains("Enabled") == false)
                {
                    mSecurityDS.Tables["i9Module"].Columns.Add("Enabled", typeof(string));
                }

                //if (mSecurityDS.Tables["i9Module"].Columns.Contains("OriginalEnabled") == false)
                //{
                //    mSecurityDS.Tables["i9Module"].Columns.Add("OriginalEnabled", typeof(string));
                //}

                //Clear Check List
                foreach (DataRow drv in mSecurityDS.Tables["i9Module"].Rows)
                {
                    drv["Enabled"] = "False";
                }

                mi9ModuleDV = mSecurityDS.Tables["i9Module"].DefaultView;
                ModulesListView.ItemsSource = mi9ModuleDV;
            }
            
            //Populate Task list box
            if (TaskListView.Items.Count <= 0)
            {
                //Add a new column for the UI List View Check List
                if (mSecurityDS.Tables["i9SecurityTask"].Columns.Contains("Enabled") == false)
                {
                    mSecurityDS.Tables["i9SecurityTask"].Columns.Add("Enabled", typeof(string));
                }

                //Clear Check List
                foreach (DataRow drv in mSecurityDS.Tables["i9SecurityTask"].Rows)
                {
                    drv["Enabled"] = 0;
                }

                mi9SecurityTaskDV = mSecurityDS.Tables["i9SecurityTask"].DefaultView;
                TaskListView.ItemsSource = mi9SecurityTaskDV;
            }

            //Accept all changes 
            mSecurityDS.AcceptChanges();

            //Load Security Groups Navigation ListBox
            if (AgencyComboBox.Items.Count > 0)
            {
                if (AgencyComboBox.SelectedItem == null)
                {
                    AgencyComboBox.BeginInit();
                    AgencyComboBox.IsEnabled = false;
                    AgencyComboBox.SelectedIndex = 0;
                    AgencyComboBox.IsEnabled = true;
                    AgencyComboBox.EndInit();
                }
            }

            RefreshSecurityGroups();
        }

        private void RefreshSecurityGroups()
        {
            //if ( SecurityGroupsListBox.Items.Count <= 0)
            //{
                ComboBoxItem SelectCbi = (ComboBoxItem)AgencyComboBox.SelectedItem;
                string i9AgencyID = SelectCbi.Tag.ToString();

                SecurityGroupsListBox.DisplayMemberPath = "SecurityGroupName";
                SecurityGroupsListBox.SelectedValuePath = "i9SecurityGroupID";

                m_SecurityGroupsDV = new DataView( mSecurityDS.Tables["i9SecurityGroup"] );
                m_SecurityGroupsDV.RowFilter = "i9AgencyID = '" + i9AgencyID + "'";

                SecurityGroupsListBox.ItemsSource = m_SecurityGroupsDV;

                //SecurityGroupsDV = new DataView();
                //SecurityGroupsDV.Table = this.SecurityGroupDS.Tables["i9SecurityGroups"];
                //this.DataContext = this.SecurityGroupsDV;
            
                this.MainDockPanel.DataContext = this.m_SecurityGroupsDV;
            //}
            
            //Unselect all checkboxes
            //SecurityGroupsListBox.UnselectAll();
            ModulesListView.UnselectAll();
            TaskListView.UnselectAll();

            SetSecurityGroupNameButtons(true);

            //Select the first item in the nav group
            if (SecurityGroupsListBox.SelectedItem == null)
            {
                if (SecurityGroupsListBox.Items.Count > 0)
                {
                    SecurityGroupsListBox.SelectedIndex = 0;
                }
            }
        }

        private void SetSecurityGroupNameButtons(bool ShowEditButton)
        {
            if (ShowEditButton)
            {
                SecurityGroupCancelButton.Visibility = System.Windows.Visibility.Collapsed;
                SecurityGroupSaveButton.Visibility = System.Windows.Visibility.Collapsed;
                SecurityGroupEditButton.Visibility = System.Windows.Visibility.Visible;

                SecurityTabControl.IsEnabled = true;
                SecurityGroupsListBox.IsEnabled = true;
                ToolbarStackPanel.IsEnabled = true;
            }
            else
            {
                SecurityGroupCancelButton.Visibility = System.Windows.Visibility.Visible;
                SecurityGroupSaveButton.Visibility = System.Windows.Visibility.Visible;
                SecurityGroupEditButton.Visibility = System.Windows.Visibility.Collapsed;

                SecurityTabControl.IsEnabled = false;
                SecurityGroupsListBox.IsEnabled = false;
                ToolbarStackPanel.IsEnabled = false;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //AgencyComboBox.Items
            if (mSecurityDS == null)
            {
                //DataTable dt = new DataTable();
                //FillDataHelper.AgencyFillComboBox(AgencyComboBox, dt);

                RefreshData();
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void SaveData(string PriorSecurityGroupName, string i9PriorAgencyID)
        {

            SaveGroupModulesData(PriorSecurityGroupName, i9PriorAgencyID);
            SaveGroupSecTaskData(PriorSecurityGroupName, i9PriorAgencyID);
        }

        /// <summary>
        /// Save i9SecurityGroupTask
        /// </summary>
        /// <param name="PriorSecurityGroupName"></param>
        /// <param name="i9PriorAgencyID"></param>
        private void SaveGroupSecTaskData(string PriorSecurityGroupName, string i9PriorAgencyID)
        {
            DataView lPrioriSecurityGroupTaskDV = new DataView(mSecurityDS.Tables["i9SecurityGroupTask"]);
            lPrioriSecurityGroupTaskDV.RowFilter = " SecurityGroupName = '" + PriorSecurityGroupName + "' AND i9AgencyID = '" + i9PriorAgencyID + "' ";

            foreach (DataRowView TaskDRV in mi9SecurityTaskDV)
            {
                bool Found = false;
                foreach (DataRowView SecGrpTaskDRV in lPrioriSecurityGroupTaskDV)
                {
                    if (TaskDRV["TaskName"].ToString().ToUpper().Trim() == SecGrpTaskDRV["TaskName"].ToString().ToUpper().Trim())
                    {
                        if (TaskDRV["Enabled"].ToString().ToUpper() == "1")
                        {
                            //Do Nothing
                        }
                        else
                        {
                            SecGrpTaskDRV.Delete();
                        }
                        Found = true;
                    }
                }

                if (Found == false)
                {
                    if (TaskDRV["Enabled"].ToString().ToUpper() == "1")
                    {
                        DataRow NewRow = mSecurityDS.Tables["i9SecurityGroupTask"].NewRow();
                        NewRow["i9SecurityGroupTaskID"] = Guid.NewGuid();
                        NewRow["SecurityGroupName"] = PriorSecurityGroupName;
                        NewRow["i9AgencyID"] = i9PriorAgencyID;
                        NewRow["TaskName"] = TaskDRV["TaskName"];
                        mSecurityDS.Tables["i9SecurityGroupTask"].Rows.Add(NewRow);
                    }
                }
            }
        }

        private void SaveGroupModulesData(string PriorSecurityGroupName, string i9PriorAgencyID)
        {
            DataView lPrioriSecurityGroupModulesDV = new DataView(mSecurityDS.Tables["i9SecurityGroupModule"]);
            lPrioriSecurityGroupModulesDV.RowFilter = " SecurityGroupName = '" + PriorSecurityGroupName + "' AND i9AgencyID = '" + i9PriorAgencyID + "' ";

            //List<DataRowView> NewRowsList = new List<DataRowView>();
            foreach (DataRowView ModuleDRV in mi9ModuleDV)
            {
                bool Found = false;
                foreach (DataRowView SecGrpModuleDRV in lPrioriSecurityGroupModulesDV)
                {
                    if (ModuleDRV["ModuleName"].ToString().ToUpper().Trim() == SecGrpModuleDRV["ModuleName"].ToString().ToUpper().Trim())
                    {
                        if (ModuleDRV["Enabled"].ToString().ToUpper() == "TRUE")
                        {
                            //Do Nothing
                        }
                        else
                        {
                            SecGrpModuleDRV.Delete();
                        }
                        Found = true;
                    }   
                }

                if (Found == false)
                {
                    if (ModuleDRV["Enabled"].ToString().ToUpper() == "TRUE")
                    {

                        DataRow NewRow = mSecurityDS.Tables["i9SecurityGroupModule"].NewRow();
                        NewRow["i9SecurityGroupModuleID"] = Guid.NewGuid();
                        NewRow["SecurityGroupName"] = PriorSecurityGroupName;
                        NewRow["i9AgencyID"] = i9PriorAgencyID;
                        NewRow["ModuleName"] = ModuleDRV["ModuleName"];
                        mSecurityDS.Tables["i9SecurityGroupModule"].Rows.Add(NewRow);
                    }
                }
            }
        }

        private void ChangeSecurityGroupName(string NewSecurityGroupName, string OldSecurityGroupName, string i9PriorAgencyID)
        {    
            foreach (DataRow dr in mSecurityDS.Tables["i9SecurityGroupModule"].Rows)
            {
                if( dr["SecurityGroupName"].ToString() == OldSecurityGroupName )
                {
                    if(dr["i9AgencyID"].ToString() == i9PriorAgencyID )
                    {
                        dr["SecurityGroupName"] = NewSecurityGroupName;
                    }
                }
            }
        }

        private void SecurityGroupsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //=================================================================================
            //Save Old Selection
            //=================================================================================
            if (e.RemovedItems.Count > 0)
            {
                DataRowView PriorSelection = (DataRowView)e.RemovedItems[0];
                string PriorSecurityGroupName = PriorSelection["SecurityGroupName"].ToString();
                string i9PriorAgencyID = PriorSelection["i9AgencyID"].ToString();

                SaveData(PriorSecurityGroupName, i9PriorAgencyID);
            }

            //=================================================================================
            //If no selection then don't display anything
            //=================================================================================
            if (SecurityGroupsListBox.SelectedItem == null)
            {
                foreach (DataRowView drv in mi9ModuleDV)
                {
                    drv["Enabled"] = false;
                }

                return;
            }

            if (SecurityGroupsListBox.SelectedItem == null)
            {
                return;
            }

            DataRowView SelectedDrv = (DataRowView)SecurityGroupsListBox.SelectedItem;
            string i9SecurityGroupName = SelectedDrv["SecurityGroupName"].ToString();
            string i9AgencyID = SelectedDrv["i9AgencyID"].ToString();

            //=================================================================================
            // Load i9Modules Groups
            //=================================================================================
            DataView lSecurityGroupModulesDV = new DataView(mSecurityDS.Tables["i9SecurityGroupModule"]);
            lSecurityGroupModulesDV.RowFilter = " SecurityGroupName = '" + i9SecurityGroupName + "' AND i9AgencyID = '" + i9AgencyID + "'";

            //Create a dictionary of Modules that are checked
            Dictionary<string, string> GroupModuleEnabled = new Dictionary<string, string>();
            foreach (DataRowView drv in lSecurityGroupModulesDV)
            {
                if (GroupModuleEnabled.ContainsKey(drv["ModuleName"].ToString()))
                {
                    System.Diagnostics.Debug.WriteLine("Module Exist: " + drv["ModuleName"].ToString());
                }
                else
                {
                    GroupModuleEnabled.Add(drv["ModuleName"].ToString(), drv["ModuleName"].ToString());
                }
            }

            foreach (DataRowView drv in mi9ModuleDV)
            {
                drv["Enabled"] = GroupModuleEnabled.ContainsKey(drv["ModuleName"].ToString());
            }

            //=================================================================================
            // Load i9Security Tasks
            //=================================================================================
            DataView lSecurityGroupTaskDV = new DataView(mSecurityDS.Tables["i9SecurityGroupTask"]);
            lSecurityGroupTaskDV.RowFilter = " SecurityGroupName = '" + i9SecurityGroupName + "' AND i9AgencyID = '" + i9AgencyID + "'";

            //Create a dictionary of Modules that are checked
            Dictionary<string, string> GroupTaskEnabled = new Dictionary<string, string>();
            foreach (DataRowView drv in lSecurityGroupTaskDV)
            {
                if (GroupModuleEnabled.ContainsKey(drv["TaskName"].ToString()))
                {
                    System.Diagnostics.Debug.WriteLine("Task Exist: " + drv["TaskName"].ToString());
                }
                else
                {
                    GroupTaskEnabled.Add(drv["TaskName"].ToString(), drv["TaskName"].ToString());
                }
            }

            foreach (DataRowView drv in mi9SecurityTaskDV)
            {
                drv["Enabled"] = GroupTaskEnabled.ContainsKey(drv["TaskName"].ToString());
            }

        }

        private void SelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            SelectListVieItems(true);
        }

        private void UnSelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            SelectListVieItems(false);
        }

        private void SelectListVieItems(bool SelectItem)
        {
            if (SecurityTabControl.SelectedIndex == 0)
            {
                ModulesListView.UnselectAll();

                foreach (DataRowView drv in mi9ModuleDV)
                {
                    drv["Enabled"] = SelectItem ? "True" : "False";
                }
            }
            else
            {
                TaskListView.UnselectAll();
            }
        }

        private void SecurityGroupEditButton_Click(object sender, RoutedEventArgs e)
        {
            SecurityGroupTextbox.Tag = SecurityGroupTextbox.Text;
            SetSecurityGroupNameButtons(false);
            SecurityGroupTextbox.IsReadOnly = false;
        }

        private void SecurityGroupSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecurityGroupTextbox.Tag == null)
            {
                throw new Exception("Error on saving security group name");
            }

            if (SecurityGroupsListBox.SelectedItem == null)
            {
                throw new Exception("Error on saving security group name");
            }



            if (SecurityGroupTextbox.Tag.ToString() != SecurityGroupTextbox.Text)
            {

                string NewSecurityGroupName = SecurityGroupTextbox.Text.Trim().ToUpper();
                int NameCount = 0;

                foreach (DataRow dr in mSecurityDS.Tables["i9SecurityGroup"].Rows)
                {
                    if (dr["SecurityGroupName"].ToString().Trim().ToUpper() == NewSecurityGroupName)
                    {
                        NameCount += 1;
                        
                    }
                }

                if(NameCount > 1)
                {
                    MessageBox.Show("You can not change the Security Group name to an existing name", "Unable to Save", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                    return;
                }

                DataRowView SelectedDrv = (DataRowView)SecurityGroupsListBox.SelectedItem;
                string i9AgencyID = SelectedDrv["i9AgencyID"].ToString();
                ChangeSecurityGroupName(SecurityGroupTextbox.Text, SecurityGroupTextbox.Tag.ToString(), i9AgencyID);
             
                SecurityGroupTextbox.IsReadOnly = true;
            }

            SetSecurityGroupNameButtons(true);
        }

        private void SecurityGroupCancelButton_Click(object sender, RoutedEventArgs e)
        {
            SecurityGroupTextbox.Text = SecurityGroupTextbox.Tag.ToString();
            SecurityGroupTextbox.Tag = "";
            SecurityGroupTextbox.IsReadOnly = true;
            SetSecurityGroupNameButtons(true);
        }

    }
}
