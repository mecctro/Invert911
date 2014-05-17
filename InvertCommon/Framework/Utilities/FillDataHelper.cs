using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Invert911.InvertCommon.StandardGui;
using System.Data;
using System.Windows.Controls;

namespace Invert911.InvertCommon.Framework.Utilities
{
    public class FillDataHelper
    {
        public static void AgencyFillComboBox(i9ComboBox AgencyComboBox, DataTable i9AgencyDataTabe)
        {
            if (AgencyComboBox.Items.Count <= 0)
            {
                AgencyComboBox.Items.Clear();
                foreach (DataRow dr in i9AgencyDataTabe.Rows)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = dr["AgencyName"].ToString();
                    cbi.Tag = dr["i9AgencyID"].ToString();
                    int i = AgencyComboBox.Items.Add(cbi);
                }
            }

            if (AgencyComboBox.Items.Count > 0)
            {
                if (AgencyComboBox.SelectedItem == null)
                {
                    AgencyComboBox.IsEnabled = false;
                    AgencyComboBox.SelectedIndex = 0;
                    AgencyComboBox.IsEnabled = true;
                }

                ComboBoxItem SelectCbi = (ComboBoxItem)AgencyComboBox.SelectedItem;
                //string i9AgencyID = SelectCbi.Tag.ToString();
            }
        }
    }
}
