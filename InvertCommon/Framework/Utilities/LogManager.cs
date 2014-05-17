using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using Invert911.InvertCommon.Framework.Communication;

namespace Invert911.InvertCommon.Utilities
{
    public class LogManager 
    {
        private static LogManager m_KALogger = null;
        private static readonly object m_Padlock = new object();

        public static LogManager Instance
        {
            get
            {
                lock (m_Padlock)
                {
                    if (m_KALogger == null)
                        m_KALogger = new LogManager();
                }

                return m_KALogger;
            }
        }

        public void LogMessage(i9MessageError ErrorMsg)
        {
            LogMessage("", "", ErrorMsg.ErrorMsg, null);
        }

        public void LogMessage(string Message, Exception ex)
        {
            //MethodBase.GetMethodFromHandle()
            LogMessage("", "", Message, ex);
        }

        public void LogMessage(Exception ex)
        {
            LogMessage("", "", "", ex);
        }

        public void LogMessage(string ClassName = "", string MethodName = "", string Message= "", Exception ex = null)
        {
            StringBuilder DetailmsgBlder = new StringBuilder(1024);

            string ExMessage = "";
            if (ex != null)
                ExMessage = ex.Message;

            string GeneralErrorMessage = String.Format("{0}{1}{1}Error Message: {2}", Message, Environment.NewLine, ExMessage);

            DetailmsgBlder.Append(GeneralErrorMessage);
            if (ex != null)
            {
                DetailmsgBlder.AppendFormat(@"{0}{0}Exception Message: {1}{0}{0}Type: {2}{0}{0}Stack Trace: {3}", Environment.NewLine, ex.Message, ex.GetType(), ex.StackTrace);

                if (ex.InnerException != null)
                {
                    DetailmsgBlder.AppendFormat("{0}{0}Inner Exception: {1}", Environment.NewLine, ex.InnerException.Message);
                }
            }

            Trace.WriteLine(string.Format("Design time error. ClassName = {0}, MethodName = {1}, Message = {2}, Exception Message = {3}",
                ClassName, MethodName, GeneralErrorMessage, DetailmsgBlder.ToString()));
        }

        public System.Data.DataTable GetAllLogs()
        {
            return null;
        }

        public static void WriteToDebugOutput(string message, MethodBase currentMeth)
        {
            
            Debug.Write(string.Format("{0} in {1}", message, currentMeth.Name));
        }

        public static void WriteToDebugOutput(MethodBase currentMeth)
        {
            Debug.Write(string.Format("call to {0}", currentMeth.Name));
        }


    }
}
