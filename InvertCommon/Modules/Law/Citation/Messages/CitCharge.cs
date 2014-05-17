using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Xml;
using System.IO;

namespace LawRecords.Citation
{
    public class CitCharge 
    {
        private string m_Section;
        private string m_Code;
        private string m_Definition;
        private string m_Level;
        private string m_Counts;
        private bool? m_Correctable;
        private string m_Key;

        public CitCharge()
        {
            m_Key = Guid.NewGuid().ToString();
            m_Section = "";
            m_Code = "";
            m_Definition = "";
            m_Level = "";
            m_Counts = "";
            m_Correctable = null;
        }

        public string Key
        {
            get { return m_Key; }
        }

        public string Section
        {
            get { return m_Section; }
            set { m_Section = value; }
        }

        public string Code
        {
            get { return m_Code; }
            set { m_Code = value; }
        }

        public string Definition
        {
            get { return m_Definition; }
            set { m_Definition = value; }
        }

        public string Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        public string Counts
        {
            get { return m_Counts; }
            set { m_Counts = value; }
        }

        public bool? Correctable
        {
            get { return m_Correctable; }
            set { m_Correctable = value; }
        }
    }
}
