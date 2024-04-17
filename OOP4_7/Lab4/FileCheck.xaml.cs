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

    public partial class FileCheck : Window
    {
        public FileCheck()
        {
            InitializeComponent();
        }

        public List<Product> FileProducts = new List<Product>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var path = "C:\\Users\\Влад\\Desktop\\Курсоры ВОВ\\Point.cur";
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    var cursor = new Cursor(fs);
                    this.Cursor = cursor;
                }


                string JsonPath = "C:\\Users\\Влад\\source\\repos\\Lab4\\Lab4\\JSON\\data.json";
                if (File.Exists(JsonPath))
                {
                    string json = File.ReadAllText(JsonPath);

                    FileProducts = SystemJsonSerializer.Deserialize<List<Product>>(json);
                    foreach (Product product in FileProducts)
                    {
                        fileValue.Text += $"ID: {product.ID}\n" +
                            $"Name:{product.Name}\n" +
                            $"Category:{product.Category}\n" +
                            $"Price:{product.Price} \n" +
                            $"Rate:{product.Rate} \n" +
                            $"Count:{product.Quantity} \n" +
                            $"Description:{product.Description}  \n";
                    }
                    
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
    }
}
