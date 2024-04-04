using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для SelectedItem.xaml
    /// </summary>
    public partial class SelectedItem : Window
    {
        public SelectedItem(Product product, List<Product> products, ListView list, List<Product> unFilteredProducts,bool Eng)
        {
            InitializeComponent();
            Product = product;
            Products = products;
            this.list = list;
            UnFilteredProducts = unFilteredProducts;
            _eng = Eng;

            var path = "C:\\Users\\Влад\\Desktop\\Курсоры ВОВ\\Point.cur";
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var cursor = new Cursor(stream);
                this.Cursor = cursor;
            }
        }
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> UnFilteredProducts { get; set; }
        public bool _eng { get; set; }

        public ListView list { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Name.Content = Product.Name;
            Cost.Content = Product.Price;
            Cat.Content = Product.Category;
            Desc.Content = Product.Description;
            Count.Content = Product.Quantity;
            Id.Content = Product.ID;
            Rate.Content = Product.Rate;
            itemImage.Source = new BitmapImage(new Uri(Product.Image));

            if (_eng)
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("Localization.xaml", UriKind.Relative) };
            }
            else
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("LocalizationRus.xaml", UriKind.Relative) };
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Products.Remove(Product);
            UnFilteredProducts.Remove(Product);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            UpdateItem upd = new UpdateItem(Product, list, Products,_eng);
            upd.ShowDialog();
        }
    }
}
