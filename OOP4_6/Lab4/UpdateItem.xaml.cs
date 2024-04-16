using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace Lab4
{

    public partial class UpdateItem : Window
    {
        public int _theme { get; set; }
        public Product selectedProduct { get; set; }
        public ListView listView { get; set; }

        public BindingList<Product> Products { get; set; }

        public Stack<BindingList<Product>> _undo { get; set; }
        public Stack<BindingList<Product>> _redo { get; set; }

        public bool eng { get; set; }
        public UpdateItem(Product selectedProduct, ListView listView, BindingList<Product> products, bool eng, int theme,
            Stack<BindingList<Product>> products1 , Stack<BindingList<Product>> products2)
        {
            InitializeComponent();
            this.selectedProduct = selectedProduct;
            this.listView = listView;
            this.Products = products;
            this.eng = eng;
            _theme = theme;
            this._undo = products1 ;
            this._redo = products2 ;

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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedItem.Content = selectedProduct.Name;
            IdValue.Content = Convert.ToString(selectedProduct.ID);
            nameValue.Text = selectedProduct.Name;
            imageValue.Text = selectedProduct.Image;
            qntValue.Text = Convert.ToString(selectedProduct.Quantity);
            catValue.Text = selectedProduct.Category;
            rateValue.Value = selectedProduct.Rate;
            descValue.Text = selectedProduct.Description;
            priceValue.Text = Convert.ToString(selectedProduct.Price);

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BindingList<Product> oldList = new BindingList<Product>();
                foreach(var p in Products)
                {
                    Product product = p.Clone();
                    
                    oldList.Add(product);
                }
                _undo.Push(oldList);
                if (listView.ItemsSource != null)
                {
                    listView.ItemsSource = null;
                    selectedProduct.Name = nameValue.Text;
                    selectedProduct.Image = imageValue.Text;
                    selectedProduct.Quantity = Convert.ToInt32(qntValue.Text);
                    selectedProduct.Category = catValue.Text;
                    selectedProduct.Rate = Convert.ToInt32(rateValue.Value);
                    selectedProduct.Description = descValue.Text;
                    selectedProduct.Price = Convert.ToDouble(priceValue.Text);
                    listView.Items.Remove(selectedProduct);
                    listView.Items.Add(selectedProduct);
                    listView.Items.Clear();
                    listView.ItemsSource = Products;
                    Close();
                }

            }
            catch(FormatException)
            {
                MessageBox.Show("Неверный формат!");
            }


        }

        private void QntValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            qntValue.MaxLength = 5;
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void CostValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            priceValue.MaxLength = 15;
            if (!Char.IsDigit(e.Text, 0) && e.Text != ",") e.Handled = true;
        }

        private void rateValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curRate.Content = Convert.ToInt32(rateValue.Value);
        }

    }
}
