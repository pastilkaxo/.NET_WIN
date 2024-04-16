    using System;
    using System.Collections.Generic;
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    namespace Lab4
    {

        public partial class UC1 : UserControl
        {
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
        "Count",
        typeof(string),
        typeof(UC1),
        new FrameworkPropertyMetadata(
            "0",
            FrameworkPropertyMetadataOptions.AffectsRender,
            new PropertyChangedCallback(OnTextChanged),
            new CoerceValueCallback(CoerceText)
        ),
        new ValidateValueCallback(IsValidContent)
);
        public UC1()
            {
                InitializeComponent();
            }

            public string Count { 
                get { return (string)GetValue(CountProperty); } 
                set { SetValue(CountProperty, value); } 
            }

            private static object CoerceText(DependencyObject d, object value)
            {
                string val = (string)value;
                if (Convert.ToInt32(val) > 10) MessageBox.Show(">10"); 
                return val.ToString();
            }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UC1 uc = (UC1)d;
            uc.UpdateTextBlock();
        }

        private void UpdateTextBlock()
        {
            tb1.Text = $"{Count}";
        }

        private static bool IsValidContent(object value)
        {
            string val = (string)value;
            return !string.IsNullOrEmpty(val);
        }

    }
    }
