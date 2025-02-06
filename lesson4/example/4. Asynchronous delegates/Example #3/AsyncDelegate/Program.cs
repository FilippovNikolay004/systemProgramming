using System;
using System.Threading;

namespace AsyncDelegate
{
    public delegate int MyThreadDelegate(int data, int ms);

    class Program
    {
        public static int MyThread(int data, int ms)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Работает фоновый поток!");
                data++;
                Thread.Sleep(ms);
            }
            Console.WriteLine("Завершает работу фоновый поток!");
            Console.WriteLine("Чтение в потоке {0} закончено", Thread.CurrentThread.ManagedThreadId);
            return data;
        }

        public static void Main()
        {
            MyThreadDelegate d1 = MyThread;
            IAsyncResult ar1 = d1.BeginInvoke(15, 700, null, null);
            Console.WriteLine("Приоритетный поток {0} ", Thread.CurrentThread.ManagedThreadId);
            while (true)
            {
                Console.WriteLine("Работает приоритетный поток!");
                // AsyncWaitHandle возвращает дескриптор WaitHandle, используемый для режима ожидания завершения асинхронной операции
                if (ar1.AsyncWaitHandle.WaitOne(200)) // Блокирует текущий поток до получения сигнала объектом WaitHandle
                {
                    int result = d1.EndInvoke(ar1);
                    Console.WriteLine("Асинхронная операция вернула результат: {0}", result);
                    break;
                }
            }           
            Console.WriteLine("Завершает работу приоритетный поток!"); 
            Console.ReadKey();
        }
    }
}
