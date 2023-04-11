using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryTest.Utilities
{
    public class Themes
    {
        public enum ThemesEnum { Light, Dark };
        private static Dictionary<ThemesEnum, string> themesPath = new Dictionary<ThemesEnum, string>()
        {
            { ThemesEnum.Light, @"Dictionaries\LightTheme.xaml" },
            {ThemesEnum.Dark, @"Dictionaries\DarkTheme.xaml" }
        };
        public static void ChangeTheme(ThemesEnum theme)
        {
            var uri = new Uri(themesPath[theme], UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
