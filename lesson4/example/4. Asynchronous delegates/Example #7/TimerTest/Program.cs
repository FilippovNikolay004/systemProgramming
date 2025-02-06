using System;
using System.Threading;

namespace TimerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerMethod /* Делегат TimerCallback, представляющий выполняемый метод.*/,
                                null /* Объект, содержащий информацию, используемую методом ответного вызова */, 
                                0 /* Количество времени до начала использования параметра callback, в миллисекундах. */, 
                                1000 /* Временной интервал между вызовами параметра callback, в миллисекундах. */);

            Console.WriteLine("Основной поток {0} продолжается...", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            t.Dispose();
            Console.ReadKey();
        }

        static void TimerMethod(Object obj)
        {
            Console.WriteLine("Поток {0} : {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
        }
    }
}
