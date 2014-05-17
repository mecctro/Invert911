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
using System.ComponentModel;

namespace Invert911.InvertCommon.Modules
{
    /// <summary>
    /// Interaction logic for Linkage.xaml
    /// </summary>
    public partial class Linkage : UserControl
    {
        private DataSet mDataSet;

        public Linkage()
        {
            InitializeComponent();
        }

        public void DataBind(DataSet lDataSet)
        {
            this.mDataSet = lDataSet;
            RefreshDisplay();
        }

        private void RefreshDisplay()
        {
            MainTreeView.Items.Clear();

            //Person
            foreach( DataRow PersonRow in this.mDataSet.Tables["i9Person"].Rows)
            {
                MainTreeView.Items.Add(PersonRow["FirstName"].ToString() + " " + PersonRow["LastName"].ToString() + " " + PersonRow["MiddleName"].ToString());
            }

            //Vehicle
            foreach (DataRow PersonRow in this.mDataSet.Tables["i9Vehicle"].Rows)
            {
                MainTreeView.Items.Add(PersonRow["MakeCode"].ToString() + " " + PersonRow["ModelCode"].ToString() + " " + PersonRow["ModelYear"].ToString());
            }

            //Property
            foreach (DataRow PersonRow in this.mDataSet.Tables["i9Property"].Rows)
            {
                MainTreeView.Items.Add(PersonRow["PropertyDescription"].ToString());
            }

            //Locations
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
