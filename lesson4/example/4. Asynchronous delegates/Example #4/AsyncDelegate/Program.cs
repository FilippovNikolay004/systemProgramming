using System;
using System.Threading;

namespace AsyncDelegate
{
    public delegate int MyThreadDelegate(int data, int ms);

    class Program
    {
        public static int MyThread(int data, int ms)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Работает фоновый поток!");
                data++;
                Thread.Sleep(ms);
            }
            Console.WriteLine("Завершает работу фоновый поток!");
            Console.WriteLine("Чтение в потоке {0} закончено", Thread.CurrentThread.ManagedThreadId);
            return data;
        }

        public static void MyThreadCompleted(IAsyncResult ar)
        {
            MyThreadDelegate d1 = ar.AsyncState as MyThreadDelegate;
            int result = d1.EndInvoke(ar);
            Console.WriteLine("Асинхронная операция вернула результат: {0}", result);
            Console.WriteLine("Метод обратного вызова {0} ", Thread.CurrentThread.ManagedThreadId);
        }

        public static void Main()
        {
            MyThreadDelegate d1 = MyThread;
            // AsyncCallback ссылается на метод, который должен вызываться при завершении соответствующей асинхронной операции
            AsyncCallback ac = MyThreadCompleted;
            d1.BeginInvoke(15, 700, ac, d1);
            Console.WriteLine("Приоритетный поток {0} ", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Работает приоритетный поток!");
                Thread.Sleep(200);
            }           
            Console.WriteLine("Приоритетный поток ожидает ввод...!"); 
            Console.ReadKey();
        }
    }
}
