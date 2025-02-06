using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace CSharpApplication.Threads
{
    class ProgressBarDance : Form
    {
        // Количество потоков
        const int ThreadsCount = 3;

        // Индикаторы
        ProgressBar[] pr = new ProgressBar[ThreadsCount];
        // Флажки для запуска/остановки потоков
        CheckBox[] bRun = new CheckBox[ThreadsCount];
        // Флажки для приостановки/возобновления потоков
        CheckBox[] bSuspend = new CheckBox[ThreadsCount];
        // Флажки для хранения состояния потоков
        bool[] ThreadsRun = new bool[ThreadsCount];
        // Массив делегатов (ссылаются на функцию - точку входа в поток)
        ThreadStart[] threadsstart;
        // Массив потоков
        Thread[] threads;

        static void Main()
        {
            // Запуск приложения
            Application.Run(new ProgressBarDance());
        }

        ProgressBarDance()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.ClientSize = new Size(350, 310);

            //Icon ico =  Icon.ExtractAssociatedIcon(@"C:\WINDOWS\system32\notepad.exe");
            //this.Icon = ico;

            this.Icon = new Icon(GetType(), "Ico.ico");
            this.Text = "Работа с потоками";

            // Инициализация элементов управления
            for (int i = 0; i < ThreadsCount; i++)
            {
                pr[i] = new ProgressBar();
                pr[i].Parent = this;
                pr[i].Location = new Point(10, 10 + i * 100);
                pr[i].ClientSize = new Size(this.ClientRectangle.Width - 20, 50);
                // Минимальное значение индикатора
                pr[i].Minimum = 0;
                // Максимальное значение индикатора
                pr[i].Maximum = 100;

                bRun[i] = new CheckBox();
                bRun[i].Parent = this;
                bRun[i].Location = new Point(10, 10 + i * 100 + 65);
                bRun[i].ClientSize = new Size(150, 20);
                bRun[i].Text = string.Format("Запустить {0}-й поток", i + 1);

                bSuspend[i] = new CheckBox();
                bSuspend[i].Parent = this;
                bSuspend[i].Location = new Point(170, 10 + i * 100 + 65);
                bSuspend[i].ClientSize = new Size(200, 20);
                bSuspend[i].Text = string.Format("Приостановить {0}-й поток", i + 1);
                bSuspend[i].Enabled = false;

                // Обработчик щелчков по CheckBox'ам
                bRun[i].Click += new EventHandler(OnCheckBoxClick);
                bSuspend[i].Click += new EventHandler(OnCheckBoxClick);
            }
        }

        // public delegate void ThreadStart(); - тип потоковой функции.
        // Потоковая функция
        private void WorkThread()
        {
            Random r = new Random();


            // public static Thread CurrentThread {get;} - свойство, содержащее объект текущего потока. 
            // Получаем индекс потока, который записан в его имени
            int index = Convert.ToInt32(Thread.CurrentThread.Name);

            // Пока флаг состояния потока утановлен
            while (ThreadsRun[index])
            {
                // Выбираем случайное значение для позиции индикатора
                pr[index].Value = r.Next(100);
                // Усыпляем поток на случайный интервал времени
                Thread.Sleep(r.Next(50, 500));
            }
        }

        // Обработчик щелчка по CheckBox'ам
        private void OnCheckBoxClick(object sender, EventArgs e)
        {
            // Если щелкаем впервые
            if (threadsstart == null)
            {
                // public delegate void ThreadStart(); - тип потоковой функции.
                // Инициализируем массив делегатов
                threadsstart = new ThreadStart[]
                    {
                        new ThreadStart(WorkThread),
                        new ThreadStart(WorkThread),
                        new ThreadStart(WorkThread)
                    };

                threads = new Thread[ThreadsCount];

                // Инициализируем потоки
                for (int i = 0; i < ThreadsCount; i++)
                {
                    // public Thread(ThreadStart start); - конструктор класса, 
                    // получает в качестве параметра делегат, который ссылается на функцию - точку входа в поток 

                    // Создаем поток
                    threads[i] = new Thread(threadsstart[i]);
                    // Даем ему имя (равное индексу)
                    threads[i].Name = string.Format("{0}", i);
                    // Указываем, что поток не запущен
                    ThreadsRun[i] = false;
                }
            }

            // Определяем активный элемент на форме (CheckBox)
            CheckBox check = (CheckBox)this.ActiveControl; // CheckBox check = (CheckBox)sender;

            // Ищем его индекс в массиве флажков запуска потоков
            int index = Array.IndexOf(bRun, check);

            // Нажат CheckBox из этого массива
            if (index != -1)
            {
                // Если галочка установлена
                if (check.Checked)
                {
                    // Указываем, что поток запущен
                    ThreadsRun[index] = true;
                    bRun[index].Text = string.Format("Остановить {0}-й поток", index + 1);
                    bSuspend[index].Enabled = true;
                    // Запуск потока
                    threads[index].Start();
                }
                else // Если галочка снята
                {
                    // Указываем, что поток заканчивает свою работу
                    ThreadsRun[index] = false;

                    // Если поток находится в приостановленном состоянии
                    if (bSuspend[index].Checked)
                    {
                        // public void Resume(); - возобновляет приостановленный поток 
                        threads[index].Resume();

                        //public void Abort(); - вызывает исключение типа ThreadAbortException и останавливает поток. 
                        // Данное исключение можно перехватить в потоке и, с помощью функции public static void ResetAbort(); отменить завершение потока. 
                        threads[index].Abort();
                        bSuspend[index].Checked = false;
                    }
                    else
                    {
                        // Можно прервать поток принудительно, но при этом все
                        // несохраненные данные будут утеряны
                        // threads[index].Abort();

                        // public void Join();
                        // public bool Join(int);
                        // public bool Join(TimeSpan);
                        // Блокирует вызывающий поток (на определенный или неопределенный промежуток времени), 
                        // пока поток, для которого функция вызывается, не завершится.

                        // Ожидаем завершения потока
                        threads[index].Join();
                    }

                    // Снова инициализируем данный поток 
                    threads[index] = new Thread(threadsstart[index]);
                    threads[index].Name = string.Format("{0}", index);
                    pr[index].Value = 0;
                    bRun[index].Text = string.Format("Запустить {0}-й поток", index + 1);
                    bSuspend[index].Text = string.Format("Приостановить {0}-й поток", index + 1);
                    bSuspend[index].Enabled = false;
                }
            }
            else
            {
                // Ищем индекс в массиве флажков приостановки потоков
                int sindex = Array.IndexOf(bSuspend, check);

                // Если галочка установлена
                if (check.Checked)
                {
                    // public void Suspend(); - приостанавливает поток 
                    threads[sindex].Suspend();
                    bSuspend[sindex].Text = string.Format("Возобновить {0}-й поток", sindex + 1);
                }
                else
                {
                    // public void Resume(); - возобновляет приостановленный поток 
                    threads[sindex].Resume();
                    bSuspend[sindex].Text = string.Format("Приостановить {0}-й поток", sindex + 1);
                }
            }
        }


        /*
        Поток является либо фоновым, либо основным (по умолчанию).
        Они отличаются по принципу действия. 
        Если работает фоновый поток и происходит закрытие приложения, поток также выгружается из оперативной памяти. 
        Основной же поток при закрытии приложения останется в оперативной памяти.
        Если все основные потоки, принадлежащие процессу, завершились, общеязыковая среда выполнения завершает процесс, 
        вызывая метод Abort для всех фоновых потоков, которые еще действуют.
        */

        // Обработчик закрытия формы
        protected override void OnClosed(EventArgs e)
        {
            // Перебираем массив потоков
            for (int i = 0; i < ThreadsCount; i++)
            {
                /*******************************************************/
                /* Первый способ остановки запущенных потоков
                /*******************************************************/
                // Если поток запущен
                if (ThreadsRun[i])
                {
                    // Сбрасываем флаг состояния потока (остановка потока)
                    ThreadsRun[i] = false;
                    // Если поток был приостановлен
                    if (bSuspend[i].Checked)
                        // Возобновляем работу потока
                        threads[i].Resume();
                }

                /******************************************************/
                /* Второй способ остановки запущенных потоков
                /******************************************************/
                /*
                if(bSuspend[i].Checked == true)
                     Возобновляем работу потока
                    threads[i].Resume();
                 "Грубая" остановка потока
                threads[i].Abort();
                */

                /******************************************************/
                /* Третий способ остановки запущенных потоков
                /******************************************************/

                // Перевод потоков в фоновый режим
                // threads[i].IsBackground = true;
            }
            base.OnClosed(e);
        }
    }
}