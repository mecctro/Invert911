using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon.Utilities;
using Invert911.InvertCommon.Framework.Interfaces;
using Invert911.InvertCommon.Invert911service;
//using Invert911.InvertCommon.Invert911ServiceClient;


namespace Invert911.InvertCommon.Framework.Communication
{
    public class i9MessageManager
    {
        public static Ii9MessageManager mIi9MessageManager = null;
        private static Dictionary<string, Thread> ThreadMessages = new Dictionary<string, Thread>();
        private static CancellationTokenSource tokenSource = null;
        private const short MsgTimeOut = 60;

        public static i9Message SendMessage(string ToBizLayer, string ToBizLayerMsgType, string From)
        {
            i9Message MobileMsg = new i9Message();

            MobileMsg.ToBizLayer = ToBizLayer;
            MobileMsg.ToBizLayerMsgType = ToBizLayerMsgType;

            MobileMsg.From = From;

            return SendMessage(MobileMsg);
        }

        public static i9Message SendMessage(string ToBizLayer, string ToBizLayerMsgType, string From, DataSet MsgDataSet )
        {
            i9Message MobileMsg = new i9Message();

            MobileMsg.ToBizLayer = ToBizLayer;
            MobileMsg.ToBizLayerMsgType = ToBizLayerMsgType;

            MobileMsg.From = From;

            MobileMsg.MsgBodyDataSet = MsgDataSet;

            return SendMessage(MobileMsg);
        }

        public static i9Message SendMessage(string ToBizLayer, string ToBizLayerMsgType, string From, Type type, object MsgBody)
        {
            i9Message MobileMsg = new i9Message();
            
            MobileMsg.ToBizLayer = ToBizLayer;
            MobileMsg.ToBizLayerMsgType = ToBizLayerMsgType;

            MobileMsg.From = From;

            if(type == typeof(string))
                MobileMsg.MsgBody = MsgBody.ToString();
            else
                MobileMsg.MsgBody = i9Message.XMLSerializeMessage(MsgBody.GetType(), MsgBody);

            return SendMessage(MobileMsg);
        }

        public static i9Message SendMessage(i9Message MobileMsg)
        {
            i9Message RespomseMsg = new i9Message();
            
            try
            {
                RespomseMsg = SendMessage_V1(MobileMsg);
                
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage(ex);
                RespomseMsg.ErrorStatus.IsError = true;
                RespomseMsg.ErrorStatus.ErrorMsg = "Error: " + ex.GetBaseException().Message + Environment.NewLine + "  StackTrace:  " + ex.GetBaseException().StackTrace;
            }

            return RespomseMsg;
        }

        private static i9Message SendMessage_V1(i9Message MobileMsg)
        {
            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            i9Message ReturnMessage = null;
            DateTime StartTime = DateTime.Now;

            Thread MsgThread = new Thread(delegate()
                                  {
                                      // Return value directly to local variable.
                                      ReturnMessage = SendMessageAsync(MobileMsg);
                                  }
                                 );

            ThreadMessages.Add(MobileMsg.MsgGUID, MsgThread);
            MsgThread.Start();

            Task taskA = Task.Factory.StartNew(() => WaitForMessage(ref ReturnMessage, token), token);
            WaitWithPumping(taskA);

            ThreadMessages.Remove(MobileMsg.MsgGUID);
            tokenSource = null;

            if (token.IsCancellationRequested)
            {
                ReturnMessage = new i9Message();
                ReturnMessage.ErrorStatus.IsError = true;
                ReturnMessage.ErrorStatus.ErrorMsg = "User Canceled the Action";
            }

            if (ReturnMessage == null)
            {
                LogManager.Instance.LogMessage("RespomseMsg was null");
                ReturnMessage.ErrorStatus.IsError = true;
                ReturnMessage.ErrorStatus.ErrorMsg = "Message timed out";
            }

            return ReturnMessage;
        }

        public static bool CancelAllMessages()
        {
            return CancelMessage(null);
        }

        public static bool CancelMessage(i9Message MobileMsg)
        {
            return CancelMessage_V1(MobileMsg);
        }

        //private static i9Message SendMessage_V2(i9Message MobileMsg)
        //{
        //    i9Message ReturnMessage = null;
        //    DateTime StartTime = DateTime.Now;

        //    Thread MsgThread = new Thread(delegate()
        //        {
        //            // Return value directly to local variable.
        //            Thread.Sleep(15000);
        //            ReturnMessage = SendMessageAsync(MobileMsg);
        //        }
        //    );

        //    ThreadMessages.Add(MobileMsg.MsgGUID, MsgThread);
        //    MsgThread.Start();

        //    if (MsgThread.Join(10000))
        //    {
        //        Console.WriteLine("New thread terminated.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Join timed out.");
        //        ReturnMessage = new i9Message();
        //        ReturnMessage.ErrorStatus.IsError = true;
        //        ReturnMessage.ErrorStatus.ErrorMsg = "User Canceled the Action";
        //    }


        //    ThreadMessages.Remove(MobileMsg.MsgGUID);
        //    tokenSource = null;

        //    return ReturnMessage;
        //}

        //private static bool CancelMessage_V2(i9Message MobileMsg)
        //{
        //    bool Results = false;

        //    if (MobileMsg == null)
        //    {
        //        foreach (KeyValuePair<string, Thread> kvp in ThreadMessages)
        //        {
        //            Thread t = kvp.Value;
        //            t.Abort();
        //            Results = true;
        //        }
        //    }
        //    else
        //    {
        //        if (ThreadMessages.ContainsKey(MobileMsg.MsgGUID))
        //        {
        //            Thread t = ThreadMessages[MobileMsg.MsgGUID];
        //            t.Abort();
        //            Results = true;
        //        }
        //    }

