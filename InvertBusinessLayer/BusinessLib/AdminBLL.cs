using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvertService.ServiceFramework;
using System.Data;
using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Messages.Admin;
using Invert911.InvertCommon.Modules;

namespace InvertService.BusinessLib
{
    public class AdminBLL
    {
        //Not sure if I need this
        public string ServiceDataAccessUtilities { get; set; }

        /// <summary>
        /// ProcessMobileMessage
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public i9Message ProcessMobileMessage(i9Message requestMessage)
        {
            
            i9Message responseMessage = new i9Message();
            
            switch (requestMessage.ToBizLayerMsgType)
            {
                case AdminType.Login:
                    responseMessage = Login(requestMessage);
                    break;

                case AdminType.CreateUser:
                    responseMessage = CreateUser(requestMessage);
                    break;

                case AdminType.DynamicEntry_GetDynamicEntryAdmin:
                    responseMessage = GetDynamicEntryAdmin(requestMessage);
                    break;

                case AdminType.DynamicEntry_SaveDynamicEntryAdmin:
                    responseMessage = SaveDynamicEntryAdmin(requestMessage);
                    break;

                case AdminType.DynamicEntry_GetTableColumns:
                    responseMessage = DynamicEntry_GetTableColumns(requestMessage);
                    break;
                                        
                case AdminType.Code_GetCodeList_Admin:
                    responseMessage = CodeGetCodeListAdmin(requestMessage);
                    break;

                case AdminType.Code_GetCodeDetail_Admin:
                    responseMessage = CodeAdminGetDetail(requestMessage);
                    break;

                case AdminType.Code_SaveCodeDetail_Admin:
                    CodeAdminSaveDetail(requestMessage);
                    break;

                case AdminType.SysPer_GetList:
                    responseMessage = PersonnelGetList(requestMessage);
                    break;

                case AdminType.SysPer_PersonGet:
                    responseMessage = PersonnelGet(requestMessage);
                    break;

                case AdminType.SysPer_PersonSave:
                    responseMessage = PersonnelSave(requestMessage);
                    break;

                case AdminType.SysPer_PersonAdd:
                    responseMessage = PersonnelAdd(requestMessage);
                    break;

                case AdminType.SysPer_PersonDelete:
                    responseMessage = PersonnelDelete(requestMessage);
                    break;

                case AdminType.Utility_NextServerTableKey:
                    responseMessage = NextTableKey(requestMessage);
                    break;

                case AdminType.Log_GetTop100:
                    responseMessage = LogGetTop100(requestMessage);
                    break;

                default:
                    responseMessage.ErrorStatus.IsError = true;
                    responseMessage.ErrorStatus.ErrorMsg = "Unknown Message Type(" + DateTime.Now.ToString() + "): " + requestMessage.ToBizLayerMsgType;
                    //response.ErrorStatus.SetError(true, "un-processed message", new Exception());
                    break;
            }
            
            return responseMessage;
        }

        private i9Message CreateUser(i9Message requestMessage)
        {
            i9Message response = new i9Message();

            string CodeSetName = requestMessage.MsgBody;
            CreateUserMessage oCreateUserMessage = (CreateUserMessage)i9Message.XMLDeserializeMessage(typeof(CreateUserMessage), requestMessage.MsgBody);

            SQLAccess da = new SQLAccess();
            string SQL = " Select * FROM i9SysPersonnel WHERE Email = " + SQLUtility.SQLString(oCreateUserMessage.Email) + " ";

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9SysPersonnel"}
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            if (ds.Tables["i9SysPersonnel"].Rows.Count > 0)
            {
                response.ErrorStatus.ErrorMsg = "Email already exists in system";
                response.ErrorStatus.IsError = true;
                return response;
            }
            else
            {
                DataRow dr = ds.Tables["i9SysPersonnel"].NewRow();
                
                dr["FirstName"] = oCreateUserMessage.FirstName;
                dr["LastName"] = oCreateUserMessage.LastName;
                
                dr["DateTimeInserted"] = DateTime.Now;
                dr["DateTimeUpdated"] = DateTime.Now;
                    
                dr["Password"] = oCreateUserMessage.Password;
                dr["Email"] = oCreateUserMessage.Email;
                dr["BadgeNumber"] = oCreateUserMessage.Email;
                dr["i9SysPersonnelID"] = Guid.NewGuid();
                dr["ActivationGuid"] = Guid.NewGuid();
                dr["Enabled"] = 1;
                dr["DemoUser"] = 1;
                dr["OfficerORI"] = "";
                dr["Officer"] = oCreateUserMessage.FirstName + ", " + oCreateUserMessage.LastName;

                if (oCreateUserMessage.i9AgencyID == Guid.Empty)
                {
                    dr["i9AgencyID"] = "53A05F38-FC9C-4260-B939-CB1F3998C4D4";
                }
                else
                {
                    dr["i9AgencyID"] = oCreateUserMessage.i9AgencyID;
                }

                ds.Tables["i9SysPersonnel"].Rows.Add(dr);

                da.SaveDataTable(ds.Tables["i9SysPersonnel"]);

                //===============================================================
                //  Send Email Confirmation
                //===============================================================
                //string EmailMessage = "";
                //string EmailSubject = "Invert911 Activation Confirmation";
                //string EmailFrom = "Eric@Invert911.com";
                //string EmailTo = oCreateUserMessage.Email;

                //EmailUtility.SendEmail(EmailTo,EmailFrom,EmailSubject, EmailMessage);

            }

            response.ErrorStatus.IsError = false;
            return response;
        }

