using System;
using System.Threading;
using System.Threading.Tasks;

class Program {
    static bool CreatedNew;
    static Mutex mutex = new Mutex(false, "78CB0A33-67AF-40CD-B215-B739409A5F3A", out CreatedNew);
    static int[] dataArray = new int[10];

    static Random r = new Random();

    static async Task Main(string[] args) {
        for (int i = 0; i < dataArray.Length; i++) {
            dataArray[i] += r.Next(1, 10);
        }

        Console.WriteLine("Изначальный массив: " + string.Join(", ", dataArray));

        Task task1 = Task.Run(() => ModifyArray());
        Task task2 = Task.Run(() => FindMaxValue());

        await Task.WhenAll(task1, task2);
    }

    static void ModifyArray() {
        mutex.WaitOne();

        for (int i = 0; i < dataArray.Length; i++) {
            dataArray[i] += r.Next(1, 10);
        }

        mutex.ReleaseMutex();
        Console.WriteLine("Массив после модификации: " + string.Join(", ", dataArray));
    }

    static void FindMaxValue() {
        mutex.WaitOne();

        int maxValue = int.MinValue;
        foreach (var num in dataArray) {
            if (num > maxValue) 
                maxValue = num;
        }

        mutex.ReleaseMutex();
        Console.WriteLine("Максимальное значение в массиве: " + maxValue);
    }
}
