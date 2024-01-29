using System.Collections.Generic;

namespace Theme.Manager.MahApps.WPF
{
    public interface IThemeManager
    {
        void InitializeTheme();

        void SetTheme(AppTheme theme);

        AppTheme GetCurrentTheme();

        IEnumerable<AccentColorMenuData> GetColors();
        void InitializeColor();

        string GetCurrentColor();
    }
}
