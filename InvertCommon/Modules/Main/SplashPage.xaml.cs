using System;
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
using System.Windows.Threading;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Invert911.InvertCommon.Modules;
using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Framework.ClientData;
using Invert911.InvertCommon.Utilities;

namespace Invert911.MDT
{
    /// <summary>
    /// Interaction logic for SplashPage.xaml
    /// </summary>
    public partial class SplashPage : Page
    {
        private BackgroundWorker mBackgroundWorker;
        private bool mSuccessfullLoad = false;
        private bool mIsPageLoaded = false;

        public SplashPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SplashPage_Loaded);
        }

        void SplashPage_Loaded(object sender, RoutedEventArgs e)
        {
            if(mBackgroundWorker == null)
                mBackgroundWorker = new BackgroundWorker();

            if (this.mIsPageLoaded == false && mBackgroundWorker.IsBusy == false)
            {
                mBackgroundWorker.DoWork += new DoWorkEventHandler(mBackgroundWorker_DoWork);
                mBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mBackgroundWorker_RunWorkerCompleted);
                mBackgroundWorker.RunWorkerAsync();
            }
        }

        void mBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.mSuccessfullLoad)
            {
                ModuleManager.Instance.NavigateTo(this, "MainMenuPage");
            }
            else
            {
                SetStatus("Error loading the application.  Please re-start the application.");
            }
            mIsPageLoaded = true;
        }

        void mBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetLatestFromServer();
        }

        private void GetLatestFromServer()
        {
            this.mSuccessfullLoad = false;

            
            //Sync Client Database
            SetStatus("Initializing local data");
            SyncSQLite ClientDS = new SyncSQLite();
            ClientDS.UpdateEvent +=new SyncSQLite.UpdateEventHandler(cds_UpdateEvent);

            if (ConfigurationManager.Instance.SyncClientDatabase)
            {
                if (ClientDS.SyncClientDatabase() == false)
                {
                    SetStatus("Sync download had problems initializing");
                    return;
                }
                ModuleManager.Instance.SetAccessToModules();
            }

            SetStatus("Loading Modules");

            //Load Module based off security rights
            if (ModuleManager.Instance.Init() == false)
            {
                SetStatus("Module manager had a problem initializing");
                return;
            }

            this.mSuccessfullLoad = true;
        }

        private void SetStatus(string Message)
        {
            //Check for cross threading
            if (StatusTextBox.Dispatcher.CheckAccess() == false)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action<string>)SetStatus, Message);
                return;
            }

            StatusTextBox.AppendText(Environment.NewLine +  Message);
            StatusTextBox.ScrollToEnd(); 
        }

        private void cds_UpdateEvent(string Status)
        {
            SetStatus(Status);
        }
    }
}
