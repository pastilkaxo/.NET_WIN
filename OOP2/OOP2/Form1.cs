using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SystemJsonSerializer = System.Text.Json.JsonSerializer;

namespace OOP2
{
    public partial class Form1 : Form
    {
        private bool basicDataEntered = false;
        public string cb1, cb2;
       public string[] syms = {"+","-",",","=","_","?"};
       public List<object> list = new List<object>();
       public static string path = "C:\\Users\\Влад\\Desktop\\ЛабыООП\\OOP2\\OOP2\\JSON\\";
       public string fullPath = Path.Combine(path, "serialized.json");
       public string type , opdate, sum , fam,name,fath,bith,ser,num;
        public string date, month, day , operY;
        public int year, year2, operYear;

        public Form1()
        {
            InitializeComponent();
        }

        public void Serialize(Stream serializationStream, Object obj)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(serializationStream, obj);
        }


        private void button3_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked )
            {
                cb1 = radioButton1.Text;        
            }
            else
            {
                cb1 = radioButton2.Text;
            }
            if(checkBox3.Checked)
            {
                cb2 = checkBox3.Text;
            }
            else
            {
                cb2 = checkBox4.Text;
            }
            if(!radioButton1.Checked && !radioButton2.Checked && !checkBox3.Checked && !checkBox4.Checked)
            {
                cb1 = "Не указан";
                cb2 = "Не указан";
            }

            
            string[] data = { textBox1.Text, comboBox1.Text
           , maskedTextBox1.Text,cb1,cb2 ,type,BalanceStatus.Text,sum,opdate,
            fam,name,fath,bith,ser,num};

            
           
            list.Add(data);
            dataGridView1.Rows.Add(data);
          
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            BalanceStatus.Clear();
            maskedTextBox1.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            button3.Enabled = false;
            fam = null;
            sum = null;
            opdate = null;
            name = null;
            fath = null;
            bith = null;
            ser = null;
            num = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!list.Any())
            {
                MessageBox.Show("Список пуст!");
            }
            else
            {
                if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                }
                using (var fs = new FileStream(fullPath, FileMode.OpenOrCreate))
                {
                    Serialize(fs, list);
                }
                list.Clear();
                dataGridView1.Rows.Clear();
                basicDataEntered=false;
                MessageBox.Show("Информация добавлена!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string jsonString = File.ReadAllText(fullPath);
            string[][] result = SystemJsonSerializer.Deserialize<string[][]>(jsonString);

            if(result.Length == 0)
            {
                MessageBox.Show("Записей нет!");
            }
            else
            {
                foreach (string[] row in result)
                {
                    if (list.Any(item => item is string[] array && array.SequenceEqual(row)))
                    {
                        MessageBox.Show("В списке уже есть такой элемент!");
                    }
                    else
                    {
                        dataGridView1.Rows.Add(row);
                        list.Add(row);
                    }
                }
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox4.Checked=false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox3.Checked = false;
            }
        }

        private void ClearGrid_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            BalanceStatus.Clear();
            maskedTextBox1.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            list.Clear();
            basicDataEntered=false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
            textBox1.MaxLength = 15;
            BalanceStatus.MaxLength = 10;

        }

        private void BalanceStatus_TextChanged(object sender, EventArgs e)
        {
            BalanceStatus.MaxLength = 20;
            if (BalanceStatus.Text.Contains(",,"))
            {
                button3.Enabled = false;
                MessageBox.Show("Неправильный баланс!");
                BalanceStatus.Clear();
            }

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            maskedTextBox1.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBox1_TypeValidationCompleted);

        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                button3.Enabled = false;
            }

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            maskedTextBox1.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBox1_TypeValidationCompleted);
        }

        public bool CheckYears()
        {
             operY = opdate.Substring(6, 4);
            operYear = Convert.ToInt32(operY);

            if (year > operYear)
            {
                MessageBox.Show("Неверно введена дата открытия!");
                maskedTextBox1.Clear();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AllCheck()
        {
            date = maskedTextBox1.Text.Substring(6, 4);
            month = maskedTextBox1.Text.Substring(3, 2);
            day = maskedTextBox1.Text.Substring(0, 2);
            year = Convert.ToInt32(date);


            if (textBox1.Text == string.Empty || BalanceStatus.Text == string.Empty)
            {
                MessageBox.Show("Введите данные!");
                return false;
            }
            else if (BalanceStatus.Text.Contains("--") || BalanceStatus.Text.Contains("--"))
            {
                MessageBox.Show("Введите баланс корректно!");
                BalanceStatus.Clear();
                return false;
            }
            else if (year > 2024 || year <= 1900 || Convert.ToInt32(month) > 12 || Convert.ToInt32(month) < 0 ||
                Convert.ToInt32(day) > 31 || Convert.ToInt32(day) < 0)
            {
                MessageBox.Show("Неверно введена дата открытия!");
                maskedTextBox1.Clear();
                return false;
            }
            else if (fam == string.Empty)
            {
                MessageBox.Show("Неверно введена дата открытия!");
                maskedTextBox1.Clear();
                return false;
            }
            else if (type == null || opdate == null || sum == null || fam == null || name == null ||
    fath == null || bith == null || ser == null || num == null )
            {
                
                MessageBox.Show("Основные данные сохранены, введите остальные данные!");
                basicDataEntered = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Accept_Click(object sender, EventArgs e)
        {


            if ( maskedTextBox1.Text.Length != 10 )
            {
                button3.Enabled = false;
                MessageBox.Show("Данные введены не корректно!");
            }
            else
            {
                
                if(AllCheck())
                {
                    if (CheckYears())
                    {
                        button3.Enabled = true;
                        MessageBox.Show("Данные успешно записаны,\n теперь вы можете добавить данные!");
                    }
                }
                else
                {
                    button3.Enabled = false;
                }
            }

        }

        private void own_Click(object sender, EventArgs e)
        {
            if (basicDataEntered)
            {
                string maskedTextBoxValue = maskedTextBox1.Text;
                OwnerForm form2 = new OwnerForm(maskedTextBoxValue);
                form2.ShowDialog();
                fam = form2.FamData;
                name = form2.OwnerName;
                fath = form2.OwnerFath;
                bith = form2.OwnerBith;
                ser = form2.OwnerPass;
                num = form2.OwnerNum;
            }
            else
            {
                MessageBox.Show("Введите основные данные!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        public string DateValue()
        {
            return maskedTextBox1.Text;
        }


        private void OpHistory_Click(object sender, EventArgs e)
        {
            if (basicDataEntered)
            {
                string maskedTextBoxValue = maskedTextBox1.Text;
                OperHistory oper = new OperHistory(maskedTextBoxValue);
                oper.ShowDialog();
                type = oper.OpType;
                sum = oper.Sum;
                opdate = oper.OpDate;
            }
            else
            {
                MessageBox.Show("Введите основные данные!");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45) 
            {
                e.Handled = true;
            }

        }
    }


    

}
