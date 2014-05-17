using System;
using System.IO;
using System.Data;
using System.Reflection;
using System.Data.SQLite;
using System.Collections.Generic;

using Invert911.InvertCommon;
using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Utilities;

namespace Invert911.InvertCommon.Framework.ClientData
{
    public class ClientDataAccess 
	{
        public DataTable GetDataTable(string strSQL, string TableName)
        {
            DataTable dt = null;
            try
            {
                using (SQLiteConnection scon = new SQLiteConnection(DataAccessUtilities.CreateSQLiteConnectionString()))
                {
                    scon.Open();
                    SQLiteCommand com = new SQLiteCommand(strSQL, scon);
                    using (SQLiteDataReader dr = com.ExecuteReader())
                    {
                        dt = new DataTable(TableName);
                        dt.Load(dr);
                        dr.Close();
                    }
                    com.Dispose();
                    scon.Close();
                    scon.Dispose();
                }
            } 
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error in GetDataTable", ex);
            }
            return dt;
        }
    }

}
