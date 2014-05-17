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
using System.Collections.Generic;

namespace Invert911.InvertCommon.StandardGui
{
    public class i9DatePicker : DatePicker
    {
        static DependencyProperty i9BindTableProperty;
        static DependencyProperty i9BindColumnProperty;
        
        static i9DatePicker()
        {
            i9BindTableProperty = DependencyProperty.Register("BindTable", typeof(string), typeof(i9Label));
            i9BindColumnProperty = DependencyProperty.Register("BindColumn", typeof(string), typeof(i9Label));
        }

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
