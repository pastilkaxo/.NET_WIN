using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PrePage.xaml
    /// </summary>
    public partial class PrePage : Window
    {

        public int _themeValue;


        public PrePage()
        {
            InitializeComponent();
            _themeValue = 0;
            var path = "C:\\Users\\Влад\\Desktop\\Курсоры ВОВ\\Point.cur";
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var cursor = new Cursor(fs);
                this.Cursor = cursor;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_themeValue);
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FileCheck fileCheck = new FileCheck();
            fileCheck.ShowDialog();
        }

        private void whiteBtn_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary theme1 = new ResourceDictionary() { Source = new Uri("WhiteTheme.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(theme1);
            _themeValue = 1;
        }

        private void defBtn_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary theme = new ResourceDictionary() { Source = new Uri("DefaultTheme.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(theme);
            _themeValue = 0;
        }

        private void blackBtn_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary theme2 = new ResourceDictionary() { Source = new Uri("BlackTheme.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(theme2);
            _themeValue = 2;
        }

        private void starBtn_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary theme3 = new ResourceDictionary() { Source = new Uri("SkyTheme.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(theme3);
            _themeValue = 3;
        }


        private void UserText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FileCheck fileCheck = new FileCheck();
            fileCheck.ShowDialog();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResourceDictionary engRes = new ResourceDictionary() { Source = new Uri("Localization.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(engRes);
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ResourceDictionary rusRes = new ResourceDictionary() { Source = new Uri("LocalizationRus.xaml", UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(rusRes);
        }
    }
}
