using System;
using System.Threading;

namespace TimerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerCallback timercallback = new TimerCallback(TimerTick);
            Timer timer = new Timer(timercallback);
            timer.Change(500,1000); // Запуск таймера.

            Console.ReadKey(); // Задержка.
        }

        static void TimerTick(object a)
        {
            Console.WriteLine("Hello in timer");
        }
    }
}
