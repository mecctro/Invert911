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
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Reflection;
using System.ComponentModel;

using Invert911.MDT;
using Invert911.InvertCommon.Framework.Interfaces;
using Invert911.InvertCommon.Framework.Communication;
using Invert911.Themes;
using Invert911.InvertCommon.Framework;

namespace Invert911.InvertCommon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        //public static Window mMainWindow;
        public static MainWindow mMainWindow;

        private i9ApplicationType mApplicationType = i9ApplicationType.i9FullClient;

        public i9ApplicationType AppType 
        { 
            get
            {
                return mApplicationType;   
            } 
        }

        public MainWindow(i9ApplicationType AppType)
        {
            InitializeComponent();
            mApplicationType = AppType;
        }

        public Window GetMainWindow
        {
            get { return mMainWindow; }
        }

        public string StatusBarItemMessage
        {
            get { return MessageStatusBarItem.Content.ToString(); }
            set { MessageStatusBarItem.Content = value; }
        }

        public string StatusBarItemUserName
        {
            get { return UserNameStatusBarItem.Content.ToString(); }
            set { UserNameStatusBarItem.Content = value; }
        }

        public bool ShowKeyBoard
        {
            get { return MainKeyBoard.Visibility == System.Windows.Visibility.Visible; }
            set { MainKeyBoard.Visibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Start app minimized.
            this.WindowState = System.Windows.WindowState.Maximized;

            //Set WPF Skin 
            ThemeManager.ApplyTheme(Application.Current, ThemeType.Royale);

            mMainWindow = this;
            SetWindowIcon();

            //Navigate to the login page:
            LoginPage lp = new LoginPage();
            MainFrame.Navigate(lp);
        }

        private void SetWindowIcon()
        {
            //Uri iconUri = new Uri("pack://application:,,,/Icon1.ico", UriKind.RelativeOrAbsolute);
            Uri iconUri = new Uri("pack://application:,,,/Invert911.InvertCommon;component/Images/Policeman.ico"); 
            switch (mApplicationType)
            {
                case i9ApplicationType.i9CloudClient:
                    iconUri = new Uri("pack://application:,,,/Invert911.InvertCommon;component/Images/InvertClientCloud.ico"); 
                    break;
                case i9ApplicationType.i9LiteClient:
                    iconUri = new Uri("pack://application:,,,/Invert911.InvertCommon;component/Images/InvertClientLite.ico"); 
                    break;
                default:
                    iconUri = new Uri("pack://application:,,,/Invert911.InvertCommon;component/Images/Policeman.ico"); 
                    break;
            }

            
            this.Icon = BitmapFrame.Create(iconUri);
        }

        private void ShowMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content.GetType() == typeof(MainMenuPage))
            {
                MainMenuPage MenuPage = (MainMenuPage)MainFrame.Content;
                MenuPage.IsMenuVisible = !MenuPage.IsMenuVisible;
            }
        }

        private void ShowKeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            this.ShowKeyBoard = !MainWindow.mMainWindow.ShowKeyBoard;
        }

        private void NightModeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ThemeType t = ThemeType.Royale;
                if (NightModeButton.Content.ToString() == "Night Mode")
                {
                    t = ThemeType.psNightTime;
                    NightModeButton.Content = "Day Mode";
                }
                else
                {
                    t = ThemeType.Royale;
                    NightModeButton.Content = "Night Mode";
                }
                Invert911.Themes.ThemeManager.ApplyTheme(Application.Current, t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CommandButton_Click(object sender, RoutedEventArgs e)
        {

            if (ConsoleTextBox.Visibility == System.Windows.Visibility.Visible)
                ConsoleTextBox.Visibility = System.Windows.Visibility.Collapsed;
            else
                ConsoleTextBox.Visibility = System.Windows.Visibility.Visible;

        }
    }
}