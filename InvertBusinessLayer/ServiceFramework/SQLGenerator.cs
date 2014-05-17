using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace InvertService.ServiceFramework
{
    public class SQLGenerator
    {

        //private String CurrentTableName = "";

        // Inserts the DataRow for the connection, returning the identity
        public string DataTableSQL(DataTable table)
        {
            //string AliasTableName = null;
            string SQL = "";

            

            foreach (DataRow dr in table.Rows)
            {

                SQL += DataRowSQL(dr);

                //if(dr.RowState == DataRowState.Added)
                //SQL += Environment.NewLine + " " + DataRowSQL(dr);
                //if(dr.RowState == DataRowState.Modified)
            }
            return SQL;
        }

        // Inserts the DataRow for the connection, returning the identity
        public string DataSetSQL(DataSet tables)
        {
            string SQL = " ";
            foreach (DataTable dt in tables.Tables)
            {
                SQL += Environment.NewLine + " " + DataTableSQL(dt);
            }
            return SQL;
        }

        private string GetTableName(string TableName)
        {
            string ReturnTableName = TableName;

            switch (TableName)
            {
                case "i9PersonAKA":
                    ReturnTableName = "i9Person";
                    break;
                default:
                    ReturnTableName = TableName;
                    break;
            }

            return ReturnTableName;
        }

        // Inserts the DataRow for the connection, returning the identity
        private string DataRowSQL(DataRow row)
        {
            //string SQL = BuildSQL(row);

            string SqlResults = "";

            if (row.RowState == DataRowState.Added)
                SqlResults = BuildInsertSQL(row);
            else if (row.RowState == DataRowState.Deleted)
                SqlResults = BuildDeleteSQL(row);
            else if (row.RowState == DataRowState.Modified)
                SqlResults = BuildUpdateSQL(row);
            else if (row.RowState == DataRowState.Unchanged)
            {
                //Do Nothing
                System.Diagnostics.Debug.WriteLine("DO Nothing");
            }
            //else
            //    results = "";

            if (string.IsNullOrEmpty(SqlResults) == false)
                SqlResults = Environment.NewLine + " " + SqlResults;

            return SqlResults;
        }


        private bool IsPrimaryKey(DataRow row, DataColumn column)
        {
            if (row.Table.PrimaryKey.Length <= 0)
                return false;

            foreach (DataColumn dc in row.Table.PrimaryKey)
            {
                if (dc.ColumnName == column.ColumnName)
                    return true;
            }

            return false;
        }

        private string BuildWhereClause(DataRow row)
        {
            if (row.Table.PrimaryKey.Length <= 0)
                return "";

            string PriColumnName = row.Table.PrimaryKey[0].ColumnName;
            string PriColumnValue = "";

            if (row.RowState == DataRowState.Deleted)
            {

                switch (row.Table.PrimaryKey[0].DataType.Name.ToLower())
                {
                    case "string":
                        PriColumnValue = SQLUtility.SQLString(row[row.Table.PrimaryKey[0], DataRowVersion.Original].ToString());
                        break;
                    case "guid":
                        PriColumnValue = SQLUtility.SQLString(row[row.Table.PrimaryKey[0], DataRowVersion.Original].ToString());
                        break;
                    default:
                        PriColumnValue = row[row.Table.PrimaryKey[0], DataRowVersion.Original].ToString();
                        break;
                }
            }
            else
            {

                switch (row.Table.PrimaryKey[0].DataType.Name.ToLower())
                {
                    case "string":
                        PriColumnValue = SQLUtility.SQLString(row[row.Table.PrimaryKey[0]].ToString());
                        break;
                    case "guid":
                        PriColumnValue = SQLUtility.SQLString(row[row.Table.PrimaryKey[0]].ToString());
                        break;
                    default:
                        PriColumnValue = row[row.Table.PrimaryKey[0]].ToString();
                        break;
                }
            }

            string WhereClause = " WHERE " + PriColumnName + " = " + PriColumnValue;

            return WhereClause;
        }

        private string BuildUpdateSQL(DataRow row)
        {
            DataTable table = row.Table;

            StringBuilder UpdateSql = new StringBuilder("UPDATE " + GetTableName(table.TableName) + " SET  ");
            string WhereClause = BuildWhereClause(row);
            bool bFirst = true;
            //bool bIdentity = false;
            //string identityType = null;

            foreach (DataColumn column in table.Columns)
            {
                if (column.AutoIncrement || IsPrimaryKey(row, column))
                {
                    //bIdentity = true;

                    //switch (column.DataType.Name)
                    //{
                    //    case "Int16":
                    //        identityType = "smallint";
                    //        break;
                    //    case "SByte":
                    //        identityType = "tinyint";
                    //        break;
                    //    case "Int64":
                    //        identityType = "bigint";
                    //        break;
                    //    case "Decimal":
                    //        identityType = "decimal";
                    //        break;
                    //    default:
                    //        identityType = "int";
                    //        break;
                    //}
                }
                else
                {
                    if (bFirst)
                    {
                        bFirst = false;
                    }
                    else
                    {
                        UpdateSql.Append(", ");
                    }

                    switch (column.DataType.Name)
                    {
                        case "Int16":
                            if (row[column] == DBNull.Value)
                                UpdateSql.Append(column.ColumnName + " = null " );
                            else
                                UpdateSql.Append(column.ColumnName + " = " + row[column].ToString());
                            break;
                        case "SByte":
                            if (row[column] == DBNull.Value)
                                UpdateSql.Append(column.ColumnName + " = null ");
                            else
                                UpdateSql.Append(column.ColumnName + " = " + row[column].ToString());
                            break;
                        case "Int64":
                            if (row[column] == DBNull.Value)
                                UpdateSql.Append(column.ColumnName + " = null ");
                            else
                                UpdateSql.Append(column.ColumnName + " = " + row[column].ToString());
                            break;
                        case "Decimal":
                            if (row[column] == DBNull.Value)
                                UpdateSql.Append(column.ColumnName + " = null ");
                            else
                                UpdateSql.Append(column.ColumnName + " = " + row[column].ToString());
                            break;
                        default:
                            if (row[column] == DBNull.Value)
                                UpdateSql.Append(column.ColumnName + " = null " );
                            else
                                UpdateSql.Append(column.ColumnName + " = " + SQLUtility.SQLString(row[column].ToString()));
                            break;
                    }
                }
            }

            UpdateSql.Append(WhereClause);

            //if (bIdentity)
            //{
            //    UpdateSql.Append("; SELECT CAST(scope_identity() AS ");
            //    UpdateSql.Append(identityType);
            //    UpdateSql.Append(")");
            //}

            return UpdateSql.ToString();
        }

        private string BuildDeleteSQL(DataRow row)
        {
            //string id = (string)row["", DataRowVersion.Original];
            //DataRow OrigRow = new DataRow();
            //OrigRow.
            //OrigRow.RejectChanges();

            //DataRow OrigRow = row.Table.NewRow();
            //OrigRow.ItemArray = (object[])row.ItemArray.Clone();


            DataTable table = row.Table;
            string SQLResults = "DELETE FROM  " + GetTableName(table.TableName) + " " + BuildWhereClause(row);
            return SQLResults;
        }

        // Returns a SQL INSERT command. Assumes autoincrement is identity (optional)
        private string BuildInsertSQL(DataRow row)
        {
            DataTable table = row.Table;

            StringBuilder sql = new StringBuilder("INSERT INTO " + GetTableName(table.TableName) + " (");
            StringBuilder values = new StringBuilder("VALUES (");
            bool bFirst = true;
            bool bIdentity = false;
            string identityType = null;

            foreach (DataColumn column in table.Columns)
            {
                if (column.AutoIncrement)
                {
                    bIdentity = true;

                    switch (column.DataType.Name)
                    {
                        case "Int16":
                            identityType = "smallint";
                            break;
                        case "SByte":
                            identityType = "tinyint";
                            break;
                        case "Int64":
                            identityType = "bigint";
                            break;
                        case "Decimal":
                            identityType = "decimal";
                            break;
                        default:
                            identityType = "int";
                            break;
                    }

                }
                else
                {
                    if (bFirst)
                    {
                        bFirst = false;
                    }
                    else
                    {
                        sql.Append(", ");
                        values.Append(", ");
                    }

                    sql.Append(column.ColumnName);

                    switch (column.DataType.Name)
                    {
                        case "Int16":
                            if(row[column] == DBNull.Value)
                                values.Append(" null ");
                            else
                                values.Append(row[column].ToString());
                            break;
                        case "SByte":
                            if(row[column] == DBNull.Value)
                                values.Append(" null ");
                            else
                                values.Append(row[column].ToString());
                            break;
                        case "Int64":
                            if(row[column] == DBNull.Value)
                                values.Append(" null ");
                            else
                                values.Append(row[column].ToString());
                            break;
                        case "Decimal":
                            if(row[column] == DBNull.Value)
                                values.Append(" null ");
                            else
                                values.Append(row[column].ToString());
                            break;
                        default:
                            if(row[column] == DBNull.Value)
                                values.Append(" null ");
                            else
                                values.Append(SQLUtility.SQLString(row[column].ToString()));
                            break;
                    }
                }
            }

            sql.Append(") ");
            sql.Append(values.ToString());
            sql.Append(")");

            if (bIdentity)
            {
                sql.Append("; SELECT CAST(scope_identity() AS ");
                sql.Append(identityType);
                sql.Append(")");
            }

            return sql.ToString();
        }

        //private string BuildSQL(DataRow row)
        //{
        //    string results = "";
        //    if (row.RowState == DataRowState.Added)
        //        results = BuildInsertSQL(row);
        //    else if (row.RowState == DataRowState.Deleted)
        //        results = BuildDeleteSQL(row);
        //    else if (row.RowState == DataRowState.Modified)
        //        results = BuildUpdateSQL(row);
        //    else
        //        results = "";

        //    return results;
        //}

    }
}