        //    return Results;
        //}

        private static bool CancelMessage_V1(i9Message MobileMsg)
        {
            bool Results = false;

            if (tokenSource != null)
                tokenSource.Cancel();

            if (MobileMsg == null)
            {
                foreach (KeyValuePair<string, Thread> kvp in ThreadMessages)
                {
                    kvp.Value.Abort();
                    Results = true;
                }
            }
            else
            {
                if (ThreadMessages.ContainsKey(MobileMsg.MsgGUID))
                {
                    Thread t = ThreadMessages[MobileMsg.MsgGUID];
                    t.Abort();
                    Results = true;
                }
            }

            return Results;
        }

        private static i9Message SendMessageAsync(i9Message MobileMsg)
        {
            i9Message ReturnMessage = new i9Message();

            try
            {
                //Thread.Sleep(10000);


                //Security Information to the Message.
                MobileMsg.MessageSecurity.MachineName = Environment.MachineName;
                MobileMsg.MessageSecurity.MachineUserName = Environment.UserName;
                MobileMsg.MessageSecurity.IPAddress = "???";
                MobileMsg.MessageSecurity.LoginPersonnelID = SettingManager.Instance.LoginPersonnelID;
                MobileMsg.MessageSecurity.AgencyID = SettingManager.Instance.AgencyID;

                string TextMsg = MobileMsg.XMLSerializeMessage();
                string ReturnXMLMessage = "";
                if (ConfigurationManager.Instance.IsDemoMode)
                {
                    //Demo Verison of the application.  No Backend system.
                    if (mIi9MessageManager == null)
                        mIi9MessageManager = GetIi9BizManager();

                    ReturnXMLMessage = mIi9MessageManager.ProcessMobileMessage(TextMsg);
                }
                else
                {
                    //Production Verison of the application.  biz logic and data access is handed in the backend.
                    Invert911Service oInvert911Service = (Invert911Service)WebServiceUtilities.GetWebService(new Invert911Service());
                    //Invert911.InvertCommon.Invert911service.Invert911Service oInvert911Service = new Invert911service.Invert911Service();

                    //ReturnXMLMessage = oInvert911Service.ProcessMobileMessageTest(TextMsg);

                    ReturnXMLMessage = oInvert911Service.ProcessMobileMessage(TextMsg);
                    
                }

                ReturnMessage = (i9Message)i9Message.XMLDeserializeMessage(typeof(i9Message), ReturnXMLMessage);
            }
            catch (Exception ex)
            {
                ReturnMessage.ErrorStatus.IsError = true;
                //ReturnMessage.ErrorStatus.ErrorMsg = ex.GetBaseException().Message;
                ReturnMessage.ErrorStatus.ErrorMsg = "Error: " + ex.GetBaseException().Message + Environment.NewLine + "  StackTrace:  " + ex.GetBaseException().StackTrace;
                LogManager.Instance.LogMessage("Error in the MessageManager.SendMessage", ex);
            }

            return ReturnMessage;
        }

        private static void WaitForMessage(ref i9Message ReturnMessage, CancellationToken ct)
        {
            DateTime StartTime = DateTime.Now;

            while (true)
            {
                if (ct.IsCancellationRequested)
                    return;

                DateTime EndTime = DateTime.Now;
                TimeSpan span = EndTime.Subtract(StartTime);

                if (ReturnMessage != null)
                    break;

                if (span.Seconds > MsgTimeOut)  //Time needs to be configurable...
                {
                    break;
                }

                Thread.Sleep(200);  //Sleep alittle bit 
            }
        }

        private static void WaitWithPumping(Task task)
        {
            if (task == null)
                throw new ArgumentNullException("task");
            var nestedFrame = new DispatcherFrame();
            task.ContinueWith(_ => nestedFrame.Continue = false);
            Dispatcher.PushFrame(nestedFrame);
            task.Wait();
        }
        
        private static Ii9MessageManager GetIi9BizManager()
        {
            string FolderPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);  //starup path

            Assembly asmLib = Assembly.LoadFile(FolderPath + @"\Invert911.InvertBusinessLayer.dll");
            Type demoClassType = asmLib.GetType("InvertService.BusinessLib.i9MessageManagerBLL");
            object demoClassobj= Activator.CreateInstance(demoClassType);

            return (Ii9MessageManager)demoClassobj;
        }

        
        //public static i9Message SendMessage(i9Message MobileMsg)
        //{

        //    i9Message ReturnMessage = null;
        //    DateTime StartTime = DateTime.Now;

        //    Thread MsgThread = new Thread(delegate()
        //    {
        //        // Return value directly to local variable.
        //        ReturnMessage = SendMessageAsync(MobileMsg);
        //    }
        //                         );

        //    ThreadMessages.Add(MobileMsg.MsgGUID, MsgThread);
        //    MsgThread.Start();

        //    while (true)
        //    {
        //        DateTime EndTime = DateTime.Now;
        //        TimeSpan span = EndTime.Subtract(StartTime);

        //        if (ReturnMessage != null)
        //            break;

        //        if (span.Seconds > 10)
        //        {
        //            if (MsgThread != null)
        //                MsgThread.Abort();
        //            break;
        //        }

        //        //TODO: Need to change this code to have a cancel button.

        //        //bool success = t.Join(10000); // Wait for the thread until the timeout expires.
        //        System.Windows.Forms.Application.DoEvents();  // Process other click events
        //        Thread.Sleep(200);  //Sleep alittle bit 
        //    }

        //    ThreadMessages.Remove(MobileMsg.MsgGUID);
        //    tokenSource = null;

        //    return ReturnMessage;
        //}
    }
}
