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
using Invert911.Themes;

namespace Invert911.InvertCommon.Modules.Law.PolicePad
{
    /// <summary>
    /// Interaction logic for IncidentLite.xaml
    /// </summary>
    public partial class PolicePadWindow : Window
    {
        //public static Window mMainWindow;
        public static PolicePadWindow mMainWindow;

        public PolicePadWindow()
        {
            InitializeComponent();
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
            this.WindowState = System.Windows.WindowState.Normal;

            //Set WPF Skin 
            ThemeManager.ApplyTheme(Application.Current, ThemeType.Royale);

            mMainWindow = this;

            //Navigate to the Incident Entry Page:
            PolicePadWorkspace lp = new PolicePadWorkspace();
            MainFrame.Navigate(lp);
        }

        private void ShowKeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            this.ShowKeyBoard = !PolicePadWindow.mMainWindow.ShowKeyBoard;
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

        //private void CommandButton_Click(object sender, RoutedEventArgs e)
        //{

        //    if (ConsoleTextBox.Visibility == System.Windows.Visibility.Visible)
        //        ConsoleTextBox.Visibility = System.Windows.Visibility.Collapsed;
        //    else
        //        ConsoleTextBox.Visibility = System.Windows.Visibility.Visible;

        //}

        //private void ShowMenuButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MainFrame.Content.GetType() == typeof(MainMenuPage))
        //    {
        //        MainMenuPage MenuPage = (MainMenuPage)MainFrame.Content;
        //        MenuPage.IsMenuVisible = !MenuPage.IsMenuVisible;
        //    }
        //}
    }
}
