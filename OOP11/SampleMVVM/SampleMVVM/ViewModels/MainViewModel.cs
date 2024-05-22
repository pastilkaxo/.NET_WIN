using SampleMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVM.Views
{
    public class MainViewModel
    {
        public ObservableCollection<BookViewModel> BooksList { get; set; }

        public MainViewModel(List<Book> books) {
            BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
        }
    }
}
