using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace Invert911.InvertCommon.StandardGui
{
    /// <summary>
    /// Interaction logic for kaKeyboard.xaml
    /// </summary>
    public partial class psKeyboard : UserControl
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        public psKeyboard()
        {
            InitializeComponent();
        }

        private void Keyboard_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label b = (Label)sender;
                switch (b.Content.ToString().Trim().ToUpper())
                {
                    case "START":
                        //KeyboardPressed("^{ESC}");  // +(EC) or +EC
                        break;
                    case "ESC":
                        KeyboardPressed(0x1B);
                        break;
                    case "<--":
                        KeyboardPressed(0x08);
                        break;
                    case "ENTER":
                        KeyboardPressed(0x0D);
                        break;
                    case "TAB":
                        KeyboardPressed(0x09);
                        break;
                    case " ":
                        //KeyboardPressed("{SPACEBAR}");
                        break;
                    case "F1":
                        KeyboardPressed(0x70);
                        break;
                    case "F2":
                        KeyboardPressed(0x71);
                        break;
                    case "F3":
                        KeyboardPressed(0x72);
                        break;
                    case "F4":
                        KeyboardPressed(0x73);
                        break;
                    case "F5":
                        KeyboardPressed(0x74);
                        break;
                    case "F6":
                        KeyboardPressed(0x75);
                        break;
                    case "F7":
                        KeyboardPressed(0x76);
                        break;
                    case "F8":
                        KeyboardPressed(0x77);
                        break;
                    case "F9":
                        KeyboardPressed(0x78);
                        break;
                    case "F10":
                        KeyboardPressed(0x79);
                        break;
                    case "F11":
                        KeyboardPressed(0x80);
                        break;
                    case "F12":
                        KeyboardPressed(0x81);
                        break;
                    case "SHIFT":
                        KeyboardPressed(0x10);
                        break;
                    case "CTRL":
                        KeyboardPressed(0x11);
                        break;
                    case "ALT":
                        //KeyboardPressed("%");
                        break;
                    case "+":
                        KeyboardPressed(0x6B);
                        break;
                    case "^":
                        //KeyboardPressed("{^}");
                        break;
                    case "~":
                        //KeyboardPressed("{~}");
                        break;
                    case "%":
                        //KeyboardPressed("{%}");
                        break;
                    case "(":
                        //KeyboardPressed("{(}");
                        break;
                    case ")":
                        //KeyboardPressed("{)}");
                        break;
                    case "PGUP":
                        //KeyboardPressed("{PGUP}");
                        break;
                    case "PGDN":
                        //KeyboardPressed("{PGDN}");
                        break;
                    case "HOME":
                        //KeyboardPressed("{HOME}");
                        break;
                    case "END":
                        //KeyboardPressed("{END}");
                        break;
                    case "DEL":
                        //KeyboardPressed("{DEL}");
                        break;
                    case "INS":
                        //KeyboardPressed("{INS}");
                        break;
                    default:
                        if (b.Content.GetType() == typeof(TextBlock))
                        {
                            TextBlock t = (TextBlock)b.Content;
                            KeyboardPressed(StringToByte(t.Text));
                        }
                        else
                        {
                            KeyboardPressed(StringToByte(b.Content.ToString()));
                        }
                        break;
                }
            }
            catch { }
        }

        //private void ArrowsKeys_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        sgKeyboardButton b = (sgKeyboardButton)sender;
        //        switch (b.Text.Trim().ToLower())
        //        {
        //            case "<":
        //                KeyboardPressed("{LEFT}");
        //                break;
        //            case ">":
        //                KeyboardPressed("{RIGHT}");
        //                break;
        //            case "^":
        //                KeyboardPressed("{UP}");
        //                break;
        //            case "|":
        //                KeyboardPressed("{DOWN}");
        //                break;
        //            default:
        //                KeyboardPressed(b.Text);
        //                break;
        //        }
        //    }
        //    catch { }
        //}

        // C# to convert a string to a byte 
        public byte StringToByte(string str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bb = encoding.GetBytes(str);
            byte b = 0x00;
            if(bb.Length > 0 )
            {
                b = bb[0];
            }
            return b;
        }

        private void KeyboardPressed(byte newChar)
        {
            try
            {
                uint KEYEVENTF_KEYUP = 0x2;  // Release key
                keybd_event(newChar, 0, 0, (UIntPtr)0);
                keybd_event(newChar, 0, KEYEVENTF_KEYUP, (UIntPtr)0);

                //System.Windows.Forms.SendKeys.SendWait(newChar);
                //System.Windows.Forms.SendKeys.SendWait
                //http://www.codeproject.com/KB/system/keyboard.aspx
                //http://msdn.microsoft.com/en-us/library/ms645540.aspx
                //http://msdn.microsoft.com/en-us/library/ms646304(VS.85).aspx
                //http://msdn.microsoft.com/en-us/library/ms646304(VS.85).aspx
                //http://www.codeproject.com/KB/system/keyboard.aspx
            }
            catch { }
        }
    }
}
