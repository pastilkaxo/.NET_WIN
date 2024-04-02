using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SelectedItem.xaml
    /// </summary>
    public partial class SelectedItem : Window
    {
        public SelectedItem(Product product)
        {
            InitializeComponent();
            Product = product;
        }
        public Product Product { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Name.Content = Product.Name;
            Cost.Content = Product.Price;
            Cat.Content = Product.Category;
            Desc.Content = Product.Description;
            Count.Content = Product.Quantity;
            Id.Content = Product.ID;
            Rate.Content = Product.Rate;
        }
    }
}
