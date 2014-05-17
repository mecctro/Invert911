using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Windows.Navigation;

using Invert911.InvertCommon;
using Invert911.InvertCommon.Modules.Law.PolicePad;

namespace Invert911
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        /// <summary>
        /// Called when the application starts.
        /// </summary>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string StartVersionType = "STANDALONE";
            if (e.Args.Length > 0)
            {
                StartVersionType = e.Args[0].ToString().Trim().ToUpper();
            }

            MainWindow mainWindow = null;
            switch (StartVersionType)
            {
                case "LITE":
                    PolicePadWindow IncidentLiteWindow = new PolicePadWindow();
                    IncidentLiteWindow.Show();
                    break;

                case "CLOUD":
                    Invert911.InvertCommon.Utilities.ConfigurationManager.Instance.WebServiceURL = @"http://www.Invert911.com/";

                    mainWindow = new MainWindow(InvertCommon.Framework.i9ApplicationType.i9CloudClient);
                    mainWindow.WindowState = WindowState.Maximized;
                    mainWindow.Show();
                    break;

                default:  //Full Version App
                    mainWindow = new MainWindow(InvertCommon.Framework.i9ApplicationType.i9FullClient);
                    mainWindow.WindowState = WindowState.Maximized;
                    mainWindow.Show();
                    break;
            }

        }
    }
}