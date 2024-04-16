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
        public int _theme { get; set; }
        public Founded(Product foundedProduct, bool eng, int theme)
        {
            InitializeComponent();
            this.foundedProduct = foundedProduct;
            this.eng = eng;
            this._theme = theme;

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
        public Product foundedProduct = new Product();

        public bool eng { get; set; }

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

            if (eng)
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
    }
}