        private i9Message LogGetTop100(i9Message requestMessage)
        {
            i9Message response = new i9Message();

            SQLAccess da = new SQLAccess();
            string SQL = " SELECT TOP 500 * FROM i9SysLog ORDER BY LogDateTime DESC " + Environment.NewLine;

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9SysLog"}
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;
            return response;
        }

        private i9Message PersonnelDelete(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            string i9SysPersonnelID = requestMessage.MsgBody;

            SQLAccess da = new SQLAccess();
            string SQL = " BEGIN TRAN T1 " + 
                         "   DELETE FROM i9SysPersonnelPhone WHERE i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID) + " " + Environment.NewLine +
                         "   DELETE FROM i9SysPersonnelAddress WHERE i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID) + " " + Environment.NewLine +
                         "   DELETE FROM i9SysPersonnelAssignment WHERE i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID) + " " + Environment.NewLine +
                         "   DELETE FROM i9SysPersonnel WHERE i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID) + " " + Environment.NewLine +
                         " COMMIT TRAN T1 ";

            int UpdateCount = da.ExecuteSQL(SQL);
            // should check the count.  if zero then that is bad
            response.MsgBody = UpdateCount.ToString();

            return response;
        }

        private i9Message PersonnelAdd(i9Message requestMessage)
        {
            i9Message response = new i9Message();

            SQLAccess da = new SQLAccess();
            string BlankSQL = " Select * FROM i9SysPersonnel where 1 = 2 ";
            
            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9SysPersonnel"}
            };

            DataSet ds = da.GetDataSet(BlankSQL, tableMapping);
            DataTable PersonDT = ds.Tables["i9SysPersonnel"];
            DataRow NewRD = PersonDT.NewRow();
            NewRD["i9SysPersonnelID"] = Guid.NewGuid();
            NewRD["FirstName"] = "@NewFirst";
            NewRD["LastName"] = "@NewLast " + DateTime.Now.ToString("MM/dd/yyyy hh:mm");
            NewRD["i9AgencyID"] = requestMessage.MsgBody.ToString();
            NewRD["BadgeNumber"] = DateTime.Now.ToString("MMddyyyyhhmm");
            NewRD["Enabled"] = 1; 
            PersonDT.Rows.Add(NewRD);

            string i9SysPersonnelID = NewRD["i9SysPersonnelID"].ToString();
            if (da.SaveDataTable(ds.Tables["i9SysPersonnel"]) <= 0)
            {
                //unable to save new personnel
                response.MsgBody = "";
                response.ErrorStatus.IsError = true;
                response.ErrorStatus.ErrorMsg = "Unable to add new user";

                return response;
            }


            requestMessage.ToBizLayerMsgType = AdminType.SysPer_PersonGet;
            requestMessage.MsgBody = i9SysPersonnelID;

            return PersonnelGet(requestMessage);


        }

