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
using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Utilities;

namespace Invert911.InvertCommon.Modules.Vehicle
{
    /// <summary>
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class Vehicle : UserControl
    {
        private DataSet mDataSet;
        private DataView mDataView;

        private Guid mi9VehicleID;
        private Guid mi9EventID;
        private Guid mi9AgencyID;

        private DataView VehicleRecoveryDV;
        private DataView VehicleRecoveryLocDV; 
        
        private DataView VehicleTowedDV;
        private DataView VehicleTowedLocDV;

        public Guid Locationi9VehicleID { set; get; }  

        public Vehicle()
        {
            InitializeComponent();
        }

        public void DataBind(DataSet lDataSet)
        {
            mDataSet = lDataSet;
            mDataView = lDataSet.Tables["i9Vehicle"].DefaultView;

            mi9EventID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
            mi9AgencyID = (Guid)mDataSet.Tables["i9Event"].Rows[0]["i9AgencyID"];

            this.DataContext = mDataView;
            
            MainVehicleDynControl.DataBind(mDataView, "Incident.Vehicle.General", "i9Vehicle");   
        }

        internal void SelectionChanged(Guid Selectedi9VehicleID)
        {
            mi9VehicleID = Selectedi9VehicleID;
            RefreshData();
        }

        private void RefreshData()
        {
            
            //==========================================================================================
            // Recovery Tab Databinding
            //==========================================================================================
            VehicleRecoveryDV = new DataView(mDataSet.Tables["i9VehicleRecovery"]);
            VehicleRecoveryDV.RowFilter = "i9VehicleID = '" + mi9VehicleID.ToString() + "'";
            RecoveryDynControl.DataBind(VehicleRecoveryDV, "Incident.Vehicle.Recovery", "i9VehicleRecovery");

            VehicleRecoveryLocDV = new DataView(mDataSet.Tables["i9Location"]);
            VehicleRecoveryLocDV.RowFilter = "i9ModuleSectionID = '" + i9ModuleSection.LawIncidentVehRecoveryLoc.ToString() + "' AND i9VehicleID = '" + mi9VehicleID + "'";
            RecoveryLocDynControl.DataBind(VehicleRecoveryLocDV, "Location", "i9Location");

            //==========================================================================================
            // Towed Tab Databinding
            //==========================================================================================
            VehicleTowedDV = new DataView(mDataSet.Tables["i9VehicleTowed"]);
            VehicleTowedDV.RowFilter = "i9VehicleID = '" + mi9VehicleID.ToString() + "'";
            TowedDynControl.DataBind(VehicleTowedDV, "Incident.Vehicle.Towed", "i9VehicleTowed");

            VehicleTowedLocDV = new DataView(mDataSet.Tables["i9Location"]);
            VehicleTowedLocDV.RowFilter = "i9ModuleSectionID = '" + i9ModuleSection.LawIncidentVehTowLoc.ToString() + "' AND i9VehicleID = '" + mi9VehicleID + "'";
            TowedLocDynControl.DataBind(VehicleTowedLocDV, "Location", "i9Location");

            RefreshButtons();
        }

        private void RefreshButtons()
        {
            if (VehicleRecoveryDV.Count > 0)
            {
                AddRecoveryButton.IsEnabled = false;
                RemoveRecoveryButton.IsEnabled = true;
                PrintRecoveryButton.IsEnabled = false;
                
                RecoveryDynControl.IsEnabled = true;
                RecoveryLocDynControl.IsEnabled = true;
            }
            else
            {
                AddRecoveryButton.IsEnabled = true;
                RemoveRecoveryButton.IsEnabled = false;
                PrintRecoveryButton.IsEnabled = false;
                
                RecoveryDynControl.IsEnabled = false;
                RecoveryLocDynControl.IsEnabled = false;
            }

            if (VehicleTowedDV.Count > 0)
            {
                AddTowedButton.IsEnabled = false;
                RemoveTowedButton.IsEnabled = true;
                PrintTowedButton.IsEnabled = false;

                TowedDynControl.IsEnabled = true;
                TowedLocDynControl.IsEnabled = true;
            }
            else
            {
                AddTowedButton.IsEnabled = true;
                RemoveTowedButton.IsEnabled = false;
                PrintTowedButton.IsEnabled = false;

                TowedDynControl.IsEnabled = false;
                TowedLocDynControl.IsEnabled = false;
            }
        }

        private void AddRecoveryButton_Click(object sender, RoutedEventArgs e)
        {
            //=====================================================================
            // Add Vehicle Recovery 
            //=====================================================================
            DataRow dr = mDataSet.Tables["i9VehicleRecovery"].NewRow();
            dr["i9VehicleRecoveryID"] = Guid.NewGuid();
            dr["i9VehicleID"] = mi9VehicleID;
            dr["i9EventID"] = mi9EventID;

            dr["Condition"] = "Found";
            mDataSet.Tables["i9VehicleRecovery"].Rows.Add(dr);

            //=====================================================================
            // Add Vehicle Recovery Location
            //=====================================================================
            DataRow LocDR = mDataSet.Tables["i9Location"].NewRow();
            LocDR["i9LocationID"] = Guid.NewGuid();
            LocDR["i9EventID"] = mi9EventID;
            LocDR["i9AgencyID"] = mi9AgencyID;
            LocDR["LocationMVI"] = 0;
            LocDR["i9VehicleID"] = mi9VehicleID; 
            LocDR["i9ModuleSectionID"] = i9ModuleSection.LawIncidentVehRecoveryLoc.ToString();

            mDataSet.Tables["i9Location"].Rows.Add(LocDR);

            RefreshData();
            RefreshButtons();
        }

        private void RemoveRecoveryButton_Click(object sender, RoutedEventArgs e)
        {
            if (mi9VehicleID == Guid.Empty)
                return;
            try
            {
                //=========================================================================================
                // Remove the Vehicle Recovery 
                //=========================================================================================
                if (VehicleRecoveryDV != null)
                {
                    List<DataRowView> DeleteRows = new List<DataRowView>();
                    foreach (DataRowView drv in VehicleRecoveryDV)
                    {
                        if (mi9VehicleID == (Guid)drv["i9VehicleID"])
                        {
                            DeleteRows.Add(drv);
                        }
                    }

                    foreach (DataRowView drv in DeleteRows)
                    {
                        drv.Delete();
                        //mDataSet.Tables["i9VehicleRecovery"].Rows.Remove(drv.Row);
                    }
                }


                //=========================================================================================
                // Remove the Vehicle Recovery Location
                //=========================================================================================
                if (VehicleRecoveryLocDV != null)
                {
                    List<DataRowView> LocDeleteRows = new List<DataRowView>();
                    foreach (DataRowView drv in VehicleRecoveryLocDV)
                    {
                        if (mi9VehicleID == (Guid)drv["i9VehicleID"])
                        {
                            if (drv["i9ModuleSectionID"].ToString() == i9ModuleSection.LawIncidentVehRecoveryLoc.ToString())
                            {
                                LocDeleteRows.Add(drv);
                            }
                        }
                    }

                    foreach (DataRowView drv in LocDeleteRows)
                    {
                        drv.Delete();
                        //mDataSet.Tables["i9VehicleRecovery"].Rows.Remove(drv.Row);
                    }
                }

            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting vehicle recovery:  ", ex);
                MessageBox.Show("Error deleting vehicle recovery " + ex.Message);
            }

            RefreshButtons();
        }

        private void PrintRecoveryButton_Click(object sender, RoutedEventArgs e)
        {
            //Disabled for now
        }

        private void PrintTowedButton_Click(object sender, RoutedEventArgs e)
        {
            //Disabled for now
        }

        private void RemoveTowedButton_Click(object sender, RoutedEventArgs e)
        {
            if (mi9VehicleID == Guid.Empty)
                return;
            try
            {
                //=========================================================================================
                // Remove the Vehicle Towed
                //=========================================================================================
                if (VehicleTowedDV != null)
                {
                    List<DataRowView> DeleteRows = new List<DataRowView>();
                    foreach (DataRowView drv in VehicleTowedDV)
                    {
                        if (mi9VehicleID == (Guid)drv["i9VehicleID"])
                        {
                            DeleteRows.Add(drv);
                        }
                    }

                    foreach (DataRowView drv in DeleteRows)
                    {
                        drv.Delete();
                        //mDataSet.Tables["i9VehicleTowed"].Rows.Remove(drv.Row);
                    }
                }


                //=========================================================================================
                // Remove the Vehicle Towed Location
                //=========================================================================================
                if (VehicleTowedLocDV != null)
                {
                    List<DataRowView> LocDeleteRows = new List<DataRowView>();
                    foreach (DataRowView drv in VehicleTowedLocDV)
                    {
                        if (mi9VehicleID == (Guid)drv["i9VehicleID"])
                        {
                            if (drv["i9ModuleSectionID"].ToString() == i9ModuleSection.LawIncidentVehTowLoc.ToString())
                            {
                                LocDeleteRows.Add(drv);
                            }
                        }
                    }

                    foreach (DataRowView drv in LocDeleteRows)
                    {
                        drv.Delete();
                        //mDataSet.Tables["i9VehicleTowed"].Rows.Remove(drv.Row);
                    }
                }

            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error deleting vehicle towed:  ", ex);
                MessageBox.Show("Error deleting vehicle towed " + ex.Message);
            }

            RefreshButtons();
        }

        private void AddTowedButton_Click(object sender, RoutedEventArgs e)
        {
            //=====================================================================
            // Add Vehicle Towed
            //=====================================================================
            DataRow dr = mDataSet.Tables["i9VehicleTowed"].NewRow();
            dr["i9VehicleTowedID"] = Guid.NewGuid();
            dr["i9VehicleID"] = mi9VehicleID;
            dr["i9EventID"] = mi9EventID;

            //dr["Condition"] = "Found";
            mDataSet.Tables["i9VehicleTowed"].Rows.Add(dr);

            //=====================================================================
            // Add Vehicle Recovery Location
            //=====================================================================
            DataRow LocDR = mDataSet.Tables["i9Location"].NewRow();
            LocDR["i9LocationID"] = Guid.NewGuid();
            LocDR["i9EventID"] = mi9EventID;
            LocDR["i9AgencyID"] = mi9AgencyID;
            LocDR["LocationMVI"] = 0;

            LocDR["i9VehicleID"] = mi9VehicleID;
            LocDR["i9ModuleSectionID"] = i9ModuleSection.LawIncidentVehTowLoc.ToString();

            mDataSet.Tables["i9Location"].Rows.Add(LocDR);

            RefreshData();
            RefreshButtons();
        }
    }
}
