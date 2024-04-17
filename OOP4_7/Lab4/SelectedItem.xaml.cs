using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class SelectedItem : Window
    {
        public int _theme { get; set; }
        public Stack<BindingList<Product>> _undo { get; set; }
        public Stack<BindingList<Product>> _redo { get; set; }
        public SelectedItem(Product product, BindingList<Product> products, ListView list,
            List<Product> unFilteredProducts,bool Eng, int theme, Stack<BindingList<Product>> products1 , Stack<BindingList<Product>> products2)
        {
            InitializeComponent();
            Product = product;
            Products = products;
            this.list = list;
            UnFilteredProducts = unFilteredProducts;
            _eng = Eng;
            _theme = theme;
            _undo = products1;
            _redo = products2;


            if (_theme == 1)
            {
                ResourceDictionary res = new ResourceDictionary() { Source = new Uri("WhiteTheme.xaml", UriKind.Relative) };
                this.Resources.MergedDictionaries.Add(res);

            }
            else if (_theme == 2)
            {
                ResourceDictionary res = new ResourceDictionary() { Source = new Uri("BlackTheme.xaml", UriKind.Relative) };
                this.Resources.MergedDictionaries.Add(res);
            }
            else if (_theme == 3)
            {
                ResourceDictionary res = new ResourceDictionary() { Source = new Uri("SkyTheme.xaml", UriKind.Relative) };
                this.Resources.MergedDictionaries.Add(res);
            }
        }
        public Product Product { get; set; }
        public BindingList<Product> Products { get; set; }
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
                ResourceDictionary engRes = new ResourceDictionary() { Source = new Uri("Localization.xaml", UriKind.Relative) };
                this.Resources.MergedDictionaries.Add(engRes);
            }
            else
            {
                ResourceDictionary rusRes = new ResourceDictionary() { Source = new Uri("LocalizationRus.xaml", UriKind.Relative) };
                this.Resources.MergedDictionaries.Add(rusRes);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _undo.Push(new BindingList<Product>(Products.ToList()));
            Products.Remove(Product);
            UnFilteredProducts.Remove(Product);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            UpdateItem upd = new UpdateItem(Product, list, Products,_eng,_theme,_undo,_redo);
            upd.ShowDialog();
        }

    }
}
