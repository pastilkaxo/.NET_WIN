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
using SystemJsonSerializer = System.Text.Json.JsonSerializer;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; } =  new ObservableCollection<Product>();

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
            ProductsListView.ItemsSource = Products;
            
        }



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri("Localization.xaml", UriKind.Relative) };
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri("LocalizationRus.xaml", UriKind.Relative) };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var path = "C:\\Users\\Влад\\Desktop\\Курсоры ВОВ\\Point.cur";
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var cursor = new Cursor(stream);
                this.Cursor = cursor;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddItem adder = new AddItem(ProductsListView, Products);
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

                ProductsListView.Items.Remove(selectedProduct);
            }
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            Product selectedProduct = (Product)ProductsListView.SelectedItem;
            if (selectedProduct != null)
            {
                UpdateItem upd = new UpdateItem(selectedProduct, ProductsListView, Products);
                upd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали товар!");
            }
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            if (Products.Count == 0)
            {
                MessageBox.Show("Товаров нет!");
                SearchText.Clear();
            }
            else
            {
                foreach (Product product in Products)
                {
                    if (product.Name.ToLower() == SearchText.Text.ToLower())
                    {
                        Founded founded = new Founded(product);
                        founded.ShowDialog();
                        SearchText.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Товара нет с таким именем!");
                        SearchText.Clear();
                    }
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
    }


}
