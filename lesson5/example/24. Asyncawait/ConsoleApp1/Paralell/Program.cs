using System;
using System.Threading.Tasks;

namespace HelloApp
{
    class Program
    {
        static void Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {n} равен {result}");
        }
        // определение асинхронного метода
        // мы можем запустить все задачи параллельно и через метод Task.WhenAll отследить их завершение. Вначале запускаются три задачи. Затем Task.WhenAll создает новую задачу, которая будет автоматически выполнена после выполнения всех предоставленных задач, то есть задач t1, t2, t3. А с помощью оператора await ожидаем ее завершения.
        //В итоге все три задачи теперь будут запускаться параллельно, однако вызывающий метод FactorialAsync благодаря оператору await все равно будет ожидать, пока они все не завершатся.

        static async void FactorialAsync()
        {
            Task t1 = Task.Run(() => Factorial(4));
            Task t2 = Task.Run(() => Factorial(3));
            Task t3 = Task.Run(() => Factorial(5));
            await Task.WhenAll(new[] { t1, t2, t3 });
        }
        static void Main(string[] args)
        {
            FactorialAsync();
            Console.Read();
        }
    }
}