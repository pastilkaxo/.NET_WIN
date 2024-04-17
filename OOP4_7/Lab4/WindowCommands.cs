using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab4
{
    public class WindowCommands
    {
        public static RoutedUICommand Exit { get; set; }
        static WindowCommands()
        {
            Exit = new RoutedUICommand();
        }
    }
}
