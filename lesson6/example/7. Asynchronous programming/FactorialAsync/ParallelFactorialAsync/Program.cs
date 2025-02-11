using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFactorialAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayResultAsync(5);
            DisplayResultAsync(6);
            DisplayResultAsync(7);
            Console.WriteLine("Введите строку: ");
            Console.ReadLine();
        }

        static async void DisplayResultAsync(int num)
        {
            int result = await Factorial(num);
            Console.WriteLine("\nФакториал числа {0} равен {1}", num, result);
        }

        static Task<int> Factorial(int x)
        {
            return Task.Run(() =>
            {
                int result = 1;
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Thread.Sleep(5000);
                return result;
            });
        }
    }
}
