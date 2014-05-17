using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.Utilities
{
    public class ConfigurationManager
    {
        private static ConfigurationManager m_Instance = null;
        private static object m_PadLock = new object();
        private string m_WebServiceURL = null;

        private ConfigurationManager()
        {

        }

        public static ConfigurationManager Instance
        {
            get
            {
                lock (m_PadLock)
                {
                    if(m_Instance == null)
                    {
                        m_Instance = new ConfigurationManager();
                    }

                    return m_Instance;
                }
            }
        }

        public string WebServiceURL
        {
            get
            {
                string Results = m_WebServiceURL;

                if (string.IsNullOrEmpty(m_WebServiceURL))
                {
                    try
                    {
                        Results = System.Configuration.ConfigurationManager.AppSettings["WebServiceURL"];
                    }
                    catch { }
                }
                
                return Results;
            }
            set
            {
                m_WebServiceURL = value;
            }
        }

        public bool IsDemoMode
        {
            get
            {   
                if (String.IsNullOrEmpty(WebServiceURL))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool SyncClientDatabase
        {
            get
            {
                Boolean Results = true;
                try
                {
                    if (System.Configuration.ConfigurationManager.AppSettings["SyncClientDatabase"].Trim().ToUpper() == "FALSE")
                    {
                        Results = false;
                    }
                }
                catch { }
                return Results;
            }
        }

        public string ConnectionString
        {
            get
            {
                string Results = "";
                try
                {
                    Results = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                }
                catch { }
                return Results;
            }
        }


        public string SMTPServerAddress
        {
            get
            {
                string Results = "";
                try
                {
                    Results = System.Configuration.ConfigurationManager.AppSettings["SMTPServerAddress"];
                }
                catch { }
                return Results;
            }
        }

        public string SMTPUserName
        {
            get
            {
                string Results = "";
                try
                {
                    Results = System.Configuration.ConfigurationManager.AppSettings["SMTPUserName"];
                }
                catch { }
                return Results;
            }
        }

        public string SMTPPassword
        {
            get
            {
                string Results = "";
                try
                {
                    Results = System.Configuration.ConfigurationManager.AppSettings["SMTPPassword"];
                }
                catch { }
                return Results;
            }
        }

        public string SMTPPort
        {
            get
            {
                string Results = "";
                try
                {
                    Results = System.Configuration.ConfigurationManager.AppSettings["SMTPPort"];
                }
                catch { }
                return Results;
            }
        }
        
        
    }
}
