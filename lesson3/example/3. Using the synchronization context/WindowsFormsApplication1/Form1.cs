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
        public SynchronizationContext uiContext;
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();
            // Получим контекст синхронизации для текущего потока 
            uiContext = SynchronizationContext.Current;
        }

        private void ThreadFunk()
        {
            uiContext.Send(d => progressBar1.Minimum = 0, null);
            uiContext.Send(d => progressBar1.Maximum = 230, null);
            uiContext.Send(d => progressBar1.Value = 0, null);
            uiContext.Send(d => button1.Enabled = false, null); 

            for (int i = 0; i < 230; i++)
            {
                Thread.Sleep(50); 
                // uiContext.Send отправляет синхронное сообщение в контекст синхронизации
                // SendOrPostCallback - делегат указывает метод, вызываемый при отправке сообщения в контекст синхронизации. 
                uiContext.Send(d => progressBar1.Value = (int)d /* Вызываемый делегат SendOrPostCallback */,
                    i /* Объект, переданный делегату */); // добавляем в список имя клиента
            }
            uiContext.Send(d => button1.Enabled = true, null); 
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
