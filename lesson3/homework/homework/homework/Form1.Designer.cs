namespace homework
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1_start = new Button();
            button2_stop = new Button();
            checkBox1 = new CheckBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "Файл";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 9);
            label2.Name = "label2";
            label2.Size = new Size(148, 15);
            label2.TabIndex = 1;
            label2.Text = "Слова или фраза в файле";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(118, 27);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(285, 23);
            textBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(409, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 5;
            label4.Text = "Файл";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(409, 9);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 6;
            label5.Text = "Диски";
            // 
            // button1_start
            // 
            button1_start.Location = new Point(536, 27);
            button1_start.Name = "button1_start";
            button1_start.Size = new Size(75, 23);
            button1_start.TabIndex = 7;
            button1_start.Text = "Найти";
            button1_start.UseVisualStyleBackColor = true;
            button1_start.Click += button1_Click;
            // 
            // button2_stop
            // 
            button2_stop.Location = new Point(617, 27);
            button2_stop.Name = "button2_stop";
            button2_stop.Size = new Size(75, 23);
            button2_stop.TabIndex = 8;
            button2_stop.Text = "Остановить";
            button2_stop.UseVisualStyleBackColor = true;
            button2_stop.Click += button2_stop_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(698, 31);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(97, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Подкаталоги";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 53);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 10;
            label6.Text = "Результаты поиска:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(132, 53);
            label7.Name = "label7";
            label7.Size = new Size(187, 15);
            label7.TabIndex = 11;
            label7.Text = "количество найденных файлов -";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(317, 53);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 12;
            label8.Text = "0";
            // 
            // listView1
            // 
            listView1.GridLines = true;
            listView1.ImeMode = ImeMode.NoControl;
            listView1.Location = new Point(12, 87);
            listView1.Name = "listView1";
            listView1.Size = new Size(776, 351);
            listView1.TabIndex = 13;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(checkBox1);
            Controls.Add(button2_stop);
            Controls.Add(button1_start);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Поиск файлов и папок";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1_start;
        private Button button2_stop;
        private CheckBox checkBox1;
        private Label label6;
        private Label label7;
        private Label label8;
        private ListView listView1;
    }
}
