using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SlideShow
{
    public partial class Form1 : Form
    {
        Thread th1=null, th2=null, th3=null,th4=null, th5=null;
        public Form1()
        {
            InitializeComponent();
            Width = 190 * 2;
            Height = 220*2;
        }
  
        // Структура, передаваемая в потоковую функцию
        struct Options
        {
            public int delay;
            public bool direction;
            public int start;
        }

        /*
         Поток является либо фоновым, либо основным (по умолчанию).
        Они отличаются по принципу действия. 
        Если работает фоновый поток и происходит закрытие приложения, поток также выгружается из памяти. 
        Основной же поток при закрытии приложения останется в память.
        Если все основные потоки, принадлежащие процессу, завершились, общеязыковая среда выполнения завершает процесс, 
        вызывая метод Abort для всех фоновых потоков, которые еще действуют.
        
        public Thread(
		ThreadStart start – делегат, который указывает на потоковую функцию.
        );
        public delegate void ThreadStart();

        public Thread(ParameterizedThreadStart start - делегат, который ссылается на потоковую функцию с 
 							параметром. 
        );

        public delegate void ParameterizedThreadStart(
 		object obj – объект, который будет передаваться в потоковую функцию.
        );  
        */
       
        void Slide(object param)
        {
            Options op = (Options)param;
            int i;
            try
            {
                if (op.direction)
                    i = 1;
                else
                    i = 7;

                while(true)
                {
                     string path = "../../IMG/" + i.ToString() + ".jpg";
                     Image img;
                     img = Image.FromFile(path);
                     Graphics gr = Graphics.FromHwnd(Handle);
                     gr.DrawImage(img, new Rectangle(op.start, 0, img.Width, img.Height));
                     Thread.Sleep(op.delay);
                     
                    if (op.direction)
                         i++;
                    else
                        i--;

                     if (i > 7 && op.direction)
                         i = 1;

                     if (i < 1 && !op.direction)
                         i = 7;
                }            
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message);
            }
        }
        private void thread1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            th1 = new Thread(new ParameterizedThreadStart(Slide));
            Options op = new Options();
            op.delay = 1500;
            op.direction = true;
            op.start = 0;
            th1.IsBackground = true;
            th1.Start(op);
            thread1ToolStripMenuItem.Enabled = false;
        }
        private void thread2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            th2 = new Thread(new ParameterizedThreadStart(Slide));
            Options op = new Options();
            op.delay = 2000;
            op.direction = false;
            op.start = 186;
            th2.IsBackground = true;
            th2.Start(op);
            thread2ToolStripMenuItem.Enabled = false;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
             public void Abort(); - порождает завершение потока. При этом генерируется исключение 
 					ThreadAbortException. Оно порождается внутри того потока, для которого был вызван Abort
             public void Join() - Блокирует вызывающий поток до завершения потока
            
            public void Suspend(); - приостанавливает поток. Считается устаревшим. Вместо него рекомендуется использовать примитивы синхронизации.
            public void Resume(); - восстанавливет исполнение приостановленного потока.
            */
            if (th3 != null)
                th3.Abort(); // основной поток
            if (th4 != null)
                th4.Join(); // основной поток
            if (th5 != null)
            {
                if(th5.ThreadState == ThreadState.Suspended)
                    th5.Resume();
                th5.Abort(); // основной поток
            }              
        }

        void SlideThread()
        {
            /*
            public static Thread CurrentThread {get;} – возвращает ссылку на текущий поток.
            */
            try
            {
                Thread t = Thread.CurrentThread;
                if (t.Name == "Slowly")
                {
                    int i = 1;
                    while (i <= 7)
                    {
                        string path = "../../IMG/" + i.ToString() + ".jpg";
                        Image img;
                        img = Image.FromFile(path);
                        Graphics gr = Graphics.FromHwnd(Handle);
                        gr.DrawImage(img, new Rectangle(0, 220, img.Width, img.Height));
                        Thread.Sleep(3000);
                        i++;
                    }
                }
                else if (t.Name == "Quickly")
                {
                    int i = 1;
                    while (i <= 7)
                    {
                        string path = "../../IMG/" + i.ToString() + ".jpg";
                        Image img;
                        img = Image.FromFile(path);
                        Graphics gr = Graphics.FromHwnd(Handle);
                        gr.DrawImage(img, new Rectangle(186, 220, img.Width, img.Height));
                        Thread.Sleep(500);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void thread3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            th3 = new Thread(new ThreadStart(SlideThread));
            th3.Name = "Slowly";
            th3.Start();
            thread3ToolStripMenuItem.Enabled = false;
        }

        private void thread4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            th4 = new Thread(new ThreadStart(SlideThread));
            th4.Name = "Quickly";
            th4.Start();
            thread4ToolStripMenuItem.Enabled = false;
        }
      
        void MyMethod()
        {
            try
            {
                while (true)
                {
                    DateTime t1 = DateTime.Now;
                    Text = t1.ToString();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
       
        private void StartThreadMenuItem_Click(object sender, EventArgs e)
        {
            th5 = new Thread(new ThreadStart(MyMethod));
            th5.Start();
            StartThreadMenuItem.Enabled = false;
            SuspendThreadMenuItem.Enabled = true;
        }

        private void SuspendThreadMenuItem_Click(object sender, EventArgs e)
        {
            if (th5 != null)
                th5.Suspend();
            SuspendThreadMenuItem.Enabled = false;
            ResumeThreadMenuItem.Enabled = true;
        }

        private void ResumeThreadMenuItem_Click(object sender, EventArgs e)
        {
            if (th5 != null && th5.ThreadState == ThreadState.Suspended)
                th5.Resume();
            ResumeThreadMenuItem.Enabled = false;
            SuspendThreadMenuItem.Enabled = true;
        }

    }
}