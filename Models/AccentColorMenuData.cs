using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Theme.Manager.MahApps.WPF
{
    public class AccentColorMenuData
    {
        public string Name { get; set; }

        public Brush BorderColorBrush { get; set; }

        public Brush ColorBrush { get; set; }

        public ICommand ChangeAccentCommand { get; }

        public AccentColorMenuData()
        {
            ChangeAccentCommand = new SimpleCommand(o => true, OnChangeColor);
        }

        protected virtual void OnChangeColor(object sender)
        {
            Application.Current.Properties["Color"] = Name.ToString();
            _ = ControlzEx.Theming.ThemeManager.Current.ChangeThemeColorScheme(Application.Current, Name);
        }
    }
}
