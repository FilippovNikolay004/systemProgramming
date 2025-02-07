using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_WhenAll
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
            int num1 = 5;
            int num2 = 6;
            int num3 = 7;
            Task<int> t1 = Factorial(num1);
            Task<int> t2 = Factorial(num2);
            Task<int> t3 = Factorial(num3);

            await Task.WhenAll( t1, t2, t3 );

            Console.WriteLine("\nФакториал числа {0} равен {1}", num1, t1.Result);
            Console.WriteLine("\nФакториал числа {0} равен {1}", num2, t2.Result);
            Console.WriteLine("\nФакториал числа {0} равен {1}", num3, t3.Result);
        }

        static Task<int> Factorial(int x)
        {
            return Task.Run(() =>
            {
                int result = 1;
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                    Thread.Sleep(1000);
                }               
                return result;
            });
        }
    }
}