        private i9Message PersonnelSave(i9Message requestMessage)
        {
            i9Message ResponseMessage = new i9Message();

            try
            {
                if (requestMessage.MsgBodyDataSet != null)
                {
                    if (requestMessage.MsgBodyDataSet.Tables.Count > 0)
                    {
                        SQLAccess da = new SQLAccess();

                        //TODO:  Need to wrap this in a transaction

                        da.SaveDataTable(requestMessage.MsgBodyDataSet.Tables["i9SysPersonnel"]);
                        da.SaveDataTable(requestMessage.MsgBodyDataSet.Tables["i9SysPersonnelAddress"]);
                        da.SaveDataTable(requestMessage.MsgBodyDataSet.Tables["i9SysPersonnelAssignment"]);
                        da.SaveDataTable(requestMessage.MsgBodyDataSet.Tables["i9SysPersonnelPhone"]);

                        ResponseMessage.ErrorStatus.IsError = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceLogManager.LogThis("Error saving dataset", LogEventType.Error, ex, "", "");
                ResponseMessage.ErrorStatus.IsError = true;
                ResponseMessage.ErrorStatus.ErrorMsg = ex.Message;
            }

            return ResponseMessage;
        }

        private i9Message PersonnelGet(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            string i9SysPersonnelID = requestMessage.MsgBody;

            SQLAccess da = new SQLAccess();
            string SQL = " Select * FROM i9SysPersonnel where i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID) + " " + Environment.NewLine +
                         " Select * from i9SysPersonnelAddress where i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID) + " " + Environment.NewLine +
                         " Select * from i9SysPersonnelAssignment where i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID) + " " + Environment.NewLine +
                         " Select * from i9SysPersonnelPhone where i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID);
            
            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9SysPersonnel"},
                {"Table1", "i9SysPersonnelAddress"},
                {"Table2", "i9SysPersonnelAssignment"},
                {"Table3", "i9SysPersonnelPhone"}
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;
            return response;
        }

        /// <summary>
        /// CodeGetCodeDetailAdmin
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        private i9Message CodeAdminGetDetail(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            string CodeSetName = requestMessage.MsgBody;

            SQLAccess da = new SQLAccess();
            string SQL = " Select * FROM i9Code where CodeSetName = " + SQLUtility.SQLString(CodeSetName) + " order by CodeText ";
            
            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9Code"}
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;
            return response;
        }

        /// <summary>
        /// CodeSaveCodeDetailAdmin
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        private i9Message CodeAdminSaveDetail(i9Message requestMessage)
        {
            i9Message ResponseMessage = new i9Message();

            try
            {
                if (requestMessage.MsgBodyDataSet != null)
                {
                    if (requestMessage.MsgBodyDataSet.Tables.Count > 0)
                    {
                        SQLAccess da = new SQLAccess();
                        da.SaveDataTable(requestMessage.MsgBodyDataSet.Tables["i9Code"]);
                        ResponseMessage.ErrorStatus.IsError = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceLogManager.LogThis("Error saving dataset", LogEventType.Error, ex, "", "");
                ResponseMessage.ErrorStatus.IsError = true;
                ResponseMessage.ErrorStatus.ErrorMsg = ex.Message;
            }

            return ResponseMessage;
        }

        /// <summary>
        /// Get Next Table Key from Main Database.
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public i9Message NextTableKey(i9Message requestMessage)
        {
            string TableName = requestMessage.MsgBody;
            //int KeyValue = 0;
            i9Message response = new i9Message();

            SQLAccess cda = new SQLAccess();
            string sql = @" BEGIN TRAN T1 " +
                          " SELECT * FROM i9TableKey WHERE TableName = " + SQLUtility.SQLString(TableName) + " " + Environment.NewLine +
                          "  Update i9TableKey Set KeyValue = KeyValue + 1  WHERE TableName = " + SQLUtility.SQLString(TableName) + " " + Environment.NewLine +
                          " COMMIT TRAN T1 ";
            DataSet ds = cda.GetDataSet(sql, "i9TableKey");
            if (ds != null)
            {
                //if (ds.Tables.Count > 0)
                //    if (ds.Tables[0].Rows.Count > 0)
                //        KeyValue = Convert.ToInt32(ds.Tables["i9TableKey"].Rows[0]["KeyValue"].ToString());
                response.MsgBodyDataSet = ds;
                return response;
            }
            else
            {
                throw new Exception("Unable to get the next table key for: " + TableName);
            }
        }

        /// <summary>
        /// CodeGetCodeListAdmin
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        private i9Message CodeGetCodeListAdmin(i9Message requestMessage)
        {
            //-------------------------------------------------------------------
            //Testing 
            //SELECT CodeName, CodeValue  FROM i9Code group by CodeName, CodeValue having count (*) > 1 order by CodeName
            //-------------------------------------------------------------------
            
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();
            string SQL = //" Select * FROM i9Code order by CodeSetName "+ Environment.NewLine +
                         " Select CodeSetName, i9AgencyID FROM i9Code Group By CodeSetName, i9AgencyID order by CodeSetName " + Environment.NewLine +
                         " Select * from i9Agency order by AgencyName ";

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                //{"Table", "i9Code"},
                {"Table", "i9Code"},
                {"Table1", "i9Agency"},
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;

            return response;
        }

        private i9Message PersonnelGetList(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();
            string SQL = " Select LastName +', ' + FirstName + ' - ' + BadgeNumber as DisplayName, * FROM i9SysPersonnel order by DisplayName " + Environment.NewLine +
                         " Select * from i9Agency order by AgencyName ";

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9SysPersonnel"},
                {"Table1", "i9Agency"},
            };

            DataSet ds = da.GetDataSet(SQL, tableMapping);
            response.MsgBodyDataSet = ds;

            return response;
        }

        /// <summary>
        /// Sync Module Manager To DB
        /// </summary>
        private void SyncModuleManagerToDB()
        {
            SQLAccess da = new SQLAccess();

            //DataTable dt = da.GetDataTable("SELECT * FROM i9Module WHERE ModuleKey = " + SQLUtility.SQLString(mi.i9ModuleID), "i9Module");
            DataTable dt = da.GetDataTable("SELECT * FROM i9Module", "i9Module");
            
            for (int i = 0; i < ModuleManager.Instance.Modules.Length - 1; i++)
            {
                ModuleItem mi = ModuleManager.Instance.Modules[i];

                bool found = false;

                if (mi.ModuleName.ToUpper() == "CRIME WATCH")
                {
                    Console.Write("");
                }


                if (mi.ModuleName.ToUpper() == "LOGIN" ||
                        mi.ModuleName.ToUpper() == "MAIN" ||
                        mi.ModuleName.ToUpper() == "MAIN MENU" ||
                        mi.ModuleName.ToUpper() == "SPLASH SCREEN")
                {
                    continue;
                }
                else
                {
                    foreach (DataRow ModuleRow in dt.Rows)
                    {
                        if (ModuleRow["ModuleName"].ToString().ToUpper() == mi.ModuleName.ToUpper())
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                    {
                        //Why am I adding a row if the table is blank this is strange
                        DataRow NewModuleRow = dt.NewRow();
                        NewModuleRow["ClassName"] = mi.ClassName;
                        NewModuleRow["ModuleName"] = mi.ModuleName;
                        NewModuleRow["Section"] = mi.Section;
                        NewModuleRow["PopupPage"] = mi.PopupPage;
                        NewModuleRow["DesktopEnabled"] = mi.DesktopEnabled;
                        NewModuleRow["MobileEnabled"] = mi.MobileEnabled;
                        NewModuleRow["ModuleType"] = mi.ModuleType;
                        NewModuleRow["ModuleKey"] = mi.i9ModuleID;
                        NewModuleRow["i9ModuleID"] = Guid.NewGuid();
                        NewModuleRow["FileName"] = mi.FileName;
                        dt.Rows.Add(NewModuleRow);
                    }
                }
            }
            
            if (dt.DataSet.HasChanges())
            {
                da.SaveDataTable(dt);
            }

        }

        /// <summary>
        /// DynamicEntry_GetTableColumns
        /// </summary>
        /// <param name="mMessage"></param>
        /// <returns></returns>
        private i9Message DynamicEntry_GetTableColumns(i9Message mMessage)
        {
            SQLAccess da = new SQLAccess(); 
            i9Message response = new i9Message();
            string ModuleSection = mMessage.MsgBody.Split(new Char[] {','})[0];
            string TableName = mMessage.MsgBody.Split(new Char[] { ',' })[1];

            string sql = " EXEC TableSchema_Get '" + TableName + "' " + Environment.NewLine ;
                         //" SELECT * FROM i9DynamicEntryConfig where ModuleSection = '" + ModuleSection  + "' " + Environment.NewLine +
                         //" SELECT * FROM i9DynamicEntryRule der, i9DynamicEntryConfig dec WHERE der.i9DynanicEntryConfigID = dec.i9DynanicEntryConfigID AND dec.ModuleSection = '" + ModuleSection + "' " + Environment.NewLine;

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9TableSchema"},      
                //{"Table1", "i9DynamicEntryConfig"},
                //{"Table2", "i9DynamicEntryRule"},
            };

            response.MsgBodyDataSet = da.GetDataSet(sql, tableMapping);
            response.ErrorStatus.IsError = false;

            return response;
        }

        /// <summary>
        /// GetDynamicEntryAdmin
        /// </summary>
        /// <param name="mMessage"></param>
        /// <returns></returns>
        private i9Message GetDynamicEntryAdmin(i9Message mMessage)
        {
            SQLAccess da = new SQLAccess();
            i9Message response = new i9Message();

            string SQLLogin = " SELECT * FROM i9DynamicEntry ORDER BY ModuleSection" + Environment.NewLine +
                              " SELECT * FROM i9DynamicEntryConfig " + Environment.NewLine +
                              " select * from i9DynamicEntryRule " + Environment.NewLine;

            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9DynamicEntry"},
                {"Table1", "i9DynamicEntryConfig"},
                {"Table2", "i9DynamicEntryRule"},
            };

            response.MsgBodyDataSet = da.GetDataSet(SQLLogin, tableMapping);
            response.ErrorStatus.IsError = false;

            return response;
        }

        private i9Message SaveDynamicEntryAdmin(i9Message mRequestMessage)
        {
            SQLAccess da = new SQLAccess();
            i9Message response = new i9Message();

            da.SaveDataTable(mRequestMessage.MsgBodyDataSet.Tables["i9DynamicEntryConfig"]);

            return response;
        }
        
        public i9Message Login(i9Message RequestMessage)
        {
            i9Message response = new i9Message();

            LoginMessage oLoginMessage = (LoginMessage)i9Message.XMLDeserializeMessage(typeof(LoginMessage), RequestMessage.MsgBody);
            SQLAccess da = new SQLAccess();

            string SQLLogin = "SELECT * FROM i9SysPersonnel WHERE Enabled != 0 AND BadgeNumber = " + SQLUtility.SQLString(oLoginMessage.UserName) + " and Password = " + SQLUtility.SQLString(oLoginMessage.Password);
            DataTable dt = da.GetDataTable(SQLLogin, "i9SysPersonnel");

            if (dt.Rows.Count <= 0)
            {
                //Just send back an empty table

                return response;
            }

            string i9SysPersonnelID = dt.Rows[0]["i9SysPersonnelID"].ToString();

            //Give an activision code to the login user
            string UpdateSql = "UPDATE i9SysPersonnel SET ActivationGuid = '" + Guid.NewGuid() + "' WHERE i9SysPersonnelID = " + SQLUtility.SQLString(i9SysPersonnelID);
            if (da.ExecuteSQL(UpdateSql) <= 0)
            {
                //Nothing was updated.  
            }

            //SyncModuleManagerToDB();


            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9SysPersonnel"},
                {"Table1", "xxSecurityGroupTask"},
                {"Table2", "xxSecurityGroupModule"},
            };

            string SQL = "SELECT * FROM i9SysPersonnel WHERE i9SysPersonnelID = @i9SysPersonnelID";

            SQL = SQL + Environment.NewLine + @"
                    SELECT sgt.TaskName, sp.BadgeNumber
                    FROM i9SecurityGroup sg
                            inner join i9SecurityGroupTask sgt
                            on sgt.SecurityGroupName = sg.SecurityGroupName	
                            inner join i9SecurityGroupPersonnel sgp 
                            on sgp.i9SecurityGroupID = sg.i9SecurityGroupID
                            inner join i9SysPersonnel sp
                            on sp.i9SysPersonnelID = sgp.i9SysPersonnelID
                    WHERE sp.i9SysPersonnelID = @i9SysPersonnelID
                    Group by TaskName, BadgeNumber                        
                    order by BadgeNumber, TaskName 
                    ";

                SQL = SQL + Environment.NewLine +  @"
                    SELECT sgm.ModuleName, sp.BadgeNumber
                    FROM i9SecurityGroup sg
                            inner join i9SecurityGroupModule sgm
                            on sgm.SecurityGroupName = sg.SecurityGroupName	
                            inner join i9SecurityGroupPersonnel sgp 
                            on sgp.i9SecurityGroupID = sg.i9SecurityGroupID
                            inner join i9SysPersonnel sp
                            on sp.i9SysPersonnelID = sgp.i9SysPersonnelID
                    WHERE sp.i9SysPersonnelID = @i9SysPersonnelID
                    Group by ModuleName, BadgeNumber                        
                    order by BadgeNumber, ModuleName     
                    ";

                SQL = SQL.Replace("@i9SysPersonnelID", SQLUtility.SQLString(i9SysPersonnelID) );

                response.MsgBodyDataSet = response.MsgBodyDataSet = da.GetDataSet(SQL, tableMapping);
                response.ErrorStatus.IsError = false;


            return response;
        }
    }
}
