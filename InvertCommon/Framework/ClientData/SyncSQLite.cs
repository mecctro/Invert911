using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Utilities;

//###########################################################################
//  Dev Notes:
//   http://www.codeproject.com/Articles/26932/Convert-SQL-Server-DB-to-SQLite-DB
//###########################################################################

namespace Invert911.InvertCommon.Framework.ClientData
{
    public class SyncSQLite
    {
        public delegate void UpdateEventHandler(string StatusMessage);
        public event UpdateEventHandler UpdateEvent;

        public bool SyncClientDatabase()
        {
            bool ReturnStatus = true;
            try
            {
                UpdateEventMessage("Syncing Client and Server");

                //=================================================================
                //Testing Code
                //=================================================================
                //if ( System.Diagnostics.Debugger.IsAttached )
                //    if (ClientDatabaseExist())
                //        return true;
                //=================================================================

                DeleteClientDatabase();
                InitClientDatabase();

                string sqliteConnString = DataAccessUtilities.CreateSQLiteConnectionString();

                using (SQLiteConnection conn = new SQLiteConnection(sqliteConnString))
                {
                    conn.Open();
                    foreach (string TableName in DataAccessUtilities.SyncTableNames())
                    {
                        i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.SyncCache, SyncCacheType.GetFullTable, "SyncClientDatabase", typeof(string), TableName);
                        if (responseMsg.ErrorStatus.IsError)
                        {
                            UpdateEventMessage("Error Syncing Table " + TableName + " - Error Message: " + responseMsg.ErrorStatus.ErrorMsg);
                            ReturnStatus = false;
                        }
                        else
                        {
                            UpdateEventMessage("   " + TableName);
                            LoadData(conn, responseMsg.MsgBodyDataSet, TableName);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                UpdateEventMessage("Error Syncing Tables - Error Message: " + ex.Message);
                LogManager.Instance.LogMessage("Sync method error", ex);
                ReturnStatus = false;
            }

            return ReturnStatus;
        }

        private void UpdateEventMessage(string Message)
        {
            if (UpdateEvent != null)
                UpdateEvent(Message);
        }

        private void InitClientDatabase()
        {
            if (File.Exists(DataAccessUtilities.ClientDatabasePath) == false)
            {
                SQLiteConnection.CreateFile(DataAccessUtilities.ClientDatabasePath);
            }
        }

        private void DeleteClientDatabase()
        {
            if (File.Exists(DataAccessUtilities.ClientDatabasePath))
            {
                File.Delete(DataAccessUtilities.ClientDatabasePath);
            }
        }

        private bool ClientDatabaseExist()
        {
            bool results = false;
            if (File.Exists(DataAccessUtilities.ClientDatabasePath))
            {
                results = true;
            }
            return results;
        }

        private void LoadData(SQLiteConnection conn, DataSet ds, string TableName)
        {
            if (ds.Tables.Contains(TableName))
            {
                DataTable dt = ds.Tables[TableName];
                string CreateSQL = BuildCreateTableQuery(dt);

                // Execute the query in order to actually create the table.
                SQLiteCommand cmd = new SQLiteCommand(CreateSQL, conn);
                int i = cmd.ExecuteNonQuery();
                
                SQLiteTransaction tx = conn.BeginTransaction();

                //StringBuilder ALLInsertSQL = new StringBuilder();
                SQLiteCommand insert = BuildInsertQuery(dt);
                int counter = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    insert.Connection = conn;
                    insert.Transaction = tx;
                    List<string> pnames = new List<string>();

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string ColumnName = dt.Columns[j].ColumnName;
                        string pname = "@" + GetNormalizedName(dt.Columns[j].ColumnName, pnames);
                        insert.Parameters[pname].Value = CastValueForColumn(dr[ColumnName], dt.Columns[j]);
                        //insert.Parameters[pname].Value = GetColumnValue(dr, dr.Table.Columns[i]);
                        pnames.Add(pname);
                    }

                    insert.ExecuteNonQuery();
                    counter++;
                    if (counter % 1000 == 0)
                    {
                        //CheckCancelled();
                        tx.Commit();
                        //handler(false, true, (int)(100.0 * i / schema.Count), "Added " + counter + " rows to table " + schema[i].TableName + " so far");
                        tx = conn.BeginTransaction();
                    }
                }

                tx.Commit();
                //handler(false, true, (int)(100.0 * i / schema.Count), "Finished inserting rows for table " + schema[i].TableName);
            }
            else
            {
                UpdateEventMessage("Table Name Does not exists " + TableName);
            }
        }

