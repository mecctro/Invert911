using System;
using System.ServiceModel;
using System.Collections.Generic;
using Invert911.InvertCommon.Framework.Communication;

namespace Invert911.InvertCommon.Framework.Interfaces
{
    //[ServiceContract]
    public interface Ii9MessageManager
    {
        //[OperationContract]
        string ProcessMobileMessage(string Message);
    }
}
