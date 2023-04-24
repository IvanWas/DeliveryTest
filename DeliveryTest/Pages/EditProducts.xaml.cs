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
    /// Логика взаимодействия для EditProducts.xaml
    /// </summary>
    public partial class EditProducts : Page
    {
        private Products _currentProducts = new Products();
        public EditProducts()
        {
            InitializeComponent();
            DataContext = _currentProducts;
            ComdoCategories.ItemsSource = MusicalInstrumentShopEntities1.GetContext().Categories.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Products());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //StringBuilder errors = new StringBuilder();

            //if (string.IsNullOrWhiteSpace(_currentProducts.Name))
            //    errors.AppendLine("Укажите название");
            //if (_currentProducts.Price)
            //    errors.AppendLine("Укажите цену");
            //if (_currentProducts.Height)
            //    errors.AppendLine("Укажите высоту");
            //if (_currentProducts.Width)
            //    errors.AppendLine("Укажите ширину");
            //if (_currentProducts.Length)
            //    errors.AppendLine("Укажите длинну");
            //if (_currentProducts.Weight)
            //    errors.AppendLine("Укажите вес");
            //if (_currentProducts.Categories == null)
            //    errors.AppendLine("Выберите категорию");

            //if (errors.Length > 0)
            //{
            //    MessageBox.Show(errors.ToString());
            //    return;
            //}
            
            //if (_currentProducts. == 0)
            //{
            //    MusicalInstrumentShopEntities1.GetContext().Products.Add(_currentProducts);
            //}

            //try
            //{
            //    MusicalInstrumentShopEntities1.GetContext().SaveChanges();
            //    MessageBox.Show("Информация сохранена!");
            //    NavigationService.GoBack();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

    }
}
