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
    public partial class SystemLogPage : Page
    {
        public DataSet mi9SysLogDS = new DataSet();
        private DataView mi9SysLogDS_DV;

        public SystemLogPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(SystemLogPage_Loaded);   
        }

        void SystemLogPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (SystemLogListView.Items.Count > 0)
                return;

            i9Message ReturnMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.Log_GetTop100, "SystemLogPage");
            if (ReturnMsg.ErrorStatus.IsError)
            {
                LogManager.Instance.LogMessage("SystemLogPage", "LoadData", "Error:  " + ReturnMsg.ErrorStatus.ErrorMsg);
            }
            else
            {
                this.mi9SysLogDS = ReturnMsg.MsgBodyDataSet;

                this.mi9SysLogDS_DV = new DataView();
                this.mi9SysLogDS_DV.Table = this.mi9SysLogDS.Tables["i9SysLog"];
                MainDockPanel.DataContext = this.mi9SysLogDS_DV;

            }
        }

         private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
