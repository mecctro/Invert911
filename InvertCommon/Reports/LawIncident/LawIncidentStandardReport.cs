using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Invert911.InvertCommon.Reports.LawIncident
{
    class LawIncidentStandardReport
    {
        public string PrintReport(DataSet ds)
        {
            string tab = "\t";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine(tab + "<body>");

            sb.AppendLine(SubHeader("Incident Detail"));

            sb.Append(PrintVerticalDataTable(ds.Tables["i9LawIncident"]   ));

            foreach (DataRow dr in ds.Tables["i9Person"].Rows)
            {
                sb.AppendLine(tab + tab + "<BR>");
                sb.AppendLine(tab + tab + "<BR>");
                sb.AppendLine(SubHeader("<B>Person</B>"));
                
                sb.AppendLine(tab + tab + "<table  border=\"1\" width=\"100%\">");
                sb.AppendLine( PrintVerticalDataRow(dr, ds.Tables["i9Person"]));
                sb.AppendLine(tab + tab + "</table>");
            }
            
            sb.AppendLine(tab + "</body>");
            sb.AppendLine("</html>");

            string sss = sb.ToString();
            return sss;
        }

        private string SubHeader(String SubHeaderText)
        {
            return "<H2>" + SubHeaderText + "</H2><BR>";
        }

        private string PrintVerticalDataRow(DataRow dr, DataTable dt )
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataColumn dc in dt.Columns)
            {
                string cellValue = dr[dc] != null ? dr[dc].ToString() : "";

                if (String.IsNullOrEmpty(cellValue) )
                {
                    //Do Nothing 
                }
                else if (dc.ColumnName.ToUpper().EndsWith("ID")) 
                {
                    //Do Nothing
                }
                else
                {
                    sb.AppendFormat("<tr><td align=\"right\">{0}</td><td><span style=\"font-weight:bold\">{1}</span></td></tr>", dc.ColumnName, cellValue);
                }

            }

            return sb.ToString();
        }

        public string PrintVerticalDataTable(DataTable dt)
        {
            string tab = "\t";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(tab + tab + "<table  border=\"1\" width=\"100%\">");

            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine( PrintVerticalDataRow(dr, dt) );
            }

            sb.AppendLine(tab + tab + "</table>");
            string sss = sb.ToString();
            return sss;
        }
    }
}
