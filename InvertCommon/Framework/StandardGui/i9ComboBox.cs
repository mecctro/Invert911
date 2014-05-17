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
using System.Windows.Automation.Peers;
using Invert911.InvertCommon.Framework.ClientData;
using System.ComponentModel;

namespace Invert911.InvertCommon.StandardGui
{
	public class i9ComboBox : ComboBox, IDisposable
    {
        static DependencyProperty i9BindTableProperty;
        static DependencyProperty i9BindColumnProperty;
        static DependencyProperty i9BindCodeSetNameProperty;
        //static DependencyProperty i9DrowndownTypeProperty;
        static DependencyProperty MaxLengthProperty;

        static i9ComboBox()
        {
            i9BindTableProperty = DependencyProperty.Register("BindTable", typeof(string), typeof(i9ComboBox));
            i9BindColumnProperty = DependencyProperty.Register("BindColumn", typeof(string), typeof(i9ComboBox));
            i9BindCodeSetNameProperty = DependencyProperty.Register("BindCodeSetName", typeof(string), typeof(i9ComboBox));
            MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(i9ComboBox));
            
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(psTextBox), new FrameworkPropertyMetadata(typeof(psTextBox)));
            //i9DrowndownTypeProperty = DependencyProperty.Register("DrowndownTypeProperty", typeof(string), typeof(i9ComboBox));
        }

        public i9ComboBox() : base()
        {
            this.IsEditable = true;
            //this.LostFocus += new RoutedEventHandler(i9ComboBox_LostFocus);
        }

        private int maxLength;
        public int MaxLength
        {

            get { return maxLength; }

            set { maxLength = value; }

        }

        void i9ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void i9DisposeOfResources()
        {
            this.LostFocus -= i9ComboBox_LostFocus;
        }

        public static void PopulateCombobox(i9ComboBox lComboBox, DataTable dt, string ColumnName)
        {
            lComboBox.Items.Clear();

            lComboBox.ItemsSource = ((IListSource)dt).GetList(); 

            //foreach (DataRow dr in dt.Rows)
            //{
            //    lComboBox.Items.Add(dr[ColumnName].ToString());
            //}
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

        public string i9BindCodeSetName
        {
            get { return (string)base.GetValue(i9BindCodeSetNameProperty); }
            set { base.SetValue(i9BindCodeSetNameProperty, value); }
        }

        //public string i9DrowndownType
        //{
        //    get { return (string)base.GetValue(i9DrowndownTypeProperty); }
        //    set { base.SetValue(i9DrowndownTypeProperty, value); }
        //}

        //public string i9BindColumn
        //{
        //    get { return (string)base.GetValue(i9BindColumnProperty); }
        //    set { base.SetValue(i9BindColumnProperty, value); }
        //}


        protected override void OnGotFocus(System.Windows.RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            ComboBoxAutomationPeer peer = new ComboBoxAutomationPeer(this);
            List<AutomationPeer> children = peer.GetChildren();

            if (children != null && children.Count == 1 && children[0] is TextBoxAutomationPeer)
            {
                ((TextBox)((TextBoxAutomationPeer)children[0]).Owner).MaxLength = maxLength;
            }
        }

        public void SetComboBoxEvents()
        {
            if ( String.IsNullOrEmpty(this.i9BindCodeSetName) == false)
            {
                this.DropDownOpened += i9ComboBox_DropDownOpened;
            }
        }

        public void Dispose()
        {
            //if(this.DropDownOpened != null)
            this.DropDownOpened -= i9ComboBox_DropDownOpened;
        }

        private void i9ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            i9ComboBox i9cb = (i9ComboBox)sender;

            if (!String.IsNullOrEmpty(i9cb.i9BindCodeSetName) && i9cb.Items.Count <= 0)
            {
                ClientDataAccess cda = new ClientDataAccess();
                DataTable dt = cda.GetDataTable("SELECT Code, CodeText FROM i9Code WHERE Enabled <> 0 AND CodeSetName = " + DataAccessUtilities.GetDBStr(i9cb.i9BindCodeSetName) + " Order By CodeText ", "i9Code");
                i9ComboBox.PopulateCombobox(i9cb, dt, "i9Code");
            }
        }

    }
}
