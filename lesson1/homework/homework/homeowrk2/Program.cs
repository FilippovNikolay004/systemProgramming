using System;
using System.Diagnostics;
using System.Threading;

// TASK #3
/*
    Реализуйте консольное игровое приложение "успел, не успел", 
    где будет проверяться скорость реакции пользователя.
    Программа должна подать сигнал пользователю в виде текста, 
    и пользователю должен будет нажать кнопку на клавиатуре, 
    после нажатия пользователь должен увидеть, 
    сколько миллисекунд ему потребовалось, чтобы нажать кнопку.
*/

class ReactionTest {
    static Stopwatch stopwatch = new Stopwatch();
    static Random random = new Random();

    static void Main() {
        int delay = random.Next(2000, 5000); // Случайная задержка от 2 до 5 секунд
        Console.WriteLine("Приготовьтесь...");

        // Таймер будет срабатывать через delay миллисекунд
        TimerCallback timercallback = new TimerCallback(TimerCallback);
        Timer timer = new Timer(timercallback, null, delay, Timeout.Infinite);

        // Ожидаем нажатие клавиши
        Console.ReadKey(true);
        stopwatch.Stop();

        // Останавливаем таймер после нажатия клавиши
        timer.Dispose();

        Console.WriteLine($"Время реакции: {stopwatch.ElapsedMilliseconds} мс");
    }

    static void TimerCallback(object state) {
        // Запускаем секундомер, когда таймер срабатывает
        Console.WriteLine("НАЖМИТЕ КНОПКУ! (любую)");
        stopwatch.Start();
    }
}