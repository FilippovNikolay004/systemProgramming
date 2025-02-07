using System;
using System.Threading;
using System.Threading.Tasks;

namespace FactorialAsyncReturnVoid
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayResultAsync();
            Console.WriteLine("Введите строку: ");
            Console.ReadLine();
        }

        static async void DisplayResultAsync()
        {
            await Factorial(5);
        }

        static Task Factorial(int x)
        {
            return Task.Run(() =>
            {
                int result = 1;
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Thread.Sleep(5000);
                Console.WriteLine("\nФакториал числа {0} равен {1}", x, result);
            });
        }
    }
}
