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
using System.IO;

using Invert911.Admin;
using Invert911.InvertCommon.Modules;
using Invert911.InvertCommon.Messages.Admin;
using Invert911.InvertCommon.Framework.Communication;
using Invert911.InvertCommon;
using Invert911.InvertCommon.Utilities;
using Invert911.InvertCommon.Framework;

namespace Invert911.MDT
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //Set the UI to read only
            Messagelabel.Content = "";
            OKButton.IsEnabled = false;
            CancelButton.IsEnabled = true;
            SettingsButton.IsEnabled = false;

            //send message 
            LoginMessage LoginMsg = new LoginMessage();
            LoginMsg.UserName = this.UserNameTextBox.Text;
            LoginMsg.Password = PasswordTextBox.Password;

            i9Message responseMsg = i9MessageManager.SendMessage(MobileMessageType.Admin, AdminType.Login, "LoginPage", LoginMsg.GetType(), LoginMsg);

            if (responseMsg.ErrorStatus.IsError)
            {
                Messagelabel.Content = responseMsg.ErrorStatus.ErrorMsg +
                    Environment.NewLine + responseMsg.ErrorStatus.ErrorException +
                    Environment.NewLine + DateTime.Now.ToString();

                OKButton.IsEnabled = true;
                CancelButton.IsEnabled = true;
                SettingsButton.IsEnabled = true;

                return;
            }

            if (responseMsg.MsgBodyDataSet == null ||responseMsg.MsgBodyDataSet.Tables[0].Rows.Count <= 0)
            {
                Messagelabel.Content = "Wrong user name or password, please try again.";

                OKButton.IsEnabled = true;
                CancelButton.IsEnabled = true;
                SettingsButton.IsEnabled = true;

                return;
            }

            //Save Login Information
            SettingManager.Instance.LoginDataSet = responseMsg.MsgBodyDataSet;

            MainWindow.mMainWindow.StatusBarItemUserName = "User: " + UserNameTextBox.Text;
            MainWindow.mMainWindow.StatusBarItemMessage = "";

            if (LaunchMobileTerminalCheckBox.IsChecked == false || LaunchMobileTerminalCheckBox.IsChecked == null)
            {
                ModuleManager.Instance.NavigateTo(this, "SplashPage");
                //ModuleManager.Instance.NavigateTo(this, "MainMenuPage");
            }
            else
            {
                ModuleManager.Instance.NavigateTo(this, "MobileTerminalPage");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Width = Double.NaN;
                this.Height = Double.NaN;
                this.ShowsNavigationUI = false;

                this.UserNameTextBox.Focus();

                //Window win = (Window)this.Parent;
                //Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/YourReferencedAssembly;component/YourPossibleSubFolder/YourResourceFile.ico")).Stream;
                //Uri iconUri = new Uri("pack://application:,,,/MobileTerminal.ico", UriKind.RelativeOrAbsolute);
                //win.Icon = BitmapFrame.Create(iconUri);
                //win.Title = "Public Safety";
                //win.WindowState = WindowState.Maximized;
                
                //Application.Current.Resources = PublicSafety.Themes.ThemeManager.GetThemeResourceDictionary(PublicSafety.Themes.ThemeManager.GetThemes()[0]);

                //if (String.IsNullOrEmpty(UserNameTextBox.Text) == false && String.IsNullOrEmpty(PasswordTextBox.Password) == false)
                //    OKButton_Click(null, null);

                SetWindowIcon();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }


        private void SetWindowIcon()
        {
            //Uri iconUri = new Uri("pack://application:,,,/Icon1.ico", UriKind.RelativeOrAbsolute);
            Uri iconUri = new Uri("pack://application:,,,/Invert911.InvertCommon;component/Images/Policeman.ico");
            switch (MainWindow.mMainWindow.AppType)
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

            BitmapImage image = new BitmapImage(iconUri);
            //Image img = new Image();
            //img.Source = image;

            this.LogoImage.Source = image; 
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (OKButton.IsEnabled)
            {
                MainWindow.mMainWindow.Close();
            }
            else
            {
                i9MessageManager.CancelAllMessages();
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new SettingsPage());
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OKButton_Click(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                CancelButton_Click(null, null);
            }
        }
    }
}
