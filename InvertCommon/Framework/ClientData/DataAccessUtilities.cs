using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;

namespace Invert911.InvertCommon.Framework.ClientData
{
    public static class DataAccessUtilities
    {
        public const string MICROSOFT_DATE_TIME_FORMAT = "MM/dd/yyyy hh:mm tt";
        public const string MICROSOFT_DATE_FORMAT = "MM/dd/yyyy";
        public const string MICROSOFT_TIME_FORMAT = "hh:mm tt";
        public const string MICROSOFT_DATE_TIME_FORMAT_REV = "yyyy/MM/dd hh:mm tt";
        public const string SQL_FALSE = "0";
        public const string SQL_TRUE = "-1";

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

        public static string GetDBStr(string VarChar)
        {
            string returnValue = "";
            returnValue = @"'" + VarChar.Replace(@"'", @"''") + @"'";

            return returnValue;
        }

        public static string GetDBStrLikeStr(string VarChar)
        {
            string returnValue = "";
            returnValue = @"'%" + VarChar.Replace(@"'", @"''") + @"%'";

            return returnValue;
        }

        public static string ClientFolderPath
        {
            get
            {
                string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                if (String.IsNullOrEmpty(AppData) == false && Directory.Exists(AppData) == false)
                    Directory.CreateDirectory(AppData);
                return AppData;
            }
        }

        public static List<string> SyncTableNames()
        {
            List<string> Tables = new List<string>();
            Tables.Add("i9CodeSet");
            Tables.Add("i9Module");
            Tables.Add("i9DynamicEntry");
            Tables.Add("i9DynamicEntryRule");
            Tables.Add("i9DynamicEntryConfig");
            Tables.Add("i9SysPersonnel");
            Tables.Add("i9Code");
            Tables.Add("i9ClientTableKey");
            Tables.Add("i9DynamicEntryCtrlType");

            Tables.Add("i9SecurityGroup");
            //Tables.Add("i9SecurityGroupModule");
            //Tables.Add("i9SecurityGroupTask");
            Tables.Add("i9SecurityTask");
            return Tables;
        }

        public static string ClientDatabaseName
        {
            get
            {
                return "Invert911DB.db3";
            }
        }

        public static string ClientDatabasePath
        {
            get
            {
                return System.IO.Path.Combine( DataAccessUtilities.ClientFolderPath , ClientDatabaseName);
            }
        }
        
        public static string CreateSQLiteConnectionString()
        {
            return CreateSQLiteConnectionString(DataAccessUtilities.ClientDatabasePath, "invert911");
        }

        /// <summary>
        /// Creates SQLite connection string from the specified DB file path.
        /// </summary>
        /// <param name="sqlitePath">The path to the SQLite database file.</param>
        /// <returns>SQLite connection string</returns>
        private static string CreateSQLiteConnectionString(string sqlitePath, string password)
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = sqlitePath;
            if (password != null)
                builder.Password = password;
            builder.PageSize = 4096;
            builder.UseUTF16Encoding = true;
            string connstring = builder.ConnectionString;

            return connstring;
        }
    }
}
