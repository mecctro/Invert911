using System;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Framework.ClientData;

using InvertService.ServiceFramework;


namespace InvertService.BusinessLib
{
    public class SyncBLL
    {
        public i9Message ProcessMobileMessage(i9Message RequestMessage)
        {
            i9Message response = new i9Message();
            switch (RequestMessage.ToBizLayerMsgType)
            {
                case SyncCacheType.GetSyncData:
                    string LastChanged = RequestMessage.MsgBody;
                    response = GetSyncData(LastChanged);
                    break;

                case SyncCacheType.GetFullTable:
                    response = GetEntireTable(RequestMessage);
                    break;
            }

            return response;
        }

        private i9Message GetEntireTable(i9Message RequestMessage)
        {
            string TableName = RequestMessage.MsgBody;

            i9Message response = new i9Message();
            string sql = "SELECT * FROM " + TableName;
            string personnelID = RequestMessage.MessageSecurity.LoginPersonnelID;

            switch (TableName.ToUpper())
            {
                case "i9SysPersonnel":
                    //Leave out the password from the result set.
                    sql = "SELECT BadgeNumber, i9SysPersonnelID, FirstName, LastName, MiddleName, OfficerORI, Officer FROM i9SysPersonnel";
                    break;
                    
                //case "i9SecurityGroupTask":
                //    sql = "SELECT * FROM i9SecurityGroupTask WHERE i9SysPersonnelID = " + SQLUtility.SQLString(personnelID);
                //    break;

                //case "i9SecurityGroupModule":
                //    sql = "SELECT * FROM i9SecurityGroupModule WHERE i9SysPersonnelID = " + SQLUtility.SQLString(personnelID);
                //    break;

                default:
                    sql = "SELECT * FROM " + TableName;
                    break;
            }

            DataSet ss = new SQLAccess().GetDataSet(sql, TableName);
            response.MsgBodyDataSet = ss;
            return response;
        }

        private i9Message GetSyncData(string LatChanged)
        {
            i9Message response = new i9Message();
            string sql = "";
            int TableCounter = 0;
            
            List<string> tables = DataAccessUtilities.SyncTableNames();
            Dictionary<string, string> tableMapping = new Dictionary<string, string>();

            tables.ForEach(delegate(String TableName)
            {
                sql += " SELECT * FROM " + TableName + " WHERE  LastUpdate >= " + SQLUtility.SQLString(LatChanged.Trim()) + "  or  LastUpdate is null " + Environment.NewLine;
                tableMapping.Add("Table" + (TableCounter == 0 ? "" : TableCounter.ToString()), TableName);
                TableCounter++;
            });

            DataSet ds = new SQLAccess().GetDataSet(sql, tableMapping);
            response.MsgBodyDataSet = ds;

            return response;
        }
    }
}
