using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.Framework.Communication
{

    public static class MobileMessageType
    {
        //System Modules
        public const string Admin = "Admin";
        public const string Agency = "Agency";
        public const string Common = "Common";
        public const string SyncCache = "SyncCache";
        public const string Security = "Security";
        
        //Law Modules
        public const string Incident = "Incident";
        public const string Citation = "Citation";
        public const string FieldContact = "FieldContact";

        //CAD Modules
        public const string CAD = "CAD";
    }

    public static class LawType
    {
        public const string Incident_New = "Incident_New";
        public const string Incident_Save = "Incident_Save";
        public const string Incident_Edit = "Incident_Edit";
        public const string Incident_Delete = "Incident_Delete";
        public const string Incident_Search = "Incident_Search";
    }

    public static class AdminType
    {
        //Login Types
        public const string Login = "Login";
        public const string Personnel = "Personnel";
        public const string CreateUser = "CreateUser";

        //Dynamic Entry Types
        public const string DynamicEntry_GetDynamicEntryAdmin = "DynamicEntry_GetDynamicEntryAdmin";
        public const string DynamicEntry_SaveDynamicEntryAdmin = "DynamicEntry_SaveDynamicEntryAdmin";
        public const string DynamicEntry_GetTableColumns = "DynamicEntry_GetTableColumns";
        
        //Codes Types
        public const string Code_GetCodeList_Admin = "Code_GetCodeList_Admin";
        public const string Code_GetCodeDetail_Admin = "Code_GetCodeDetail_Admin";
        public const string Code_SaveCodeDetail_Admin = "Code_SaveCodeDetail_Admin";
        
        //System Personnel Types
        public const string SysPer_GetList = "SysPer_GetList";
        public const string SysPer_PersonGet = "SysPer_PersonGet";
        public const string SysPer_PersonSave = "SysPer_PersonSave";
        public const string SysPer_PersonAdd = "SysPer_PersonAdd";
        public const string SysPer_PersonDelete = "SysPer_PersonDelete";

        //Utilities Types
        public const string Utility_NextServerTableKey = "Utility_NextServerTableKey";

        //Log Types
        public const string Log_GetTop100 = "Log_GetTop100";
    }

    public static class AgencyType
    {
        //Agency 
        public const string Agency_GetList = "Agency_GetList";
        public const string Agency_Save = "Agency_Save";
        public const string Agency_GetDetail = "Agency_GetDetail";
        public const string Agency_Delete = "Agency_Delete";
    }

    public class SyncCacheType
    {
        public const string GetSyncData = "GetSyncData";
        public const string GetFullTable = "GetEntireTable";
    }

    public class SecurityType
    {
        public const string Security_SecurityGroupsGet = "Security_GetSecurityGroups";
        public const string Security_SecurityGroupSave = "Security_SaveSecurityGroup";

        public const string Security_PersonnelGroupsGet = "Security_GetPersonnelGroups";
        public const string Security_PersonnelGroupsSave = "Security_SavePersonnelGroups";

        public const string Security_PersonnelGroupTaskGet = "Security_PersonnelGroupTaskGet";
    }
}
