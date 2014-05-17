using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace InvertService.ServiceFramework
{
    public class ServerKeyManager
    {
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// This Method is not used anymore because we switched to a GUID keys
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static long GetSingleTableKey(string TableName)
        {
            SQLAccess da = new SQLAccess();
            long KeyValue = -1;
            
            StringBuilder SQLi9Table = new StringBuilder();
            SQLi9Table.AppendLine(" BEGIN TRAN T1 ");
            SQLi9Table.AppendLine(" Update i9TableKey set KeyValue = KeyValue + 1 WHERE TableName = " + SQLUtility.SQLString(TableName) + " ");
            SQLi9Table.AppendLine(" SELECT KeyValue FROM i9TableKey WHERE TableName = " + SQLUtility.SQLString(TableName) + " ");
            SQLi9Table.AppendLine(" COMMIT TRAN T1 ");

            string SQL = SQLi9Table.ToString();
            DataTable dt = da.GetDataTable(SQLi9Table.ToString(), "Results");
            if (dt.Rows.Count > 0)
            {       
                if (DBNull.Value != dt.Rows[0]["KeyValue"])
                    if (String.IsNullOrEmpty(dt.Rows[0]["KeyValue"].ToString()) == false)
                        KeyValue = (long)  dt.Rows[0]["KeyValue"] ;
            }
            return KeyValue;
        }
    }
}