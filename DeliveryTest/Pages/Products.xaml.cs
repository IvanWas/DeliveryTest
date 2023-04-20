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
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
            DataGridProducts.ItemsSource = MusicalInstrumentShopEntities1.Context.Products.ToList().Select(x => new
            {
                Name = x.Name,
                Count = x.Count,
                Price = x.Price,
                Height = x.Height,
                Width = x.Width,
                Length = x.Length,
                Weight = x.Weight,
                CategoryId = x.CategoryId,
            }).ToList();
        }

       
    }

        
}
