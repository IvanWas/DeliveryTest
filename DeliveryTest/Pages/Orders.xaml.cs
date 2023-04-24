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
using System.Diagnostics;
using System.IO;
using Path = System.IO.Path;
using Microsoft.Win32;

namespace DeliveryTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void Button_Click_Import(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogWindow = new OpenFileDialog();
            dialogWindow.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dialogWindow.ShowDialog();
            if (dialogWindow.FileName == "")
            {
                MessageBox.Show("Файл для импорта не выбран!");
            }
            else
            {
                string fileContent = File.ReadAllText(dialogWindow.FileName);
                MessageBox.Show(fileContent, "Содержимое файла");
            }
        }

        private void Button_Click_Export(object sender, RoutedEventArgs e)
        {
            ExportData(path);
        }

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "exportFile.txt");

        private void ExportData(string path)
        {
            StreamWriter streamWriter = new StreamWriter(path);

            using (var context = new MusicalInstrumentShopEntities1())
            {
                foreach (var element in context.Couriers)
                {
                    streamWriter.WriteLine($"{element.FullName} {element.Phone} {element.Username} {element.Password}");
                }
            }
            streamWriter.Close();
            Process.Start("notepad.exe", path);
        }

        private void Button_Click_BD(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pr19());
        }
    }
}
