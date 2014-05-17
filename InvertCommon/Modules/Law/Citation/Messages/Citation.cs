using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Invert911.InvertCommon;
using Invert911.InvertCommon.Utilities;

namespace Invert911.Citation
{
    public class Citation
    {
        private DataSet     m_DataSet;
        //private CitCharges  m_CitCharges;
        private string      m_GUID;
        //private string      m_FilePath;
        private string      m_Status;
        private bool        m_CitationLocked;
        private bool        m_HasIssues;
        //private string      m_UnitNumber;

        public Citation()
        {
            m_DataSet = new DataSet();
            m_GUID = Guid.NewGuid().ToString();
            m_CitationLocked = false;
        }

        public Citation(string FilePath)
        {
            m_CitationLocked = false;
            m_DataSet = new DataSet();
            //m_FilePath = FilePath;
            //LoadFile(m_FilePath);
        }

        public bool HasIssues
        {
            get 
            { 
                if(m_HasIssues)
                    return true;
                else
                    return false;

                //else if (String.IsNullOrEmpty(GetColumnValue("CITATION_CITATIONWRITER", "SIGNATURE_INK", "")))
                //    return true;

            }
            set { m_HasIssues = value; }
        }

        public bool CitationLocked
        {
            get { return m_CitationLocked; }
            set { m_CitationLocked = value; }
        }

        public string RecordedDateTime
        {
            get
            {
                string returnValue = "";
                try
                {
					//DataTable dt = m_DataSet.Tables["CITATION"];
					//string s = dt.Rows[0]["VIOLATION_DATE"].ToString();

					//DateTime TheDateTime = Convert.ToDateTime(s);
					//returnValue = TheDateTime.ToString("MM/dd/yyyy HH:mm");
                }
                catch {}

                return returnValue;
            }
        }

        public string Location
        {
            get
            {
                string returnValue = "";
                try
                {
                    DataTable dt = m_DataSet.Tables["CITATION"];
                    returnValue = dt.Rows[0]["ADDR_NO"].ToString();
                }
                catch { }

                try
                {
                    DataTable dt = m_DataSet.Tables["CITATION"];
                    if (returnValue == "")
                        returnValue = dt.Rows[0]["STREET"].ToString();
                    else
                        returnValue = returnValue + " " +  dt.Rows[0]["STREET"].ToString();
                }
                catch { }

                try
                {
                    DataTable dt = m_DataSet.Tables["CITATION"];
                    if(returnValue == "")
                        returnValue = dt.Rows[0]["XSTREET1"].ToString();
                    else
                        returnValue = returnValue + " / " + dt.Rows[0]["XSTREET1"].ToString();
                }
                catch { }

                return returnValue;
            }
        }

        public string CitationNumber
        {
            get 
            { 
                //TODO:  Need to change this to the real CitationNumber
                return m_GUID.Substring(0,8).ToUpper(); 
            }
        }

        public DataSet BindDataSet
        {
            get { return m_DataSet;  }
            set { m_DataSet = value; }
        }

        public string GetColumnValue(string TableName, string ColumnName, string DefaultValue)
        {
            string returnValue = "";
            if (m_DataSet.Tables.Contains(TableName))
            {
                DataTable t = m_DataSet.Tables[TableName];
                if (t.Columns.Contains(ColumnName))
                {
                    if (t.Rows.Count > 0)
                    {
                        returnValue = t.Rows[0][ColumnName].ToString();
                    }
                }
            }
            return returnValue;
        }

        public string Status
        {
            get 
            { 
                if(m_Status == null)
                    return "";  
                else
                    return m_Status.ToUpper();  
            }
            set { m_Status = value.ToUpper(); }
        }

        public string Charges
        {
            get { return ""; }
        }

		//public string Signature
		//{
		//    get 
		//    {
		//        return GetColumnValue("CITATION_CITATIONWRITER", "SIGNATURE_INK", "");
		//    }
		//    set 
		//    {
		//        SaveInfo("CITATION_CITATIONWRITER", "SIGNATURE_INK", value);  
		//    }
		//}

        public string Name
        {
            get
            {
                string CitationName = "";
                try
                {
                    if (m_DataSet.Tables.Contains("Alpha"))
                    {
                        DataTable dtAlpha = m_DataSet.Tables["ALPHA"];
                        if (dtAlpha.Rows.Count > 0)
                        {
                            if (dtAlpha.Columns.Contains("LAST_NAME"))
                                CitationName += dtAlpha.Rows[0]["LAST_NAME"].ToString();

                            if (dtAlpha.Columns.Contains("FIRST_NAME"))
                                CitationName += " " + dtAlpha.Rows[0]["FIRST_NAME"].ToString();
                        }
                    }
                }
                catch { }

                return CitationName.Trim();
            }
        }

        public string Key
        {
            get { return m_GUID; }
        }

        //public string FilePath
        //{
        //    get { return m_FilePath; }
        //}

        private void SaveInfo(string TableName, string ColumnName, string dbValue)
        {
            try
            {
                DataTable dt;
                if (m_DataSet.Tables.Contains(TableName))
                    dt = m_DataSet.Tables[TableName];
                else
                    dt = m_DataSet.Tables.Add(TableName);

                if (dt.Rows.Count <= 0)
                    dt.Rows.Add(dt.NewRow());

                if (dt.Columns.Contains(ColumnName))
                {
                    dt.Rows[0][ColumnName] = dbValue;
                }
                else
                {
                    DataColumn dc = dt.Columns.Add(ColumnName);
                    dt.Rows[0][ColumnName] = dbValue;
                }
            }
            catch { }
        }

        //private void ClearData()
        //{
        //    m_GUID = "";
        //    m_FilePath = "";
        //    m_Status = "";
        //    m_DataSet = "";
        //    m_CitCharges = "";
        //    m_CitationLocked = false;
        //    m_HasIssues = false;
        //    m_UnitNumber = "";
        //}

        public void Save()
        {
            try
            {

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        //private bool LoadFile(string XmlBindFilePath)
        //{
        //    //Need a lot more error handle
        //    FileInfo fi = new FileInfo(XmlBindFilePath);
        //    if (fi.Exists == false)
        //        return false;

        //    if (fi.Extension.ToLower() != ".xml")
        //        return false;

        //    m_DataSet = new DataSet();
        //    m_GUID = "";
        //    m_FilePath = XmlBindFilePath;

        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(XmlBindFilePath);
        //    //return this.Load(xmlDoc);
        //    return true;
        //}

        private string LoadInfo(string TableName, string ColumnName, string DefaultValue)
        {
            string ReturnValue = DefaultValue;
            try
            {
                if (m_DataSet.Tables.Contains(TableName))
                {
                    DataTable dt = m_DataSet.Tables[TableName];
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Columns.Contains(ColumnName))
                        {
                            ReturnValue = dt.Rows[0][ColumnName].ToString();
                        }
                    }
                }
            }
            catch { }

            return ReturnValue;
        }
    }
}