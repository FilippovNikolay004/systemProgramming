namespace examProject
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
            groupBox1 = new GroupBox();
            listBoxResults = new ListBox();
            label1 = new Label();
            textBoxForbiddenWords = new TextBox();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            fileSelection = new Button();
            groupBox2 = new GroupBox();
            textBoxNameFile = new TextBox();
            Start = new Button();
            Stop = new Button();
            pathSelection = new Button();
            label3 = new Label();
            textBoxChosenPath = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxResults);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(209, 218);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Результат";
            // 
            // listBoxResults
            // 
            listBoxResults.FormattingEnabled = true;
            listBoxResults.ItemHeight = 15;
            listBoxResults.Location = new Point(6, 22);
            listBoxResults.Name = "listBoxResults";
            listBoxResults.Size = new Size(197, 184);
            listBoxResults.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(227, 12);
            label1.Name = "label1";
            label1.Size = new Size(168, 15);
            label1.TabIndex = 2;
            label1.Text = "Введите запрещённые слова:";
            // 
            // textBoxForbiddenWords
            // 
            textBoxForbiddenWords.Location = new Point(227, 34);
            textBoxForbiddenWords.Name = "textBoxForbiddenWords";
            textBoxForbiddenWords.Size = new Size(217, 23);
            textBoxForbiddenWords.TabIndex = 3;
            textBoxForbiddenWords.TextChanged += textBoxForbiddenWords_TextChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 265);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(432, 23);
            progressBar1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 67);
            label2.Name = "label2";
            label2.Size = new Size(136, 15);
            label2.TabIndex = 5;
            label2.Text = "Или загрузите txt файл:";
            // 
            // fileSelection
            // 
            fileSelection.Location = new Point(369, 63);
            fileSelection.Name = "fileSelection";
            fileSelection.Size = new Size(75, 23);
            fileSelection.TabIndex = 6;
            fileSelection.Text = "Файл...";
            fileSelection.UseVisualStyleBackColor = true;
            fileSelection.Click += fileSelection_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxNameFile);
            groupBox2.Location = new Point(227, 104);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(217, 53);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Название файла";
            // 
            // textBoxNameFile
            // 
            textBoxNameFile.Enabled = false;
            textBoxNameFile.Location = new Point(6, 22);
            textBoxNameFile.Name = "textBoxNameFile";
            textBoxNameFile.Size = new Size(205, 23);
            textBoxNameFile.TabIndex = 8;
            // 
            // Start
            // 
            Start.Location = new Point(12, 236);
            Start.Name = "Start";
            Start.Size = new Size(104, 23);
            Start.TabIndex = 8;
            Start.Text = "Запустить";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // Stop
            // 
            Stop.Location = new Point(117, 236);
            Stop.Name = "Stop";
            Stop.Size = new Size(104, 23);
            Stop.TabIndex = 9;
            Stop.Text = "Завершить";
            Stop.UseVisualStyleBackColor = true;
            Stop.Click += Stop_Click;
            // 
            // pathSelection
            // 
            pathSelection.Location = new Point(103, 63);
            pathSelection.Name = "pathSelection";
            pathSelection.Size = new Size(108, 23);
            pathSelection.TabIndex = 13;
            pathSelection.Text = "Путь...";
            pathSelection.UseVisualStyleBackColor = true;
            pathSelection.Click += pathSelection_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 67);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 12;
            label3.Text = "Выберите путь:";
            // 
            // textBoxChosenPath
            // 
            textBoxChosenPath.Enabled = false;
            textBoxChosenPath.Location = new Point(6, 37);
            textBoxChosenPath.Name = "textBoxChosenPath";
            textBoxChosenPath.Size = new Size(205, 23);
            textBoxChosenPath.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 19);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 10;
            label4.Text = "Указанный путь:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxChosenPath);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(pathSelection);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(227, 163);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(217, 96);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Сохранение отчёта";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 301);
            Controls.Add(groupBox3);
            Controls.Add(Stop);
            Controls.Add(Start);
            Controls.Add(groupBox2);
            Controls.Add(fileSelection);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(textBoxForbiddenWords);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Поиск запрещённых слов";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBoxForbiddenWords;
        private ProgressBar progressBar1;
        private Label label2;
        private Button fileSelection;
        private GroupBox groupBox2;
        private TextBox textBoxNameFile;
        private Button Start;
        private Button Stop;
        private ListBox listBoxResults;
        private Button pathSelection;
        private Label label3;
        private TextBox textBoxChosenPath;
        private Label label4;
        private GroupBox groupBox3;
    }
}
