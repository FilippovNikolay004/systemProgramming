using System;
using System.Threading;
using System.Threading.Tasks;

namespace FactorialAsyncWait
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = DisplayResultAsync();         
            Console.WriteLine("Введите строку: ");
            Console.ReadLine(); 
            t.Wait();
        }

        static async Task DisplayResultAsync()
        {
            int num = 5;
            int result = await Factorial(num);
            Thread.Sleep(5000);
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
                return result;
            });
        }
    }
}
