using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП8.Entities
{
    public class ClientCheck : INotifyPropertyChanged
    {
        private string _number;
        public string Number { get { return _number; } set { _number = value; OnPropertyChanged("Number"); } }
        private string _type;
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged("Type"); } }
        private string _balance;
        public string Balance { get { return _balance; } set { _balance = value; OnPropertyChanged("Balance"); } }
        private string _openDate;
        public string OpenDate { get { return _openDate; } set { _openDate = value; OnPropertyChanged("OpenDate"); } }
        private string _smsService;
        public string SmsService { get { return _smsService; } set { _smsService = value; OnPropertyChanged("SMS"); } }
        private string _bankingService;
        public string BankingService { get { return _bankingService; } set { _bankingService = value; OnPropertyChanged("Banking"); } }

        private string _clientName;
        public string ClientName { get { return _clientName; } set { _clientName = value; OnPropertyChanged("ClientName"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
