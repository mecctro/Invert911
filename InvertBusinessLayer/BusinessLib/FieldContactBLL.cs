using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invert911.InvertCommon.Framework.Communication;

namespace InvertService.BusinessLib
{
    public class FieldContactBLL
    {
        public i9Message ProcessMobileMessage(i9Message mMessage)
        {
            i9Message response = new i9Message();
            response.ErrorStatus.SetError(true, "un-processed message", new Exception());
            return response;
        }
    }
}
