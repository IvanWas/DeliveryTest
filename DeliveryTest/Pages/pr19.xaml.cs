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
    /// Логика взаимодействия для pr19.xaml
    /// </summary>
    public partial class pr19 : Page
    {
        public pr19()
        {
            InitializeComponent();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Customers());
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Categories());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Orders());
        }
    }
}
