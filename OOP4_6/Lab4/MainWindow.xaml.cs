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
using System.Security.Cryptography.X509Certificates;

namespace Lab4
{

    public partial class MainWindow : Window
    {
        public static bool _sorted = false;


        public Stack<BindingList<Product>> UndoList = new Stack<BindingList<Product>>();
        public Stack<BindingList<Product>> RedoList = new Stack<BindingList<Product>>();

        public int _theme { get; set; }

        public BindingList<Product> Products { get; set; } =  new BindingList<Product>();
        public List<Product> UnFilteredProducts  = new List<Product>();
        public bool english = false;
        public MainWindow(int theme)
        {
            InitializeComponent();
            _theme = theme;
            if (_theme == 1)
            {
                ResourceDictionary res = new ResourceDictionary() { Source = new Uri("WhiteTheme.xaml", UriKind.Relative) };
                this.Resources.MergedDictionaries.Add(res);

            }
            else if(_theme == 2)
            {
                ResourceDictionary res = new ResourceDictionary() { Source = new Uri("BlackTheme.xaml", UriKind.Relative) };
                this.Resources.MergedDictionaries.Add(res);
            }
            else if(_theme == 3)
            {
                ResourceDictionary res = new ResourceDictionary() { Source = new Uri("SkyTheme.xaml", UriKind.Relative) };
                this.Resources.MergedDictionaries.Add(res);
            }
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
                        Products = new BindingList<Product>(Products.Where(p => p.Category == filCat.Text).ToList());
                        ProductsListView.Items.Clear();
                        ProductsListView.ItemsSource = Products;
                    }
                    else
                    {
                        Products =new BindingList<Product>( Products.Where(p => p.Category == filCat.Text).ToList());
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
                            Products = new BindingList<Product>( Products.Where(p => p.Price <= Convert.ToDouble(maxCost.Text) && 
                            p.Price >= Convert.ToDouble(minCost.Text) &&
                            p.Category == filCat.Text).ToList());
                            ProductsListView.Items.Clear();
                            ProductsListView.ItemsSource = Products;
                        }
                        else
                        {
                            Products = new BindingList<Product>(Products.Where(p => p.Price <= Convert.ToDouble(maxCost.Text) && 
                            p.Price >= Convert.ToDouble(minCost.Text) && p.Category == filCat.Text).ToList());
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
                            Products = new BindingList<Product>( Products.Where(p => p.Price <= Convert.ToDouble(maxCost.Text) &&
                            p.Price >= Convert.ToDouble(minCost.Text) ).ToList());
                            ProductsListView.Items.Clear();
                            ProductsListView.ItemsSource = Products;
                        }
                        else
                        {
                            Products = new BindingList<Product>( Products.Where(p => p.Price <= Convert.ToDouble(maxCost.Text) &&
                            p.Price >= Convert.ToDouble(minCost.Text)).ToList());
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
                Products = new BindingList<Product>( Products.OrderBy(p => p.ID).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = new BindingList<Product>( Products.OrderBy(p => p.ID).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }

        private void Sort_By_Name(object sender, RoutedEventArgs e)
        {
            if(ProductsListView.ItemsSource  != null)
            {
                ProductsListView.ItemsSource = null;
                Products = new BindingList<Product>(Products.OrderBy(p => p.Name).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = new BindingList<Product>(Products.OrderBy(p => p.Name).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }


        private void Sort_By_Rate(object sender, RoutedEventArgs e)
        {
            if (ProductsListView.ItemsSource != null)
            {
                ProductsListView.ItemsSource = null;
                Products = new BindingList<Product>(Products.OrderBy(p => p.Rate).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = new BindingList<Product>(Products.OrderBy(p => p.Rate).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }

        private void Sort_By_Qnt(object sender, RoutedEventArgs e)
        {
            if (ProductsListView.ItemsSource != null)
            {
                ProductsListView.ItemsSource = null;
                Products = new BindingList<Product>(Products.OrderBy(p => p.Quantity).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = new BindingList<Product>(Products.OrderBy(p => p.Quantity).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }
        private void Sort_By_Price(object sender, RoutedEventArgs e)
        {
            if (ProductsListView.ItemsSource != null)
            {
                ProductsListView.ItemsSource = null;
                Products = new BindingList<Product>(Products.OrderBy(p => p.Price).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
            else
            {
                Products = new BindingList<Product>(Products.OrderBy(p => p.Price).ToList());
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
            }
        }




        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResourceDictionary engRes = new ResourceDictionary() { Source = new Uri("Localization.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(engRes);
            english = true;
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ResourceDictionary rusRes = new ResourceDictionary() { Source = new Uri("LocalizationRus.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(rusRes);
            english = false;
        }

        private void LoadProductsFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    Products = SystemJsonSerializer.Deserialize<BindingList<Product>>(json);
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
            AddItem adder = new AddItem(ProductsListView, Products, UnFilteredProducts,english,_theme, UndoList,RedoList);
            adder.Cursor = this.Cursor;
            adder.ShowDialog();
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {

            UndoList.Push(new BindingList<Product>(Products.ToList()));
            Product selectedProduct = (Product)ProductsListView.SelectedItem;
            if (selectedProduct == null)
            {
                MessageBox.Show("Вы не выбрали товар!");
            }
            else
            {
                    ProductsListView.ItemsSource = null;
                    ProductsListView.Items.Remove(selectedProduct);
                    Products.Remove(selectedProduct);
                    UnFilteredProducts.Remove(selectedProduct);
                    ProductsListView.ItemsSource = Products;
            }


        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            Product selectedProduct = (Product)ProductsListView.SelectedItem;
            if (selectedProduct != null)
            {
                UpdateItem upd = new UpdateItem(selectedProduct, ProductsListView, Products,english,_theme,UndoList,RedoList);
                upd.Cursor = this.Cursor;
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
                        Founded founded = new Founded(product,english,_theme);
                        founded.Cursor = this.Cursor;
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
                Products = new BindingList<Product>(UnFilteredProducts);
                ProductsListView.Items.Clear();
                ProductsListView.ItemsSource = Products;
                

            }
            else
            {
                Products = new BindingList<Product>(UnFilteredProducts); 
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
                    SelectedItem selectedItem = new SelectedItem(selectedProduct,Products,ProductsListView,UnFilteredProducts,
                    english,_theme,UndoList,RedoList);
                    selectedItem.Cursor = this.Cursor;
                    selectedItem.ShowDialog();
                    ProductsListView.Items.Refresh();
                }
            }
            catch (NullReferenceException )
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

        private void CommandBinding_Executed_6(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                
                if (UndoList.Count > 0)
                {
                    ProductsListView.ItemsSource = null;
                    RedoList.Push(new BindingList<Product>(Products));
                    Products = UndoList.Pop();
                    ProductsListView.ItemsSource = Products;

                }
                else
                {
                    UndoList.Clear();
                }

            }
            catch(Exception)
            {
                MessageBox.Show("Нечего отменять!");
            }
        }

        private void CommandBinding_Executed_7(object sender, ExecutedRoutedEventArgs e)
        {

            try
            {

                if (RedoList.Count > 0)
                {
                    ProductsListView.ItemsSource = null;
                    UndoList.Push(new BindingList<Product>(Products));
                    Products = RedoList.Pop();
                    ProductsListView.ItemsSource = Products;

                }
                else
                {
                    RedoList.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Нечего отменять!");
            }

        }

        private void ProductsListView_Loaded(object sender, RoutedEventArgs e)
        {

            uc_tb.Count = ProductsListView.Items.Count.ToString();
        }

        private void Products_ListChanged(object sender, ListChangedEventArgs e)
        {
            MessageBox.Show("dwewd");
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                uc_tb.Count = ProductsListView.Items.Count.ToString();
            }
            
        }
    }


}
