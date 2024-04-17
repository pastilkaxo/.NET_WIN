using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4
{
    public partial class UC2 : UserControl
    {
        public static readonly RoutedEvent MouseEvent = EventManager.RegisterRoutedEvent(
          "MouseDown",
          RoutingStrategy.Bubble,
          typeof(RoutedEventHandler),
          typeof(UC2));

        public static readonly RoutedEvent MouseEvent2 = EventManager.RegisterRoutedEvent(
        "PrevieMouseMove",
        RoutingStrategy.Tunnel,
        typeof(RoutedEventHandler),
        typeof(UC2));

        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
            "Click",
            RoutingStrategy.Direct,
            typeof(RoutedEventHandler),
            typeof(UC2)
            );

        public static readonly DependencyProperty ButtonProperty = DependencyProperty.Register(
            "AuthorInfo",
            typeof(string),
            typeof(UC2),
            new FrameworkPropertyMetadata(
                "Лемешевский Владислав",
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceText)
                ),
            new ValidateValueCallback(IsValid));

        public UC2()
        {
            InitializeComponent();
        }

        private static object CoerceText(DependencyObject d, object value)
        {
            string val = (string)value;
            if (val.Length > 100) val.Substring(0,10);
            return val.ToString();
        }

        public event RoutedEventHandler PreviewMouseMove
        {
            add { base.AddHandler(UC2.MouseEvent2,value); }
            remove { base.RemoveHandler(UC2.MouseEvent2,value); }
        }

        public event RoutedEventHandler MouseDown
        {
            add { base.AddHandler(UC2.MouseEvent,value); }
            remove { base.RemoveHandler(UC2.MouseEvent,value); }
        }

        public event RoutedEventHandler Click
        {
            add { base.AddHandler(UC2.ClickEvent,value); }
            remove { base.RemoveHandler(UC2.ClickEvent, value); }
        }

        public string AuthorInfo
        {
            get { return (string)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        private static bool IsValid(object value)
        {
            string val = (string)value;
            return !string.IsNullOrEmpty(val);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(directRad.IsChecked == true)
            {
                MessageBox.Show(AuthorInfo + '\n' + sender.ToString() + '\n' + e.Source.ToString() + "\n\n", "Информация об авторе-Direct");
            }
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(bubbleRad.IsChecked == true)
            {
                MessageBox.Show(AuthorInfo + '\n' + sender.ToString() + '\n' + e.Source.ToString() + "\n\n", "Информация об авторе-Bubble");
            }
        }

        private void Control_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (tunnleRad.IsChecked == true)
            {
                MessageBox.Show(AuthorInfo + '\n' + sender.ToString() + '\n' + e.Source.ToString() + "\n\n", "Информация об авторе-Tunnle");
            }
        }

    }
}
