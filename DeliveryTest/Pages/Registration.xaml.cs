using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
using System.Xml.Linq;
using System.Security.Cryptography;

namespace DeliveryTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private readonly MusicalInstrumentShopEntities1 database;
        public static Themes.ThemesEnum CurrentTheme = Themes.ThemesEnum.Light;
        public Registration()
        {
            InitializeComponent();
            database = new MusicalInstrumentShopEntities1();
        }

       
        private void RegisterUser(Couriers user)
        {
            try
            {
                database.Couriers.Add(user);
                database.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return
                string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTBReg.Text;
            string password = PasswordTBReg.Text;
            string passwordTwo = PasswordTwoTBReg.Text;
            string fio = FIOTBReg.Text;
            string phone = PhoneTBReg.Text;
            if (new[] { login, password, passwordTwo, fio, phone }.Any(x => String.IsNullOrWhiteSpace(x)))
            {
                MessageBox.Show("Есть незаполненные поля", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (new[] { login, password, passwordTwo, fio, phone }.Where(x => x.Length < 6).Any())
            {
                MessageBox.Show("Поля должны быть боьше 6", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (password != passwordTwo)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                PasswordTBReg.Text = "";
                PasswordTwoTBReg.Text = "";
                return;
            }

            if (UserExists(login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginTBReg.Text = "";
                return;
            }


            RegisterUser(new Couriers { Username = login, Password = GetHash(password), FullName = fio, Phone = phone });

            MessageBox.Show("Вы успешно зарегистрировались", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new Authorization());
        }
        private bool UserExists(string login)
        {
            return database.Couriers.FirstOrDefault(x => x.Username == login) != null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTheme == Themes.ThemesEnum.Light) CurrentTheme = Themes.ThemesEnum.Dark;
            else if (CurrentTheme == Themes.ThemesEnum.Dark) CurrentTheme = Themes.ThemesEnum.Light;
            Themes.ChangeTheme(CurrentTheme);
        }
    }
}
