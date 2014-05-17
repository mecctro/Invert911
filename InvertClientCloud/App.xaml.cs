using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Invert911.InvertCommon;

namespace Invert911.InvertClientCloud
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        /// <summary>
        /// Called when the application starts.
        /// </summary>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Invert911.InvertCommon.Utilities.ConfigurationManager.Instance.WebServiceURL = @"http://www.Invert911.com/";

            MainWindow mainWindow = new MainWindow(InvertCommon.Framework.i9ApplicationType.i9CloudClient);
            mainWindow.WindowState = WindowState.Maximized;
            mainWindow.Show();
        }

    }
}
