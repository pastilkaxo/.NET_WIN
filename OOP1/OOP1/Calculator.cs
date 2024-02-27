using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP1
{
    public partial class Calculator : Form,IBinaryCalculate
    {
        int a;
        public bool znak = true;
        int count;

        public Calculator()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }


        private void button17_Click(object sender, EventArgs e)
        {
            int num2, result , newA;
            string binaryRes;

            switch (count)
            {
                case 1:

                    if (checkBox4.Checked)
                    {
                        binaryRes = Convert.ToString(BinaryAND(), 2);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox2.Checked)
                    {
                        textBox1.Text = DecimalAND().ToString();
                        label1.Text = "";
                    }
                    else if (checkBox3.Checked)
                    {
                        binaryRes = Convert.ToString(OctusAND(), 8);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox1.Checked)
                    {
                        binaryRes = Convert.ToString(HexAND(), 16);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    break;
                case 2:
                    if (checkBox4.Checked)
                    {
                        binaryRes = Convert.ToString(BinaryOR(), 2);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox3.Checked)
                    {
                        binaryRes = Convert.ToString(OctusOR(), 8);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox2.Checked)
                    {
                        binaryRes = Convert.ToString(DecimalOR(), 10);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox1.Checked)
                    {
                        binaryRes = Convert.ToString(HexOR(), 16);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    break;
                case 3:
                    if (checkBox4.Checked)
                    {
                        binaryRes = Convert.ToString(BinaryXOR(), 2);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox3.Checked)
                    {
                        binaryRes = Convert.ToString(OctusXOR(), 8);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox2.Checked)
                    {
                        binaryRes = Convert.ToString(DecimalXOR(), 10);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox1.Checked)
                    {
                        binaryRes = Convert.ToString(HexXOR(), 16);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    break;
                case 4:
                    if (checkBox4.Checked)
                    {
                        binaryRes = Convert.ToString(BinaryNOT(a), 2);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox3.Checked)
                    {
                        binaryRes = Convert.ToString(OctusNOT(a), 8);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox2.Checked)
                    {
                        binaryRes = Convert.ToString(DecimalNOT(a), 10);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    else if (checkBox1.Checked)
                    {
                        binaryRes = Convert.ToString(HexNOT(a), 16);
                        textBox1.Text = binaryRes;
                        label1.Text = "";
                    }
                    break;
            }
        }


   
     

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            try
            {
                if(textBox1.Text != string.Empty)
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }


                if (checkBox4.Checked)
                {
                    textBox5.Text = textBox1.Text;

                    double result = 0;
                    for (int i = 0; i < textBox1.Text.Length; i++)
                    {
                        if (textBox1.Text[i] == '1')
                        {
                            result += Math.Pow(2, textBox1.Text.Length - i - 1);

                        }
                    }

                    textBox3.Text = result.ToString();
                    string octRes = Convert.ToString((int)result, 8);
                    textBox4.Text = octRes;
                    string hexRes = Convert.ToString((int)result, 16);
                    textBox2.Text = hexRes;
                }
                else if (checkBox3.Checked)
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        if (int.TryParse(textBox1.Text, out int num))
                        {
                            textBox4.Text = textBox1.Text;
                            int oct = Convert.ToInt32(textBox1.Text, 8);
                            string dec = Convert.ToString(oct, 10);
                            string hex = Convert.ToString(oct, 16);
                            string bin = Convert.ToString(oct, 2);
                            textBox3.Text = dec;
                            textBox5.Text = bin;
                            textBox2.Text = hex;
                        }

                    }
                    else
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                    }

                }
                else if (checkBox2.Checked)
                {


                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        if (int.TryParse(textBox1.Text, out int num))
                        {
                            textBox3.Text = textBox1.Text;
                            int dec = Convert.ToInt32(textBox1.Text, 10);
                            string bin = Convert.ToString(dec, 2);
                            string oct = Convert.ToString(dec, 8);
                            string hex = Convert.ToString(dec, 16);
                            textBox2.Text = hex;
                            textBox4.Text = oct;
                            textBox5.Text = bin;

                        }

                    }
                    else
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                    }


                }
                else if (checkBox1.Checked)
                {
                    if (!string.IsNullOrEmpty(textBox1.Text) )
                    {
                        if (int.TryParse(textBox1.Text, out int num))
                        {
                           
                            int hex = Convert.ToInt32(textBox1.Text);
                            string bin = Convert.ToString(Convert.ToInt32(textBox1.Text, 16), 2);
                            string oct = Convert.ToString(Convert.ToInt32(textBox1.Text, 16), 8);
                            string dec = Convert.ToString(Convert.ToInt32(textBox1.Text, 16), 10);
                            textBox3.Text = dec;
                            textBox4.Text = oct;
                            textBox5.Text = bin;
                            textBox2.Text = hex.ToString();

                        }

                    }
                    else
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
                textBox1.Clear();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            a = int.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label1.Text = a.ToString() + " OR ";
            znak = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                a = int.Parse(textBox1.Text);
                textBox1.Clear();
                count = 1;
                label1.Text = a.ToString() + " AND ";
                znak = true;
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a = int.Parse(textBox1.Text);
            textBox1.Clear();
            count = 3;
            label1.Text = a.ToString() + " XOR ";
            znak = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = int.Parse(textBox1.Text);
            textBox1.Clear();
            count = 4;
            label1.Text = a.ToString() + " NOT ";
            znak = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox4.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                button7.Enabled = true;
                button8.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button18.Enabled = true;
                button19.Enabled = true;
                button20.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox4.Checked = false;
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                button7.Enabled = true;
                button8.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = false;
                button15.Enabled = false;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;

            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox4.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                button7.Enabled = true;
                button8.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button18.Enabled = false;
                button19.Enabled = false;
                button20.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
            }
   
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0x0A;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0x0B;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0x0C;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0x0D;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0x0E;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0x0F;
        }



        int num2, result, newA;
        public int BinaryAND()
        {
            newA = Convert.ToInt32(a.ToString(), 2);
            num2 = Convert.ToInt32(textBox1.Text, 2);
            result = newA & num2;
            return result;

        }

        public int BinaryNOT(int answer)
        {
            string binaryA = Convert.ToString(a, 2);
            result = ~Convert.ToInt32(binaryA, 2);
            return result;
        }

        public int BinaryOR()
        {
            newA = Convert.ToInt32(a.ToString(), 2);
            num2 = Convert.ToInt32(textBox1.Text, 2);
            result = newA | num2;
            return result;

        }

        public int BinaryXOR()
        {
            newA = Convert.ToInt32(a.ToString(), 2);
            num2 = Convert.ToInt32(textBox1.Text, 2);
            result = newA ^ num2;
            return result;
        }

        public int DecimalAND()
        {
            newA = Convert.ToInt32(a.ToString(), 10);
            num2 = Convert.ToInt32(textBox1.Text, 10);
            result = newA & num2;
            return result;
        }

        public int DecimalNOT(int answer)
        {
            string binaryA = Convert.ToString(answer, 10);
            result = ~Convert.ToInt32(binaryA, 10);
            return result;
        }

        public int DecimalOR()
        {
            newA = Convert.ToInt32(a.ToString(), 10);
            num2 = Convert.ToInt32(textBox1.Text, 10);
            result = newA | num2;
            return result;
        }

        public int DecimalXOR()
        {
            newA = Convert.ToInt32(a.ToString(), 10);
            num2 = Convert.ToInt32(textBox1.Text, 10);
            result = newA ^ num2;
            return result;
        }

        public int HexAND()
        {
            num2 = Convert.ToInt32(textBox1.Text, 16);
            result = Convert.ToInt32(a.ToString(),16) & num2;
            return result;
        }

        public int HexNOT(int answer)
        {
            result = ~Convert.ToInt32(answer.ToString(), 16);
            return result;
        }

        public int HexOR()
        {
            num2 = Convert.ToInt32(textBox1.Text, 16);
            result = Convert.ToInt32(a.ToString(), 16) | num2;
            return result;
        }

        public int HexXOR()
        {
            newA = Convert.ToInt32(a.ToString(), 16);
            num2 = Convert.ToInt32(textBox1.Text, 16);
            result = newA ^ num2;
            return result;
        }

        public int OctusAND()
        {
            newA = Convert.ToInt32(a.ToString(), 8);
            num2 = Convert.ToInt32(textBox1.Text, 8);
            result = newA & num2;
            return result;
        }

        public int OctusNOT(int answer)
        {
            string binaryA = Convert.ToString(a, 8);
            result = ~Convert.ToInt32(binaryA, 8);
            return result;
        }

        public int OctusOR()
        {
            newA = Convert.ToInt32(a.ToString(), 8);
            num2 = Convert.ToInt32(textBox1.Text, 8);
            result = newA | num2;
            return result;
        }

        public int OctusXOR()
        {
            newA = Convert.ToInt32(a.ToString(), 8);
            num2 = Convert.ToInt32(textBox1.Text, 8);
            result = newA ^ num2;
            return result;
        }




    }
}
