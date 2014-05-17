using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Invert911.InvertCommon.Reports
{
    class ReportUtility
    {
        public string PrintHorizontalDataSet(DataSet ds)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataTable dt in ds.Tables)
            {
                sb.Append(PrintHorizontalDataTable(dt));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Reference Notes:
        /// http://stackoverflow.com/questions/9792882/creating-html-from-a-datatable-using-c-sharp
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string PrintHorizontalDataTable(DataTable dt)
        {
            //dt.Rows.Add(new object[] { "a", "b", "c" });
            //dt.Rows.Add(new object[] { "d", "e", "f" });

            string tab = "\t";

            StringBuilder sb = new StringBuilder();

            //==================================================
            // HTML Table
            //==================================================
            sb.AppendLine("<html>");
            sb.AppendLine(tab + "<body>");


            sb.AppendLine(tab + tab + "<table>");

            //==================================================
            // headers.
            //==================================================
            sb.Append(tab + tab + tab + "<tr>");

            foreach (DataColumn dc in dt.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", dc.ColumnName);
            }

            sb.AppendLine("</tr>");

            //==================================================
            // Data rows
            //==================================================
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(tab + tab + tab + "<tr>");

                foreach (DataColumn dc in dt.Columns)
                {
                    string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
                    sb.AppendFormat("<td>{0}</td>", cellValue);
                }

                sb.AppendLine("</tr>");
            }

            sb.AppendLine(tab + tab + "</table>");


            //==================================================
            // End HTML Table
            //==================================================
            sb.AppendLine(tab + "</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        public string PrintVerticalDataSet(DataSet ds)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataTable dt in ds.Tables)
            {
                sb.Append(PrintVerticalDataTable(dt));
            }

            return sb.ToString();
        }

        public string PrintVerticalDataTable(DataTable dt)
        {
            //dt.Rows.Add(new object[] { "a", "b", "c" });
            //dt.Rows.Add(new object[] { "d", "e", "f" });

            string tab = "\t";

            StringBuilder sb = new StringBuilder();

            //==================================================
            // HTML Table
            //==================================================
            //sb.AppendLine("<html>");
            //sb.AppendLine(tab + "<body>");

            //sb.AppendLine( @"<table  border= "" "" width=""100%"">");
            sb.AppendLine(tab + tab + "<table  border=\"1\" width=\"100%\">");

            //==================================================
            // headers.
            //==================================================
            //sb.Append(tab + tab + tab + "<tr>");

            //foreach (DataColumn dc in dt.Columns)
            //{
            //    sb.AppendFormat("<td>{0}</td>", dc.ColumnName);
            //}

            //sb.AppendLine("</tr>");

            //==================================================
            // Data rows
            //==================================================
            foreach (DataRow dr in dt.Rows)
            {
                //sb.Append(tab + tab + tab + "<tr>");

                foreach (DataColumn dc in dt.Columns)
                {
                    string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
                    sb.AppendFormat("<tr><td align=\"right\">{0}</td><td><span style=\"font-weight:bold\">{1}</span></td></tr>", dc.ColumnName, cellValue);
                }

                //sb.AppendLine("</tr>");
            }

            sb.AppendLine(tab + tab + "</table>");


            //==================================================
            // End HTML Table
            //==================================================
            //sb.AppendLine(tab + "</body>");
            //sb.AppendLine("</html>");

            return sb.ToString();
        }


    }
}
