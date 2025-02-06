using System;
using System.Threading;

namespace AsyncDelegate
{
    /*
     Асинхронность позволяет вынести отдельные задачи из основного потока в специальные асинхронные методы или блоки кода
    */
    public delegate void MyThreadDelegate(string name, int data, int ms);

    class Program
    {
        public static void MyThread(string name, int data, int ms)
        {
            for (int i = 0; i < data; i++)
            {
                Console.WriteLine("Работает " + name + " поток!");
                Thread.Sleep(ms);
            }
            Console.WriteLine("Завершает работу " + name + " поток!");
            Console.WriteLine("Чтение в потоке {0} закончено", Thread.CurrentThread.ManagedThreadId);
        }

        public static void Main()
        {
            // Как известно, делегаты могут вызываться как с помощью метода Invoke, 
            // так и в асинхронном режиме с помощью пары методов BeginInvoke/EndInvoke. 
            MyThreadDelegate d1 = MyThread;
            IAsyncResult ar1 = d1.BeginInvoke("первый", 15, 100, null, null);
            // После вызова метода MyThread через делегат d1.BeginInvoke() работа метода Main не приостанавливается. 
            // А выполнение метода MyThread происходит в другом потоке.
            MyThreadDelegate d2 = MyThread;
            IAsyncResult ar2 = d2.BeginInvoke("второй", 10, 200, null, null);
            MyThreadDelegate d3 = MyThread;
            IAsyncResult ar3 = d3.BeginInvoke("третий", 5, 400, null, null);
            Console.WriteLine("Приоритетный поток {0} ", Thread.CurrentThread.ManagedThreadId);
            while (!ar1.IsCompleted || !ar2.IsCompleted || !ar3.IsCompleted)
            {
                Console.WriteLine("Работает приоритетный поток!");
                Thread.Sleep(300);
            }
            // Для очистки внутренних ресурсов CLR, выделяемых под асинхронную операцию
            d1.EndInvoke(ar1);
            d2.EndInvoke(ar2);
            d3.EndInvoke(ar3);
            Console.WriteLine("Завершает работу приоритетный поток!"); 
            Console.ReadKey();
        }
    }
}
