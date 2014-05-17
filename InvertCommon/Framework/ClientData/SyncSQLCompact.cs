using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.Framework.ClientData
{
    class SyncSQLCompact
    {

        private string ConnectionString
        {
            get
            {
                string mDatabaseName = "localdb.sdf";
                string sConnectionString = string.Format("Data Source={0};Max Database Size=4091;Max Buffer Size = 1024;Default Lock Escalation =100;Encrypt Database={1}", mDatabaseName, "FALSE");
                return sConnectionString;
            }
        }

    }
}
