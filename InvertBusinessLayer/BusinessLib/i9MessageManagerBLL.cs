using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvertService.ServiceFramework;

using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Framework.Interfaces;
using System.Data;
//using Invert911.InvertCommon.Utilities;

namespace InvertService.BusinessLib
{
    public class i9MessageManagerBLL : Ii9MessageManager
    {

        private bool HasSecurityRight(i9Message RequestMessage, ref i9Message ResponseMessage)
        {
            //Need to Check the 
            return true;
        }

        public string ProcessMobileMessage(string Message)
        {
            ServiceLogManager.LogThis(Message, LogEventType.InMessages, "", "");

            
  
            i9Message Response = new i9Message();
            
            try
            {
                i9Message RequestMessage = (i9Message)i9Message.XMLDeserializeMessage(typeof(i9Message), Message);

                if (RequestMessage.MessageFormatVersion != i9Message.MESSAGE_FORMAT_VERSION)
                {
                    throw new Exception("Your Invert911 Cloud app is out of sync with the Clould server.  Please upgrade to the latest i9Invert911 Clound App");
                }
                
                //Need to Log Inbound Message
                //ServiceLogManager.LogThis(Message, LogEventType.Info, RequestMessage.MessageSecurity.LoginPersonnelID, RequestMessage.MessageSecurity.AgencyID);

                //Security Check:
                if (HasSecurityRight(RequestMessage, ref Response) == false)
                    return Response.XMLSerializeMessage();

                //Module Message Switch.  Routes Messages
                switch (RequestMessage.ToBizLayer)
                {
                    case MobileMessageType.Admin:
                        Response = new AdminBLL().ProcessMobileMessage(RequestMessage);
                        break;
                    case MobileMessageType.Agency:
                        Response = new AgencyBLL().ProcessMobileMessage(RequestMessage);
                        break;
                    case MobileMessageType.Citation:
                        Response = new CitationBLL().ProcessMobileMessage(RequestMessage);
                        break;
                    case MobileMessageType.Common:
                        Response = new CommonBLL().ProcessMobileMessage(RequestMessage);
                        break;
                    case MobileMessageType.FieldContact:
                        Response = new FieldContactBLL().ProcessMobileMessage(RequestMessage);
                        break;
                    case MobileMessageType.Incident:
                        Response = new LawIncidentBLL().ProcessMobileMessage(RequestMessage);
                        break;
                    case MobileMessageType.SyncCache:
                        Response = new SyncBLL().ProcessMobileMessage(RequestMessage);
                        break;
                    case MobileMessageType.Security:
                        Response = new SecurityBLL().ProcessMobileMessage(RequestMessage);
                        break;
                    default:
                        ServiceLogManager.LogThis("Unkown message type in the Message Manager BLL:  " + RequestMessage.ToBizLayerMsgType, LogEventType.Info, "", "");
                        Response.ErrorStatus.SetError(true, "Message Type is unknown", new Exception());
                        break;
                }
            }
            catch (Exception ex)
            {
                ServiceLogManager.LogThis("Error", LogEventType.Error, ex, "", "");
                Response.ErrorStatus.IsError = true;
                Response.ErrorStatus.ErrorMsg = "Error processing server message: ";
                Response.ErrorStatus.ErrorTrace = ex.StackTrace;
                Response.ErrorStatus.ErrorException = ex.Message;
            }

            //Response Message In string format
            string ResponseMessageText = Response.XMLSerializeMessage();

            //Log Outbound Message 
            ServiceLogManager.LogThis(ResponseMessageText, LogEventType.OutMessages, "", "");

            //
            return ResponseMessageText;
        }

        public static i9Message SendMessage(string ToBizLayer, string ToBizLayerMsgType, string From)
        {
            i9Message MobileMsg = new i9Message();
            MobileMsg.ToBizLayer = ToBizLayer;
            MobileMsg.ToBizLayerMsgType = ToBizLayerMsgType;
            MobileMsg.From = From;

            return SendMessage(MobileMsg);
        }

        public static i9Message SendMessage(string ToBizLayer, string ToBizLayerMsgType, string From, DataSet MsgDataSet)
        {
            i9Message MobileMsg = new i9Message();

            MobileMsg.ToBizLayer = ToBizLayer;
            MobileMsg.ToBizLayerMsgType = ToBizLayerMsgType;
            MobileMsg.From = From;
            MobileMsg.MsgBodyDataSet = MsgDataSet;

            return SendMessage(MobileMsg);
        }

        public static i9Message SendMessage(string ToBizLayer, string ToBizLayerMsgType, string From, Type type, object MsgBody)
        {
            i9Message MobileMsg = new i9Message();

            MobileMsg.ToBizLayer = ToBizLayer;
            MobileMsg.ToBizLayerMsgType = ToBizLayerMsgType;
            MobileMsg.From = From;

            if (type == typeof(string))
                MobileMsg.MsgBody = MsgBody.ToString();
            else
                MobileMsg.MsgBody = i9Message.XMLSerializeMessage(MsgBody.GetType(), MsgBody);

            return SendMessage(MobileMsg);
        }

        public static i9Message SendMessage(i9Message MobileMsg)
        {
            i9Message ReturnMessage = new i9Message();

            try
            {
                //RespomseMsg = SendMessage_V1(MobileMsg);
                ReturnMessage = SendMessageAsync(MobileMsg);

            }
            catch (Exception ex)
            {
                ServiceLogManager.LogThis("", LogEventType.Error, ex, "", "");
                ReturnMessage.ErrorStatus.IsError = true;
                ReturnMessage.ErrorStatus.ErrorMsg = "Error: " + ex.GetBaseException().Message + Environment.NewLine + "  StackTrace:  " + ex.GetBaseException().StackTrace;
            }

            return ReturnMessage;
        }

        private static i9Message SendMessageAsync(i9Message MobileMsg)
        {
            i9Message ReturnMessage = new i9Message();

            try
            {
                //Security Information to the Message.
                MobileMsg.MessageSecurity.MachineName = Environment.MachineName;
                MobileMsg.MessageSecurity.MachineUserName = Environment.UserName;
                MobileMsg.MessageSecurity.IPAddress = "???";
                MobileMsg.MessageSecurity.LoginPersonnelID = ""; // SettingManager.Instance.LoginPersonnelID;
                MobileMsg.MessageSecurity.AgencyID = "";         // SettingManager.Instance.AgencyID;

                string TextMsg = MobileMsg.XMLSerializeMessage();
                string ReturnXMLMessage = "";

                Ii9MessageManager oIi9MessageManager = new InvertService.BusinessLib.i9MessageManagerBLL();
                ReturnXMLMessage = oIi9MessageManager.ProcessMobileMessage(TextMsg);

                ReturnMessage = (i9Message)i9Message.XMLDeserializeMessage(typeof(i9Message), ReturnXMLMessage);
            }
            catch (Exception ex)
            {
                ReturnMessage.ErrorStatus.IsError = true;
                ReturnMessage.ErrorStatus.ErrorMsg = "Error: " + ex.GetBaseException().Message + Environment.NewLine + "  StackTrace:  " + ex.GetBaseException().StackTrace;
                //LogManager.Instance.LogMessage("Error in the MessageManager.SendMessage", ex);
                ServiceLogManager.LogThis("", LogEventType.Error, ex, "", "");
            }

            return ReturnMessage;
        }

    }
}