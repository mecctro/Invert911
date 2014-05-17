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
using Invert911.InvertCommon;

namespace Invert911.MDT
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LoadModules();
        }

        private void LoadModules()
        {
            Dictionary<string, WrapPanel> TabSections = new Dictionary<string, WrapPanel>();

            for (int i = 0; i < ModuleManager.Instance.Modules.Length - 1; i++)
            {
                try
                {
                    ModuleItem mod = ModuleManager.Instance.Modules[i];
                    WrapPanel lWrapPanel = new WrapPanel();
                    
                    if (mod.DesktopEnabled)
                    {
                        if (TabSections.ContainsKey(mod.Section))
                        {
                            lWrapPanel = TabSections[mod.Section];
                        }
                        else
                        {
                            TabItem ti = new TabItem();
                            TextBlock tb = new TextBlock();
                            tb.FontSize = 16;
                            tb.Width = 120;
                            //tb.Height = 50;
                            tb.Text = mod.Section;
                            tb.TextAlignment = TextAlignment.Center;
                            ti.Header = tb;
                            ModulesTabControl.Items.Add(ti);

                            ti.Width = double.NaN;
                            ti.Height = double.NaN;
                            lWrapPanel = new WrapPanel();

                            ti.Content = lWrapPanel;
                            TabSections.Add(mod.Section, lWrapPanel);
                        }

                        TextBlock butonTextBlock = new TextBlock();
                        butonTextBlock.FontSize = 16;
                        butonTextBlock.Width = 120;
                        butonTextBlock.TextWrapping = TextWrapping.WrapWithOverflow;
                        butonTextBlock.Text = mod.ModuleName;
                        butonTextBlock.TextAlignment = TextAlignment.Center;

                        Button b = new Button();
                        b.Content = butonTextBlock;
                        b.Tag = mod.i9ModuleID;
                        b.Height = 160;  //for the lStackPanel
                        b.Width = 160;

                        lWrapPanel.Children.Add(b);
                        b.Margin = new Thickness(4, 4, 4, 4);

                        if (mod.ModuleName == "Exit")
                            b.Click += new RoutedEventHandler(ExitButton_Click); //+= new EventHandler(ExitButton_Click);
                        else
                            b.Click += new RoutedEventHandler(MenuButton_Click);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
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
                MessageBox.Show("Error: " + ex.Message);
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
                    //ObjectHandle handle2 = Activator.CreateInstanceFrom(Assembly.GetExecutingAssembly().Location, modItem.ClassName);
                    //System.Windows.Forms.Form FormModule = (System.Windows.Forms.Form)handle2.Unwrap();
                    //FormModule.Text = modItem.Name;

                    System.Windows.Forms.Form FormModule = ModuleManager.Instance.GetModuleForm(modItem.i9ModuleID);
                    FormModule.Show();

                }
                else if (modItem.ModuleType == ModuleTypeEnum.Window)
                {
                    //ObjectHandle handle2 = Activator.CreateInstanceFrom(Assembly.GetExecutingAssembly().Location, modItem.ClassName);
                    //Window ModuleWindow = (Window)handle2.Unwrap();
                    //ModuleWindow.Title = modItem.Name;

                    Window ModuleWindow = ModuleManager.Instance.GetModuleWindows(modItem.i9ModuleID);
                    ModuleWindow.Show();
                }
                else
                {
                    //ObjectHandle handle = Activator.CreateInstanceFrom(Assembly.GetExecutingAssembly().Location, modItem.ClassName);
                    //Page PageModule = (Page)handle.Unwrap();
                    Page PageModule = null;

                    if(modItem.Instance == null)
                        PageModule = ModuleManager.Instance.GetModulePage(modItem.i9ModuleID);
                    else
                        PageModule = (Page)modItem.Instance;
                    
                    PageModule.Width = double.NaN;
                    PageModule.Height = double.NaN;
                    PageModule.Title = modItem.ModuleName;
                    NavigationService.GetNavigationService(this).Navigate(PageModule);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mMainWindow.Close(); 
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }
    }
}