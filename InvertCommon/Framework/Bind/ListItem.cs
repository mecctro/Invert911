using System;
using System.Collections.Generic;
using System.Text;

namespace Invert911.InvertCommon.Bind
{
    public class ListItem
    {
        private string m_Key;
        //private string m_Value;

        public ListItem(string Key)
        {
            m_Key = Key;
        }

        public string Key
        {
            get { return m_Key; }
        }
    }
}
