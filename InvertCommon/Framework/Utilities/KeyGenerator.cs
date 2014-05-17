using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Framework.ClientData;

namespace Invert911.InvertCommon.Framework.Utilities
{
    public class KeyGenerator
    {
        private static KeyGenerator m_Instance = null;
        private static readonly object m_Padlock = new object();

        private KeyGenerator()
		{

        }

        public static KeyGenerator Instance
        {
            get
            {
                lock (m_Padlock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new KeyGenerator();
                    }
                }
                return m_Instance;
            }   
        }

        /// <summary>
        /// Get Next Table Key from the local client keys cache.
        /// </summary>
        /// <param name="TableName">Table Name key</param>
        /// <param name="GoToServerIfEmpty">If no more keys in the client cache go to server to get next key</param>
        /// <returns></returns>
        public int NextClientTableKey(string TableName, bool GoToServerIfEmpty)
        {
            int KeyValue = 0;
            ClientDataAccess cda = new ClientDataAccess();
            string sql = "SELECT * FROM i9ClientTableKey WHERE " + TableName + " ";
            DataTable dt = cda.GetDataTable(sql, "i9ClientTableKey");
            if (dt != null)
            {
                //if(ds.Tables.Count > 0)
                if (dt.Rows.Count > 0)
                    KeyValue = Convert.ToInt32(dt.Rows[0]["KeyValue"].ToString());
            }

            if (KeyValue == 0)
            {
                if (GoToServerIfEmpty)
                    KeyValue = NextServerTableKey(TableName);
            }

            if (KeyValue == 0)
            {
                throw new Exception("Unable to get the next table key for: " + TableName);
            }

            return KeyValue;
        }

        public int NextServerTableKey(string TableName)
        {
            int KeyValue = 0;

            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.Utility_NextServerTableKey, this.GetType().Name, typeof(string), TableName);
            if (responseMsg.ErrorStatus.IsError)
            {
                throw new Exception("Unable to get the next Server table key for: " + TableName);
            }
            else
            {
                DataSet ds = responseMsg.MsgBodyDataSet;
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                        if (ds.Tables[0].Rows.Count > 0)
                            KeyValue = Convert.ToInt32(ds.Tables[0].Rows[0]["KeyValue"].ToString());

                    return KeyValue;
                }
                else
                {
                    throw new Exception("Unable to get the next table key for: " + TableName);
                }
            }
        }

        public string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
