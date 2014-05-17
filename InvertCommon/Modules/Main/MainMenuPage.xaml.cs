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
using System.Runtime.Remoting;
using System.Reflection;
using System.Windows.Controls.Primitives;

using Invert911.InvertCommon.Modules;
using Invert911.InvertCommon.Utilities;
using Invert911.InvertCommon;
using System.Data;

namespace Invert911.MDT
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
            LoadModules();
        }

        public bool IsMenuVisible
        {
            get 
            { 
                if (MenuDockPanel.Visibility == System.Windows.Visibility.Visible)
                    return true; 
                else
                    return false; 
            }
            set 
            {
                if (value)
                    MenuDockPanel.Visibility = System.Windows.Visibility.Visible;
                else
                    MenuDockPanel.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void LoadModules()
        {
            Dictionary<string, StackPanel> TabSections = new Dictionary<string, StackPanel>();
            Button SelectButton = null;

            //bool DemoUser = true;
            //if (SettingManager.Instance.LoginDataSet.Tables["i9SysPersonnel"].Rows[0]["DemoUser"].ToString() == "0")
            //{
            //    DemoUser = false;
            //}


            Dictionary<string, string> xxSecurityGroupModule = new Dictionary<string, string>();
            foreach (DataRow dr in SettingManager.Instance.LoginDataSet.Tables["xxSecurityGroupModule"].Rows)
            {
                if (xxSecurityGroupModule.ContainsKey(dr["ModuleName"].ToString()) == false)
                {
                    xxSecurityGroupModule.Add(dr["ModuleName"].ToString().ToUpper(), dr["ModuleName"].ToString().ToUpper());
                }

            }

            for (int i = 0; i < ModuleManager.Instance.Modules.Length - 1; i++)
            {
                try
                {
                    ModuleItem mod = ModuleManager.Instance.Modules[i];

                    if (mod.ModuleName.ToUpper() == "CRIME WATCH")
                    {
                        Console.Write("ddddd");
                    }

                    //If User has securoity rights to see the module then display the module
                    if(xxSecurityGroupModule.ContainsKey(mod.ModuleName.ToUpper()))
                    {
                        StackPanel lStackPanel = new StackPanel();

                        //ModuleItem mod = ModuleManager.Instance.Modules[i];
                        if (mod.DesktopEnabled)
                        {
                            if (TabSections.ContainsKey(mod.Section))
                            {
                                lStackPanel = TabSections[mod.Section];
                            }
                            else
                            {
                                Expander e = new Expander();
                                e.Header = mod.Section;
                                e.IsExpanded = true;
                                NavigationStackPanel.Children.Add(e);

                                lStackPanel = new StackPanel();
                                lStackPanel.Name = mod.Section + "StackPanel";
                                e.Content = lStackPanel;

                                TabSections.Add(mod.Section, lStackPanel);
                            }

                            TextBlock butonTextBlock = new TextBlock();
                            butonTextBlock.TextWrapping = TextWrapping.WrapWithOverflow;
                            butonTextBlock.Text = mod.ModuleName;
                            //butonTextBlock.TextAlignment = TextAlignment.Center;

                            //Create Image button
                            Image ButtonImage = new Image();
                            BitmapImage logo = new BitmapImage();
                            logo.BeginInit();
                            //http://stackoverflow.com/questions/350027/setting-wpf-image-source-in-code
                            logo.UriSource = new Uri("pack://application:,,,/Invert911.InvertCommon;component/Images/form_blue.png"); 
                            logo.EndInit();
                            ButtonImage.Source = logo;
                            ButtonImage.Height = 12;
                            ButtonImage.Width = 12;
                            ButtonImage.Margin = new Thickness(0, 0, 5, 0);

                            //Add Grid to button content and set the image and text inside the grid
                            var oGrid = new Grid();
                            oGrid.Background = new SolidColorBrush(Colors.Transparent);
                            oGrid.ColumnDefinitions.Add(new ColumnDefinition());
                            oGrid.ColumnDefinitions.Add(new ColumnDefinition());

                            oGrid.Children.Add(ButtonImage);
                            Grid.SetColumn(ButtonImage, 0);
                            Grid.SetRow(ButtonImage, 0);

                            oGrid.Children.Add(butonTextBlock);
                            Grid.SetColumn(butonTextBlock, 1);
                            Grid.SetRow(butonTextBlock, 0);

                            Button b = new Button();
                            b.Content = oGrid;
                            b.Height = 35;
                            b.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
                            b.Tag = mod.ModuleKey;

                            if (mod.ModuleName.Contains("Dynamic"))
                            {
                                SelectButton = b;
                            }
                            else
                            {
                                if (SelectButton == null)
                                    SelectButton = b;
                            }
                        
                            lStackPanel.Children.Add(b);
                            b.Margin = new Thickness(4, 4, 4, 4);

                            if (mod.ModuleName == "Exit")
                                b.Click += new RoutedEventHandler(ExitButton_Click);
                            else if (mod.ModuleName == "Keyboard")
                                b.Click += new RoutedEventHandler(KeyboardButton_Click);
                            else if (mod.ModuleName == "Clipboard")
                                b.Click += new RoutedEventHandler(ClipboardButton_Click); 
                            else
                                b.Click += new RoutedEventHandler(MenuButton_Click);
                        }

                    }



                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogMessage("Error loading module",ex);
                }
            }

            //Raise the click event on the selected button.
            if (SelectButton != null)
                SelectButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); ;

            //MainFrameNavigateTo("MainPage");
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((Button)sender).Tag == null)
                    return;

                string ModuleKey = ((Button)sender).Tag.ToString();
                ModuleItem mi = ModuleManager.Instance.GetModuleItem(ModuleKey);
                DisplayModule(mi);

                this.Title = "Invert - " + ((Button)sender).Content;
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error clicking the Menu button", ex);
                MessageBox.Show("Error clicking the Menu button: " + ex.Message);
            }
        }

        private void DisplayModule(ModuleItem modItem)
        {
            try
            {
                if (modItem.ModuleType == ModuleTypeEnum.None)
                {
                    //Do Nothing 
                }
                else if (modItem.ModuleType == ModuleTypeEnum.Form) // .Name.Equals("QueryCe") || modItem.Name.Equals("QueryExpress"))
                {
                    System.Windows.Forms.Form FormModule = ModuleManager.Instance.GetModuleForm(modItem.ModuleKey);
                    FormModule.Show();

                }
                else if (modItem.ModuleType == ModuleTypeEnum.Window)
                {
                    Window ModuleWindow = ModuleManager.Instance.GetModuleWindows(modItem.ModuleKey);
                    ModuleWindow.Show();
                }
                else
                {
                    MainFrameNavigateTo(modItem.ModuleKey);
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogMessage("Error displaying module", ex);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void MainFrameNavigateTo(string ModuleKey)
        {
            Page PageModule = null;
            
            ModuleItem modItem = ModuleManager.Instance.GetModuleItem(ModuleKey);

            if (modItem.Instance == null)
                PageModule = ModuleManager.Instance.GetModulePage(modItem.ModuleKey);
            else
                PageModule = (Page)modItem.Instance;

            PageModule.Width = double.NaN;
            PageModule.Height = double.NaN;
            PageModule.Title = modItem.ModuleName;
            MainFrame.Navigate(PageModule);
        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void ClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mMainWindow.Close();
        }

        private void GoNoWhere(object sender, ExecutedRoutedEventArgs args)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }
    }
}
