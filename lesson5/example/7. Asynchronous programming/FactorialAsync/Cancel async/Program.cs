using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cancel_async
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayResultAsync(7);
            Console.Read();
        }

        static async void DisplayResultAsync(int num)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                Task t1 = Factorial(num, cts.Token);
                Task t2 = Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    cts.Cancel(); // отмена асинхронной операции
                });
                await Task.WhenAll(t1, t2);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cts.Dispose();
            }
        }

        static async Task Factorial(int x, CancellationToken token)
        {
            await Task.Run(() =>
            {
                int result = 1;
                for (int i = 1; i <= x; i++)
                {
                    token.ThrowIfCancellationRequested();
                    result *= i;
                    Console.WriteLine("Факториал числа {0} равен {1}", i, result);
                    Thread.Sleep(500);
                }
            }, token);
        }
    }
}
