using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace InvertService.ServiceFramework
{
    public class ReportNumberManager
    {

        public static string GetReportNumber(string i9ModuleID)
        {
            SQLAccess da = new SQLAccess();
 
            string ReportNumber = "";
            //need a transaction
            StringBuilder SQLReportNumber = new StringBuilder();
            SQLReportNumber.AppendLine(" BEGIN TRAN T1 ");
            SQLReportNumber.AppendLine(" if EXISTS( select * from i9ModuleReportNumber where i9ModuleID = " + SQLUtility.SQLString(i9ModuleID) + " and ResetReportNumber = 'DAY' ) ");
            SQLReportNumber.AppendLine(" BEGIN ");
            SQLReportNumber.AppendLine("     if EXISTS( select * from i9ModuleReportNumber where i9ModuleID = " + SQLUtility.SQLString(i9ModuleID) + " and CONVERT(date, LastUpdate) != CONVERT(date, getdate()) ) ");
            SQLReportNumber.AppendLine("     BEGIN ");
            SQLReportNumber.AppendLine("         update i9ModuleReportNumber set LastUpdate = GetDate(), ReportNumber = StartNumber WHERE i9ModuleID = " + SQLUtility.SQLString(i9ModuleID) + " ");
            SQLReportNumber.AppendLine("     END ");
            SQLReportNumber.AppendLine(" END ");
            SQLReportNumber.AppendLine(" ELSE ");
            SQLReportNumber.AppendLine(" BEGIN ");
            SQLReportNumber.AppendLine("     if EXISTS( select * from i9ModuleReportNumber where i9ModuleID = " + SQLUtility.SQLString(i9ModuleID) + " and year(LastUpdate) != year(getdate()) ) ");
            SQLReportNumber.AppendLine("     BEGIN ");
            SQLReportNumber.AppendLine("         update i9ModuleReportNumber set LastUpdate = GetDate(), ReportNumber = StartNumber WHERE i9ModuleID = " + SQLUtility.SQLString(i9ModuleID) + " ");
            SQLReportNumber.AppendLine("     END ");
            SQLReportNumber.AppendLine(" END ");

            SQLReportNumber.AppendLine(" Update i9ModuleReportNumber set ReportNumber = ReportNumber + 1 WHERE i9ModuleID = " + SQLUtility.SQLString(i9ModuleID) + "  ");
            SQLReportNumber.AppendLine(" select * from i9ModuleReportNumber ");
            SQLReportNumber.AppendLine(" COMMIT TRAN T1 ");

            string SQL = SQLReportNumber.ToString();
            DataTable dt = da.GetDataTable(SQLReportNumber.ToString(), "Results");
            if (dt.Rows.Count > 0)
            {
                ReportNumber = dt.Rows[0]["ReportNumber"].ToString();

                if (DBNull.Value != dt.Rows[0]["NumberPrefix"])
                    if (String.IsNullOrEmpty(dt.Rows[0]["NumberPrefix"].ToString()) == false)
                        ReportNumber = DateTime.Now.ToString(dt.Rows[0]["NumberPrefix"].ToString()) + ReportNumber;

                if (DBNull.Value != dt.Rows[0]["NumberSubFix"])
                    if (String.IsNullOrEmpty(dt.Rows[0]["NumberSubFix"].ToString()) == false)
                        ReportNumber = ReportNumber + DateTime.Now.ToString(dt.Rows[0]["NumberSubFix"].ToString());
            }

            return ReportNumber;
        }
    }
}