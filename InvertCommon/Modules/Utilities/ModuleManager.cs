using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting;
using System.Reflection;

using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Utilities;
using Invert911.InvertCommon.StandardGui;
using System.Data.SQLite;
using Invert911.InvertCommon.Framework.ClientData;
using System.Data;
using Invert911.MDT;


namespace Invert911.InvertCommon.Modules
{
    
    public class ModuleManager //: Dictionary<string, ModuleItem>
    {
        public ModuleItem[] Modules;
        private static ModuleManager m_ModuleManager;
        private static object m_PadLock = new object();
        private static Page m_SplashScreen = null;
        private static Page m_MobileTerminalPage = null; 
        

        private ModuleManager()
        {
            LoadModuleList();
            SetDemoModules();
        }



        public static ModuleManager Instance
        {
            get
            {
                lock (m_PadLock)
                {
                    if (m_ModuleManager == null)
                        m_ModuleManager = new ModuleManager();
                }

                return m_ModuleManager;
            }
        }

        public bool Init()
        {
            return true;
        }
        
        public Page GetModulePage(string ModuleKey)
        {

            Page PageModule = (Page)this.GetModuleItem(ModuleKey).Instance;
            if (PageModule == null)
            {
                try
                {
                    ObjectHandle handle = Activator.CreateInstanceFrom(Assembly.GetExecutingAssembly().Location, this.GetModuleItem(ModuleKey).ClassName);
                    PageModule = (Page)handle.Unwrap();
                    this.GetModuleItem(ModuleKey).Instance = PageModule;
                }
                catch (Exception ex)
                {
                    //If error that means the page is under construction.
                    LogManager.Instance.LogMessage("Unable to load page: " + ModuleKey, ex);
                    
                    PageModule = new Page();
                    i9Label l = new i9Label();
                    l.Content = ModuleKey + " Coming Soon";
                    l.FontSize = 18;
                    l.HorizontalContentAlignment = HorizontalAlignment.Center;
                    l.VerticalAlignment = VerticalAlignment.Center;
                    PageModule.Content = l;

                    this.GetModuleItem(ModuleKey).Instance = PageModule;
                }
            }

            return PageModule;
        }

        public Window GetModuleWindows(string ModuleName)
        {
            Window ModuleWindow = (Window)this.GetModuleItem(ModuleName).Instance;
            if (ModuleWindow == null)
            {
                ObjectHandle handle2 = Activator.CreateInstanceFrom(Assembly.GetExecutingAssembly().Location, this.GetModuleItem(ModuleName).ClassName);
                ModuleWindow = (Window)handle2.Unwrap();
                ModuleWindow.Title = this.GetModuleItem(ModuleName).ModuleName;

                this.GetModuleItem(ModuleName).Instance = ModuleWindow;
            }
            return ModuleWindow;
        }

        public System.Windows.Forms.Form GetModuleForm(string modItem)
        {
            System.Windows.Forms.Form FormModule = (System.Windows.Forms.Form)this.GetModuleItem(modItem).Instance;
            if (FormModule == null)
            {
                ObjectHandle handle2 = Activator.CreateInstanceFrom(Assembly.GetExecutingAssembly().Location, this.GetModuleItem(modItem).ClassName);
                FormModule = (System.Windows.Forms.Form)handle2.Unwrap();
                FormModule.Text = this.GetModuleItem(modItem).ModuleName;

                this.GetModuleItem(modItem).Instance = FormModule;
            }
            return FormModule;
        }

        /// <summary>
        /// Navigate from one WPF page to another WPF page
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="ModuleName"></param>
        public void NavigateTo(Page CurrentPage, string ModuleName)
        {
            Page p = null;

            switch (ModuleName)
            {
                case "SplashPage":
                    if (m_SplashScreen == null)
                        m_SplashScreen = new SplashPage(); 

                    p = m_SplashScreen;

                    break;
                case "MobileTerminalPage":
                    if (m_MobileTerminalPage == null)
                        m_MobileTerminalPage = new SplashPage();

                    p = m_MobileTerminalPage;
 
                    break;
                default:
                    //if (ModuleManager.Instance.ContainsKey("MainPage"))
                    ModuleItem mi = this.GetModuleItem(ModuleName);
                    p = this.GetModulePage(mi.ModuleKey);
                    
                    break;
            }

            NavigationService.GetNavigationService(CurrentPage).Navigate(p);

        }

