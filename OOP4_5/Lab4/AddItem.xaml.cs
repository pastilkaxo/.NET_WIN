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
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    /// 


   

    public partial class AddItem : Window
    {
        public AddItem(ListView listView, List<Product> products , List<Product> filtered,bool Eng)
        {
            InitializeComponent();
            ListView = listView;
            Products = products;
            filteredProd = filtered;
            eng = Eng;
        }


        public ListView ListView { get; set; }

        public bool eng { get; set; }

        public List<Product> Products { get; set; }
        public List<Product> filteredProd { get; set; }
        public List<Product> Shared { get { return Products; } }

        public int _counter = 0;

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
                        Product newProduct = new Product
                        {
                            ID = Convert.ToInt32(IdValue.Text),
                            Image = ImageValue.Text,
                            Name = NameValue.Text,
                            Category = CatValue.Text,
                            Price = Convert.ToDouble(CostValue.Text),
                            Quantity = Convert.ToInt32(QntValue.Text),
                            Rate = Convert.ToInt32(RateValue.Value),
                            Description = DescValue.Text
                        };

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
            var path = "C:\\Users\\Влад\\Desktop\\Курсоры ВОВ\\Point.cur";
            using(var fs = new FileStream(path, FileMode.Open))
            {
                var cursor = new Cursor(fs);
                this.Cursor = cursor;
            }

            if (eng)
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("Localization.xaml", UriKind.Relative) };
            }
            else
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("LocalizationRus.xaml", UriKind.Relative) };
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

        private void RateValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            curRate.Content = Convert.ToInt32(RateValue.Value);
        }
    }
}
