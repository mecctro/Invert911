using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;

using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Utilities;
using System.IO;

namespace Invert911.InvertCommon.Modules
{
    /// <summary>
    /// Interaction logic for Attachments.xaml
    /// </summary>
    public partial class Attachments : UserControl
    {
        private DataView mDataView;
        private DataSet mDataSet;
        //i9AttachmentData
        private ICollectionView mCollectionView;

        public Attachments()
        {
            InitializeComponent();
        }

        public void DataBind(DataSet lDataSet)
        {
            this.mDataSet = lDataSet;
            this.mDataView = mDataSet.Tables["i9Attachment"].DefaultView;
            this.mCollectionView = CollectionViewSource.GetDefaultView(mDataSet.Tables["i9Attachment"]);
            this.DataContext = mDataView;
        }

        private void DisableUI()
        {
            this.IsEnabled = false;
        }

        private void AttachmentNew_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                if (File.Exists(filename))
                {

                    byte[] bData = File.ReadAllBytes(filename);
                    
                    Guid i9Event = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
                    Guid i9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

                    //Add i9Attachment to incident 
                    DataRow dr = mDataSet.Tables["i9Attachment"].NewRow();
                    dr["i9AttachmentID"] = Guid.NewGuid();
                    dr["i9EventID"] = i9Event;
                    dr["AttachmentName"] = dlg.SafeFileName;
                    dr["Capturedate"] = DateTime.Now;
                    
                    dr["ImageTypeCode"] = new FileInfo(dlg.SafeFileName).Extension;
                    dr["ImageTypeText"] = new FileInfo(dlg.SafeFileName).Extension;
                        
                    dr["AttachmentFile"] = bData;

                    mDataSet.Tables["i9Attachment"].Rows.Add(dr);            
                }
            }
        }

        private void AttachmentOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mDataView != null)
                {
                    if (AttachmentListView.SelectedItem != null)
                    {
                        DataRowView drv = mDataView[mCollectionView.CurrentPosition];
                        byte[] bData = (byte[])drv["AttachmentFile"];
                        string FileName = drv["AttachmentName"].ToString();
                        string tempfolder = Environment.SpecialFolder.CommonApplicationData + @"\temp\";
                        string TempFilePath = tempfolder + FileName;

                        if (Directory.Exists(tempfolder))
                            Directory.CreateDirectory(tempfolder);

                        if (File.Exists(TempFilePath))
                            File.Delete(TempFilePath);

                        File.WriteAllBytes(TempFilePath, bData);

                        System.Diagnostics.Process.Start(TempFilePath); 
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error opening attachment:  ", ex);
                MessageBox.Show("Error opening attachment " + ex.Message);
            }
        }

        private void AttachmentRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mDataView != null)
                {
                    if (AttachmentListView.SelectedItem != null)
                    {
                        mDataView.Delete(mCollectionView.CurrentPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting attachment:  ", ex);
                MessageBox.Show("Error deleting attachment " + ex.Message);
            }
        }
    }
}
