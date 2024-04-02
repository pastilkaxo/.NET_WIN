using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id;
        public int ID { get { return _id; } set { _id = value; OnPropertyChanged("ID"); } }
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }

        private string _image;

        public string Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }

        private string _category;
        public string Category { get { return _category; } set { _category = value; OnPropertyChanged("Category"); } }

        private double _price;
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged("Price"); } }

        private int _qnt;
        public int Quantity { get { return _qnt; } set { _qnt = value; OnPropertyChanged("Qantity"); } }

        private int _rate;
        public int Rate { get { return _rate; } set { _rate = value; OnPropertyChanged("Rate"); } }

        private string _desc;
        public string Description { get { return _desc; } set { _desc = value; OnPropertyChanged("Description"); } }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
