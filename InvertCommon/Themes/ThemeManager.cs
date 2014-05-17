namespace Invert911.Themes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    

    public enum ThemeType  
    { 
        Royale,
        //ExpressionDark, 
        ExpressionLight,
        psDefault,
        psNightTime
        //RainierOrange, 
        //RainierPurple, 
        //ShinyBlue, 
        //ShinyRed, 
        //DavesGlossyControls, 
        //WhistlerBlue, 
        //BureauBlack, 
        //BureauBlue, 
        //BubbleCreme, 
        //TwilightBlue,
        //UXMusingsRed, 
        //UXMusingsGreen, 
        //UXMusingsRoughRed, 
        //UXMusingsRoughGreen, 
        //UXMusingsBubblyBlue
        //RainierRadialBlue, 
        //ShinyDarkTeal, 
        //ShinyDarkGreen, 
        //ShinyDarkPurple,
    }

    public static class ThemeManager
    {


        private static ResourceDictionary GetThemeResourceDictionary(ThemeType? theme)
        {
            ResourceDictionary dictionary = null;
            if (theme != null)
            {
                switch (theme)
                {
                    case ThemeType.Royale:
                        dictionary = new ResourceDictionary();
                        string s = "/PresentationFramework.Royale, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, ProcessorArchitecture=MSIL;component/themes/Royale.normalcolor.xaml";
                        dictionary.Source = new Uri(s, UriKind.Relative);
                        //Application.Current.Resources.MergedDictionaries.Clear();
                        //Application.Current.Resources.MergedDictionaries.Add(dictionary);
                        break;
                    default:
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        string packUri = String.Format(@"/Invert911.InvertCommon;component/Themes/{0}/Theme.xaml", theme);
                        dictionary = Application.LoadComponent(new Uri(packUri, UriKind.Relative)) as ResourceDictionary;
                        break;
                }
            }
            return dictionary;
        }

        public static string[] GetThemes()
        {
            return Enum.GetNames(typeof(ThemeType));
        }

        public static void ApplyTheme(this Application app, ThemeType theme)
        {
            ResourceDictionary dictionary = ThemeManager.GetThemeResourceDictionary(theme);

            if (dictionary != null)
            {
                app.Resources.MergedDictionaries.Clear();
                app.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        public static void ApplyTheme(this ContentControl control, ThemeType theme)
        {
            ResourceDictionary dictionary = ThemeManager.GetThemeResourceDictionary(theme);

            if (dictionary != null)
            {
                control.Resources.MergedDictionaries.Clear();
                control.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        #region Theme

        /// <summary>
        /// Theme Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.RegisterAttached("Theme", typeof(string), typeof(ThemeManager),
                new FrameworkPropertyMetadata((string)string.Empty,
                    new PropertyChangedCallback(OnThemeChanged)));

        /// <summary>
        /// Gets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static string GetTheme(DependencyObject d)
        {
            return (string)d.GetValue(ThemeProperty);
        }

        /// <summary>
        /// Sets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetTheme(DependencyObject d, string value)
        {
            d.SetValue(ThemeProperty, value);
        }

        /// <summary>
        /// Handles changes to the Theme property.
        /// </summary>
        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string theme = e.NewValue as string;
            if (theme == string.Empty)
                return;

            ContentControl control = d as ContentControl;
            if (control != null)
            {
                ThemeType t = ThemeType.Royale;
                Enum.TryParse<ThemeType>(theme, out t);
                control.ApplyTheme(t);
            }
        }

        #endregion



    }
}