        /// <summary>
        /// Used in order to adjust the value received from SQL Servr for the SQLite database.
        /// </summary>
        /// <param name="val">The value object</param>
        /// <param name="columnSchema">The corresponding column schema</param>
        /// <returns>SQLite adjusted value.</returns>
        private static object CastValueForColumn(object val, DataColumn columnSchema)
        {
            if (val is DBNull)
                return null;

            DbType dt = GetDbTypeOfColumn(columnSchema);

            switch (dt)
            {
                case DbType.Int32:
                    if (val is short)
                        return (int)(short)val;
                    if (val is byte)
                        return (int)(byte)val;
                    if (val is long)
                        return (int)(long)val;
                    if (val is decimal)
                        return (int)(decimal)val;
                    break;

                case DbType.Int16:
                    if (val is int)
                        return (short)(int)val;
                    if (val is byte)
                        return (short)(byte)val;
                    if (val is long)
                        return (short)(long)val;
                    if (val is decimal)
                        return (short)(decimal)val;
                    break;

                case DbType.Int64:
                    if (val is int)
                        return (long)(int)val;
                    if (val is short)
                        return (long)(short)val;
                    if (val is byte)
                        return (long)(byte)val;
                    if (val is decimal)
                        return (long)(decimal)val;
                    break;

                case DbType.Single:
                    if (val is double)
                        return (float)(double)val;
                    if (val is decimal)
                        return (float)(decimal)val;
                    break;

                case DbType.Double:
                    if (val is float)
                        return (double)(float)val;
                    if (val is double)
                        return (double)val;
                    if (val is decimal)
                        return (double)(decimal)val;
                    break;

                case DbType.String:
                    if (val is Guid)
                        return ((Guid)val).ToString();
                    break;

                case DbType.Guid:
                    if (val is string)
                        return ParseStringAsGuid((string)val);
                    if (val is byte[])
                        return ParseBlobAsGuid((byte[])val);
                    break;

                case DbType.Binary:
                case DbType.Boolean:
                case DbType.DateTime:
                    break;

                default:
                    //_log.Error("argument exception - illegal database type");
                    throw new ArgumentException("Illegal database type [" + Enum.GetName(typeof(DbType), dt) + "]");
            } // switch

            return val;
        }

        private static Guid ParseBlobAsGuid(byte[] blob)
        {
            byte[] data = blob;
            if (blob.Length > 16)
            {
                data = new byte[16];
                for (int i = 0; i < 16; i++)
                    data[i] = blob[i];
            }
            else if (blob.Length < 16)
            {
                data = new byte[16];
                for (int i = 0; i < blob.Length; i++)
                    data[i] = blob[i];
            }

            return new Guid(data);
        }

        private static Guid ParseStringAsGuid(string str)
        {
            try
            {
                return new Guid(str);
            }
            catch
            {
                return Guid.Empty;
            }
        }

        private SQLiteCommand BuildInsertQuery(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [" + dt.TableName + "] (");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append("[" + dt.Columns[i].ColumnName + "]");
                if (i < dt.Columns.Count - 1)
                    sb.Append(", ");
            } // for

            sb.Append(") VALUES (");

            SQLiteCommand res = new SQLiteCommand();

            List<string> pnames = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string pname = "@" + GetNormalizedName(dt.Columns[i].ColumnName, pnames);
                sb.Append(pname);
                if (i < dt.Columns.Count - 1)
                    sb.Append(", ");

                DbType dbType = GetDbTypeOfColumn(dt.Columns[i]);
                SQLiteParameter prm = new SQLiteParameter(pname, dbType, dt.Columns[i].ColumnName);
                res.Parameters.Add(prm);

                // Remember the parameter name in order to avoid duplicates
                pnames.Add(pname);
            } // for
            sb.Append(")");

