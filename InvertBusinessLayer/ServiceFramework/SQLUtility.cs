using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace InvertService.ServiceFramework
{
    public static class SQLUtility
    {
        public const string MICROSOFT_DATE_TIME_FORMAT = "MM/dd/yyyy hh:mm tt";
        public const string MICROSOFT_DATE_FORMAT = "MM/dd/yyyy";
        public const string MICROSOFT_TIME_FORMAT = "hh:mm tt";
        public const string MICROSOFT_DATE_TIME_FORMAT_REV = "yyyy/MM/dd hh:mm tt";
        public const string SQL_FALSE = "0";
        public const string SQL_TRUE = "1";

        public static bool isDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string SQLString(string VarChar)
        {
            string returnValue = "";
            returnValue = @"'" + VarChar.Replace(@"'", @"''") + @"'";
            return returnValue;
        }

        public static string SQLStringLike(string VarChar)
        {
            string returnValue = "";
            returnValue = @"'%" + VarChar.Replace(@"'", @"''") + @"%'";

            return returnValue;
        }

        public static bool HasTables(DataSet ds)
        {
            if (ds == null)
                return false;
            if (ds.Tables.Count <= 0)
                return false;

            return true;
        }

        public static bool HasTableRows(DataSet ds)
        {
            if (ds == null)
                return false;

            if (ds.Tables.Count <= 0)
                return false;

            if (ds.Tables[0].Rows.Count <= 0)
                return false;

            return true;
        }

        public static string WrapInTransaction(string SQL)
        {
            string TransactionSQL = " BEGIN TRAN T1 " + Environment.NewLine +
             SQL + " " + Environment.NewLine +
             " COMMIT TRAN T1 ";

            return TransactionSQL;
        }
    }
}
