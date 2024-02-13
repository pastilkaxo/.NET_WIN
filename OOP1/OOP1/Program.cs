using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP1
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Calculator());

            }
            catch(Exception ex)
            {
                MessageBox.Show("Вызвано исключение:" + ex.Message);    
            }
            finally
            {
                MessageBox.Show("Программа выполнена.");
                Application.Exit();
            }
      


        }
    }
}
