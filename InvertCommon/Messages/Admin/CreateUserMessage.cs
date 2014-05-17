using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.Messages.Admin
{

    [Serializable]
    public class CreateUserMessage
    {
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Guid i9AgencyID { get; set; }
        public Guid i9SysPersonnelID { get; set; }
    }

}
