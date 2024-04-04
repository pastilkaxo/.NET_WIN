using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using SystemJsonSerializer = System.Text.Json.JsonSerializer;
using System.Runtime.InteropServices.ComTypes;

namespace Lab4
{



    public partial class MainWindow : Window
    {
        public static bool _sorted = false;
        public List<Product> Products { get; set; } =  new List<Product>();
        public List<Product> UnFilteredProducts  = new List<Product>();
        public bool english = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Serialize(Stream stream , Object obj)
        {
            Serializer serializer = new Serializer();
            serializer.Serialize(stream, obj);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(maxCost.Text) && string.IsNullOrEmpty(minCost.Text) && string.IsNullOrEmpty(filCat.Text))
            {
                MessageBox.Show("Пустые параметры!");
            }
            else
            {
                if (string.IsNullOrEmpty(maxCost.Text) || string.IsNullOrEmpty(minCost.Text))
                {
                    if(ProductsListView.ItemsSource != null)
                    {
                        ProductsListView.ItemsSource = null;
                        Products = Products.Where(p => p.Category == filCat.Text).ToList();
                        ProductsListView.Items.Clear();
                        ProductsListView.ItemsSource = Products;
                    }
                    else
                    {
                        Products = Products.Where(p => p.Category == filCat.Text).ToList();
                        ProductsListView.Items.Clear();
                        ProductsListView.ItemsSource = Products;
                    }
                }
                else if (!string.IsNullOrEmpty(filCat.Text))
                {

                    try
                    {
                        if(ProductsListView.ItemsSource != null)
                        {
                            ProductsListView.ItemsSource = null; 
                            Products = Products.Where(p => p.Price <= Convert.ToDouble(maxCost.Text) && p.Price >= Convert.ToDouble(minCost.Text) && p.Category == filCat.Text).ToList();
                            ProductsListView.Items.Clear();
                            ProductsListView.ItemsSource = Products;
                        }
                        else
                        {
                            Products = Products.Where(p => p.Price <= Convert.ToDouble(maxCost.Text) && p.Price >= Convert.ToDouble(minCost.Text) && p.Category == filCat.Text).ToList();
                            ProductsListView.Items.Clear();
                            ProductsListView.ItemsSource = Products;
                        }
                    }
                    catch(FormatException ex)
                    {
                        MessageBox.Show("Неверный формат!");
                    }
                }
                else
                {
                    try
                    {
                        if (ProductsListView.ItemsSource != null)
                        {
                            ProductsListView.ItemsSource = null;
                            Products = Products.Where(p => p.Price <= Convert.ToDouble(maxCost.Text) && p.Price >= Convert.ToDouble(minCost.Text) ).ToList();
                            ProductsListView.Items.Clear();
                            ProductsListView.ItemsSource = Products;
                        }
                        else
                        {
                            Products = Products.Where(p => p.Price <= Convert.ToDouble(maxCost.Text) && p.Price >= Convert.ToDouble(minCost.Text)).ToList();
                            ProductsListView.Items.Clear();
                            ProductsListView.ItemsSource = Products;
                        }
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Неверный формат!");
                    }
                }

            }
            maxCost.Clear();
            minCost.Clear();
            filCat.SelectedIndex = -1;


        }