            res.CommandText = sb.ToString();
            res.CommandType = CommandType.Text;

            return res;
        }

        /// <summary>
        /// Used in order to avoid breaking naming rules (e.g., when a table has
        /// a name in SQL Server that cannot be used as a basis for a matching index
        /// name in SQLite).
        /// </summary>
        /// <param name="str">The name to change if necessary</param>
        /// <param name="names">Used to avoid duplicate names</param>
        /// <returns>A normalized name</returns>
        private static string GetNormalizedName(string str, List<string> names)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetterOrDigit(str[i]) || str[i] == '_')
                    sb.Append(str[i]);
                else
                    sb.Append("_");
            } // for

            // Avoid returning duplicate name
            if (names.Contains(sb.ToString()))
                return GetNormalizedName(sb.ToString() + "_", names);
            else
                return sb.ToString();
        }

        /// <summary>
        /// Matches SQL Server types to general DB types
        /// </summary>
        /// <param name="cs">The column schema to use for the match</param>
        /// <returns>The matched DB type</returns>
        private static DbType GetDbTypeOfColumn(DataColumn cs)
        {
            if (cs.DataType == typeof(byte))    //.ToString() == "tinyint")
                return DbType.Byte;
            if (cs.DataType == typeof(int))
                return DbType.Int32;
            if (cs.DataType == typeof(Int16))
                return DbType.Int16;
            if (cs.DataType == typeof(Int64))
                return DbType.Int64;
            if (cs.DataType == typeof(bool))
                return DbType.Boolean;
            if (cs.DataType == typeof(string))  
                return DbType.String;
            if (cs.DataType == typeof(float))
                return DbType.Double;
            if (cs.DataType == typeof(double))
                return DbType.Single;
            if (cs.DataType == typeof(byte[]))
                return DbType.Binary;
            if (cs.DataType == typeof(double))
                return DbType.Double;
            if (cs.DataType == typeof(DateTime)) 
                return DbType.DateTime;
            if (cs.DataType == typeof(Guid))
                return DbType.Guid;

            //_log.Error("illegal db type found");
            throw new ApplicationException("Illegal DB type found (" + cs.DataType.ToString() + ")");
        }

        private static string BuildCreateTableQuery(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder PrimaryKeySB = new StringBuilder();

            sb.Append("CREATE TABLE [" + dt.TableName + "] (\n");

            bool pkey = false;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataColumn col = dt.Columns[i];
                string cline = BuildColumnStatement(col, dt, ref pkey);
                sb.Append(cline);
                if (i < dt.Columns.Count - 1)
                    sb.Append(",\n");

                if (col.ColumnName.ToUpper() == (dt.TableName + "ID").ToUpper())
                {
                    string PrimaryKeyName = dt.TableName + "ID";
                    PrimaryKeySB.Append(",\n");
                    PrimaryKeySB.Append("    PRIMARY KEY (");
                    PrimaryKeySB.Append("[" + PrimaryKeyName + "]");
                    PrimaryKeySB.Append(")\n");
                }
            } // foreach

            sb.Append(PrimaryKeySB.ToString());

            sb.Append("\n");
            sb.Append(");\n");

            string query = sb.ToString();
            return query;
        }

        private static string BuildColumnStatement(DataColumn col, DataTable ts, ref bool pkey)
        {
            bool IsCaseSensitiviteValue = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("\t[" + col.ColumnName + "]\t");

            switch (col.DataType.Name)
            {
                case "Int64":
                    sb.Append("integer");
                    break;
                case "Int32":
                    sb.Append("integer");
                    break;
                case "Boolean":
                    sb.Append("integer");
                    break;
                case "Decimal":
                    sb.Append("real");
                    break;
                case "String":
                    sb.Append("text");
                    IsCaseSensitiviteValue = true;
                    break;
                case "DateTime":
                    sb.Append("datetime");
                    break;
                case "Guid":
                    sb.Append("guid");
                    break;
                case "Single":
                    sb.Append("real");
                    break;
                default:
                    sb.Append("text");
                    IsCaseSensitiviteValue = true;
                    break;
            }

            if (col.MaxLength > 0)
                sb.Append("(" + col.MaxLength + ")");

            
            if (col.AllowDBNull == false)
                sb.Append(" NOT NULL");

            //if (col.IsCaseSensitivite.HasValue && !col.IsCaseSensitivite.Value)
            if(IsCaseSensitiviteValue)
                sb.Append(" COLLATE NOCASE");

            string defval = StripParens(col.DefaultValue.ToString());
            defval = DiscardNational(defval);
            //_log.Debug("DEFAULT VALUE BEFORE [" + col.DefaultValue + "] AFTER [" + defval + "]");
            if (defval != string.Empty && defval.ToUpper().Contains("GETDATE"))
            {
                //_log.Debug("converted SQL Server GETDATE() to CURRENT_TIMESTAMP for column [" + col.ColumnName + "]");
                sb.Append(" DEFAULT (CURRENT_TIMESTAMP)");
            }
            else if (defval != string.Empty && IsValidDefaultValue(defval))
                sb.Append(" DEFAULT " + defval);

            return sb.ToString();
        }

        /// <summary>
        /// Check if the DEFAULT clause is valid by SQLite standards
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsValidDefaultValue(string value)
        {
            if (IsSingleQuoted(value))
                return true;

            double testnum;
            if (!double.TryParse(value, out testnum))
                return false;
            return true;
        }

        private static bool IsSingleQuoted(string value)
        {
            value = value.Trim();
            if (value.StartsWith("'") && value.EndsWith("'"))
                return true;
            return false;
        }

        /// <summary>
        /// Discards the national prefix if exists (e.g., N'sometext') which is not
        /// supported in SQLite.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static string DiscardNational(string value)
        {
            Regex rx = new Regex(@"N\'([^\']*)\'");
            Match m = rx.Match(value);
            if (m.Success)
                return m.Groups[1].Value;
            else
                return value;
        }

        /// <summary>
        /// Strip any parentheses from the string.
        /// </summary>
        /// <param name="value">The string to strip</param>
        /// <returns>The stripped string</returns>
        private static string StripParens(string value)
        {
            Regex rx = new Regex(@"\(([^\)]*)\)");
            Match m = rx.Match(value);
            if (!m.Success)
                return value;
            else
                return StripParens(m.Groups[1].Value);
        }

        private static string GetSqlServerConnectionString(string address, string db)
        {
            string res = @"Data Source=" + address.Trim() +
                          ";Initial Catalog=" + db.Trim() + ";Integrated Security=SSPI;";
            return res;
        }

        private static string GetSqlServerConnectionString(string address, string db, string user, string pass)
        {
            string res = @"Data Source=" + address.Trim() +
                          ";Initial Catalog=" + db.Trim() + ";User ID=" + user.Trim() + ";Password=" + pass.Trim();
            return res;
        }

        //private string GetColumnValue(DataRow dr, DataColumn dc)
        //{
        //    string ReturnValue = "";
        //    switch (dc.DataType.Name)
        //    {
        //        case "Int64":
        //            ReturnValue = dr[dc].ToString();
        //            break;
        //        case "Int32":
        //            ReturnValue = dr[dc].ToString();
        //            break;
        //        case "Boolean":
        //            ReturnValue = dr[dc].ToString() == "False" ? "0" : "1";
        //            break;
        //        case "Decimal":
        //            ReturnValue = dr[dc].ToString();
        //            break;
        //        case "String":
        //            ReturnValue = DataAccessUtilities.GetDBStr( dr[dc].ToString());
        //            break;
        //        case "DateTime":
        //            ReturnValue = DataAccessUtilities.GetDBStr(dr[dc].ToString());
        //            break;
        //        case "Guid":
        //            ReturnValue = DataAccessUtilities.GetDBStr(dr[dc].ToString());
        //            break;
        //        default:
        //            ReturnValue = DataAccessUtilities.GetDBStr(dr[dc].ToString());
        //            break;
        //    }

        //    if (ReturnValue == "")
        //        ReturnValue = "null";

        //    return ReturnValue;
        //}
    }
}
