namespace practice
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
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            progressBar3 = new ProgressBar();
            progressBar4 = new ProgressBar();
            progressBar5 = new ProgressBar();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(41, 8);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(322, 23);
            progressBar1.TabIndex = 0;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(41, 37);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(322, 23);
            progressBar2.TabIndex = 1;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(41, 66);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(322, 23);
            progressBar3.TabIndex = 2;
            // 
            // progressBar4
            // 
            progressBar4.Location = new Point(41, 95);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new Size(322, 23);
            progressBar4.TabIndex = 3;
            // 
            // progressBar5
            // 
            progressBar5.Location = new Point(41, 124);
            progressBar5.Name = "progressBar5";
            progressBar5.Size = new Size(322, 23);
            progressBar5.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(148, 157);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 12);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 6;
            label1.Text = "#1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 41);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 7;
            label2.Text = "#2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 70);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 8;
            label3.Text = "#3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 99);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 9;
            label4.Text = "#4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 128);
            label5.Name = "label5";
            label5.Size = new Size(20, 15);
            label5.TabIndex = 10;
            label5.Text = "#5";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 187);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(progressBar5);
            Controls.Add(progressBar4);
            Controls.Add(progressBar3);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Конные скачки";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;
        private ProgressBar progressBar4;
        private ProgressBar progressBar5;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