        private void Sort_By_Id(object sender, RoutedEventArgs e)
        {

            if (ProductsListView.ItemsSource != null)
            {
                ProductsListView.ItemsSource = null;
                Products = Products.OrderBy(p => p.ID).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = Products.OrderBy(p => p.ID).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }

        private void Sort_By_Name(object sender, RoutedEventArgs e)
        {
            if(ProductsListView.ItemsSource  != null)
            {
                ProductsListView.ItemsSource = null;
                Products = Products.OrderBy(p => p.Name).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = Products.OrderBy(p => p.Name).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }


        private void Sort_By_Rate(object sender, RoutedEventArgs e)
        {
            if (ProductsListView.ItemsSource != null)
            {
                ProductsListView.ItemsSource = null;
                Products = Products.OrderBy(p => p.Rate).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = Products.OrderBy(p => p.Rate).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }

        private void Sort_By_Qnt(object sender, RoutedEventArgs e)
        {
            if (ProductsListView.ItemsSource != null)
            {
                ProductsListView.ItemsSource = null;
                Products = Products.OrderBy(p => p.Quantity).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = Products.OrderBy(p => p.Quantity).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }
        private void Sort_By_Price(object sender, RoutedEventArgs e)
        {
            if (ProductsListView.ItemsSource != null)
            {
                ProductsListView.ItemsSource = null;
                Products = Products.OrderBy(p => p.Price).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = Products.OrderBy(p => p.Price).ToList();
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }




        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri("Localization.xaml", UriKind.Relative) };
            english = true;
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri("LocalizationRus.xaml", UriKind.Relative) };
            english = false;
        }

        private void LoadProductsFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    Products = SystemJsonSerializer.Deserialize<List<Product>>(json);
                    UnFilteredProducts = new List<Product>(Products);
                    ProductsListView.ItemsSource = Products;
                }
                else
                {
                    MessageBox.Show("Файл JSON не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных из файла JSON: {ex.Message}");
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var path = "C:\\Users\\Влад\\Desktop\\Курсоры ВОВ\\Point.cur";
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var cursor = new Cursor(stream);
                this.Cursor = cursor;
            }
            string JsonPath = "C:\\Users\\Влад\\source\\repos\\Lab4\\Lab4\\JSON\\data.json";
            LoadProductsFromJson(JsonPath);

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddItem adder = new AddItem(ProductsListView, Products, UnFilteredProducts,english);
            adder.ShowDialog();
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            Product selectedProduct = (Product)ProductsListView.SelectedItem;
            if (selectedProduct == null)
            {
                MessageBox.Show("Вы не выбрали товар!");
            }
            else
            {
                if(ProductsListView.ItemsSource != null)
                {
                    ProductsListView.ItemsSource = null;
                    ProductsListView.Items.Remove(selectedProduct);
                    Products.Remove(selectedProduct);
                    UnFilteredProducts.Remove(selectedProduct);
                    ProductsListView.Items.Clear();
                    ProductsListView.ItemsSource = Products;
                }
                else
                {
                    ProductsListView.Items.Remove(selectedProduct);
                    Products.Remove(selectedProduct);
                    UnFilteredProducts.Remove(selectedProduct);
                }
            }
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            Product selectedProduct = (Product)ProductsListView.SelectedItem;
            if (selectedProduct != null)
            {
                UpdateItem upd = new UpdateItem(selectedProduct, ProductsListView, Products,english);
                upd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали товар!");
            }
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            bool found = false;

            if (Products.Count == 0)
            {
                MessageBox.Show("Товаров нет!");
                SearchText.Clear();
            }
            else
            {
                foreach (Product product in Products)
                {
                    if (product.Name.ToLower().Contains(SearchText.Text.ToLower()))
                    {
                        Founded founded = new Founded(product,english);
                        founded.ShowDialog();
                        SearchText.Clear();
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Товара нет с таким именем!");
                    SearchText.Clear();
                }
            }
        }

        private void CommandBinding_Executed_4(object sender, ExecutedRoutedEventArgs e)
        {
            string path = "C:\\Users\\Влад\\source\\repos\\Lab4\\Lab4\\JSON\\data.json";
            if (File.Exists(path))
            {
                File.Delete(path);

                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {

                    Serialize(fs, ProductsListView.Items);
                }
                MessageBox.Show("Данные сохранены!");
            }
            else
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    Serialize(fs, ProductsListView.Items);
                }
                MessageBox.Show("Данные сохранены!");
            }
        }


        private void CommandBinding_Executed_5(object sender, ExecutedRoutedEventArgs e)
        {

            if (ProductsListView.ItemsSource != null)
            {
                ProductsListView.ItemsSource = null;
                Products = new List<Product>(UnFilteredProducts); 
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = new List<Product>(UnFilteredProducts); 
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }

        }

        private void minCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            minCost.MaxLength = 15;
            maxCost.MaxLength = 15;
            if (!Char.IsDigit(e.Text, 0) && e.Text != ",") e.Handled = true;
        }

        private void ProductsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ProductsListView.SelectedItem == null)
                {
                    MessageBox.Show("Не выбран товар!");
                }
                else
                {
                    Product selectedProduct = (Product)ProductsListView.SelectedItem;
                    SelectedItem selectedItem = new SelectedItem(selectedProduct,Products,ProductsListView,UnFilteredProducts,english);
                    selectedItem.ShowDialog();
                    ProductsListView.Items.Refresh();
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Не выбран товар!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrePage page = new PrePage();
            page.Show();
            this.Close();
        }


    }


}
