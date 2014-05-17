using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Invert911.InvertCommon.Framework.Interfaces
{
    interface IMainWindow
    {
        bool ShowKeyBoard
        {
            get;
            set;
        }

        Window GetMainWindow
        {
            get;
            //set;
        }

    }
}
