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

namespace Invert911.InvertCommon.StandardGui
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
	///     xmlns:MyNamespace="clr-namespace:LawRecords.Framework.StandardGui"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
	///     xmlns:MyNamespace="clr-namespace:LawRecords.Framework.StandardGui;assembly=LawRecords"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
	public class i9TextBox : System.Windows.Controls.TextBox
    {
        static i9TextBox()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(psTextBox), new FrameworkPropertyMetadata(typeof(psTextBox)));

            i9BindTableProperty = DependencyProperty.Register("BindTable", typeof(string), typeof(i9TextBox));
            i9BindColumnProperty = DependencyProperty.Register("BindColumn", typeof(string), typeof(i9TextBox));
        }

        public i9TextBox()
            : base()
        {
            this.Height = 23;
            //this.LostFocus += new RoutedEventHandler(i9ComboBox_LostFocus);
        }

        
        static DependencyProperty i9BindTableProperty;
        static DependencyProperty i9BindColumnProperty;

        public string i9BindTable
        {
            get { return (string)base.GetValue(i9BindTableProperty); }
            set { base.SetValue(i9BindColumnProperty, value); }
        }

        public string i9BindColumn
        {
            get { return (string)base.GetValue(i9BindColumnProperty); }
            set { base.SetValue(i9BindColumnProperty, value); }
        }
    }
}
