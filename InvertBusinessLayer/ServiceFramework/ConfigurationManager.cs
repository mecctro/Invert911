using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvertService.ServiceFramework
{
    public class i9ConfigurationManager
    {
        private static i9ConfigurationManager m_Instance = null;
        private static object m_PadLock = new object();

        private i9ConfigurationManager()
        {

        }

        public static i9ConfigurationManager Instance
        {
            get
            {
                lock (m_PadLock)
                {
                    if(m_Instance == null)
                    {
                        m_Instance = new i9ConfigurationManager();
                    }

                    return m_Instance;
                }
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

        public string DatabaseUserName
        {
            get 
            {
                string Results = "";
                try
                {
                    Results = System.Configuration.ConfigurationManager.AppSettings["DatabaseUserName"];
                }
                catch { }

                return Results;
            }
        }
        
    }
}
