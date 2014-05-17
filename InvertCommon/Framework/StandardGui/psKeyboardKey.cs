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
    public class psKeyboardKey : Label
    {
        static psKeyboardKey()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(psTextBox), new FrameworkPropertyMetadata(typeof(psTextBox)));

            i9BindTableProperty = DependencyProperty.Register("BindTable", typeof(string), typeof(psKeyboardKey));
            i9BindColumnProperty = DependencyProperty.Register("BindColumn", typeof(string), typeof(psKeyboardKey));
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
