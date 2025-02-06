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

        public static void Main()
        {
            Console.WriteLine("Приоритетный {0} ", Thread.CurrentThread.ManagedThreadId);
            MyThreadDelegate d1 = MyThread;
            d1.BeginInvoke(15, 700, 
                ar =>
                    {
                        int result = d1.EndInvoke(ar);
                        Console.WriteLine("Асинхронная операция вернула результат: {0}", result);
                        Console.WriteLine("Метод обратного вызова {0} ", Thread.CurrentThread.ManagedThreadId);
                    }, null);

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
