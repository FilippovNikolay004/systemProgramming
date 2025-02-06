using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread thread = null;
        private delegate void InWork(int a);

        private void ThreadFunk()
        {
            try
            {
                // Создание анонимных делегатов
                Action Act1 = delegate
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 230;
                    progressBar1.Value = 0;
                    button1.Enabled = false;
                };

                Action Act2 = delegate
                {
                    button1.Enabled = true;
                };

                InWork IW = delegate(int a)
                {
                    progressBar1.Value = a;
                };

                // Выполняет указанный делегат в том потоке, которому принадлежит базовый дескриптор окна элемента управления.
                this.Invoke(Act1);

                for (int i = 0; i < 230; i++)
                {
                    Thread.Sleep(50);
                    // Выполняет указанный делегат в том потоке, которому принадлежит базовый дескриптор окна элемента управления.
                    this.Invoke(IW, i);
                }
                this.Invoke(Act2);
            }
            catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание делегата функции, в которой будет работать новый поток
            ThreadStart MethodThread = new ThreadStart(ThreadFunk);
            // Создание объекта потока
            thread = new Thread(MethodThread);
            // Старт потока
            thread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
                thread.Abort();
        }
   
    }
}
