using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.Framework.Utilities
{
    public delegate void CommandDelegate(string Command, string SubCommand, string Msg);

    public static class AppCommandType
    {
        //System Modules
        public const string Error = "Error";
    }

    public static class AppSubCommandType
    {
        public const string DisplayError = "DisplayError";
    }


    public class AppCommand
    {
        public event CommandDelegate ProccessAppCommand;

        private static AppCommand m_Instance = null;
        private static readonly object m_Padlock = new object();

        private AppCommand()
		{
        }

        public static AppCommand Instance
        {
            get
            {
                lock (m_Padlock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new AppCommand();
                    }
                }
                return m_Instance;
            }   
        }

        public static void SendCommand(string Command, string SubCommand, string Msg)
        {
            if (AppCommand.Instance.ProccessAppCommand != null)
                AppCommand.Instance.ProccessAppCommand(Command, SubCommand, Msg);
        }
    }
}
