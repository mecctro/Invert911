using System;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

using Invert911.InvertCommon.Framework.Utilities;
using Invert911.InvertCommon.Messages.Law;
using Invert911.InvertCommon.Framework.Communication;
using InvertService.ServiceFramework;
using Invert911.InvertCommon.Framework;


namespace InvertService.BusinessLib
{
    public class LawIncidentBLL
    {
        public i9Message ProcessMobileMessage(i9Message mMessage)
        {
            i9Message response = new i9Message();
            response.ErrorStatus.SetError(true, "un-processed message", new Exception());

            switch (mMessage.ToBizLayerMsgType)
            {
                case LawType.Incident_New:
                    response = NewIncident(mMessage);
                    break;

                case LawType.Incident_Edit:
                    response = EditIncident(mMessage);
                    break;

                case LawType.Incident_Save:
                    response = SaveIncident(mMessage);
                    break;

                case LawType.Incident_Search:
                    response = SearchIncident(mMessage);
                    break;

                case LawType.Incident_Delete:
                    response = DeleteIncident(mMessage);
                    break;

                default:
                    response.ErrorStatus.IsError = true;
                    response.ErrorStatus.ErrorMsg = "Unknown Message Type(" + DateTime.Now.ToString() + "): " + mMessage.ToBizLayerMsgType;
                    //response.ErrorStatus.SetError(true, "un-processed message", new Exception());
                    break;
            }
            return response;
        }

        private i9Message DeleteIncident(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();

            LawIncidentMessage lim = (LawIncidentMessage)i9Message.XMLDeserializeMessage(typeof(LawIncidentMessage), requestMessage.MsgBody);
            string i9EventID = lim.i9EventID;

            string DeleteIncidentSql =
                  " DELETE FROM i9LawIncident WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9PersonSMT WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9Property WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9Narrative WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9VehicleRecovery WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9VehicleTowed WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9AttachmentLink WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9Attachment WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9AttachmentData WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9Person WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9Vehicle WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9Location WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  " DELETE FROM i9Event WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine;
                  //" DELETE FROM i9Offense WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                  //" DELETE FROM i9CADServiceCall WHERE i9EventID = " + SQLUtility.SQLString(i9EventID);


            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            
            DeleteIncidentSql = SQLUtility.WrapInTransaction(DeleteIncidentSql);

            response.MsgBody = da.ExecuteSQL(DeleteIncidentSql).ToString();

            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //ts.Hours, ts.Minutes, ts.Seconds,
            //ts.Milliseconds / 10);
            //Console.WriteLine(elapsedTime);

            response.ErrorStatus.IsError = false;

            return response;
        }

        private i9Message EditIncident(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();

            LawIncidentMessage lim = (LawIncidentMessage)i9Message.XMLDeserializeMessage(typeof(LawIncidentMessage), requestMessage.MsgBody);
            string i9EventID = lim.i9EventID;

            string SQLIncident = " SELECT * FROM i9Event WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                    " SELECT * FROM i9LawIncident WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                    " SELECT * FROM i9Person WHERE i9ModuleSectionID = '" + i9ModuleSection.LawIncidentPerson.ToString() + "' AND i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                    " SELECT * FROM i9Vehicle WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                    " SELECT * FROM i9Location WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                    " SELECT * FROM i9Property WHERE  i9EventID = " + SQLUtility.SQLString(i9EventID) + Environment.NewLine +
                    " SELECT * FROM i9Offense WHERE  1=2 " + Environment.NewLine +
                    " SELECT * FROM i9CADServiceCall WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) +
                    " SELECT * FROM i9VehicleRecovery WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) +
                    " SELECT * FROM i9VehicleTowed WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) +
                    " SELECT * FROM i9AttachmentLink WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) +
                    " SELECT * FROM i9Attachment WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) +
                    " SELECT * FROM i9AttachmentData WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) +
                    " SELECT * FROM i9Narrative WHERE i9EventID = " + SQLUtility.SQLString(i9EventID) +
                    " SELECT * FROM i9Person WHERE i9ModuleSectionID = '" + i9ModuleSection.LawIncidentPersonAKA.ToString() + "' AND i9EventID = " + SQLUtility.SQLString(i9EventID) +
                    " SELECT * FROM i9PersonSMT WHERE i9EventID = " + SQLUtility.SQLString(i9EventID);
            
            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9Event"},
                {"Table1", "i9LawIncident"},
                {"Table2", "i9Person"},
                {"Table3", "i9Vehicle"},
                {"Table4", "i9Location"},
                {"Table5", "i9Property"},
                {"Table6", "i9Offense"},
                {"Table7", "i9CADServiceCall"},
                {"Table8", "i9VehicleRecovery"},
                {"Table9", "i9VehicleTowed"},
                {"Table10", "i9AttachmentLink"},
                {"Table11", "i9Attachment"},
                {"Table12", "i9AttachmentData"},
                {"Table13", "i9Narrative"},
                {"Table14", "i9PersonAKA"},
                {"Table15", "i9PersonSMT"}
            };

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            response.MsgBodyDataSet = da.GetDataSet(SQLIncident, tableMapping);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime);

