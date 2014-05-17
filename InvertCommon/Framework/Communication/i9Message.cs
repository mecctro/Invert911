using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Data;

namespace Invert911.InvertCommon.Framework.Communication
{
    [Serializable]
    public class i9Message
    {
        public const string MESSAGE_FORMAT_VERSION = "1.1.3";

        public i9MessageError ErrorStatus;
        public i9MessageSecurity MessageSecurity;

        public string ToBizLayer;
        public string ToBizLayerMsgType;  

        public string From = "";

        public string LogMessagePath = "";

        public string MsgBody;
        public DataSet MsgBodyDataSet;
        public string MsgGUID = Guid.NewGuid().ToString();
        public string MessageFormatVersion = MESSAGE_FORMAT_VERSION;

        public DateTime CreateDate;

        public i9Message()
        {
            this.CreateDate = DateTime.Now;
            this.ErrorStatus = new i9MessageError();
            this.MessageSecurity = new i9MessageSecurity();
        }

        public void AppendLogMessagePath(string Section)
        {
            LogMessagePath = LogMessagePath + "." + Section;
        }

        public static object XMLDeserializeMessage(Type oType, string XMLMessage)
        {
            StringReader msgRdr = new StringReader(XMLMessage);
            XmlSerializer xser = new XmlSerializer(oType);
            object retObj = xser.Deserialize(msgRdr);
            return retObj;
        }

        public static string XMLSerializeMessage(Type oType, object ThisObject)
        {
            XmlSerializer xser = new XmlSerializer(oType);
            StringBuilder outSB = new StringBuilder();
            StringWriter outSW = new StringWriter(outSB);
            xser.Serialize(outSW, ThisObject);
            outSW.Close();
            return outSB.ToString();
        }

        public string XMLSerializeMessage()
        {
            XmlSerializer xser = new XmlSerializer(this.GetType());
            StringBuilder outSB = new StringBuilder();
            StringWriter outSW = new StringWriter(outSB);
            xser.Serialize(outSW, this);
            outSW.Close();
            return outSB.ToString();
        }

        public bool HasTables()
        {
            
            bool HasTables = false;
            if (MsgBodyDataSet != null)
            {
                if (MsgBodyDataSet.Tables.Count > 0)
                {
                    HasTables = true;
                }
            }
            return HasTables;
        }

        public bool HasTable(string TableName)
        {
            bool HasTables = false;
            if (MsgBodyDataSet != null)
            {
                if (MsgBodyDataSet.Tables.Count > 0)
                {
                    if (MsgBodyDataSet.Tables.Contains(TableName))
                    {
                        if (MsgBodyDataSet.Tables[TableName].Rows.Count > 0)
                        {
                            HasTables = true;
                        }
                    }
                }
            }
            return HasTables;
        }

        public bool HasTableRows(string TableName)
        {
            bool HasTables = false;
            if (MsgBodyDataSet != null)
            {
                if (MsgBodyDataSet.Tables.Count > 0)
                {
                    if (MsgBodyDataSet.Tables.Contains(TableName))
                    {
                        if (MsgBodyDataSet.Tables[TableName].Rows.Count > 0)
                        {
                            HasTables = true;
                        }
                    }
                }
            }
            return HasTables;
        }

    }
}


