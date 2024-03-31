using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    /// 


    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }
        private string _name;
        public string Name { get { return _name; } set
            { 
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _image;

        public string Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }

        private string _category;
        public string Category { get { return _category; } set { _category = value; OnPropertyChanged("Category"); } }

        private double _price;
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged("Price"); } }

        private int _qnt;
        public int Quantity { get { return _qnt; } set { _qnt = value;OnPropertyChanged("Qantity"); } }

        private int _rate;
        public int Rate { get { return _rate; } set { _rate = value; OnPropertyChanged("Rate"); } }

        private string _desc;
        public string Description { get { return _desc; } set { _desc = value; OnPropertyChanged("Description"); } }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public partial class AddItem : Window
    {
        public AddItem(ListView listView, List<Product> products , List<Product> filtered)
        {
            InitializeComponent();
            ListView = listView;
            Products = products;
            filteredProd = filtered;
        }


        public ListView ListView { get; set; }

        public List<Product> Products { get; set; }
        public List<Product> filteredProd { get; set; }
        public List<Product> Shared { get { return Products; } }


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
                    filteredProd.Add(newProduct);
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
