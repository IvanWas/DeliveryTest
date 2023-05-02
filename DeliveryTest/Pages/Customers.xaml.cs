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

namespace DeliveryTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        public Customers()
        {
            InitializeComponent();
            var currents = MusicalInstrumentShopEntities1.GetContext().Customers.ToList();
            ListCustomers.ItemsSource = currents;
            ListCustomers.ItemsSource = MusicalInstrumentShopEntities1.GetContext().Customers.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pr19());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            ListCustomers.ItemsSource = MusicalInstrumentShopEntities1.GetContext().Customers.ToList().Where(x => $"{x.FullName}".ToLower().Contains(Tb.Text.ToLower())).ToList();
        }
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListCustomers.ItemsSource = ListCustomers.ItemsSource.OfType<DeliveryTest.Customers>().OrderBy(x => x.FullName).ToList();
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            ListCustomers.ItemsSource = ListCustomers.ItemsSource.OfType<DeliveryTest.Customers>().OrderByDescending(x => x.FullName).ToList();
        }
    }
}

