using System;
using System.Collections.Generic;
using System.Text;

using Invert911.InvertCommon.Framework.Communication;

namespace Invert911.InvertCommon.Messages.Admin
{
    [Serializable]
    public class LoginMessage
    {
        public string UserName;
        public string Password;

        public LoginMessage()
        {
            //this.From
        }
    }
}
