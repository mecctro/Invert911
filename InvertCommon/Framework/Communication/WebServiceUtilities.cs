using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using Invert911.InvertCommon;
using Invert911.InvertCommon.Utilities;

namespace Invert911.InvertCommon.Framework
{
    public class WebServiceUtilities
    {
        public static SoapHttpClientProtocol GetWebService(SoapHttpClientProtocol ws)
        {
            string url = ws.Url.ToLower();
            int LastSlash = url.LastIndexOf("/");
            string UrlDirectory = url.Substring(0, LastSlash + 1);

            string app = ConfigurationManager.Instance.WebServiceURL.Trim();

            if (app.Length == 0 || app.ToLower() == UrlDirectory)
            {
                return ws;
            }
            else
            {
                ws.Url = url.Replace(UrlDirectory, app);
                return ws;
            }
        }
        
    }
}
