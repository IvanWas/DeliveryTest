using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DeliveryTest.Utilities;

namespace DeliveryTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {

        public static Themes.ThemesEnum CurrentTheme = Themes.ThemesEnum.Light;
        public Authorization()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Login.Text) || String.IsNullOrEmpty(Password.Text))

            {
                MessageBox.Show("Есть незаполненные поля", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            using (var db = new MusicalInstrumentShopEntities())
            {
                var users = db.Couriers.FirstOrDefault(u => u.Username == Login.Text && u.Password == Password.Text);

                if (users == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
            }
            NavigationService.Navigate(new Orders());
        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTheme == Themes.ThemesEnum.Light) CurrentTheme = Themes.ThemesEnum.Dark;
            else if (CurrentTheme == Themes.ThemesEnum.Dark) CurrentTheme = Themes.ThemesEnum.Light;
            Themes.ChangeTheme(CurrentTheme);
        }
    }
}
