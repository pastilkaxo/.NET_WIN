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

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    /// 


    public class Product
    {
        public int ID { get; set; } 
        public string Image { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
    }

    public partial class AddItem : Window
    {
        public AddItem(ListView listView, ObservableCollection<Product> products)
        {
            InitializeComponent();
            ListView = listView;
            Products = products;
        }


        public ListView ListView { get; set; }

        public ObservableCollection<Product> Products { get; set; } 
        public ObservableCollection<Product> Shared { get { return Products; } }


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

                    Products.Add(newProduct);
                    ListView.Items.Add(newProduct);
                    this.Close();
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
        }
    }
}
