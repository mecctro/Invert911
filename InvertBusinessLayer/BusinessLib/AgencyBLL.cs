using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Messages.Admin;
using Invert911.InvertCommon.Modules;
using InvertService.ServiceFramework;

namespace InvertService.BusinessLib
{
    public class AgencyBLL
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
                case AgencyType.Agency_GetList:
                    responseMessage = GetList(requestMessage);
                    break;
                case AgencyType.Agency_Delete:
                    responseMessage = DeleteAgency(requestMessage);
                    break;
                case AgencyType.Agency_GetDetail:
                    responseMessage = GetDetail(requestMessage);
                    break;
                case AgencyType.Agency_Save:
                    responseMessage = AgencySave(requestMessage);
                    break;
                default:
                    responseMessage.ErrorStatus.IsError = true;
                    responseMessage.ErrorStatus.ErrorMsg = "Unknown Message Type(" + DateTime.Now.ToString() + "): " + requestMessage.ToBizLayerMsgType;
                    ServiceLogManager.LogThis("Unkown message type in the Agency business layer :  " + requestMessage.ToBizLayerMsgType, LogEventType.Info, "", "");
                    break;
            }
            
            return responseMessage;
        }

        private i9Message GetDetail(i9Message requestMessage)
        {
            string AgencyID = requestMessage.MsgBody.ToString();
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();
            string SQL = " Select * from i9Agency WHERE i9AgencyID = " + SQLUtility.SQLString(AgencyID) + " order by AgencyName ";

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9Agency"},
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;

            return response;
        }

        private i9Message DeleteAgency(i9Message requestMessage)
        {
            string AgencyID = requestMessage.MsgBody.ToString();
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();
            string SQL = "DELETE FROM i9Agency WHERE i9AgencyID = " + SQLUtility.SQLString(AgencyID) + " ";

            int UpdatedRows = da.ExecuteSQL(SQL);
            response.MsgBody = UpdatedRows.ToString();

            return response;
        }

        private i9Message AgencySave(i9Message requestMessage)
        {
            i9Message ResponseMessage = new i9Message();

            try
            {
                if (requestMessage.MsgBodyDataSet != null)
                {
                    if (requestMessage.MsgBodyDataSet.Tables.Count > 0)
                    {
                        SQLAccess da = new SQLAccess();
                        da.SaveDataTable(requestMessage.MsgBodyDataSet.Tables["i9Agency"]);
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

        private i9Message GetList(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();
            string SQL = " Select * from i9Agency order by AgencyName ";

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9Agency"},
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;

            return response;
        }
    }
}