        public void NavigateTo(Page CurrentPage, i9Modules ModuleName)
        {
            //if (ModuleManager.Instance.ContainsKey("MainPage"))
            ModuleItem mi = this.GetModuleItem(ModuleName.ToString());
            Page p = this.GetModulePage(mi.ModuleKey);
            NavigationService.GetNavigationService(CurrentPage).Navigate(p);
        }

        public ModuleItem GetModuleItem(string ModuleName)
        {
            ModuleItem ReponseItem = null;
            for (int i = 0; i < this.Modules.Length - 1; i++)
            {
                ModuleItem mi = (ModuleItem)this.Modules[i];
                if (mi.ModuleKey == ModuleName)
                {
                    ReponseItem = mi;
                    break;
                }
            }
            return ReponseItem;
        }

        /// <summary>
        /// Set access to modules based of the login user.
        /// </summary>
        public void SetAccessToModules()
        {

            //List<ModuleItem> lModules = new List<ModuleItem>();

            ////MDTModules.Add(new ModuleItem("Invert911.MainWorkspace", "Main", "General", true, true));
            //lModules.Clear();

            //string sql = "SELECT * FROM i9Module";
            //ClientDataAccess da = new ClientDataAccess();
            
            //DataTable dt = da.GetDataTable(sql, "i9Module");
            
            ////=========================================================
            ////Testing 
            ////=========================================================
            ////DataSet ds = new DataSet();
            ////ds.Tables.Add(dt);
            ////ds.AcceptChanges();
            //// ds.WriteXml(@"c:\Temp\i9Modules.xml");


            //foreach (DataRow dr in dt.Rows)
            //{
            //    ModuleItem mi = new ModuleItem();
            //    mi.ClassName = dr["ClassName"].ToString();
            //    mi.ModuleName = dr["ModuleName"].ToString();
            //    mi.Section = dr["Section"].ToString();
            //    mi.PopupPage = dr["PopupPage"].ToString() == "0" ? false : true;
            //    mi.DesktopEnabled = dr["DesktopEnabled"].ToString() == "0" ? false : true;
            //    mi.MobileEnabled = dr["MobileEnabled"].ToString() == "0" ? false : true;
            //    mi.FileName = dr["FileName"].ToString();
            //    mi.i9ModuleID = dr["i9ModuleID"].ToString();

            //    mi.ModuleKey = dr["ModuleKey"].ToString();
            //    //mi.LastUpdate = dr["LastUpdate"].ToString();

            //    switch(dr["ModuleType"].ToString().ToUpper().Trim())
            //    {
            //        case "PAGE":
            //            mi.ModuleType = ModuleTypeEnum.Page;
            //            break;
            //        case "WINDOW":
            //            mi.ModuleType = ModuleTypeEnum.Window;
            //            break;
            //        case "FORM":
            //            mi.ModuleType = ModuleTypeEnum.Form;
            //            break;
            //        default:
            //            mi.ModuleType = ModuleTypeEnum.None;
            //            break;
            //    }
                
                

            //    lModules.Add(mi);
            //}

            //this.Modules = lModules.ToArray();
            
        }

