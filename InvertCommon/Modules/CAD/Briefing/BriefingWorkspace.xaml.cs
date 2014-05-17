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
using System.IO;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;

using Invert911.InvertCommon.Modules;

namespace Invert911.Briefing
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class BriefingWorkspace : Page, IMDTModule
	{
		private string m_ModuleName = "BriefingWorkspace";

        //FileStream stream;

		public BriefingWorkspace()
		{
			InitializeComponent();
		}

		//ILawRecordsModule Interface
		public string ModuleName
		{
			get { return m_ModuleName; }
		}

		private void Window_Initialized(object sender, EventArgs e)
		{
            //AnnotationService service = AnnotationService.GetService(flowDoc);
            //if (service == null)
            //{
            //    stream = new FileStream("annotstorage.xml", FileMode.OpenOrCreate);
            //    service = new AnnotationService(flowDoc);
            //    AnnotationStore store = new XmlStreamStore(stream);
            //    store.AutoFlush = true;
            //    service.Enable(store);
            //}
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e)
		{
			try
			{
                //AnnotationService service = AnnotationService.GetService(flowDoc);
                //if (service != null && service.IsEnabled)
                //{
                //    service.Disable();
                //    stream.Close();
                //}
			}
			catch { }
		}
	}
}
