using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

//using Invert911.InvertCommon.Data;
using Invert911.InvertCommon.Framework;
using Invert911.InvertCommon.Framework.ClientData;

namespace Invert911.InvertCommon.Bind
{
    public class ListManager
    {
        #region Variables

        private List<ListItem> m_MasterList;    
        private int m_MasterIndex;              //Cursor positon
        private ClientDataAccess m_DataAccess;

        private string m_SQLStatement;
        private string m_KeyColumnName;

        #endregion

        #region Constructors

        public ListManager(ClientDataAccess da)
        {
            m_DataAccess = da;
            m_MasterList = new List<ListItem>();
            m_MasterIndex = -1;
        }

        #endregion

        #region Properties

        public int Count
        {
            get { return m_MasterList.Count; }
        }

        public bool IsFirst
        {
            get 
            { 
                if (m_MasterList.Count < 0)
                    return false;
                else if (m_MasterIndex == 0)
                    return true;
                else
                    return false;
            }
        }

        public bool HasPrev
        {
            get
            {
                if (m_MasterList.Count < 0)
                    return false;
                else if (m_MasterIndex > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool HasNext
        {
            get
            {
                if (m_MasterList.Count < 0)
                    return false;
                else if (m_MasterIndex < (m_MasterList.Count - 1))
                    return true;
                else
                    return false;
            }
        }

        public bool IsLast
        {
            get
            {
                if (m_MasterList.Count < 0)
                    return false;
                else if (m_MasterIndex == (m_MasterList.Count - 1))
                    return true;
                else
                    return false;
            }
        }

        public bool CurrentIndexValid
        {
            get
            {
                if (m_MasterList.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public string CurrentKey
        {
            get { return m_MasterList[m_MasterIndex].Key; }
        }

        public int CurrentIndex
        {
            get { return m_MasterIndex; }
        }



        #endregion

        #region Methods

        public void Load(string SQLStatement, string KeyColumnName)
        {
            m_MasterList = new List<ListItem>();
            m_MasterIndex = -1;
            
            m_SQLStatement = SQLStatement;
            m_KeyColumnName = KeyColumnName;

            //IDataReader dr = m_DataAccess.GetDataReader(SQLStatement);
            //while(dr.Read())
            //{
            //    ListItem li = new ListItem(dr[KeyColumnName].ToString());
            //    m_MasterList.Add(li);
            //}
            //dr.Close();

            if(m_MasterList.Count > 0 )
                m_MasterIndex = 0;   // Set it to the first item in the list.
        }

        public void ReLoad()
        {
            Load(m_SQLStatement, m_KeyColumnName);
        }

        public void MoveFirst()
        {
            if (m_MasterList.Count > 0)
                m_MasterIndex = 0;
            else
                m_MasterIndex = -1;
        }

        public void MoveLast()
        {
            if (m_MasterList.Count > 0)
                m_MasterIndex = m_MasterList.Count - 1;
            else
                m_MasterIndex = -1;
        }

        public void MoveNext()
        {
            if (this.HasNext)
                m_MasterIndex += 1;
        }

        public void MovePrev()
        {
            if (this.HasPrev)
                m_MasterIndex -= 1;
            
        }

        public bool ContainsKey(string IndexKey)
        {
            for (int i = 0; i < m_MasterList.Count; i++)
            {
                if (IndexKey.ToLower().Trim() == m_MasterList[i].Key.ToLower().Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public void MoveTo(string IndexKey)
        {
            for (int i = 0; i < m_MasterList.Count; i++)
            {
                if (IndexKey.ToLower().Trim() == m_MasterList[i].Key.ToLower().Trim())
                {
                    m_MasterIndex = i;
                }
            }
        }

        public ListItem this[int Index]
        {
            get
            {
                return m_MasterList[Index];
            }
        }

        #endregion

      #region Sample Code
        //public string GetValue(string SectionName, string KeyName, string DefaultValue)
        //{
        //    bool FoundGroup = false;
        //    foreach (string line in m_ConfigFileContents)
        //    {
        //        //Check to see if this line is a Section header
        //        if (line.Trim().ToLower().StartsWith("[") && line.Trim().ToLower().EndsWith("]"))
        //        {
        //            if (line.Trim().ToLower().StartsWith("[" + SectionName.ToLower() + "]"))
        //                FoundGroup = true;
        //            else
        //                FoundGroup = false;
        //        }
        //        //Check in the INI section for the KeyName
        //        if (FoundGroup == true)
        //        {
        //            if (ContainsKey(line, KeyName))
        //            {
        //                return GetKeyValue(line);
        //            }
        //        }
        //    }
        //    //Section and Key not found - return default value.
        //    return DefaultValue;
        //}

        //public void SetValue(string SectionName, string KeyName, string Value)
        //{
        //    bool FoundGroup = false;
        //    if (SectionExists(SectionName) == false)
        //    {
        //        //Section, KeyName does not exist - add Section, Key and Value.
        //        m_ConfigFileContents.Add("");  //Leave a space between the sections
        //        m_ConfigFileContents.Add("[" + SectionName + "]");
        //        m_ConfigFileContents.Add(KeyName + "=" + Value);
        //        return;
        //    }
        //    for (int lineNumber = 0; lineNumber < m_ConfigFileContents.Count; lineNumber++)
        //    {
        //        //Check to see if this line is a Section header
        //        if (m_ConfigFileContents[lineNumber].Trim().ToLower().StartsWith("[") && m_ConfigFileContents[lineNumber].Trim().ToLower().EndsWith("]"))
        //        {
        //            if (m_ConfigFileContents[lineNumber].Trim().ToLower().StartsWith("[" + SectionName.ToLower() + "]"))
        //            {
        //                FoundGroup = true;
        //            }
        //            else
        //            {
        //                if (FoundGroup)
        //                {
        //                    //End of Section and could find keyName.
        //                    //insert the Key and Value at the end of the section.
        //                    m_ConfigFileContents.Insert(lineNumber, KeyName + "=" + Value);
        //                    return;
        //                }
        //                FoundGroup = false;
        //            }
        //        }
        //        //Check in the INI section for the KeyName
        //        if (FoundGroup == true)
        //        {
        //            if (m_ConfigFileContents[lineNumber].Trim().StartsWith(";") == false)
        //            {
        //                if (ContainsKey(m_ConfigFileContents[lineNumber], KeyName))
        //                {
        //                    m_ConfigFileContents[lineNumber] = SetKeyValue(m_ConfigFileContents[lineNumber], Value);
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //    if (FoundGroup)
        //    {
        //        //End of Section, and File and could find keyName.
        //        //insert the Key and Value at the end of the section.
        //        m_ConfigFileContents.Insert((m_ConfigFileContents.Count), KeyName + "=" + Value);
        //        return;
        //    }
        //}

        //private string GetKeyValue(string INILine)
        //{
        //    string INIValue = "";
        //    if (INILine.Contains("="))
        //    {
        //        int EqualIndex = INILine.IndexOf("=");
        //        INIValue = INILine.Substring(EqualIndex + 1, (INILine.Length - (EqualIndex + 1)));
        //        if (INIValue.Contains(";"))
        //        {
        //            int ColonIndex = INIValue.IndexOf(";");
        //            INIValue = INIValue.Substring(0, ColonIndex);
        //        }
        //    }
        //    return INIValue.Trim();
        //}

        //private bool ContainsKey(string INILine, string KeyName)
        //{
        //    string INIKey = "";
        //    if (INILine.Contains("="))
        //    {
        //        int EqualIndex = INILine.IndexOf("=");
        //        INIKey = INILine.Substring(0, EqualIndex);
        //        if (INIKey.Trim().ToLower() == KeyName.Trim().ToLower())
        //            return true;
        //    }
        //    else
        //    {
        //        if (INILine.Trim().ToLower() == KeyName.Trim().ToLower())
        //            return true;
        //    }
        //    return false;
        //}

        //private string SetKeyValue(string INILine, string NewValue)
        //{
        //    string INIKey = "";
        //    string INIValue = "";
        //    string INIComment = "";
        //    string NewINILine = "";

        //    if (INILine.Contains("="))
        //    {
        //        int EqualIndex = INILine.IndexOf("=");
        //        INIKey = INILine.Substring(0, EqualIndex);
        //        INIValue = INILine.Substring(EqualIndex + 1, (INILine.Length - (EqualIndex + 1)));
        //        if(INIValue.Contains(";"))
        //        {
        //            int ColonIndex = INIValue.IndexOf(";");
        //            INIComment = INIValue.Substring(ColonIndex + 1, (INIValue.Length - ColonIndex + 1));
        //            INIValue = INIValue.Substring(0, ColonIndex);
        //        }
        //        if(INIComment != "")
        //            NewValue = NewValue + " ; " + INIComment;
        //        NewINILine = INIKey + "=" + NewValue;
        //    }
        //    else
        //    {
        //        NewINILine = INILine + "=" + NewValue;
        //    }
        //    return NewINILine;
        //}

        //public void SectionAdd(string SectionName)
        //{
        //    foreach (string line in m_ConfigFileContents)
        //    {
        //        if (line.Trim().ToLower().StartsWith("[" + SectionName.ToLower() + "]"))
        //        {
        //            //Found the Group so do not add the group.
        //            return;
        //        }
        //    }
        //    m_ConfigFileContents.Add("[" + SectionName + "]");
        //}

        //public bool SectionExists(string SectionName)
        //{
        //    foreach (string line in m_ConfigFileContents)
        //    {
        //        if (line.Trim().ToLower().StartsWith("[" + SectionName.ToLower() + "]"))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public void Save()
        //{
        //    if (File.Exists(m_ConfigFilePath))
        //    {
        //        File.Delete(m_ConfigFilePath);
        //    }
        //    File.WriteAllLines(m_ConfigFilePath, m_ConfigFileContents.ToArray());
        //}

        //private void LoadConfigFile()
        //{
        //    if (File.Exists(m_ConfigFilePath) == false)
        //    {
        //        File.CreateText(m_ConfigFilePath);
        //        if (File.Exists(m_ConfigFilePath) == false)
        //        {
        //            throw new Exception("Configuration file does not exist:  " + m_ConfigFilePath);
        //        }
        //    }
        //    string[] m_Contents = File.ReadAllLines(m_ConfigFilePath);
        //    m_ConfigFileContents = new List<string>(m_Contents);
        //}
      #endregion
    }
}