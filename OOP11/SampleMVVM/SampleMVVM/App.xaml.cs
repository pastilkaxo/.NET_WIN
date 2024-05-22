using SampleMVVM.Models;
using SampleMVVM.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SampleMVVM
{
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            List<Book> books = new List<Book>()
            {
                new Book("Пттерны проетирования", "John Gossman", 3),
                new Book("CLR via C#", "Джеффри Рихтер", 2),
                new Book("Исскуство программирования", "Кнут", 2)
            };

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new MainViewModel(books); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }


    }
}
