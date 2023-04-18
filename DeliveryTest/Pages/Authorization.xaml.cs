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
using System.Security.Cryptography;

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
            if (String.IsNullOrEmpty(LoginTB.Text) || String.IsNullOrEmpty(PasswordTB.Text))

            {
                MessageBox.Show("Есть незаполненные поля", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                var database = new MusicalInstrumentShopEntities1();
                var pass = Registration.GetHash(PasswordTB.Text);
                var сouriers = database.Couriers.FirstOrDefault(u => u.Username == LoginTB.Text && u.Password == pass);


                if (сouriers != null && (сouriers.Username != LoginTB.Text || сouriers.Password != pass))
                {
                    var result = MessageBox.Show("Пользователь под таким именем не найден!", "Ошибка авторизации", MessageBoxButton.YesNo, MessageBoxImage.Information);
                }
                
                else if (сouriers == null)
                {
                    var result = MessageBox.Show("Пользователь не найден, хотите зарегистрироваться?", "Ошибка авторизации", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        NavigationService.Navigate(new Registration());
                    }
                    LoginTB.Text = "";
                    PasswordTB.Text = "";

                }
                else if (сouriers.Username == LoginTB.Text && сouriers.Password == pass)
                {
                    MessageBox.Show($"Доброго времени суток, {сouriers.FullName}! У Вас вышло авторизоваться!");
                    NavigationService.Navigate(new Orders());
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTheme == Themes.ThemesEnum.Light) CurrentTheme = Themes.ThemesEnum.Dark;
            else if (CurrentTheme == Themes.ThemesEnum.Dark) CurrentTheme = Themes.ThemesEnum.Light;
            Themes.ChangeTheme(CurrentTheme);
        }
    }
}
