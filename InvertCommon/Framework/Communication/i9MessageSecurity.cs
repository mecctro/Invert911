using System;
using System.Collections.Generic;
using System.Text;

namespace Invert911.InvertCommon.Framework.Communication
{
    [Serializable]
    public class i9MessageSecurity
    {
        public string LoginPersonnelID = "";
        public string MachineName = "";
        public string MachineDomain = "";
        public string MachineUserName = "";
        public string IPAddress = "";
        public string AgencyID = "";
    }
}
