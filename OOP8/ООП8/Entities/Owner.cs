using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП8.Entities
{
    public class Owner : INotifyPropertyChanged
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }

        private string _surname;
        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged("Surname"); } }

        private string _fathername;
        public string Fathername { get { return _fathername; } set { _fathername = value; OnPropertyChanged("Fathername"); } }

        private string _passSeries;
        public string PassSeries { get { return _passSeries; } set { _passSeries = value; OnPropertyChanged("PassportSeries"); } }

        private string _passNumber;
        public string PassNumber { get { return _passNumber; } set { _passNumber = value; OnPropertyChanged("PassportNumber"); } }

        private string _ownerPhoto;
        public string OwnerPhoto { get { return _ownerPhoto; } set { _ownerPhoto = value; OnPropertyChanged("Person_Photo"); } }

        private string _birthDate;
        public string BirthDate { get { return _birthDate; } set { _birthDate = value; OnPropertyChanged("Birth"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
