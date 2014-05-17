using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.DataTypes
{
    public class xNode
    {
        private string _NodeName;   //This property might not be needed
        private string _OriginalValue;
        private string _CurrentValue;
        
        public string NodeName  
        {
            get
            {
                return _NodeName;
            }
            set
            {
                if (_NodeName == value)
                    return;
                _NodeName = value;
            }
        }

        public string OriginalValue
        {
            get
            {
                return _OriginalValue;
            }
            set
            {
                if (_OriginalValue == value)
                    return;
                _OriginalValue = value;
            }
        }

        public string CurrentValue
        {
            get
            {
                return _CurrentValue;
            }
            set
            {
                if (_CurrentValue == value)
                    return;
                _CurrentValue = value;
            }
        }
    }
}
