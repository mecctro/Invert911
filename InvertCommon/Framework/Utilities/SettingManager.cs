using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Invert911.InvertCommon.Framework.Utilities;
using System.Data;

namespace Invert911.InvertCommon.Utilities
{
    public class SettingManager
    {
        private static SettingManager m_Instance = null;
        private static readonly object m_Padlock = new object();
        private string m_ConfigFilePath;
        //private List<string> m_ConfigFileContents;
        private string m_AppDataPath;
        public DataSet LoginDataSet { get; set; }

        

        private SettingManager()
		{
            //m_ConfigFilePath = ConfigFilePath;
            SetConfigFile();
            //LoadConfigFile();
        }

        public static SettingManager Instance
        {
            get
            {
                lock (m_Padlock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new SettingManager();
                    }
                }
                return m_Instance;
            }   
        }



        public string AppDataPath
        {
            get { return m_AppDataPath; }
        }

        public string LoginPersonnelID 
        { 
            get
            {
                if(LoginDataSet == null)
                    return "";
                else
                    return LoginDataSet.Tables["i9SysPersonnel"].Rows[0]["i9SysPersonnelID"].ToString();
            } 
        }

        public string AgencyID
        {
            get
            {
                if(LoginDataSet == null)
                    return "";
                else
                    return LoginDataSet.Tables["i9SysPersonnel"].Rows[0]["i9AgencyID"].ToString();
            }
        }

        public string BadgeNumber
        {
            get
            {
                if(LoginDataSet == null)
                    return "";
                else
                    return LoginDataSet.Tables["i9SysPersonnel"].Rows[0]["BadgeNumber"].ToString();
            }
        }

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
        //            if(m_ConfigFileContents[lineNumber].Trim().StartsWith(";") == false)
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


        private void SetConfigFile()
        {

            try
            {
                //AppDomain.CurrentDomain.BaseDirectory
                DirectoryInfo di = Directory.GetParent(Application.CommonAppDataPath);
                m_AppDataPath = di.FullName;

                if (Directory.Exists(m_AppDataPath) == false)
                    Directory.CreateDirectory(m_AppDataPath);
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage(ex);
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string ConfigINIFilename = Application.ExecutablePath;
            ConfigINIFilename = ConfigINIFilename.Substring(ConfigINIFilename.LastIndexOf("\\") + 1);
            ConfigINIFilename = ConfigINIFilename.ToLower().Replace(".exe", ".ini");
            
            //ConfigINIPath = Application.StartupPath + "\\" + ConfigINIPath;
            //m_ConfigFilePath = ConfigINIPath;

            m_ConfigFilePath = Path.Combine(m_AppDataPath, @"\" + ConfigINIFilename);
           
        }

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
    }
}