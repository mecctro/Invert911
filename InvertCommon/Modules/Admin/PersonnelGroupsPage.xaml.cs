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
using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Utilities;
using System.Data;

namespace Invert911.InvertCommon.Modules.Admin
{
    /// <summary>
    /// Interaction logic for ConfidentialityPage.xaml
    /// </summary>
    public partial class PersonnelGroupsPage : Page
    {
        private DataSet m_PageDataSet;
        private DataView m_i9SysPersonnelDV;
        private DataView m_SecurityGroupsDV;

        public PersonnelGroupsPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save Existing Data
            if (SecurityGroupsListView.SelectedItem != null)
            {
                DataRowView SelectedDrv = (DataRowView)SecurityGroupsListView.SelectedItem;
                string i9SecurityGroupID = SelectedDrv["i9SecurityGroupID"].ToString();
                string i9AgencyID = SelectedDrv["i9AgencyID"].ToString();

                SaveData(i9SecurityGroupID, i9AgencyID);
            }


            //Save All Changes to the database
            if (m_PageDataSet != null)
            {
                if (m_PageDataSet.HasChanges() == false)
                    return;

                //Security Group Data Table
                i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Security, SecurityType.Security_PersonnelGroupsSave, "PersonnelGroupsPage", m_PageDataSet);
                if (responseMsg.ErrorStatus.IsError)
                {
                    LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                    MessageBox.Show("Unable to save Security information, please try again.", "Security", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    m_PageDataSet.AcceptChanges();
                    MessageBox.Show("Save Successful.", "Security Personnel Groups", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            return;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_PageDataSet != null)
            {
                m_PageDataSet.RejectChanges();
                MessageBox.Show("Canceled changes.", "Security Personnel Groups", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(m_PageDataSet == null)
                RefreshData();
        }

        private void RefreshData()
        {
            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Security, SecurityType.Security_PersonnelGroupsGet, "");
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                MessageBox.Show("Unable to get Security information, please try again.", "Security Personnel Groups", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            m_PageDataSet = responseMsg.MsgBodyDataSet;

            //Load Agency ComboBox
            if (AgencyComboBox.Items.Count <= 0)
            {
                AgencyComboBox.Items.Clear();
                foreach (DataRow dr in m_PageDataSet.Tables["i9Agency"].Rows)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = dr["AgencyName"].ToString();
                    cbi.Tag = dr["i9AgencyID"].ToString();
                    int i = AgencyComboBox.Items.Add(cbi);
                }
            }

            

            //Add a new column for the UI List View Check List
            if (m_PageDataSet.Tables["i9SysPersonnel"].Columns.Contains("Enabled") == false)
            {
                m_PageDataSet.Tables["i9SysPersonnel"].Columns.Add("Enabled", typeof(string));
            }

            //Clear Check List
            foreach (DataRow drv in m_PageDataSet.Tables["i9SysPersonnel"].Rows)
            {
                drv["Enabled"] = "False";
            }

            //============================================================================
            //Accept all changes 
            //============================================================================
            m_PageDataSet.AcceptChanges();

            //============================================================================
            //Load Agency ListBox
            //============================================================================
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

            ComboBoxItem SelectCbi = (ComboBoxItem)AgencyComboBox.SelectedItem;
            string i9AgencyID = SelectCbi.Tag.ToString();

            //============================================================================
            // Refresh the Security Group list view based on the selected agency
            //============================================================================
            SecurityGroupsListView.SelectedValuePath = "i9SecurityGroupID";
            SecurityGroupsListView.DisplayMemberPath = "SecurityGroupName";

            SecurityGroupsListView.BeginInit();

            m_SecurityGroupsDV = new DataView(m_PageDataSet.Tables["i9SecurityGroup"]);
            m_SecurityGroupsDV.RowFilter = "i9AgencyID = '" + i9AgencyID + "'";

            this.DataContext = m_SecurityGroupsDV;
            SecurityGroupsListView.UnselectAll();

            

            //============================================================================
            // Refresh the Security Personnel list view based on the selected agency
            //============================================================================
            m_i9SysPersonnelDV = m_PageDataSet.Tables["i9SysPersonnel"].DefaultView;
            PersonnelListView.ItemsSource = m_i9SysPersonnelDV;
            PersonnelListView.UnselectAll();


            //============================================================================
            //Select the first item in the nav group
            //============================================================================

            SecurityGroupsListView.EndInit();
            if (SecurityGroupsListView.SelectedItem == null)
            {
                if (SecurityGroupsListView.Items.Count > 0)
                {
                    SecurityGroupsListView.SelectedIndex = 0;
                }
            }

        }

        private void AgencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AgencyComboBox.IsEnabled)
                RefreshData();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void SecurityGroupsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //=================================================================================
            //Save Old Selection
            //=================================================================================
            if (e.RemovedItems.Count > 0)
            {
                DataRowView PriorSelection = (DataRowView)e.RemovedItems[0];
                string PriorSecurityGroupName = PriorSelection["i9SecurityGroupID"].ToString();
                string i9PriorAgencyID = PriorSelection["i9AgencyID"].ToString();

                SaveData(PriorSecurityGroupName, i9PriorAgencyID);
            }

            //=================================================================================
            //If no selection then don't display anything
            //=================================================================================
            if (SecurityGroupsListView.SelectedItem == null)
            {
                foreach (DataRowView drv in m_i9SysPersonnelDV)
                {
                    drv["Enabled"] = false;
                }

                return;
            }


            //if (SecurityGroupsListView.SelectedItem == null)
            //{
            //    return;
            //}

            DataRowView SelectedDrv = (DataRowView)SecurityGroupsListView.SelectedItem;
            string i9SecurityGroupID = SelectedDrv["i9SecurityGroupID"].ToString();
            string i9AgencyID = SelectedDrv["i9AgencyID"].ToString();

            //=================================================================================
            // Load personnel for the given security Groups
            //=================================================================================
            DataView li9SecurityGroupPersonnelDV = new DataView(m_PageDataSet.Tables["i9SecurityGroupPersonnel"]);
            li9SecurityGroupPersonnelDV.RowFilter = " i9SecurityGroupID = '" + i9SecurityGroupID + "' AND i9AgencyID = '" + i9AgencyID + "'";

            //Create a dictionary of Modules that are checked
            Dictionary<string, string> EnabledPersonnel = new Dictionary<string, string>();
            foreach (DataRowView drv in li9SecurityGroupPersonnelDV)
            {
                if (EnabledPersonnel.ContainsKey(drv["i9SysPersonnelID"].ToString()))
                {
                    System.Diagnostics.Debug.WriteLine("i9SysPersonnelID Exist: " + drv["i9SysPersonnelID"].ToString());
                }
                else
                {
                    EnabledPersonnel.Add(drv["i9SysPersonnelID"].ToString(), drv["i9SysPersonnelID"].ToString());
                }
            }

            foreach (DataRowView drv in m_i9SysPersonnelDV)
            {
                drv["Enabled"] = EnabledPersonnel.ContainsKey(drv["i9SysPersonnelID"].ToString());
            }

            //=================================================================================
            // Load i9Security Tasks
            //=================================================================================

        }

