using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Messages.Admin;
using Invert911.InvertCommon.Modules;
using InvertService.ServiceFramework;

namespace InvertService.BusinessLib
{
    public class SecurityBLL
    {
        /// <summary>
        /// Process Mobile Message
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public i9Message ProcessMobileMessage(i9Message requestMessage)
        {
            i9Message responseMessage = new i9Message();
            
            switch (requestMessage.ToBizLayerMsgType)
            {
                case SecurityType.Security_PersonnelGroupsGet:
                    responseMessage = Security_GetPersonnelGroups(requestMessage);
                    break;

                case SecurityType.Security_PersonnelGroupsSave:
                    responseMessage = Security_SavePersonnelGroups(requestMessage);
                    break;

                case SecurityType.Security_SecurityGroupsGet:
                    responseMessage = Security_GetSecurityGroups(requestMessage);
                    break;

                case SecurityType.Security_SecurityGroupSave:
                    responseMessage = Security_SaveGroupItems(requestMessage);
                    break;

                case SecurityType.Security_PersonnelGroupTaskGet:
                    responseMessage = Security_PersonnelGroupTaskGet(requestMessage);
                    break;

                default:
                    responseMessage.ErrorStatus.IsError = true;
                    responseMessage.ErrorStatus.ErrorMsg = "Unknown Message Type(" + DateTime.Now.ToString() + "): " + requestMessage.ToBizLayerMsgType;
                    ServiceLogManager.LogThis("Unkown message type in the Security business layer :  " + requestMessage.ToBizLayerMsgType, LogEventType.Info, "", "");
                    break;
            }
            return responseMessage;
        }

        private i9Message Security_PersonnelGroupTaskGet(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();
            string i9SysPersonnelID = requestMessage.MsgBody;


            string SQL1 = @"
                            SELECT sgm.ModuleName 
                            FROM i9SecurityGroupPersonnel sgp
	                            INNER JOIN i9SecurityGroup sg ON  sgp.i9SecurityGroupID = sg.i9SecurityGroupID
	                            LEFT OUTER JOIN i9SecurityGroupModule sgm ON  sgm.SecurityGroupName = sg.SecurityGroupName
	                            LEFT OUTER JOIN i9Agency a on a.i9AgencyID = sgp.i9AgencyID
	                            INNER JOIN i9SysPersonnel per on per.i9SysPersonnelID = sgp.i9SysPersonnelID
                            WHERE per.i9SysPersonnelID = @i9SysPersonnelID
                            GROUP BY sgm.ModuleName	
                            ORDER BY sgm.ModuleName
                            ";

            SQL1 = SQL1.Replace("@i9SysPersonnelID", SQLUtility.SQLString(i9SysPersonnelID));

            string SQL2 = @"    SELECT * FROM i9SecurityGroupTask WHERE 1=2";

            SQL2 = SQL2.Replace("@i9SysPersonnelID", SQLUtility.SQLString(i9SysPersonnelID));

            string SQL = SQL1 + " " + Environment.NewLine + " " + SQL2;

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table",  "ModuleName"},
                {"Table1", "TaskName"},
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;

            return response;
        }

        private i9Message Security_GetPersonnelGroups(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();
            string SQL = " Select * FROM i9SecurityGroup order by SecurityGroupName ASC" + Environment.NewLine +
                         " Select * FROM i9Agency order by AgencyName " + Environment.NewLine +
                         " Select * FROM i9SecurityGroupPersonnel " + Environment.NewLine +
                         " Select * FROM i9SysPersonnel ORDER BY LastName, FirstName" ;

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table",  "i9SecurityGroup"},
                {"Table1", "i9Agency"},
                {"Table2", "i9SecurityGroupPersonnel"},
                {"Table3", "i9SysPersonnel"},
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;

            return response;
        }

        private i9Message Security_SavePersonnelGroups(i9Message requestMessage)
        {
            i9Message ResponseMessage = new i9Message();
            try
            {
                if (requestMessage.MsgBodyDataSet != null)
                {
                    if (requestMessage.MsgBodyDataSet.Tables.Count > 0)
                    {
                        StringBuilder sbSQL = new StringBuilder();
                        SQLGenerator SqlGen = new SQLGenerator();
                        DataSet ds = requestMessage.MsgBodyDataSet;

                        sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9SecurityGroupPersonnel"]));

                        SQLAccess sqla = new SQLAccess();
                        string SQL = SQLUtility.WrapInTransaction(sbSQL.ToString());
                        sqla.ExecuteSQL(SQL);

                        ResponseMessage.ErrorStatus.IsError = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceLogManager.LogThis("Error Saving Personnel Group", LogEventType.Error, ex, "", "");
                ResponseMessage.ErrorStatus.IsError = true;
                ResponseMessage.ErrorStatus.ErrorMsg = ex.Message;
            }

            return ResponseMessage;
        }

        private i9Message Security_SaveGroupItems(i9Message requestMessage)
        {
            i9Message ResponseMessage = new i9Message();
            try
            {
                if (requestMessage.MsgBodyDataSet != null)
                {
                    if (requestMessage.MsgBodyDataSet.Tables.Count > 0)
                    {                        
                        StringBuilder sbSQL = new StringBuilder();
                        SQLGenerator SqlGen = new SQLGenerator();
                        DataSet ds = requestMessage.MsgBodyDataSet;

                        sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9SecurityGroup"]));
                        sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9SecurityGroupModule"]));
                        sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9SecurityGroupTask"]));
                     
                        SQLAccess sqla = new SQLAccess();
                        string SQL = SQLUtility.WrapInTransaction(sbSQL.ToString());
                        sqla.ExecuteSQL(SQL);

                        ResponseMessage.ErrorStatus.IsError = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceLogManager.LogThis("Error saving dataset", LogEventType.Error, ex, "", "");
                ResponseMessage.ErrorStatus.IsError = true;
                ResponseMessage.ErrorStatus.ErrorMsg = ex.Message;
            }

            return ResponseMessage;
        }

        private i9Message Security_GetSecurityGroups(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();
            string SQL = " Select * FROM i9SecurityGroup order by SecurityGroupName ASC" + Environment.NewLine +
                         " Select * FROM i9Agency order by AgencyName " + Environment.NewLine +
                         " Select * FROM i9Module order by Section ASC, ModuleName ASC " + Environment.NewLine +
                         " Select * FROM i9SecurityTask Order By TaskName ASC " + Environment.NewLine +
                         " Select * FROM i9SecurityGroupModule " + Environment.NewLine +
                         " Select * FROM i9SecurityGroupTask ";

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9SecurityGroup"},
                {"Table1", "i9Agency"},
                {"Table2", "i9Module"},
                {"Table3", "i9SecurityTask"},
                {"Table4", "i9SecurityGroupModule"},
                {"Table5", "i9SecurityGroupTask"},
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;

            return response;
        }
    }
}
