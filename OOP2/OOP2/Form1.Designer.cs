namespace OOP2
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScoreBox = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.BalanceStatus = new System.Windows.Forms.TextBox();
            this.Balance = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.EthernetBank = new System.Windows.Forms.Label();
            this.Sms = new System.Windows.Forms.Label();
            this.OpenDate = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.Type = new System.Windows.Forms.Label();
            this.Number = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Номер = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Тип = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_открытия = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.СМС = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ИБ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Тип_Операции = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Баланс = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Сумма = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_Операции = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Фамилия = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Имя = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Отчество = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_Рождения = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Серия_паспорта = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Номер_паспорта = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClearGrid = new System.Windows.Forms.Button();
            this.Accept = new System.Windows.Forms.Button();
            this.own = new System.Windows.Forms.Button();
            this.OpHistory = new System.Windows.Forms.Button();
            this.ScoreBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ScoreBox
            // 
            this.ScoreBox.Controls.Add(this.radioButton2);
            this.ScoreBox.Controls.Add(this.radioButton1);
            this.ScoreBox.Controls.Add(this.BalanceStatus);
            this.ScoreBox.Controls.Add(this.Balance);
            this.ScoreBox.Controls.Add(this.checkBox4);
            this.ScoreBox.Controls.Add(this.checkBox3);
            this.ScoreBox.Controls.Add(this.EthernetBank);
            this.ScoreBox.Controls.Add(this.Sms);
            this.ScoreBox.Controls.Add(this.OpenDate);
            this.ScoreBox.Controls.Add(this.maskedTextBox1);
            this.ScoreBox.Controls.Add(this.Type);
            this.ScoreBox.Controls.Add(this.Number);
            this.ScoreBox.Controls.Add(this.comboBox1);
            this.ScoreBox.Controls.Add(this.textBox1);
            this.ScoreBox.Location = new System.Drawing.Point(12, 12);
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.Size = new System.Drawing.Size(341, 350);
            this.ScoreBox.TabIndex = 0;
            this.ScoreBox.TabStop = false;
            this.ScoreBox.Text = "Счет";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(56, 191);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(44, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Нет";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 191);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(40, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Да";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // BalanceStatus
            // 
            this.BalanceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BalanceStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BalanceStatus.Location = new System.Drawing.Point(6, 277);
            this.BalanceStatus.Name = "BalanceStatus";
            this.BalanceStatus.Size = new System.Drawing.Size(270, 31);
            this.BalanceStatus.TabIndex = 14;
            this.BalanceStatus.TextChanged += new System.EventHandler(this.BalanceStatus_TextChanged);
            this.BalanceStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // Balance
            // 
            this.Balance.AutoSize = true;
            this.Balance.Location = new System.Drawing.Point(11, 261);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(47, 13);
            this.Balance.TabIndex = 13;
            this.Balance.Text = "Баланс:";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(61, 241);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(45, 17);
            this.checkBox4.TabIndex = 12;
            this.checkBox4.Text = "Нет";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(14, 241);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(41, 17);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Да";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // EthernetBank
            // 
            this.EthernetBank.AutoSize = true;
            this.EthernetBank.Location = new System.Drawing.Point(11, 225);
            this.EthernetBank.Name = "EthernetBank";
            this.EthernetBank.Size = new System.Drawing.Size(178, 13);
            this.EthernetBank.TabIndex = 10;
            this.EthernetBank.Text = "Подключение интернет-банкинга ";
            // 
            // Sms
            // 
            this.Sms.AutoSize = true;
            this.Sms.Location = new System.Drawing.Point(8, 175);
            this.Sms.Name = "Sms";
            this.Sms.Size = new System.Drawing.Size(165, 13);
            this.Sms.TabIndex = 1;
            this.Sms.Text = "Подключение смс оповещения";
            // 
            // OpenDate
            // 
            this.OpenDate.AutoSize = true;
            this.OpenDate.Location = new System.Drawing.Point(6, 123);
            this.OpenDate.Name = "OpenDate";
            this.OpenDate.Size = new System.Drawing.Size(84, 13);
            this.OpenDate.TabIndex = 6;
            this.OpenDate.Text = "Дата открытия";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(6, 139);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 5;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            this.maskedTextBox1.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.maskedTextBox1_TypeValidationCompleted);
            // 
            // Type
            // 
            this.Type.AutoSize = true;
            this.Type.Location = new System.Drawing.Point(3, 66);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(65, 13);
            this.Type.TabIndex = 4;
            this.Type.Text = "Тип вклада";
            // 
            // Number
            // 
            this.Number.AutoSize = true;
            this.Number.Location = new System.Drawing.Point(3, 16);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(41, 13);
            this.Number.TabIndex = 3;
            this.Number.Text = "Номер";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "срочные",
            "накопительные",
            "сберегательные",
            "до востребования"});
            this.comboBox1.Location = new System.Drawing.Point(6, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(499, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сохранение информации в JSON";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Location = new System.Drawing.Point(639, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 50);
            this.button2.TabIndex = 4;
            this.button2.Text = "Чтение информации из JSON ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(359, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 50);
            this.button3.TabIndex = 5;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(359, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 284);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "История вкладов";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Номер,
            this.Тип,
            this.Дата_открытия,
            this.СМС,
            this.ИБ,
            this.Тип_Операции,
            this.Баланс,
            this.Сумма,
            this.Дата_Операции,
            this.Фамилия,
            this.Имя,
            this.Отчество,
            this.Дата_Рождения,
            this.Серия_паспорта,
            this.Номер_паспорта});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(623, 259);
            this.dataGridView1.TabIndex = 0;
            // 
            // Номер
            // 
            this.Номер.HeaderText = "Номер";
            this.Номер.Name = "Номер";
            this.Номер.ReadOnly = true;
            // 
            // Тип
            // 
            this.Тип.HeaderText = "Тип";
            this.Тип.Name = "Тип";
            this.Тип.ReadOnly = true;
            // 
            // Дата_открытия
            // 
            this.Дата_открытия.HeaderText = "Дата_открытия";
            this.Дата_открытия.Name = "Дата_открытия";
            this.Дата_открытия.ReadOnly = true;
            // 
            // СМС
            // 
            this.СМС.HeaderText = "СМС";
            this.СМС.Name = "СМС";
            this.СМС.ReadOnly = true;
            // 
            // ИБ
            // 
            this.ИБ.HeaderText = "ИБ";
            this.ИБ.Name = "ИБ";
            this.ИБ.ReadOnly = true;
            // 
            // Тип_Операции
            // 
            this.Тип_Операции.HeaderText = "Тип_Операции";
            this.Тип_Операции.Name = "Тип_Операции";
            this.Тип_Операции.ReadOnly = true;
            // 
            // Баланс
            // 
            this.Баланс.HeaderText = "Баланс";
            this.Баланс.Name = "Баланс";
            this.Баланс.ReadOnly = true;
            // 
            // Сумма
            // 
            this.Сумма.HeaderText = "Сумма";
            this.Сумма.Name = "Сумма";
            this.Сумма.ReadOnly = true;
            // 
            // Дата_Операции
            // 
            this.Дата_Операции.HeaderText = "Дата_Операции";
            this.Дата_Операции.Name = "Дата_Операции";
            this.Дата_Операции.ReadOnly = true;
            // 
            // Фамилия
            // 
            this.Фамилия.HeaderText = "Фамилия";
            this.Фамилия.Name = "Фамилия";
            this.Фамилия.ReadOnly = true;
            // 
            // Имя
            // 
            this.Имя.HeaderText = "Имя";
            this.Имя.Name = "Имя";
            this.Имя.ReadOnly = true;
            // 
            // Отчество
            // 
            this.Отчество.HeaderText = "Отчество";
            this.Отчество.Name = "Отчество";
            this.Отчество.ReadOnly = true;
            // 
            // Дата_Рождения
            // 
            this.Дата_Рождения.HeaderText = "Дата_Рождения";
            this.Дата_Рождения.Name = "Дата_Рождения";
            this.Дата_Рождения.ReadOnly = true;
            // 
            // Серия_паспорта
            // 
            this.Серия_паспорта.HeaderText = "Серия_паспорта";
            this.Серия_паспорта.Name = "Серия_паспорта";
            this.Серия_паспорта.ReadOnly = true;
            // 
            // Номер_паспорта
            // 
            this.Номер_паспорта.HeaderText = "Номер_паспорта";
            this.Номер_паспорта.Name = "Номер_паспорта";
            this.Номер_паспорта.ReadOnly = true;
            // 
            // ClearGrid
            // 
            this.ClearGrid.Image = global::OOP2.Properties.Resources.trash;
            this.ClearGrid.Location = new System.Drawing.Point(779, 22);
            this.ClearGrid.Name = "ClearGrid";
            this.ClearGrid.Size = new System.Drawing.Size(75, 50);
            this.ClearGrid.TabIndex = 6;
            this.ClearGrid.UseVisualStyleBackColor = true;
            this.ClearGrid.Click += new System.EventHandler(this.ClearGrid_Click);
            // 
            // Accept
            // 
            this.Accept.BackColor = System.Drawing.Color.Tomato;
            this.Accept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Accept.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Accept.Location = new System.Drawing.Point(639, 372);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(112, 45);
            this.Accept.TabIndex = 7;
            this.Accept.Text = "Применить";
            this.Accept.UseVisualStyleBackColor = false;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // own
            // 
            this.own.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.own.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.own.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.own.Location = new System.Drawing.Point(757, 372);
            this.own.Name = "own";
            this.own.Size = new System.Drawing.Size(97, 45);
            this.own.TabIndex = 8;
            this.own.Text = "Ввод Владельца";
            this.own.UseVisualStyleBackColor = false;
            this.own.Click += new System.EventHandler(this.own_Click);
            // 
            // OpHistory
            // 
            this.OpHistory.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.OpHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpHistory.Location = new System.Drawing.Point(860, 372);
            this.OpHistory.Name = "OpHistory";
            this.OpHistory.Size = new System.Drawing.Size(97, 45);
            this.OpHistory.TabIndex = 9;
            this.OpHistory.Text = "История Опраций";
            this.OpHistory.UseVisualStyleBackColor = false;
            this.OpHistory.Click += new System.EventHandler(this.OpHistory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 455);
            this.Controls.Add(this.OpHistory);
            this.Controls.Add(this.own);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.ClearGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ScoreBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Банк";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ScoreBox.ResumeLayout(false);
            this.ScoreBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ScoreBox;
        private System.Windows.Forms.Label Type;
        private System.Windows.Forms.Label Number;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label OpenDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label Sms;
        private System.Windows.Forms.TextBox BalanceStatus;
        private System.Windows.Forms.Label Balance;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label EthernetBank;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ClearGrid;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button own;
        private System.Windows.Forms.Button OpHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Номер;
        private System.Windows.Forms.DataGridViewTextBoxColumn Тип;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_открытия;
        private System.Windows.Forms.DataGridViewTextBoxColumn СМС;
        private System.Windows.Forms.DataGridViewTextBoxColumn ИБ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Тип_Операции;
        private System.Windows.Forms.DataGridViewTextBoxColumn Баланс;
        private System.Windows.Forms.DataGridViewTextBoxColumn Сумма;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_Операции;
        private System.Windows.Forms.DataGridViewTextBoxColumn Фамилия;
        private System.Windows.Forms.DataGridViewTextBoxColumn Имя;
        private System.Windows.Forms.DataGridViewTextBoxColumn Отчество;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_Рождения;
        private System.Windows.Forms.DataGridViewTextBoxColumn Серия_паспорта;
        private System.Windows.Forms.DataGridViewTextBoxColumn Номер_паспорта;
    }
}

