using System;
using System.Collections.Generic;
using System.Text;

namespace Invert911.InvertCommon.Framework.Communication
{
    [Serializable]
    public class i9MessageError
    {
        public bool IsError = false;
        public string ErrorMsg = "";
        public string ErrorException = "";
        public string ErrorTrace = "";
        //public Exception ErrorException;

        public i9MessageError()
        {

        }

        public void SetError(bool IsError, string ErrorMsg, Exception ErrorEx)
        {
            this.IsError = IsError;
            this.ErrorMsg = ErrorMsg;
            //this.ErrorException = ErrorEx;
        }
    }
}
