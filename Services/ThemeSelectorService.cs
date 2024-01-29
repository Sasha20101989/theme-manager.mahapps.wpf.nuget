using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ControlzEx.Theming;
using MahApps.Metro.Theming;

namespace Theme.Manager.MahApps.WPF
{
    public class ThemeManager : IThemeManager
    {
        private const string _hcDarkTheme = "pack://application:,,,/Styles/Themes/HC.Dark.Blue.xaml";
        private const string _hcLightTheme = "pack://application:,,,/Styles/Themes/HC.Light.Blue.xaml";

        public ThemeManager()
        {
        }


        public void InitializeTheme()
        {
            _ = ControlzEx.Theming.ThemeManager.Current.AddLibraryTheme(new LibraryTheme(new Uri(_hcDarkTheme), MahAppsLibraryThemeProvider.DefaultInstance));
            _ = ControlzEx.Theming.ThemeManager.Current.AddLibraryTheme(new LibraryTheme(new Uri(_hcLightTheme), MahAppsLibraryThemeProvider.DefaultInstance));

            AppTheme theme = GetCurrentTheme();
            SetTheme(theme);
        }

        public void SetTheme(AppTheme theme)
        {
            if (theme == AppTheme.Default)
            {
                ControlzEx.Theming.ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncAll;
                ControlzEx.Theming.ThemeManager.Current.SyncTheme();
            }
            else
            {
                ControlzEx.Theming.ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncWithHighContrast;
                ControlzEx.Theming.ThemeManager.Current.SyncTheme();
                _ = ControlzEx.Theming.ThemeManager.Current.ChangeTheme(Application.Current, $"{theme}.Blue", SystemParameters.HighContrast);
            }

            Application.Current.Properties["Theme"] = theme.ToString();
        }

        public AppTheme GetCurrentTheme()
        {
            if (Application.Current.Properties.Contains("Theme"))
            {
                string themeName = Application.Current.Properties["Theme"].ToString();
                _ = Enum.TryParse(themeName, out AppTheme theme);
                return theme;
            }

            return AppTheme.Default;
        }

        public IEnumerable<AccentColorMenuData> GetColors()
        {
            return ControlzEx.Theming.ThemeManager.Current.Themes
                                            .GroupBy(x => x.ColorScheme)
                                            .OrderBy(a => a.Key)
                                            .Select(a => new AccentColorMenuData { Name = a.Key, ColorBrush = a.First().ShowcaseBrush })
                                            .ToList();
        }

        public string GetCurrentColor()
        {
            if (Application.Current.Properties.Contains("Color"))
            {
                string colorName = Application.Current.Properties["Color"].ToString();
                return colorName;
            }

            return "#FFF5671E";
        }

        public void InitializeColor()
        {
            string color = GetCurrentColor();
            SetColor(color);
        }

        private static void SetColor(string color)
        {
            _ = ControlzEx.Theming.ThemeManager.Current.ChangeThemeColorScheme(Application.Current, color);
        }
    }
}
