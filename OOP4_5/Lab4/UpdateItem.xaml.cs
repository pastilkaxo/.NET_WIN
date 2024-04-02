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

    public partial class UpdateItem : Window
    {
       
        public UpdateItem(Product selectedProduct, ListView listView, List<Product> products)
        {
            InitializeComponent();
            this.selectedProduct = selectedProduct;
            this.listView = listView;
            this.Products = products;
        }
        public Product selectedProduct { get; set; }
        public ListView listView { get; set; }

        public List<Product> Products { get; set; }

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


            var path = "C:\\Users\\Влад\\Desktop\\Курсоры ВОВ\\Point.cur";
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var cursor = new Cursor(fs);
                this.Cursor = cursor;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(listView.ItemsSource != null)
            {
                try
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
                catch(FormatException ex)
                {
                    MessageBox.Show("Неверный формат!");
                }
            }
            else
            {
                try
                {
                   
                    selectedProduct.Name = nameValue.Text;
                    selectedProduct.Image = imageValue.Text;
                    selectedProduct.Quantity = Convert.ToInt32(qntValue.Text);
                    selectedProduct.Category = catValue.Text;
                    selectedProduct.Rate = Convert.ToInt32(rateValue.Value);
                    selectedProduct.Description = descValue.Text;
                    selectedProduct.Price = Convert.ToDouble(priceValue.Text);
                    listView.Items.Remove(selectedProduct);
                    listView.Items.Add(selectedProduct);
                    Close();
                }
                catch(FormatException ex)
                {
                    MessageBox.Show("Неверный формат!");
                }
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


    }
}
