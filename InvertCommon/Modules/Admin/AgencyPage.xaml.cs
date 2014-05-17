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


namespace Invert911.InvertCommon.Modules.Admin
{
    /// <summary>
    /// Interaction logic for ConfidentialityPage.xaml
    /// </summary>
    public partial class AgencyPage : Page
    {
        DataSet AgencyListDS;

        public AgencyPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AgencyListDS  != null)
            {
                if (AgencyListDS.HasChanges() == false)
                    return ;

                // Validation of application 
                //Validate(AgencyListDS);


                //Peronnel Data Table
                i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Agency, AgencyType.Agency_Save, "AgencyPage", AgencyListDS);
                if (responseMsg.ErrorStatus.IsError)
                {
                    LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                    MessageBox.Show("Unable to save agency information, please try again.", "Agency", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    AgencyListDS.AcceptChanges();
                }
            }
            return;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if( AgencyListDS != null)
            {
                AgencyListDS.RejectChanges();
            }
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Agency, AgencyType.Agency_GetList, "");
            if (responseMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage(responseMsg.ErrorStatus);
                MessageBox.Show("Unable to get agency list, please try again.", "Agency", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AgencyListDS = responseMsg.MsgBodyDataSet;
            AgencyListListBox.SelectedValuePath = "i9AgencyID";
            AgencyListListBox.DisplayMemberPath = "AgencyName";
            this.DataContext = AgencyListDS.Tables["i9Agency"].DefaultView;
            //DynamicEntryControlsListBox.ItemsSource = AgencyListDS.Tables["i9Agency"].DefaultView;

            AgencyListListBox.UnselectAll();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //ComboBoxItem SelectCbi = (ComboBoxItem)AgencyComboBox.SelectedItem;
            //string i9AgencyID = SelectCbi.Tag.ToString();
            DataRow[] dRows = AgencyListDS.Tables["i9Agency"].Select();
            if (dRows.Length > 0)
            {
                dRows[0].Delete();
                //AgencyListDS.Tables["i9Agency"].Rows.Remove(
                //string i9AgencyID = dRows[0][""].ToString();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DataRow dr =  AgencyListDS.Tables["i9Agency"].NewRow();
            dr["i9AgencyID"] = Guid.NewGuid();
            dr["AgencyName"] = "NewAgency";

            AgencyListDS.Tables["i9Agency"].Rows.Add(dr);
        }

        //private void AgencyListListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (PersonnelDetailDS != null)
        //    {
        //        if (PersonnelDetailDS.HasChanges())
        //        {
        //            if (MessageBox.Show("Save changes?", "Save?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //            {
        //                if (SaveData() == false)
        //                {
        //                    e.Handled = true;
        //                    return;
        //                }
        //            }
        //        }
        //    }

        //    if (PersonnelListBox.SelectedValue == null)
        //    {
        //        this.DataContext = null;
        //    }
        //    else
        //    {
        //        string PersonnelID = PersonnelListBox.SelectedValue.ToString();
        //        LoadPersonnelDetailData(PersonnelID);
        //    }
        //}
    }
}
