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

    public partial class Founded : Window
    {
        public Founded(Product foundedProduct)
        {
            InitializeComponent();
            this.foundedProduct = foundedProduct;
        }
        public Product foundedProduct = new Product();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            idValue.Content = foundedProduct.ID;
            nameValue.Content = foundedProduct.Name;
            catValue.Content = foundedProduct.Category;
            qntValue.Content = foundedProduct.Quantity;
            costValue.Content = foundedProduct.Price;
            rateValue.Content = foundedProduct.Rate;
            itemImage.Source = new BitmapImage(new Uri(foundedProduct.Image));
            descValue.Text = foundedProduct.Description;

            var path = "C:\\Users\\Влад\\Desktop\\Курсоры ВОВ\\Point.cur";
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var cursor = new Cursor(fs);
                this.Cursor = cursor;
            }
        }
    }
}
