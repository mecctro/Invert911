using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace InvertService.ServiceFramework
{
    public enum LogEventType
    {
        Info,
        Warning,
        Error,
        InMessages,
        OutMessages,
        MessagePath
    }

    public class ServiceLogManager
    {
        public static void LogThis(string ErrorMessage, LogEventType LogEvent, string BadgeNumber, string AgencyName)
        {
            bool LogMessage = true;

            switch ( LogEvent)
            {
                case LogEventType.Error:
                    break;
                case LogEventType.Warning:
                    break;
                case LogEventType.Info:
                    break;
                case LogEventType.InMessages:
                    LogMessage = false;
                    break;
                case LogEventType.OutMessages:
                    LogMessage = false;
                    break;
                case LogEventType.MessagePath:
                    LogMessage = false;
                    break;
            }

            if (LogMessage == false)
                return;

            try
            {
                if (ErrorMessage.Length > 1000)
                    ErrorMessage = ErrorMessage.Substring(0, 999);

                if (BadgeNumber.Length > 23)
                    BadgeNumber = BadgeNumber.Substring(0, 22);

                if (AgencyName.Length > 60)
                    AgencyName = AgencyName.Substring(0, 59);

                AgencyName = "";

                string SQL = "INSERT INTO i9SysLog (LogDateTime, LogDescription, LogType, AgencyName, BadgeNumber) VALUES ('" + DateTime.Now.ToString() + "', " + SQLUtility.SQLString(ErrorMessage) + ", " + SQLUtility.SQLString(LogEvent.ToString()) + ", " + SQLUtility.SQLString(AgencyName) + ", " + SQLUtility.SQLString(BadgeNumber) + ")";
                SQLAccess da = new SQLAccess();
                da.ExecuteSQL(SQL);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LogThis(string ErrorMessage, LogEventType LogEvent, Exception ex, string BadgeNumber, string AgencyName)
        {
            LogThis(ErrorMessage + " Error Msg " + ex.Message, LogEvent, BadgeNumber, AgencyName);
        }
    }
}
