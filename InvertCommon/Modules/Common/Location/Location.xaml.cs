using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

using Invert911.InvertCommon.Framework;


namespace Invert911.InvertCommon.Modules.Location
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : UserControl
    {
        private DataView mDataView;
        
        //private string mTableName = "i9Location";
        //private ICollectionView mCollectionView;

        public Location()
        {
            InitializeComponent();
        }

        public void DataBind(DataView lDataView)
        {
            this.mDataView = lDataView;

            this.DataContext = mDataView;
            //this.mCollectionView = CollectionViewSource.GetDefaultView(mDataView);
        }

    }
}
