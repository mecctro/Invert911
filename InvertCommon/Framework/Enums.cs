using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.Framework
{

    //public enum i911Modules
    public enum i9Modules
    {
        //--------------------------------------------------------
        //Login and Main Screens:
        //--------------------------------------------------------
        LoginPage,
        MainPage,
        MainMenuPage,
        SplashPage,

        //--------------------------------------------------------
        //Law:
        //--------------------------------------------------------
        Incident,
        Citation,
        FieldContact,
        Warrant,
        Gang,
        PropertyRoom,
        PhotoLineUp,
        Impound,
        PawnTickets,
        BicycleRegistration,
        PetRegistration,
        SexOffender,
        RestrainingOrder,
        FalseAlarm,
        BeatBook,
        CaseManagement,
        UCR,
        NIBRS,
        ApplicantSystem,
        MobileTerminalPage,
        Accident,
        TrafficCollision,
        Intelligence,

        //--------------------------------------------------------
        //CAD:
        //--------------------------------------------------------
        DispatchWindow,
        MessageSwitch,
        AlarmPermits,
        BOLO,
        Briefing,
        //MobileCAD,

        //--------------------------------------------------------
        //CAD and Mobile CAD:
        //--------------------------------------------------------
        MobileDispatch,
        Messages,
        AVL,
        Video,
        EventEntry,

        //--------------------------------------------------------
        //Corrections:
        //--------------------------------------------------------
        Booking,
        Arrest,
        Release,
        HousingAssignment,
        Meals,

        //--------------------------------------------------------
        //Fire:
        //--------------------------------------------------------
        FireIncident,
        FireInspection,
        HazMat,
        Arson,

        //--------------------------------------------------------
        //EMS:
        //--------------------------------------------------------
        EMSIncident,
        EMSEquipment,

        //--------------------------------------------------------
        //Administion
        //--------------------------------------------------------
        Security,
        Personnel,
        PersonnelGroups,
        Confidentiality,
        SystemConfigurations,
        Systemlog,
        Schedule,
        DepartmentEquipment,
        MasterLocationIndex,
        MasterNameIndex,
        MasterVehicleIndex,
        FleetManagementProperty,
        SupplyControlInventory,
        DataSharing,
        CodesAdmin,
        DynamicEntry,   
        InterfaceSetting,
        Agency,

        //--------------------------------------------------------
        //Utilites
        //--------------------------------------------------------
        MasterAddress,
        MasterName,
        MasterVehicle,
        MasterLocation,
        AdHocReport,
        Clipboard,
        Keyboard,
        Exit,

        //--------------------------------------------------------
        //THINGS TO ADD LATER:
        //--------------------------------------------------------
        WreckerRotation,
        ContactRolodexManagedByGroups,
        IntegratedLocalStateAndNCIC,
        CallSheet,
        VideoOverview,
        TrainingSystem,
        CrimeWatch,
        ServiceRequests,
        SpecialIntelligence,
        liquorLicense,
        FirearmLicenseEtc,
        DepartmentEquipmentProperty
    }


    public enum i9ModuleSection
    {
        LawIncidentLocation,
        LawIncidentPerson,
        LawIncidentPersonLocation,
        LawIncidentVeh,
        LawIncidentVehTowed,
        LawIncidentVehTowLoc,
        LawIncidentVehRecovery,
        LawIncidentVehRecoveryLoc,
        LawIncidentPersonAKA
    }

    public enum i9ApplicationType
    {
        i9FullClient,
        i9CloudClient,
        i9LiteClient
        
    }

    public enum i9SecurityEnum
    {
        Admin_Login,

        Admin_Personnel_New,
        Admin_Personnel_Edit,
        Admin_Personnel_Delete,

        Admin_DynamicEntry_New,
        Admin_DynamicEntry_Edit,
        Admin_DynamicEntry_Delete,

        Admin_Code_New,
        Admin_Code_Edit,
        Admin_Code_Delete,

        Admin_SystemPerson_New,
        Admin_SystemPerson_Edit,
        Admin_SystemPerson_Delete,

        Admin_Agency_New,
        Admin_Agency_Edit,
        Admin_Agency_Delete,

        Admin_Security_New,
        Admin_Security_Edit,
        Admin_Security_Delete,

        Admin_PersonnelGroups_New,
        Admin_PersonnelGroups_Edit,
        Admin_PersonnelGroups_Delete,

        Law_Incident_New,
        Law_Incident_Edit,
        Law_Incident_Delete,
        Law_Incident_Search,
    }











}
