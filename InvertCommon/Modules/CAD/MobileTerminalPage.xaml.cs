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
using System.Windows.Shapes;
using System.Reflection;
using System.Runtime.Remoting;
using System.IO;

//using Hix.Resources;
using Invert911.Incident;
using Invert911.Citation;
using Invert911.InvertCommon.StandardGui;
using Invert911.InvertCommon.Modules;
using Invert911.InvertCommon.Utilities;
using Invert911.InvertCommon;

namespace Invert911.CAD
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MobileTerminalPage : Page
    {
        private Dictionary<string, IMDTModule> m_Modules;

        public MobileTerminalPage()
        {
            InitializeComponent();
            m_Modules = new Dictionary<string, IMDTModule>();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(MenuItem))
            {
                MenuItem mi = (MenuItem)sender;
                string header = mi.Header.ToString().ToUpper();
                header = header.Replace("_", "");
                if ( header == "EXIT")
                {
                    MainWindow.mMainWindow.Close();
                }
            }
            Console.WriteLine("");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Width = double.NaN;
                this.Height = double.NaN;

                NavigationService.RemoveBackEntry();

                InitToolbar();
                InitNavBar();

                NavigatorTreeView.Visibility = Visibility.Collapsed;
                ModulesList.Visibility = Visibility.Visible;
                
                //this.WindowState = WindowState.Maximized;
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage(ex);
            }
        }

        private void HideAllControls()
        {
            foreach (KeyValuePair<string, IMDTModule> kvp in m_Modules)
            {
                Control c = (Control)kvp.Value;
                c.Visibility = Visibility.Hidden;
            }
        }

        private void InitNavBar()
        {
            NavigatorTreeView.Items.Clear();
            Dictionary<string, TreeViewItem> TreeViewGroups = new Dictionary<string, TreeViewItem>();

            for (int i = 0; i < ModuleManager.Instance.Modules.Length - 1; i++)
            {
                try
                {
                    ModuleItem mod = ModuleManager.Instance.Modules[i];

                    //Mobile CAD Enabled
                    if (mod.MobileEnabled)  
                    {
                        TreeViewItem ParentTreeViewItem;
                        if (TreeViewGroups.ContainsKey(mod.Section.ToLower()))
                        {
                            ParentTreeViewItem = TreeViewGroups[mod.Section.ToLower()];
                        }
                        else
                        {
                            ParentTreeViewItem = new TreeViewItem();

                            StackPanel s = new StackPanel();
                            s.Orientation = Orientation.Horizontal;
                            Image img = new Image();

                            TextBlock t = new TextBlock();
                            t.Text = mod.Section;
                            s.Children.Add(img);
                            s.Children.Add(t);
                            ParentTreeViewItem.Header = s;

                            //ParentTreeViewItem.Header = mod.Section;
                            ParentTreeViewItem.Header = mod.Section;
                            ParentTreeViewItem.Tag = "";
                            NavigatorTreeView.Items.Add(ParentTreeViewItem);

                            TreeViewGroups.Add(mod.Section.ToLower(), ParentTreeViewItem);
                        }

                        TreeViewItem newChild = new TreeViewItem();
                        newChild.Header = mod.ModuleName;
                        newChild.Tag = mod.ModuleName;
                        newChild.IsExpanded = true;
                        ParentTreeViewItem.Items.Add(newChild);

                        newChild.MouseUp += new MouseButtonEventHandler(newChild_MouseUp);
                    }
                }
                catch { }
            }

            foreach (KeyValuePair<string, TreeViewItem> kvp in TreeViewGroups)
            {
                TreeViewItem i = kvp.Value;
                //Need to add some icons
            }
        }

        void newChild_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (((TreeViewItem)sender).Tag == null)
                    return;

                string Command = ((TreeViewItem)sender).Tag.ToString();

                if (Command == "Exit")
                {
                    //this.Close();
                    MainWindow.mMainWindow.Close();
                }
                else if (Command == "Keyboard")
                {
                    ToggleKeyBoard();
                }
                else if (Command == "Clipboard")
                {
                    ToggleClipboard();
                }
                else
                {
                    string ModuleName = ((TreeViewItem)sender).Tag.ToString();
                    DisplayModule(ModuleName);

                    this.Title = "Admin - " + ((TreeViewItem)sender).Header;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InitToolbar()
        {
            ModulesList.Children.Clear();
            for (int i = 0; i < ModuleManager.Instance.Modules.Length - 1; i++)
            {
                try
                {
                    ModuleItem mod = ModuleManager.Instance.Modules[i];
                    if (mod.MobileEnabled)
                    {
                        Button b = new Button();
                        b.Content = mod.ModuleName;
                        b.Tag = mod.ModuleName;
                        ModulesList.Children.Add(b);
                        b.Width = 100;

                        if (mod.ModuleName == "Exit")
                        {
                            b.Click += new RoutedEventHandler(ExitButton_Click); //+= new EventHandler(ExitButton_Click);
                        }
                        else if (mod.ModuleName == "Keyboard")
                        {
                            b.Click += new RoutedEventHandler(KeyBoardButton_Click);
                        }
                        else if (mod.ModuleName == "Clipboard")
                        {
                            b.Click += new RoutedEventHandler(ClipboardButton_Click);
                        }
                        else
                        {
                            b.Click += new RoutedEventHandler(MenuButton_Click);
                        }

                        if (b.Content.ToString() == "Main")
                        {
                            MenuButton_Click(b, new RoutedEventArgs());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    LogManager.Instance.LogMessage(ex);
                }

            }
        }

		private void ClipboardButton_Click(object sender, RoutedEventArgs e)
		{
			ToggleClipboard();
		}

        private void KeyBoardButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleKeyBoard();
        }

        private void ToggleKeyBoard()
        {
            if (KeyboardArea.Visibility == Visibility.Visible)
                KeyboardArea.Visibility = Visibility.Collapsed;
            else
                KeyboardArea.Visibility = Visibility.Visible;

            //if (MainKeyboard.Visibility == Visibility.Visible)
            //    MainKeyboard.Visibility = Visibility.Collapsed;
            //else
            //    MainKeyboard.Visibility = Visibility.Visible;
        }
        
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((Button)sender).Tag == null)
                    return;

                string ModuleName = ((Button)sender).Tag.ToString();
                DisplayModule(ModuleName);

                this.Title = " " + ((Button)sender).Content.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private IMDTModule DisplayModule(string ModuleName)
        {
            IMDTModule ReturnModule = null;
            try
            {
                if (m_Modules.ContainsKey(ModuleName))
                {
                    ReturnModule = m_Modules[ModuleName];
                }
                else
                {
                    try
                    {
                        ModuleItem modItem = ModuleManager.Instance.GetModuleItem(ModuleName);
                        if (modItem.PopupPage)
                        {
                            //if (modItem.Name.Contains("QueryCe") || modItem.Name.Contains("QueryExpress"))
                            //{
                            //    ObjectHandle handle2 = Activator.CreateInstanceFrom("DatabaseUtilities.dll", modItem.ClassName);
                            //    System.Windows.Forms.Form FormModule = (System.Windows.Forms.Form)handle2.Unwrap();
                            //    FormModule.Text = modItem.Name;
                            //    FormModule.Show();
                            //}
                            //else
                            //{
                                ObjectHandle handle2 = Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().Location, modItem.ClassName);
                                Window ModuleWindow = (Window)handle2.Unwrap();
                                ModuleWindow.Title = modItem.ModuleName;
                                ModuleWindow.Show();
                            //}
                        }
                        else
                        {
                            ObjectHandle handle = Activator.CreateInstanceFrom(Assembly.GetExecutingAssembly().Location, modItem.ClassName);
                            Page PageModule = (Page)handle.Unwrap();
                            PageModule.Width = double.NaN;
                            PageModule.Height = double.NaN;
                            PageModule.Title = modItem.ModuleName;

                            ReturnModule = (IMDTModule)PageModule;
                            m_Modules.Add(ModuleName, ReturnModule);
                            MainBackground.Children.Add(PageModule);

                            PageModule.Width = double.NaN;
                            PageModule.Height = double.NaN;

                            //NavigationService.GetNavigationService(this).Navigate(PageModule);
                            //ObjectHandle handle = Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().Location, ModuleName);
                            //ReturnModule = (IMDTModule)handle.Unwrap();
                            //Control c = ((Control)ReturnModule);
                            //m_Modules.Add(ModuleName, ReturnModule);
                            //MainBackground.Children.Add(c);
                            //c.Width = double.NaN;
                            //c.Height = double.NaN;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                foreach (UIElement child in MainBackground.Children)
                {
                    child.Visibility = Visibility.Collapsed;
                }

                if (ReturnModule != null)
                {
                    ((Page)ReturnModule).Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return ReturnModule;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("");
            //this.Close();
        }

        

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
				ToggleClipboard();
            }
            else if (e.Key == Key.F11)
            {
                ToggleToolbar();
            }
            else if (e.Key == Key.F9)
            {
                ToggleNavbar();
            }
        }

        private void ToggleNavbar()
        {
            try
            {
                if (NavigatorTreeView.Visibility == Visibility.Visible)
                    NavigatorTreeView.Visibility = Visibility.Collapsed;
                else
                    NavigatorTreeView.Visibility = Visibility.Visible;
            }
            catch { }
        }

        private void ToggleToolbar()
        {
            try
            {
                if (ModulesList.Visibility == Visibility.Visible)
                    ModulesList.Visibility = Visibility.Collapsed;
                else
                    ModulesList.Visibility = Visibility.Visible;
            }
            catch { }
        }

		private void ToggleClipboard()
		{
			try
			{
				if (psClipboard.Visibility == Visibility.Visible)
					psClipboard.Visibility = Visibility.Collapsed;
				else
					psClipboard.Visibility = Visibility.Visible;
			}
			catch { }
		}

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
        
            //if (MessageBox.Show("Close Application?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            //{
            //    //e.RoutedEvent.RoutingStrategy.     
                    
            //    //e.Cancel = true;
            //    //m_MessageManager.Close();
            //    //m_MessageManager = null;
            //}
        }
        

        //private void ModuleButton_Click(object sender, RoutedEventArgs e)
        //{
        //    HideAllControls();

        //    //foreach (UIElement uie in ModulesList.Children)
        //    //{
        //    //    Button bu = (Button)uie;
        //    //    bu.BorderBrush = new SolidColorBrush(Colors.Blue);  //Change border color
        //    //}

        //    //Button b = (Button)sender;
        //    //b.Style = new Button().Style;
        //    //b.BorderBrush = new SolidColorBrush(Colors.Red);//Change border color

        //    //if (m_ModuleCollection.ContainsKey(b.Tag.ToString()) == false )
        //    //{
        //    //    //switch (b.Tag.ToString())
        //    //    //{
        //    //    //    case CitationMenu.Mo:
        //    //    //        break;
        //    //    //}

        //    //    //m_CitationMenu = new CitationMenu();
        //    //    //MainCanvas.Children.Add(m_CitationMenu);
        //    //    //m_CitationMenu.Width = MainCanvas.Width;
        //    //    //m_CitationMenu.Height = MainCanvas.Height;
        //    //    //m_ControlList.Add((Control)m_CitationMenu);
        //    //}
        //    //m_CitationMenu.Visibility = Visibility.Visible;
        //    //ResizeAllControls();
        //}
    }
}
