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
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            DataGridProducts.ItemsSource = MusicalInstrumentShopEntities1.GetContext().Products.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pr19());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EditProducts((sender as Button).DataContext as Products));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditProducts(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = DataGridProducts.SelectedItems.Cast<Products>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {productForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusicalInstrumentShopEntities1.GetContext().Products.RemoveRange(productForRemoving);
                    MusicalInstrumentShopEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridProducts.ItemsSource = MusicalInstrumentShopEntities1.GetContext().Products.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MusicalInstrumentShopEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(r => r.Reload());
                DataGridProducts.ItemsSource = MusicalInstrumentShopEntities1.GetContext().Products.ToList();
            }
        }
    }

        
}
