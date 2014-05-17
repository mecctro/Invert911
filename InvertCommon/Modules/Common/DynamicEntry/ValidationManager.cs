using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Invert911.InvertCommon.Modules.Common.DynamicEntry
{
    class ValidationManager
    {
        internal static bool IsValid(string input, string module, DataRowView drv, string table, string column, ref string ErrorMessage)
        {
            bool Results = true;
            ErrorMessage = "";

            return Results;
        }
    }
}
