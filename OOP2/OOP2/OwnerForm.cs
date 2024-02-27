using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP2
{
    public partial class OwnerForm : Form
    {
        public string FamData {get{return Fam.Text;}}
        public string OwnerName {get{return nam.Text;}}
        public string OwnerFath { get { return fath.Text;} }
        public string OwnerBith { get { return maskedTextBox2.Text; } }
        public string OwnerPass { get { return comboBox2.Text; } }
        public string OwnerNum { get { return textBox3.Text; } }

        public string MaskedTextBoxValue { get; set; }




        public OwnerForm(string maskedTextBoxValue)
        {
            InitializeComponent();
            MaskedTextBoxValue = maskedTextBoxValue;
        }


        private void Accept_Click(object sender, EventArgs e)
        {
            string  date2;
            string month2;
            string  day2;
            int  year2;

            if (maskedTextBox2.Text.Length != 10 || comboBox2.Text == string.Empty)
            {
                MessageBox.Show("Данные введены не корректно!");
            }
            else if(textBox3.Text == string.Empty || textBox3.Text.Length != 7)
            {
                MessageBox.Show("Введите номер паспорта корректно!");
            }
            else
            {
                date2 = maskedTextBox2.Text.Substring(6, 4);
                month2 = maskedTextBox2.Text.Substring(3, 2);
                day2 = maskedTextBox2.Text.Substring(0, 2);
                year2 = Convert.ToInt32(date2);
                string openDate = MaskedTextBoxValue.Substring(6, 4);
                string openDay = MaskedTextBoxValue.Substring(0, 2);
                string openMonth = MaskedTextBoxValue.Substring(3, 2);
                int openY = Convert.ToInt32(openDate);
                int openD = Convert.ToInt32(openDay);
                int openM = Convert.ToInt32(openMonth);

                if ( Fam.Text == string.Empty || nam.Text == string.Empty || fath.Text == string.Empty)
                {
                    MessageBox.Show("Введите данные!");
                }

                else if (year2 > 2024 || year2 <= 1900 || Convert.ToInt32(month2) > 12 || Convert.ToInt32(month2) < 0 || Convert.ToInt32(day2) > 31 || Convert.ToInt32(day2) < 0)
                {
                    MessageBox.Show("Неверно введена дата рождения!");
                    maskedTextBox2.Clear();
                }
                else if (year2 > openY && Convert.ToInt32(day2) > openD  && Convert.ToInt32(month2) > openM)
                {
                    MessageBox.Show("Дата рождения не может быть раньше открытия!");
                    maskedTextBox2.Clear();
                }
                else
                {
                    button1.Enabled = true;
                    MessageBox.Show("Данные сохранены!");
                    this.Close();
                }
            }

        }

        private void Fam_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
                if (l < 'А' || l > 'я')
                    e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 7;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fam.Clear();
            nam.Clear();
            fath.Clear();
            maskedTextBox2.Clear();
            comboBox2.SelectedIndex = -1;
            textBox3.Clear();
        }
    }
}
