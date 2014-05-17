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

using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Framework.Utilities;
using Invert911.InvertCommon.Utilities;
using Invert911.InvertCommon.Framework.ClientData;

namespace Invert911.InvertCommon.Modules.Admin
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CodeAdminPage : Page
    {
        DataTable CodeDetailDataTable;

        public CodeAdminPage()
        {
            InitializeComponent();
            this.Unloaded += new RoutedEventHandler(CodeAdminPage_Unloaded);
            //CodeTypesListBox.SelectionChanged += new SelectionChangedEventHandler(CodeTypesListBox_SelectionChanged);
        }

        void CodeTypesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CodeDetailDataTable != null)
            {
                if (CodeDetailDataTable.DataSet.HasChanges())
                {
                    if (MessageBox.Show("Save changes?", "Save?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (SaveData() == false)
                        {
                            e.Handled = true;
                            return;
                        }

                    }
                }
            }

            if(CodeTypesListBox.SelectedValue== null  )
            {
                this.DataContext = null;
            }
            else
            {
                string CodeSetName = CodeTypesListBox.SelectedValue.ToString();
                LoadCodeDetailData(CodeSetName);

                //=========================================================================================================
                //THIS IS OLD CODE:
                //=========================================================================================================
                //string sql = "Select * FROM i9Code where CodeSetName = '" + CodeSetName.Replace("'", "''").Trim() + "' order by Code";
                //ClientDataAccess cda = new ClientDataAccess();
                //CodeDataTable = cda.GetDataTable(sql, "i9Code");
            }
        }

        private void LoadCodeDetailData(string CodeSetName)
        {
            
            i9Message RequestMessage = new i9Message();
            RequestMessage.MsgBody = CodeSetName;
            RequestMessage.ToBizLayer = MobileMessageType.Admin;
            RequestMessage.ToBizLayerMsgType = AdminType.Code_GetCodeDetail_Admin;

            i9Message responseMsg = i9MessageManager.SendMessage(RequestMessage);
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                //AppCommand.SendCommand(AppCommandType.Error, AppSubCommandType.DisplayError, "");
                MessageBox.Show("Unable to get codes, please try again.", "Codes", MessageBoxButton.OK, MessageBoxImage.Information);
                
                this.DataContext = null;
                return;
            }

            if (responseMsg.HasTables())
            {
                CodeDetailDataTable = responseMsg.MsgBodyDataSet.Tables[0];
                this.DataContext = CodeDetailDataTable.DefaultView;
            }
            else
            {
                this.DataContext = null;
            }
            
        }

        void CodeAdminPage_Unloaded(object sender, RoutedEventArgs e)
        {
            //Check for unsaved changes   
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            ModuleManager.Instance.NavigateTo(this, "MainPage");
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshCodeList();
        }

        private void RefreshCodeList()
        {
            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.Code_GetCodeList_Admin, "");
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                //AppCommand.SendCommand(AppCommandType.Error, AppSubCommandType.DisplayError, "");
                MessageBox.Show("Unable to get codes, please try again.", "Codes", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DataSet CodeDataSet = responseMsg.MsgBodyDataSet;

            //string sql = "Select CodeSetName FROM i9Code group by CodeSetName order by CodeSetName";
            //ClientDataAccess cda = new ClientDataAccess();
            //DataTable dt = cda.GetDataTable(sql, "i9CodeSet");

            if (CodeDataSet != null)
            {
                if (CodeDataSet.Tables.Count > 0)
                {
                    if (AgencyComboBox.Items.Count <= 0)
                    {
                        AgencyComboBox.Items.Clear();
                        foreach (DataRow dr in CodeDataSet.Tables["i9Agency"].Rows)
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

                        CodeTypesListBox.SelectedValuePath = "CodeSetName";
                        CodeTypesListBox.DisplayMemberPath = "CodeSetName";

                        DataView dv = CodeDataSet.Tables["i9Code"].DefaultView;
                        dv.RowFilter = "i9AgencyID = '" + i9AgencyID + "'";
                        
                        CodeTypesListBox.ItemsSource = dv;
                        CodeTypesListBox.UnselectAll();
                    }
                    else
                    {
                        CodeTypesListBox.ItemsSource = null;
                    }
                }
            }
            else
            {
                AppCommand.SendCommand(AppCommandType.Error, AppSubCommandType.DisplayError, "Unable to retrieve data");
                //Need to give an error message.
            }
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            RefreshCodeList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        private bool SaveData()
        {
            if (CodeDetailDataTable != null)
            {
                DataSet MessageDS = CodeDetailDataTable.DataSet;

                //CodeDataTable
                i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.Code_SaveCodeDetail_Admin, "CodeAdminPage", MessageDS);
                if (responseMsg.ErrorStatus.IsError)
                {
                    LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                    //AppCommand.SendCommand(AppCommandType.Error, AppSubCommandType.DisplayError, "");
                    MessageBox.Show("Unable to save codes detail, please try again.", "Codes", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                else
                {
                    CodeDetailDataTable.AcceptChanges();
                    CodeDetailDataTable.DataSet.AcceptChanges();
                }
            }
            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (CodeDetailDataTable != null)
            {
                CodeDetailDataTable.RejectChanges();
            }
        }

        private void AgencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshCodeList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CodeDetailDataTable != null)
                {
                    CodeDetailDataTable.Rows.Add(CodeDetailDataTable.NewRow());
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error adding log", ex);
                MessageBox.Show("Error adding code to codeset: " + ex.Message);
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CodeSetExportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string CodeSetName = "";
            try
            {
                if (CodeDetailDataTable != null)
                {
                    if (CodeListView.SelectedItem != null)
                    {
                        ICollectionView cv = CollectionViewSource.GetDefaultView(CodeDetailDataTable);
                        CodeDetailDataTable.DefaultView.Delete(cv.CurrentPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting code (" + CodeSetName + "):  ", ex);
                MessageBox.Show("Error deleting code in codeset(" + CodeSetName + "):  " + ex.Message);
            }
        }

        //if (this.DataContext != null)
        //{
        //    if (this.CodeDataTable.GetChanges().Rows.Count > 0)
        //    {
        //        MessageBoxResult lMessageBoxResult = MessageBox.Show("Save Changes?", "Save", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
        //        if (lMessageBoxResult == MessageBoxResult.Yes)
        //        {
        //            //Save //Need to save CodeDataTable
        //            //i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.Code_SaveCode_Admin, "");
        //            //if (responseMsg.ErrorStatus.IsError)
        //            //{
        //            //}
        //        }
        //        else if (lMessageBoxResult == MessageBoxResult.Cancel)
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //        else if (lMessageBoxResult == MessageBoxResult.No)
        //        {
        //            //Do Nothing
        //        }
        //    }
        //}
    }
}
