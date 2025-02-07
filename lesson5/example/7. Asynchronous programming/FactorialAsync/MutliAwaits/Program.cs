using System;
using System.Threading;
using System.Threading.Tasks;

namespace MutliAwaits
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
            int num = 5;
            int result = await Factorial(num);
            Console.WriteLine("\nФакториал числа {0} равен {1}", num, result);

            num = 6;
            result = await Factorial(num);            
            Console.WriteLine("\nФакториал числа {0} равен {1}", num, result);

            num = 7;
            result = await Factorial(num);
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
