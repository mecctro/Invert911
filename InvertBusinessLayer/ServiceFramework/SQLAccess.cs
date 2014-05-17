using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

using Invert911.InvertCommon.Utilities;

using Microsoft.Win32;
using System.Web.Hosting;

namespace InvertService.ServiceFramework
{
    public class SQLAccess
	{
        //private SqlConnection m_Connection = null;
        public SQLAccess()
        {
            
        }

        private SqlConnection GetSqlConnection()
        {
            string ConnectionString = "";
            
            if (String.IsNullOrEmpty(ConfigurationManager.Instance.ConnectionString) == false)
            {
                // SQL Server Database - Run from Invert911 production
                ConnectionString = ConfigurationManager.Instance.ConnectionString;
            }
            else
            {
                ConnectionString = GetDemoConnectionString();
            }

            SqlConnection lConnection = new SqlConnection(ConnectionString);  
            lConnection.Open();

            return lConnection;
        }

        private string GetDemoConnectionString()
        {
            string ConnectionString = "";
            string ExpressInstance = GetExpressInstance();

            //Running in a windows client - demo mode 
            if (Environment.UserInteractive && !HostingEnvironment.IsHosted)
            {
                // SQL Server Express Database - Run from Invert911 Lite - Dev Demo
                string FolderPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);  //starup path
                string DatabasePath = System.IO.Path.Combine( FolderPath , @"Invert911.mdf");

                if (File.Exists(DatabasePath))
                {
                    Console.WriteLine("DatabasePath: " + DatabasePath);
                    //Running in Demo mode with the database in the app startup folder
                }
                else
                {
                    //Running in Demo and in the development envirorment
                    FolderPath = new DirectoryInfo(FolderPath).Parent.Parent.FullName;
                    DatabasePath = System.IO.Path.Combine(FolderPath, @"InvertBusinessLayer\Database\Invert911.mdf");
                }
                ConnectionString = ExpressInstance + @";AttachDbFilename=" + DatabasePath + ";Integrated Security=True";
            }
            else
            {
                //Running in IIS as development mode.
                // SQL Server Express Database - Ran from a windows service - Dev
                string DatabasePath = System.IO.Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"Database\Invert911.mdf");
                ConnectionString = ExpressInstance + @";AttachDbFilename= " + DatabasePath + ";Integrated Security=True";
            }

            return ConnectionString;
        }

        private string GetExpressInstance()
        {
            string ExpressInstance = "";
            try
            {
                String[] InstanceNames;
                ExpressInstance = @"Server=localhost";  //.\SQLEXPRESS

                // *******************************************************************************************
                // * WORKS IN both x86 x64 mode 
                // *******************************************************************************************
                RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey windowsNTKey = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                InstanceNames = (String[])windowsNTKey.GetValue("InstalledInstances");


                if (InstanceNames.Length == 1)
                {
                    ExpressInstance = @"Server=.\" + InstanceNames[0];
                }
                else if (InstanceNames.Length > 0)
                {
                    foreach (String InstanceName in InstanceNames)
                    {
                        if (InstanceName.Contains("EXPRESS"))
                            ExpressInstance = @"Server=.\" + InstanceName;
                        //Console.Write(element);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable able to find SQL Server 2008 r2 Express Instance", ex);
            }

            return ExpressInstance;
        }

        public int ExecuteSQL(string strSQL)
        {
            SqlConnection lConnection = GetSqlConnection();

            SqlCommand cmd = new SqlCommand(strSQL, lConnection);
            int RowsEffected = -1;
            cmd.CommandTimeout = 10;
            RowsEffected = cmd.ExecuteNonQuery();
            cmd.Dispose();

            lConnection.Close();
            lConnection.Dispose();

            return RowsEffected;
        }

        public SqlDataReader GetDataReader(string strSQL, SqlConnection lConnection)
        {
            lConnection = GetSqlConnection();

            SqlCommand cmd = new SqlCommand(strSQL, lConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            cmd.Dispose();
            return sdr;
        }

        public SqlDataReader GetDataReader(string strSQL, Hashtable SQLParameters, SqlConnection lConnection)
        {
            //CheckDBConnentions();
            lConnection = GetSqlConnection();

            SqlCommand cmd = new SqlCommand(strSQL, lConnection);
            cmd.CommandType = CommandType.Text;
            foreach (DictionaryEntry d in SQLParameters)
            {
                cmd.Parameters.AddWithValue(d.Key.ToString(), d.Value);
            }
            SqlDataReader sdr = cmd.ExecuteReader();
            cmd.Dispose();
            return sdr;
        }

        public DataSet GetDataSet(string strSQL, string SourceTable)
        {
            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", SourceTable}
            };

            return GetDataSet(strSQL, tableMapping);
        }

        public DataSet GetDataSet(string strSQL, Dictionary<string, string> tableMapping)
        {

            SqlConnection lConnection = GetSqlConnection();
            SqlCommand cmd = new SqlCommand(strSQL, lConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(cmd);
            DataSet myDS = new DataSet();

            if (tableMapping != null)
            {
                foreach (KeyValuePair<string, string> kvp in tableMapping)
                {
                    myDataAdapter.TableMappings.Add(kvp.Key, kvp.Value);
                }
            }
            
            myDataAdapter.FillSchema(myDS, SchemaType.Mapped);
            myDataAdapter.Fill(myDS);

            lConnection.Close();
            lConnection.Dispose();
            return myDS;
        }

        public DataSet GetDataSet(string strSQL, string SourceTable, out SqlDataAdapter DataAdapter)
        {
            //CheckDBConnentions();
            SqlConnection lConnection = GetSqlConnection();

            SqlCommand cmd = new SqlCommand(strSQL, lConnection);
            DataAdapter = new SqlDataAdapter(cmd);
            DataSet myDS = new DataSet();

            DataAdapter.Fill(myDS, SourceTable);

            cmd.Dispose();
            lConnection.Close();
            lConnection.Dispose();

            return myDS;
        }

        public DataTable GetDataTable(string strSQL, string SourceTable)
        {
            //CheckDBConnentions();

            SqlConnection lConnection = GetSqlConnection();
            SqlCommand cmd = new SqlCommand(strSQL, lConnection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(cmd);
            DataSet myDS = new DataSet();

            myDataAdapter.Fill(myDS, SourceTable);
            DataTable dt = myDS.Tables[SourceTable];

            cmd.Dispose();
            lConnection.Close();
            lConnection.Dispose();

            //return dt.Clone();
            return dt;
        }

        public int SaveDataDataset(DataSet ds)
        {
            string SQL = new SQLGenerator().DataSetSQL(ds);
            SQLAccess sqla = new SQLAccess();
            return sqla.ExecuteSQL(SQL);
        }

        public int SaveDataTable(DataTable dt)
        {
            int UpdateCount = 0;
            if (dt.Rows.Count > 0)
            {
                string SQL = new SQLGenerator().DataTableSQL(dt);
                SQLAccess sqla = new SQLAccess();
                UpdateCount = sqla.ExecuteSQL(SQL);
            }

            return UpdateCount;
        }
        
	}
}