        /// <summary>
        /// Create a list of modules the are currently supported
        /// </summary>
        private void LoadModuleList()
        {
            //TODO: Need to implement security.  Look in the local database for modules to load.

            List<ModuleItem> lModules = new List<ModuleItem>();
            string FileName = "Invert911.InvertCommon.dll";

            //MDTModules.Add(new ModuleItem("Invert911.MainWorkspace", "Main", "General", true, true));
            lModules.Clear();
            
            //Login and Shell Screens:
            lModules.Add(new ModuleItem(i9Modules.LoginPage.ToString(), ModuleTypeEnum.Page, "Invert911.MDT.LoginPage", "Login", "General", false, false, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.MainPage.ToString(), ModuleTypeEnum.Page, "Invert911.MDT.MainPage", "Main", "General", false, false, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.MainMenuPage.ToString(), ModuleTypeEnum.Page, "Invert911.MDT.MainMenuPage", "Main Menu", "General", false, false, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.SplashPage.ToString(), ModuleTypeEnum.Page, "Invert911.MDT.SplashPage", "Splash Screen", "General", false, false, false, FileName));

            //Law:
            lModules.Add(new ModuleItem(i9Modules.Incident.ToString(), ModuleTypeEnum.Page, "Invert911.Incident.IncidentWorkspace", "Incident", "Police", false, true, true, FileName));
            lModules.Add(new ModuleItem(i9Modules.CaseManagement.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Law.CaseManagement.CaseManagementPage", "Case Management", "Police", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Citation.ToString(), ModuleTypeEnum.Page, "Invert911.Citation.CitationWorkspace", "Citation", "Police", false, true, true, FileName));
            lModules.Add(new ModuleItem(i9Modules.FieldContact.ToString(), ModuleTypeEnum.Page, "Invert911.FieldContact.FieldContactWorkspace", "Field Contact", "Police", false, true, true, FileName));
            lModules.Add(new ModuleItem(i9Modules.BeatBook.ToString(), ModuleTypeEnum.Page, "Invert911.Law.BeatBook.BeatBookPage", "Beat Book", "Police", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Warrant.ToString(), ModuleTypeEnum.Page, "Invert911.Warrant.WarrantWorkspace", "Warrant", "Police", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Gang.ToString(), ModuleTypeEnum.Page, "Invert911.Gang.GangWorkspace", "Gang", "Police", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.PropertyRoom.ToString(), ModuleTypeEnum.Page, "Invert911.Law.PropertyRoom.PropertyRoomWorkspace", "Property Room", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.PhotoLineUp.ToString(), ModuleTypeEnum.Page, "Invert911.Law.PhotoLineUp.PhotoLineUpWorkspace", "Photo Line Up", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Impound.ToString(), ModuleTypeEnum.Page, "Invert911.Law.Impound.ImpoundPage", "Impound", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.UCR.ToString(), ModuleTypeEnum.Page, "Invert911.Law.UCR.UCRPage", "UCR", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.NIBRS.ToString(), ModuleTypeEnum.Page, "Invert911.Law.NIBRS.NIBRSPage", "NIBRS", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.PawnTickets.ToString(), ModuleTypeEnum.Page, "Invert911.Law.PawnTickets.PawnTicketsPage", "Pawn Tickets", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.CrimeWatch.ToString(), ModuleTypeEnum.Page, "Invert911.Law.CrimeWatch.CrimeWatchPage", "Crime Watch", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.BicycleRegistration.ToString(), ModuleTypeEnum.Page, "Invert911.BicycleRegistration.BicycleRegistrationPage", "Bicycle Registration", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.PetRegistration.ToString(), ModuleTypeEnum.Page, "Invert911.Law.PetRegistration.PetRegistrationPage", "Pet Registration", "Police", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.SexOffender.ToString(), ModuleTypeEnum.Page, "Invert911.Law.SexOffender.SexOffenderPage", "Sex Offender", "Police", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.RestrainingOrder.ToString(), ModuleTypeEnum.Page, "Invert911.Law.RestrainingOrder.RestrainingOrderPage", "Restraining Order", "Police", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.FalseAlarm.ToString(), ModuleTypeEnum.Page, "Invert911.Law.FalseAlarm.FalseAlarmPage", "False Alarm", "Police", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.ApplicantSystem.ToString(), ModuleTypeEnum.Page, "Invert911.Law.ApplicantSystem.ApplicantSystemPage", "Applicant System", "Police", false, true, false, FileName));

            //Mobile Terminal / Mobile CAD / MDT:
            lModules.Add(new ModuleItem(i9Modules.MobileTerminalPage.ToString(), ModuleTypeEnum.Window, "Invert911.CAD.MobileTerminalPage", "Mobile Terminal", "MDT", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.MobileDispatch.ToString(), ModuleTypeEnum.Page, "Invert911.CAD.MobileDispatch", "Dispatch", "MDT", false, true, true, FileName));
            lModules.Add(new ModuleItem(i9Modules.Messages.ToString(), ModuleTypeEnum.Page, "Invert911.CAD.Messages", "Messages", "MDT", false, true, true, FileName));
            lModules.Add(new ModuleItem(i9Modules.Video.ToString(), ModuleTypeEnum.Page, "Invert911.General.VideoMenu", "Video", "MDT", false, true, true, FileName));
            lModules.Add(new ModuleItem(i9Modules.EventEntry.ToString(), ModuleTypeEnum.Page, "Invert911.CAD.EventEntryPage", "Event Entry", "MDT", false, true, true, FileName));

            //Administion
            lModules.Add(new ModuleItem(i9Modules.Briefing.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.BriefingWorkspace", "Briefing", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.CodesAdmin.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Admin.CodeAdminPage", "Codes Admin", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.DynamicEntry.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Admin.DynamicEntryAdminPage", "Dynamic Entry", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Systemlog.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Admin.SystemLogPage", "System Log", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Agency.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Admin.AgencyPage", "Agency", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.PersonnelGroups.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Admin.PersonnelGroupsPage", "Personnel Groups", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Security.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.SecurityPage", "Security", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Personnel.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Admin.PersonnelPage", "Personnel", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Confidentiality.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Admin.ConfidentialityPage", "Confidentiality", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.SystemConfigurations.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.SystemConfigurationsPage", "System Configurations", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Schedule.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.SchedulePage", "Schedule", "Administration", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.DepartmentEquipment.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.DepartmentEquipmentProperty.DepartmentEquipmentPropertyPage", "Department Equipment", "Administration", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.FleetManagementProperty.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.FleetManagement.FleetManagementPage", "Fleet Management", "Administration", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.SupplyControlInventory.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.SupplyControlInventory.SupplyControlInventoryPage", "Supply Control Inventory", "Administration", false, false, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.DataSharing.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.DataSharing.DataSharingPage", "DataSharing", "Administration", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.MasterLocationIndex.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.MasterLocationIndex.MasterLocationIndexPage", "Master Location Index", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.MasterNameIndex.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.MasterNameIndex.MasterNameIndexPage", "Master Name Index", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.MasterVehicleIndex.ToString(), ModuleTypeEnum.Page, "Invert911.Admin.MasterVehicleIndex.MasterVehicleIndexPage", "Master Vehicle Index", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.InterfaceSetting.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Admin.InterfaceSettingsPage", "Interface Settings", "Administration", false, FileName));
            lModules.Add(new ModuleItem(i9Modules.AdHocReport.ToString(), ModuleTypeEnum.Page, "Invert911.InvertCommon.Modules.Utilities.AdHocReportPage", "AdHoc Report", "Administration", false, FileName));

            
            //lModules.Add(new ModuleItem(i911Modules.AdHocReport.ToString(), ModuleTypeEnum.Page, "Ad-Hoc Reports", "Ad-Hoc Reports", "Utilites", false, true, false, FileName));

            //Corrections:
            lModules.Add(new ModuleItem(i9Modules.Booking.ToString(), ModuleTypeEnum.Page, "Invert911.Booking.BookingWorkspace", "Booking", "Corrections", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Arrest.ToString(), ModuleTypeEnum.Page, "Invert911.Arrest.ArrestWorkspace", "Arrest", "Corrections", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Release.ToString(), ModuleTypeEnum.Page, "Invert911.Release.ReleaseWorkspace", "Release", "Corrections", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.HousingAssignment.ToString(), ModuleTypeEnum.Page, "Invert911.HousingAssignment.HousingAssignmentWorkspace", "Housing Assignment", "Corrections", false, false, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.Meals.ToString(), ModuleTypeEnum.Page, "Invert911.Meals.MealsWorkspace", "Meals", "Corrections", false, true, false, FileName));

            //CAD:
            lModules.Add(new ModuleItem(i9Modules.DispatchWindow.ToString(), ModuleTypeEnum.Window, "Invert911.CAD.DispatchWindow", "Dispatch Window", "CAD", true, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.MessageSwitch.ToString(), ModuleTypeEnum.Page, "Invert911.CAD.MessageSwitchPage", "Message Switch", "CAD", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.AlarmPermits.ToString(), ModuleTypeEnum.Page, "Invert911.CAD.AlarmPermitsPage", "Alarm Permits", "CAD", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.BOLO.ToString(), ModuleTypeEnum.Page, "Invert911.BOLO.BOLOWorkspace", "BOLO", "CAD", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.CallSheet.ToString(), ModuleTypeEnum.Page, "Invert911.CallSheet.CallSheetWorkspace", "CallSheet", "CAD", false, true, false, FileName));
            lModules.Add(new ModuleItem(i9Modules.AVL.ToString(), ModuleTypeEnum.Page, "Invert911.CAD.AVLPage", "AVL", "CAD", false, true, true, FileName));

            //Utilites
            lModules.Add(new ModuleItem(i9Modules.Clipboard.ToString(), ModuleTypeEnum.None, "Clipboard", "Clipboard", "Utilites", false, false, true, FileName));
            lModules.Add(new ModuleItem(i9Modules.Keyboard.ToString(), ModuleTypeEnum.None, "Keyboard", "Keyboard", "Utilites", false, false, true, FileName));
            lModules.Add(new ModuleItem(i9Modules.Exit.ToString(), ModuleTypeEnum.None, "Exit", "Exit", "Utilites", false, true, true, FileName));
                        
            //Fire:
            //lModules.Add(new ModuleItem(i911Modules.FireIncident.ToString(), ModuleTypeEnum.Page, "Invert911.FireIncident.FireIncidentWorkspace", "Fire Incident", "Fire Dept", false, FileName));
            //lModules.Add(new ModuleItem(i911Modules.FireInspection.ToString(), ModuleTypeEnum.Page, "Invert911.FireInspection.FireInspectionWorkspace", "Fire Inspection", "Fire Dept", false, FileName));
            //lModules.Add(new ModuleItem(i911Modules.HazMat.ToString(), ModuleTypeEnum.Page, "Invert911.HazMat.HazMatWorkspace", "HazMat", "Fire Dept", false, FileName));
            //lModules.Add(new ModuleItem(i911Modules.Arson.ToString(), ModuleTypeEnum.Page, "Invert911.Arson.ArsonWorkspace", "Arson", "Fire Dept", false, FileName));

            //EMS:
            //lModules.Add(new ModuleItem(i911Modules.EMSIncident.ToString(), ModuleTypeEnum.Page, "Invert911.EMSIncident.EMSIncidentWorkspace", "EMS Incident", "EMS", false, FileName));
            //lModules.Add(new ModuleItem(i911Modules.EMSEquipment.ToString(), ModuleTypeEnum.Page, "Invert911.EMSEquipment.EMSEquipmentWorkspace", "EMS Equipment", "EMS", false, FileName));

            //*************************************************************
            //THINGS TO ADD LATER:
            //*************************************************************
            //Wrecker rotation
            //Contact rolodex managed by groups
            //Integrated local, state, and NCIC
            //VideoOverview
            //Intelligence
            //Training System
            //Traffic Collision or Accident
            //Service Requests
            //Special Intelligence
            //liquor license
            //firearm license etc


            this.Modules = lModules.ToArray();
        }

        /// <summary>
        /// Indicate what Invert911 Modules will show up for demo users.
        /// This method will change in the future
        /// </summary>
        private void SetDemoModules()
        {
            GetModuleItem(i9Modules.LoginPage.ToString()).IsDemoModule = true;
            GetModuleItem(i9Modules.SplashPage.ToString()).IsDemoModule = true;
            GetModuleItem(i9Modules.Incident.ToString()).IsDemoModule = true;

            //GetModuleItem(i9Modules.CodesAdmin.ToString()).IsDemoModule = true;
            //GetModuleItem(i9Modules.Agency.ToString()).IsDemoModule = true;
            //GetModuleItem(i9Modules.Personnel.ToString()).IsDemoModule = true;
            //GetModuleItem(i9Modules.DynamicEntry.ToString()).IsDemoModule = true;
            //GetModuleItem(i9Modules.Security.ToString()).IsDemoModule = true;
        }
    }
}