            response.MsgBodyDataSet.AcceptChanges();
            response.ErrorStatus.IsError = false;

            //===============================================================================
            //Retro fit older Events:  
            //     Add i9Narrative to law incident if it does not exist
            //===============================================================================
            if (response.MsgBodyDataSet.Tables["i9Narrative"].Rows.Count <= 0)
            {
                DataRow dr = response.MsgBodyDataSet.Tables["i9Narrative"].NewRow();
                dr["i9EventID"] = response.MsgBodyDataSet.Tables["i9Event"].Rows[0]["i9EventID"];
                dr["i9NarrativeID"] = Guid.NewGuid();
                response.MsgBodyDataSet.Tables["i9Narrative"].Rows.Add(dr);
            }

            return response;
        }

        private i9Message SearchIncident(i9Message mMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();

            string SQLIncident = " SELECT i.i9LawIncidentID, i.i9EventID, i.IncidentNumber, i.SupplementNumber, i.StatusCode, i.IncidentReportDate, i.ORI, 'N3,V1,P4', a.AgencyName " +
                                 " FROM i9LawIncident i join i9Agency a on i.i9AgencyID = a.i9AgencyID   ";

            response.MsgBodyDataSet = da.GetDataSet(SQLIncident, "i9LawIncident"); 
            return response;
        }

        private i9Message SaveIncident(i9Message mMessage)
        {
            i9Message response = new i9Message();
            DataSet ds = mMessage.MsgBodyDataSet;
            StringBuilder sbSQL = new StringBuilder();

            SQLGenerator SqlGen = new SQLGenerator();

            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9Event"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9LawIncident"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9CADServiceCall"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9Offense"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9Person"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9Vehicle"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9Location"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9Property"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9VehicleRecovery"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9VehicleTowed"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9Narrative"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9PersonAKA"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9PersonSMT"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9AttachmentLink"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9Attachment"]));
            sbSQL.Append(SqlGen.DataTableSQL(ds.Tables["i9AttachmentData"]));

            SQLAccess sqla = new SQLAccess();
            string SQL =   SQLUtility.WrapInTransaction( sbSQL.ToString());
            sqla.ExecuteSQL(SQL);

            return response;
        }

        private i9Message NewIncident(i9Message requestMessage)
        {
            i9Message response = new i9Message();
            SQLAccess da = new SQLAccess();

            string SQLIncident = " SELECT * FROM i9Event WHERE 1=2 " + Environment.NewLine +
                              " SELECT * FROM i9LawIncident WHERE 1=2 " + Environment.NewLine +
                              " SELECT * FROM i9Person WHERE 1=2  " + Environment.NewLine +
                              " SELECT * FROM i9Vehicle WHERE 1=2  " + Environment.NewLine +
                              " SELECT * FROM i9Location WHERE 1=2  " + Environment.NewLine +
                              " SELECT * FROM i9Property WHERE 1=2  " + Environment.NewLine +
                              " SELECT * FROM i9Offense WHERE 1=2 " + Environment.NewLine +
                              " SELECT * FROM i9CADServiceCall WHERE 1=2" + Environment.NewLine +
                              " SELECT * FROM i9AttachmentLink WHERE 1=2" + Environment.NewLine +
                              " SELECT * FROM i9Attachment WHERE 1=2" + Environment.NewLine +
                              " SELECT * FROM i9AttachmentData WHERE 1=2" + Environment.NewLine +
                              " SELECT * FROM i9VehicleRecovery WHERE 1=2" + Environment.NewLine +
                              " SELECT * FROM i9VehicleTowed WHERE 1=2" + Environment.NewLine +
                              " SELECT * FROM i9Narrative WHERE 1=2" + Environment.NewLine +
                              " SELECT * FROM i9Person WHERE 1=2" + Environment.NewLine +
                              " SELECT * FROM i9PersonSMT WHERE 1=2" + Environment.NewLine;
            
            
            Dictionary<string, string> tableMapping = new Dictionary<string, string>() 
            {
                {"Table", "i9Event"},
                {"Table1",  "i9LawIncident"},
                {"Table2", "i9Person"},
                {"Table3", "i9Vehicle"},
                {"Table4", "i9Location"},
                {"Table5", "i9Property"},
                {"Table6", "i9Offense"},
                {"Table7", "i9CADServiceCall"},
                {"Table8", "i9AttachmentLink"},
                {"Table9", "i9Attachment"},
                {"Table10", "i9AttachmentData"},
                {"Table11", "i9VehicleRecovery"},
                {"Table12", "i9VehicleTowed"},
                {"Table13", "i9Narrative"},
                {"Table14", "i9PersonAKA"},
                {"Table15", "i9PersonSMT"}
            };

            response.MsgBodyDataSet = da.GetDataSet(SQLIncident, tableMapping);

            //***************************************************************************
            //* Adding standard table rows -  need to move this to the common dll
            //***************************************************************************

            //Adding Event Information:
            DataRow dri9Event = response.MsgBodyDataSet.Tables["i9Event"].NewRow();
            dri9Event["i9EventID"] = ServerKeyManager.NewGuid();
            dri9Event["i9EventType"] = "Incident";
            dri9Event["i9AgencyID"] = requestMessage.MessageSecurity.AgencyID;
            response.MsgBodyDataSet.Tables["i9Event"].Rows.Add(dri9Event);

            //Adding Incident Information:
            DataRow dr = response.MsgBodyDataSet.Tables["i9LawIncident"].NewRow();
            dr["i9LawIncidentID"] = ServerKeyManager.NewGuid();
            dr["i9EventID"] = dri9Event["i9EventID"];
            dr["IncidentNumber"] = ReportNumberManager.GetReportNumber("Incident");
            dr["SupplementNumber"] = 1;
            dr["i9AgencyID"] = requestMessage.MessageSecurity.AgencyID;  //This is the Login user agency (default Agency)
            response.MsgBodyDataSet.Tables["i9LawIncident"].Rows.Add(dr);

            //Add location incident 
            dr = response.MsgBodyDataSet.Tables["i9Location"].NewRow();
            dr["i9EventID"] = dri9Event["i9EventID"];
            dr["i9AgencyID"] = requestMessage.MessageSecurity.AgencyID;
            dr["i9LocationID"] = Guid.NewGuid();
            dr["i9ModuleSectionID"] = i9ModuleSection.LawIncidentLocation.ToString();
            dr["LocationMVI"] = 0;
            response.MsgBodyDataSet.Tables["i9Location"].Rows.Add(dr);

            //Add i9Narrative to law incident 
            dr = response.MsgBodyDataSet.Tables["i9Narrative"].NewRow();
            dr["i9EventID"] = dri9Event["i9EventID"];
            dr["i9NarrativeID"] = Guid.NewGuid();
            response.MsgBodyDataSet.Tables["i9Narrative"].Rows.Add(dr);
            
            //=========================================================================
            //Relations
            //=========================================================================
            response.MsgBodyDataSet.Relations.Add("PersonToLocation",
              response.MsgBodyDataSet.Tables["i9Person"].Columns["i9PersonID"],
              response.MsgBodyDataSet.Tables["i9Location"].Columns["i9PersonID"]);

            //response.MsgBodyDataSet.Relations.Add("PersonLocationToPerson",
            //  response.MsgBodyDataSet.Tables["i9PersonLocation"].Columns["i9PersonID"],
            //  response.MsgBodyDataSet.Tables["i9Person"].Columns["i9PersonID"]);

            //response.MsgBodyDataSet.Relations.Add("PersonLocationToLocation",
            //  response.MsgBodyDataSet.Tables["i9PersonLocation"].Columns["i9LocationID"],
            //  response.MsgBodyDataSet.Tables["i9Location"].Columns["i9LocationID"]);

            //=========================================================================
            //DO NOT EXCEPT CHANGES TO THE DataSet
            //=========================================================================
            //Because I will not know if the row is new or old.
            //response.MsgBodyDataSet.AcceptChanges();

            response.ErrorStatus.IsError = false;
            return response;
        }
    }
}


//=========================================================================
// Old Code
//=========================================================================
//    bool ResetNumber = false;
//    if (dt.Rows[0]["ResetReportNumber"].ToString().ToUpper() == "DAY")
//    {
//        DateTime LastUpdate;
//        DateTime.TryParse(dt.Rows[0]["LastUpdate"].ToString(), out LastUpdate);
//        if (LastUpdate.ToString("yyyymmdd") != DateTime.Now.ToString("yyyymmdd"))
//            ResetNumber = true;   
//    }
//    else if (dt.Rows[0]["ResetReportNumber"].ToString().ToUpper() == "YEAR")
//    {
//        DateTime LastUpdate;
//        DateTime.TryParse(dt.Rows[0]["LastUpdate"].ToString(), out LastUpdate);
//        if (LastUpdate.ToString("yyyy") != DateTime.Now.ToString("yyyy"))
//            ResetNumber = true;
//    }

//    if (ResetNumber)
//    {
//        string SQLReset = "Update i9ModuleReportNumber set ReportNumber = ReportNumber + 1 WHERE TableID = Incident  " + Environment.NewLine +
//                                 "select * from i9ModuleReportNumber";
//    }


