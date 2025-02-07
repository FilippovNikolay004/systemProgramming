using System;
using System.Threading;

namespace FactorialSync
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayResultSync();
            Console.WriteLine("Введите строку: ");
            Console.ReadLine();
        }

        static void DisplayResultSync()
        {
            int num = 5;
            int result = Factorial(num);
            Thread.Sleep(5000);
            Console.WriteLine("\nФакториал числа {0} равен {1}", num, result);
        }

        static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
