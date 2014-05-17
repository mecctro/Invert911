using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Invert911.InvertCommon.Framework.Communication;
using InvertService.BusinessLib;
using InvertService.ServiceFramework;
using Invert911.InvertCommon.Utilities;

namespace InvertService
{
    /// <summary>
    /// Summary description for Invert911Service
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    public class Invert911Service : System.Web.Services.WebService
    {
        [WebMethod]
        public string ProcessMobileMessage(string Message)
        {
            //-------------------------------------------------
            //Production Code
            //-------------------------------------------------
            i9MessageManagerBLL BizManager = new i9MessageManagerBLL();
            return BizManager.ProcessMobileMessage(Message);
        }

        [WebMethod]
        public string ProcessMobileMessageTest(string Message)
        {
            return "Test:  " + DateTime.Now.ToString() ;
        }
    }
}