        private void SaveData(string Priori9SecurityGroupID, string i9PriorAgencyID)
        {
            DataView lPrioriSecurityGroupPersonnelDV = new DataView(m_PageDataSet.Tables["i9SecurityGroupPersonnel"]);
            lPrioriSecurityGroupPersonnelDV.RowFilter = " i9SecurityGroupID = '" + Priori9SecurityGroupID + "' AND i9AgencyID = '" + i9PriorAgencyID + "' ";

            //Loop Through the i9SysPersonnel Table
            foreach (DataRowView SysPersonnelDRV in m_i9SysPersonnelDV)
            {
                bool Found = false;

                //Loop through the i9SecurityGroupPersonnel table checking for the i9syspersonnelid
                foreach (DataRowView SecGrpModuleDRV in lPrioriSecurityGroupPersonnelDV)
                {
                    if (SysPersonnelDRV["i9SysPersonnelID"].ToString().ToUpper().Trim() == SecGrpModuleDRV["i9SysPersonnelID"].ToString().ToUpper().Trim())
                    {
                        if (SysPersonnelDRV["Enabled"].ToString().ToUpper() == "TRUE")
                        {
                            //Do Nothing
                        }
                        else
                        {
                            SecGrpModuleDRV.Delete();
                        }
                        Found = true;
                        continue;
                    }
                }

                //If not found in the i9SecurityGroupPersonnel table then add it.
                if (Found == false)
                {
                    if (SysPersonnelDRV["Enabled"].ToString().ToUpper() == "TRUE")
                    {
                        DataRow NewRow = m_PageDataSet.Tables["i9SecurityGroupPersonnel"].NewRow();
                        NewRow["i9SecurityGroupPersonnelID"] = Guid.NewGuid();
                        NewRow["i9SecurityGroupID"] = Priori9SecurityGroupID;
                        NewRow["i9AgencyID"] = i9PriorAgencyID;
                        NewRow["i9SysPersonnelID"] = SysPersonnelDRV["i9SysPersonnelID"];
                        m_PageDataSet.Tables["i9SecurityGroupPersonnel"].Rows.Add(NewRow);
                    }
                }
            }
        }
    }
}
