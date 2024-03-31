using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    public partial class OperHistory : Form
    {
        public string MaskedTextBoxValue { get; set; }
        public string date, day, month;
        public int year;
        public string OpType
        {
            get
            {
                return comboBox3.Text;
            }
        }

        public string Sum
        {
            get
            {
               return textBox4.Text;
            }
        }

        public string OpDate
        {
            get
            {
                return maskedTextBox1.Text;
            }
        }

        public OperHistory(string maskedTextBoxValue)
        {
            InitializeComponent();
            MaskedTextBoxValue = maskedTextBoxValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Contains("--") || textBox4.Text == string.Empty)
            {
                MessageBox.Show("Введите баланс корректно!");
                textBox4.Clear();
            }
            else if (textBox4.Text.Contains(",,"))
            {
                MessageBox.Show("Неправильный баланс!");
                textBox4.Clear();
            }
            else if (comboBox3.Text == string.Empty)
            {
                MessageBox.Show("Выберите тип операции!");
            }
            else if (maskedTextBox1.Text.Length != 10)
            {
                MessageBox.Show("Неккоректная дата!");
                maskedTextBox1.Clear();
            }
            else
            {
                date = maskedTextBox1.Text.Substring(6, 4);
                month = maskedTextBox1.Text.Substring(3, 2);
                day = maskedTextBox1.Text.Substring(0, 2);
                year = Convert.ToInt32(date);
                if (year > 2024 || year <= 1900 || Convert.ToInt32(month) > 12 || Convert.ToInt32(month) < 0 ||
                    Convert.ToInt32(day) > 31 || Convert.ToInt32(day) < 0)
                {
                    MessageBox.Show("Неверно введена дата операции!");
                    maskedTextBox1.Clear();
                }
                else
                {
                    string openDate = MaskedTextBoxValue.Substring(6, 4);
                    string openDay = MaskedTextBoxValue.Substring(0, 2);
                    string openMonth = MaskedTextBoxValue.Substring(3, 2);
                    int openYear = Convert.ToInt32(openDate);
                    int openD = Convert.ToInt32(openDay);
                    int openM = Convert.ToInt32(openMonth);
                    if (year < openYear || (year == openYear && Convert.ToInt32(month) < openM) 
                        || (year == openYear && Convert.ToInt32(month) == openM && Convert.ToInt32(day) < openD))
                    {
                        MessageBox.Show("Дата операции не может быть позже открытия!");
                        maskedTextBox1.Clear();
                    }
                    else
                    {
                        button1.Enabled = true;
                        MessageBox.Show($"Данные сохранены!");
                        this.Close();
                    }

                }
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            string openDate = MaskedTextBoxValue.Substring(6, 4);
            int openYear = Convert.ToInt32(openDate);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = -1;
            maskedTextBox1.Clear();
            textBox4.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 20;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 ) 
            {
                e.Handled = true;
            }
        }
    }
}
