using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;


using Invert911.InvertCommon;
using Invert911.InvertCommon.Modules.Law.PolicePad;

namespace Invert911.PolicePad
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
            // Create main application window, starting minimized if specified
            PolicePadWindow IncidentLiteWindow = new PolicePadWindow();
            IncidentLiteWindow.Show();
        }

    }
}
