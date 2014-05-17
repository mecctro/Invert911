using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invert911.InvertCommon.Utilities
{
    public class ClipboardManager
    {
        private static ClipboardManager m_ClipboardManager;
        private ClipboardItems m_ClipboardItems;

        private ClipboardManager()
        {
            m_ClipboardItems = new ClipboardItems();
        }

        public ClipboardManager Instance
        {
            get
            {
                if (m_ClipboardManager == null)
                {
                    m_ClipboardManager = new ClipboardManager();
                }

                return m_ClipboardManager;
            }
        }

        public ClipboardItems GetClipboardItems()
        {
            return m_ClipboardItems;
        }
    }
}