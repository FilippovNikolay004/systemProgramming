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
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            progressBar1 = new ProgressBar();
            buttonStart = new Button();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            checkBox6 = new CheckBox();
            isSaveResults = new CheckBox();
            showPath = new TextBox();
            groupBox3 = new GroupBox();
            inputNameFile = new TextBox();
            groupBox4 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            buttonPath = new Button();
            label2 = new Label();
            label1 = new Label();
            buttonStop = new Button();
            button4 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 24);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(170, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Количество предложений";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(6, 49);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(149, 19);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "Количество символов";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(6, 74);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(120, 19);
            checkBox3.TabIndex = 3;
            checkBox3.Text = "Количество слов";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(6, 99);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(265, 19);
            checkBox4.TabIndex = 4;
            checkBox4.Text = "Количество вопросительных предложений";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(6, 124);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(270, 19);
            checkBox5.TabIndex = 5;
            checkBox5.Text = "Количество восклицательных предложений";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 387);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(656, 23);
            progressBar1.TabIndex = 6;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(12, 358);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(91, 23);
            buttonStart.TabIndex = 7;
            buttonStart.Text = "Старт";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(313, 312);
            textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(325, 340);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ввод";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBox6);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(checkBox4);
            groupBox2.Controls.Add(checkBox5);
            groupBox2.Location = new Point(343, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(325, 175);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Фильтры";
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(6, 149);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(88, 19);
            checkBox6.TabIndex = 6;
            checkBox6.Text = "Все пункты";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += checkBox6_CheckedChanged;
            // 
            // isSaveResults
            // 
            isSaveResults.AutoSize = true;
            isSaveResults.Location = new Point(6, 22);
            isSaveResults.Name = "isSaveResults";
            isSaveResults.Size = new Size(181, 19);
            isSaveResults.TabIndex = 10;
            isSaveResults.Text = "Сохранить результат в файл";
            isSaveResults.UseVisualStyleBackColor = true;
            isSaveResults.CheckedChanged += isSaveResults_CheckedChanged;
            // 
            // showPath
            // 
            showPath.Enabled = false;
            showPath.Location = new Point(47, 47);
            showPath.Name = "showPath";
            showPath.ScrollBars = ScrollBars.Vertical;
            showPath.Size = new Size(190, 23);
            showPath.TabIndex = 11;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(inputNameFile);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(buttonPath);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(showPath);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(isSaveResults);
            groupBox3.Location = new Point(343, 193);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(325, 188);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Сохранение результата";
            // 
            // inputNameFile
            // 
            inputNameFile.Enabled = false;
            inputNameFile.Location = new Point(112, 77);
            inputNameFile.Name = "inputNameFile";
            inputNameFile.ScrollBars = ScrollBars.Vertical;
            inputNameFile.Size = new Size(206, 23);
            inputNameFile.TabIndex = 17;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Location = new Point(6, 106);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(312, 74);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Вид сохранения";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Enabled = false;
            radioButton2.Location = new Point(6, 47);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(214, 19);
            radioButton2.TabIndex = 16;
            radioButton2.Text = "Только те что выбраны в фильтре";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Enabled = false;
            radioButton1.Location = new Point(6, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(207, 19);
            radioButton1.TabIndex = 15;
            radioButton1.TabStop = true;
            radioButton1.Text = "Сохранить в файл весь результат";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonPath
            // 
            buttonPath.Enabled = false;
            buttonPath.Location = new Point(243, 47);
            buttonPath.Name = "buttonPath";
            buttonPath.Size = new Size(75, 23);
            buttonPath.TabIndex = 13;
            buttonPath.Text = "Путь...";
            buttonPath.UseVisualStyleBackColor = true;
            buttonPath.Click += buttonPath_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 80);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 12;
            label2.Text = "Название файла:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 51);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 11;
            label1.Text = "Путь:";
            // 
            // buttonStop
            // 
            buttonStop.Enabled = false;
            buttonStop.Location = new Point(109, 358);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(91, 23);
            buttonStop.TabIndex = 13;
            buttonStop.Text = "Стоп";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(206, 358);
            button4.Name = "button4";
            button4.Size = new Size(131, 23);
            button4.TabIndex = 14;
            button4.Text = "Повторный запуск";
            button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 420);
            Controls.Add(button4);
            Controls.Add(buttonStop);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonStart);
            Controls.Add(progressBar1);
            Name = "Form1";
            Text = "Отчёт текста";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private ProgressBar progressBar1;
        private Button buttonStart;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox checkBox6;
        private CheckBox isSaveResults;
        private TextBox showPath;
        private GroupBox groupBox3;
        private Button buttonPath;
        private Label label2;
        private Label label1;
        private GroupBox groupBox4;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button buttonStop;
        private Button button4;
        private TextBox inputNameFile;
    }
}
