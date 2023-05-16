using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DeliveryTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditProducts.xaml
    /// </summary>
    public partial class EditProducts : Page
    {
        private Products _currentProducts = new Products();
        public EditProducts(Products selectedProducts)
        {
            InitializeComponent();
            if (selectedProducts != null)
                _currentProducts = selectedProducts;
            DataContext = _currentProducts;
            ComdoCategories.ItemsSource = DBContext.GetContext().Categories.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentProducts.Name))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentProducts.Width.ToString()))
                errors.AppendLine("Укажите цену");
            if (string.IsNullOrWhiteSpace(_currentProducts.Height.ToString()))
                errors.AppendLine("Укажите высоту");
            if (string.IsNullOrWhiteSpace(_currentProducts.Length.ToString()))
                errors.AppendLine("Укажите длинну");
            if (string.IsNullOrWhiteSpace(_currentProducts.Weight.ToString()))
                errors.AppendLine("Укажите вес");
            if (_currentProducts.Categories == null)
                errors.AppendLine("Выберите категорию");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentProducts.Id == 0)
            {
                DBContext.GetContext().Products.Add(_currentProducts);
            }

            try
            {
                DBContext.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            NavigationService.Navigate(new ProductsPage());
        }

    }
}
