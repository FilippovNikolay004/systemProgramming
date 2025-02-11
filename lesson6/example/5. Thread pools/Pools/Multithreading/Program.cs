using System;
using System.Threading;

public class Multithreading
{
    class Program
    {
        static void Main()
        {
            int nWorkerThreads;
            int nCompletionPortThreads;
            // ThreadPool.GetAvailableThreads возвращает разницу между максимальным числом потоков пула, 
            // возвращаемым методом GetMaxThreads, и количеством активных в данный момент потоков.
            ThreadPool.GetAvailableThreads(out nWorkerThreads, out nCompletionPortThreads);
            Console.WriteLine("Количество рабочих потоков: {0}, Количество потоков завершения ввода/вывода: {1}",
               nWorkerThreads, nCompletionPortThreads);
            for (int i = 0; i < 20; i++)
            {
                // QueueUserWorkItem помещает рабочий элемент (метод JobForAThread) в очередь пула потоков на выполнение. 
                // Метод JobForAThread выполняется, когда становится доступным поток из пула потоков.
                // QueueUserWorkItem сразу возвращает управление приложению
                ThreadPool.QueueUserWorkItem(JobForAThread, 100); 
            }

            Console.ReadKey();
        }

        static void JobForAThread(object state)
        {
            int nWorkerThreads;
            int nCompletionPortThreads;
            // ThreadPool.GetAvailableThreads возвращает разницу между максимальным числом потоков пула, 
            // возвращаемым методом GetMaxThreads, и количеством активных в данный момент потоков.
            ThreadPool.GetAvailableThreads(out nWorkerThreads, out nCompletionPortThreads);
            Console.WriteLine("Количество рабочих потоков: {0}, Количество потоков завершения ввода/вывода: {1}",
                nWorkerThreads, nCompletionPortThreads);
            int sleep = (int) state;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Работает цикл, выполняемый внутри потока {0}",
                   Thread.CurrentThread.ManagedThreadId /*Возвращает уникальный идентификатор для текущего управляемого потока.*/);
                Thread.Sleep(sleep);
            }
            Console.WriteLine("Завершает работу метод, выполняемый внутри потока {0}",
                              Thread.CurrentThread.ManagedThreadId);
        }
    }
}
