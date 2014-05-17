using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Invert911.InvertCommon.Framework.Utilities
{
    class NightModeManager
    {
        private static NightModeManager m_Instance = null;
        private static readonly object m_Padlock = new object();
        private bool NightMode = false;

        private NightModeManager()
		{
        }

        public static NightModeManager Instance
        {
            get
            {
                lock (m_Padlock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new NightModeManager();
                    }
                }
                return m_Instance;
            }   
        }


        private void SetColorControls(DependencyObject root, bool nightMode)
        {
            this.NightMode = nightMode;
            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(root, i);
                try
                {
                    if (NightMode)
                    {
                        if (child is StackPanel)
                        {
                            ((StackPanel)child).Background = new SolidColorBrush(Colors.Black);
                        }
                        else if (child is Control)
                        {
                            Control ctrl = (Control)child;
                            ctrl.Foreground = new SolidColorBrush(Colors.LimeGreen);
                            ctrl.Background = new SolidColorBrush(Colors.Black);
                        }
                    }
                    else
                    {
                        if (child is StackPanel)
                        {
                            ((StackPanel)child).Background = new StackPanel().Background;
                        }
                        else if (child is Control)
                        {
                            var oType = child.GetType();
                            Object obj = Activator.CreateInstance(oType);
                            if (obj is Control)
                            {
                                Control ctrl = (Control)child;
                                Control NewCtrl = (Control)Activator.CreateInstance(oType);
                                ctrl.Foreground = NewCtrl.Foreground;
                                ctrl.Background = NewCtrl.Background;
                            }
                        }
                        else if (child is TabItem)
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(@"SOMETHING BAD HAPPEN :-) " + ex.Message);
                }

                SetColorControls(child, NightMode);
            }
        }
    }
}
