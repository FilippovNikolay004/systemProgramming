using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


namespace GUID
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public SynchronizationContext uiContext;
        Task[] arraytasks = new Task[15];
        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
        }

        void GeneratorOfNumbers()
        {
            try
            {
                FileStream file2 = new FileStream("../../array.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(file2);
                int range = rnd.Next(1000);
                for (int i = 0; i < 500000000; i++)
                {
                    int n = rnd.Next(range);
                    writer.Write(n);
                }
                writer.Close();
                file2.Close();
                uiContext.Send(d => label1.Text = "Файл с числовыми данными создан!", null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void MaxOfNumbers()
        {
            try
            {
                FileStream file = new FileStream("../../array.dat", FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file);
                int max = 0;
                int[] ar = new int[file.Length / 4];
                for (int i = 0; i < ar.Length; i++)
                {
                    ar[i] = reader.ReadInt32();
                    if (ar[i] > ar[max])
                        max = i;
                    i++;
                }
                reader.Close();
                file.Close();
                uiContext.Send(
                    d => label2.Text = "Максимальный элемент массива чисел " + ar[max].ToString() 
                        + " имеет индекс " + max.ToString(), null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void AverageOfNumbers()
        {
            try
            {
                FileStream file = new FileStream("../../array.dat", FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(file);
                double sum = 0;
                try
                {
                    while (true)
                    {
                        sum += reader.ReadInt32();
                    }
                }
                catch (EndOfStreamException)
                {
                    //Достигнут конец файла
                }
                uiContext.Send(d => label3.Text = "Среднее арифметическое элементов массива: " + sum / (file.Length / 4), null);
                reader.Close();
                file.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /*
        Monitor - предоставляет механизм для синхронизации доступа к объектам.
        Класс Monitor – аналог секции.
        public static void Enter( - обозначает точку входа в секцию (монитор).
	        object obj – Объект, для которого получается блокировка монитора.
        );

        public static void Exit( - выход из секции.
	        object obj – Объект, для которого получается блокировка монитора.
        );
        
        Альтернативный вариант 
        lock(this)
        {
          тело критической секции
        }
        */
        void ThreadFunction1()
        {
            uiContext.Send(d => label1.Text = "Поток пытается войти в критическую секцию!", null);
            Monitor.Enter(this);
            uiContext.Send(d => label1.Text = "Поток вошел в критическую секцию!", null);
            GeneratorOfNumbers();
            Monitor.Exit(this);
        }
        void ThreadFunction2(Task t)
        {
            if (t.Exception == null)
            {
                uiContext.Send(d => label2.Text = "Поток пытается войти в критическую секцию!", null);
                Monitor.Enter(this);
                uiContext.Send(d => label2.Text = "Поток вошел в критическую секцию!", null);
                MaxOfNumbers();
                Monitor.Exit(this);
            }
        }
        void ThreadFunction3(Task t)
        {
            if (t.Exception == null)
            {
                uiContext.Send(d => label3.Text = "Поток пытается войти в критическую секцию!", null);
                Monitor.Enter(this);
                uiContext.Send(d => label3.Text = "Поток вошел в критическую секцию!", null);
                AverageOfNumbers();
                Monitor.Exit(this);
            }
        }

        // пример на критическую секцию
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                arraytasks[0] = Task.Factory.StartNew(ThreadFunction1);
                arraytasks[1] = arraytasks[0].ContinueWith(ThreadFunction2);
                arraytasks[2] = arraytasks[0].ContinueWith(ThreadFunction3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         мьютекс - примитив синхронизации, который также может использоваться в межпроцессорной синхронизации. 
       public Mutex(
             bool initiallyOwned, - Значение true для предоставления вызывающему потоку начального владения мьютексом; в противном случае — false.
             string name - Имя объекта Mutex. Если значение равно null, то у объекта Mutex нет имени.
             out bool createdNew - При возврате из данного метода содержит логическое значение, равное true, 
                      если был создан новый мьютекс; false, если была получена ссылка на существующий мютекс. 
                      Этот параметр передается неинициализированным. 
               )
                
              public virtual bool WaitOne(); - ожидает переход мьютекса в сигнальное состояние. 
              public void ReleaseMutex(); - переводит мьютекс из несигнального в сигнальное состояние.
              public static Mutex OpenExisting(string name); - возвращает ссылку на существующий мьютекс. 
              Если его нет, то появляется WaitHandleCannotBeOpenedException
             * public virtual void Close(); - закрывает дескриптор открытых мьютексов.
         */
        void ThreadFunction4()
        {
            bool CreatedNew;
            // Создаём мьютекс 
            Mutex mutex = new Mutex(false, "DB744E26-72C1-4F2A-8BF8-5C31980953C7", out CreatedNew);
            mutex.WaitOne();
            uiContext.Send(d => label1.Text = "Поток захватил мьютекс!", null);
            GeneratorOfNumbers();
            mutex.ReleaseMutex();
        }
        void ThreadFunction5(Task t)
        {
            if (t.Exception == null)
            {
                bool CreatedNew;
                // Получаем мьютекс
                Mutex mutex = new Mutex(false, "DB744E26-72C1-4F2A-8BF8-5C31980953C7", out CreatedNew);
                // Ожидаем переход мьютекса в сигнальное состояние
                uiContext.Send(d => label2.Text = "Ожидаем переход мьютекса в сигнальное состояние", null);
                mutex.WaitOne();
                uiContext.Send(d => label2.Text = "Мьютекс свободен! Будем искать максимальный элемент.", null);
                MaxOfNumbers();
                //Переводим мьютекс в сигнальное состояние
                mutex.ReleaseMutex();
            }
        }
        void ThreadFunction6(Task t)
        {
            if (t.Exception == null)
            {
                bool CreatedNew;
                // Получаем мьютекс
                Mutex mutex = new Mutex(false, "DB744E26-72C1-4F2A-8BF8-5C31980953C7", out CreatedNew);
                // Ожидаем переход мьютекса в сигнальное состояние
                uiContext.Send(d => label3.Text = "Ожидаем переход мьютекса в сигнальное состояние", null);
                mutex.WaitOne();
                uiContext.Send(d => label3.Text = "Мьютекс свободен! Будет вычислять среднее арифметическое элементов массива.", null);
                AverageOfNumbers();
                //Переводим мьютекс в сигнальное состояние
                mutex.ReleaseMutex();
            }
        }
        // пример на мьютекс
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                arraytasks[3] = Task.Factory.StartNew(ThreadFunction4);
                arraytasks[4] = arraytasks[3].ContinueWith(ThreadFunction5);
                arraytasks[5] = arraytasks[3].ContinueWith(ThreadFunction6);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /*
        Семафор ограничивает число потоков, которые могут одновременно получать доступ к ресурсу или пулу ресурсов. 
         public Semaphore(
	        int initialCount,  - Начальное количество запросов семафора, которое может быть удовлетворено одновременно.
	        int maximumCount,  - Максимальное количество запросов семафора, которое может быть удовлетворено одновременно.
	        string name – имя  - Имя объекта именованного системного семафора.
        );

        public int Release( - Выходит из семафора указанное число раз и возвращает последнее значение счетчика.
	        int releaseCount – Количество требуемых выходов из семафора.
        );

        public virtual bool WaitOne();  ожидает переход семафора в сигнальное состояние
        
        public static Semaphore OpenExisting( - Открытие существующего именованного семафора.
	        string name
        );
        */

        void ThreadAct(Object obj)
        {
            try
            {
                TextBox txt = (TextBox)obj;
                Semaphore sem = Semaphore.OpenExisting("1A9191BF-AA26-46E1-BB85-BDA396BC6469");
                sem.WaitOne();
                int i = 0;
                while (i++ < 500)
                {
                    uiContext.Send(d => txt.Text = i.ToString(), null);
                    System.Threading.Thread.Sleep(10);
                }
                sem.Release();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // пример на семафор
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Semaphore s = new Semaphore(2, 2, "1A9191BF-AA26-46E1-BB85-BDA396BC6469");
                arraytasks[6] = Task.Factory.StartNew(ThreadAct, textBox1);
                arraytasks[7] = Task.Factory.StartNew(ThreadAct, textBox2);
                arraytasks[8] = Task.Factory.StartNew(ThreadAct, textBox3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
        События делятся на ручные и автоматические.
        class ManualResetEvent – ручное событие
        public ManualResetEvent(
	 	        bool initialState – определяет состояние события. true – сигнальное.
        );

        public bool Set(); - Задает сигнальное (свободное) состояние события. При этом 
 					        освобождаются ждущие потоки.

        public bool Reset(); - переводит событие в несигнальное состояние. 

        После вызова Set из-за того, что событие ручное – оно остается в сигнальном состоянии. 
        И любой поток, который проверит событие, будет знать, что оно осталось сигнальным.
        public virtual bool WaitOne(); - используется для ожидания перехода события в сигнальное состояние.
        */
       
        ManualResetEvent e = new ManualResetEvent(false); // событие с ручным сбросом в несигнальном состоянии

        void Thread(Object obj)
        {
            TextBox txt = (TextBox)obj;
            int i = 0;
            e.WaitOne();
            while (i < 500)
            {
                uiContext.Send(d => txt.Text = (++i).ToString(), null);
                System.Threading.Thread.Sleep(10);
            }
            e.Reset(); // переводим событие в несигнальное состояние
        }

        //пример на события
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                arraytasks[9] = Task.Factory.StartNew(Thread, textBox1);
                arraytasks[10] = Task.Factory.StartNew(Thread, textBox2);
                arraytasks[11] = Task.Factory.StartNew(Thread, textBox3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs er)
        {
            e.Set(); // переводим событие в сигнальное состояние и отпускаем все ждущие потоки
        }

        /*
         class  AutoResetEvent  - автоматическое событие.
        Функции и конструктор аналогичен ManualResetEvent.
        Отличие состоит в том, что при вызове Set для автоматического события освобождается только один поток 
        и событие сразу же переходит в несигнальное состояние. 
        */
        AutoResetEvent autoevent = new AutoResetEvent(true); // событие с автоматическим сбросом в несигнальное состояние
        void ThreadAuto(Object obj)
        {
            TextBox txt = (TextBox)obj;
            int i = 0;
            autoevent.WaitOne();
            while (i < 500)
            {
                uiContext.Send(d => txt.Text = (++i).ToString(), null);
                System.Threading.Thread.Sleep(10);
            }
            autoevent.Set();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                arraytasks[12] = Task.Factory.StartNew(ThreadAuto, textBox1);
                arraytasks[13] = Task.Factory.StartNew(ThreadAuto, textBox2);
                arraytasks[14] = Task.Factory.StartNew(ThreadAuto, textBox3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
