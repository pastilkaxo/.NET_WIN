namespace OOP2
{
    partial class OwnerForm
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Owner = new System.Windows.Forms.GroupBox();
            this.Fathername = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Surname = new System.Windows.Forms.Label();
            this.fath = new System.Windows.Forms.TextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.nam = new System.Windows.Forms.TextBox();
            this.PassNum = new System.Windows.Forms.Label();
            this.Fam = new System.Windows.Forms.TextBox();
            this.PassSer = new System.Windows.Forms.Label();
            this.Birth = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Owner.SuspendLayout();
            this.SuspendLayout();
            // 
            // Owner
            // 
            this.Owner.Controls.Add(this.Fathername);
            this.Owner.Controls.Add(this.textBox3);
            this.Owner.Controls.Add(this.Name);
            this.Owner.Controls.Add(this.comboBox2);
            this.Owner.Controls.Add(this.Surname);
            this.Owner.Controls.Add(this.fath);
            this.Owner.Controls.Add(this.maskedTextBox2);
            this.Owner.Controls.Add(this.nam);
            this.Owner.Controls.Add(this.PassNum);
            this.Owner.Controls.Add(this.Fam);
            this.Owner.Controls.Add(this.PassSer);
            this.Owner.Controls.Add(this.Birth);
            this.Owner.Location = new System.Drawing.Point(12, 12);
            this.Owner.Name = "Owner";
            this.Owner.Size = new System.Drawing.Size(338, 375);
            this.Owner.TabIndex = 2;
            this.Owner.TabStop = false;
            this.Owner.Text = "Владелец";
            // 
            // Fathername
            // 
            this.Fathername.AutoSize = true;
            this.Fathername.Location = new System.Drawing.Point(9, 127);
            this.Fathername.Name = "Fathername";
            this.Fathername.Size = new System.Drawing.Size(54, 13);
            this.Fathername.TabIndex = 13;
            this.Fathername.Text = "Отчество";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(14, 297);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(9, 76);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(29, 13);
            this.Name.TabIndex = 12;
            this.Name.Text = "Имя";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "НВ",
            "КН",
            "МР",
            "МС"});
            this.comboBox2.Location = new System.Drawing.Point(14, 240);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // Surname
            // 
            this.Surname.AutoSize = true;
            this.Surname.Location = new System.Drawing.Point(9, 36);
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(56, 13);
            this.Surname.TabIndex = 11;
            this.Surname.Text = "Фамилия";
            // 
            // fath
            // 
            this.fath.Location = new System.Drawing.Point(9, 143);
            this.fath.Name = "fath";
            this.fath.Size = new System.Drawing.Size(100, 20);
            this.fath.TabIndex = 10;
            this.fath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fath_KeyPress);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(11, 188);
            this.maskedTextBox2.Mask = "00/00/0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(88, 20);
            this.maskedTextBox2.TabIndex = 5;
            this.maskedTextBox2.ValidatingType = typeof(System.DateTime);
            // 
            // nam
            // 
            this.nam.Location = new System.Drawing.Point(9, 92);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(100, 20);
            this.nam.TabIndex = 9;
            this.nam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Fam_KeyPress);
            // 
            // PassNum
            // 
            this.PassNum.AutoSize = true;
            this.PassNum.Location = new System.Drawing.Point(11, 281);
            this.PassNum.Name = "PassNum";
            this.PassNum.Size = new System.Drawing.Size(94, 13);
            this.PassNum.TabIndex = 3;
            this.PassNum.Text = "Номер паспорта:";
            // 
            // Fam
            // 
            this.Fam.Location = new System.Drawing.Point(9, 53);
            this.Fam.Name = "Fam";
            this.Fam.Size = new System.Drawing.Size(100, 20);
            this.Fam.TabIndex = 8;
            this.Fam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Fam_KeyPress);
            // 
            // PassSer
            // 
            this.PassSer.AutoSize = true;
            this.PassSer.Location = new System.Drawing.Point(11, 223);
            this.PassSer.Name = "PassSer";
            this.PassSer.Size = new System.Drawing.Size(91, 13);
            this.PassSer.TabIndex = 2;
            this.PassSer.Text = "Серия паспорта:";
            // 
            // Birth
            // 
            this.Birth.AutoSize = true;
            this.Birth.Location = new System.Drawing.Point(8, 172);
            this.Birth.Name = "Birth";
            this.Birth.Size = new System.Drawing.Size(89, 13);
            this.Birth.TabIndex = 1;
            this.Birth.Text = "Дата рождения:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.Image = global::OOP2.Properties.Resources.trash;
            this.button2.Location = new System.Drawing.Point(121, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 38);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.Location = new System.Drawing.Point(12, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Accept_Click);
            // 
            // OwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Owner);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OwnerForm";
            this.Owner.ResumeLayout(false);
            this.Owner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Owner;
        private System.Windows.Forms.Label Fathername;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Surname;
        private System.Windows.Forms.TextBox fath;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.TextBox nam;
        private System.Windows.Forms.Label PassNum;
        private System.Windows.Forms.TextBox Fam;
        private System.Windows.Forms.Label PassSer;
        private System.Windows.Forms.Label Birth;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}