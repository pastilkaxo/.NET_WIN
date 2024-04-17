using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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
  

    public partial class AddItem : Window
    {
        public int _theme { get; set; }
        public Product newProduct = new Product();
        public Stack<BindingList<Product>> _undo { get; set; }
        public Stack<BindingList<Product>> _redo { get; set; }
        public ListView ListView { get; set; }

        public bool eng { get; set; }

        public BindingList<Product> Products { get; set; }
        public List<Product> filteredProd { get; set; }

        public int _counter = 0;

        public AddItem(ListView listView, BindingList<Product> products , List<Product> filtered, bool Eng, int theme, Stack<BindingList<Product>> products1 , Stack<BindingList<Product>> products2)
        {
            InitializeComponent();
            ListView = listView;
            Products = products;
            filteredProd = filtered;
            eng = Eng;
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(IdValue.Text) &&
                !string.IsNullOrEmpty(ImageValue.Text) &&
                !string.IsNullOrEmpty(NameValue.Text) &&
                !string.IsNullOrEmpty(CatValue.Text) &&
                !string.IsNullOrEmpty(CostValue.Text) &&
                !string.IsNullOrEmpty(QntValue.Text) &&
                !string.IsNullOrEmpty(RateValue.Value.ToString()) &&
                !string.IsNullOrEmpty(DescValue.Text))
            {
                if (Products.Any(product => product.ID == Convert.ToInt32(IdValue.Text)) || Products.Any(product => product.Name == NameValue.Text))
                {
                    MessageBox.Show("Продукт с таким ID/Именем уже существует!");
                }
                else
                {
                    try
                    {

                        newProduct.ID = Convert.ToInt32(IdValue.Text);
                        newProduct.Image = ImageValue.Text;
                        newProduct.Name = NameValue.Text;
                        newProduct.Category = CatValue.Text;
                        newProduct.Price = Convert.ToDouble(CostValue.Text);
                        newProduct.Quantity = Convert.ToInt32(QntValue.Text);
                        newProduct.Rate = Convert.ToInt32(RateValue.Value);
                        newProduct.Description = DescValue.Text;
                        _undo.Push(new BindingList<Product>(Products.ToList()));

                        if (ListView.ItemsSource != null)
                        {
                            ListView.ItemsSource = null;
                            Products.Add(newProduct);
                            filteredProd.Add(newProduct);
                            ListView.Items.Add(newProduct);
                            ListView.Items.Clear();
                            ListView.ItemsSource = Products;
                            this.Close();
                        }
                        else
                        {
                            Products.Add(newProduct);
                            filteredProd.Add(newProduct);
                            ListView.Items.Add(newProduct);
                            this.Close();
                        }
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Некорректный формат!");
                        CostValue.Clear();
                    }

                }
            }
            else
            {
                MessageBox.Show("Данные не введены/Введены не корректно!");
            }
        }

        private void IdValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            IdValue.MaxLength = 5;
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void QntValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            QntValue.MaxLength = 5;
            if (!Char.IsDigit(e.Text, 0) ) e.Handled = true;
        }

        private void CostValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CostValue.MaxLength = 15;
            if (!Char.IsDigit(e.Text, 0) && e.Text != ",") e.Handled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IdValue.Clear();
            NameValue.Clear();
            CatValue.SelectedIndex = -1;
            RateValue.Value = 0;
            CostValue.Clear();
            DescValue.Clear();
            QntValue.Clear();
            ImageValue.SelectedIndex = -1;
        }

        private void RateValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curRate.Content = Convert.ToInt32(RateValue.Value);

        }
    }
}
