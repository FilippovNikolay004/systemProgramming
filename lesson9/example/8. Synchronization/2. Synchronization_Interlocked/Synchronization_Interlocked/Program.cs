using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Synchronization_Interlocked
{
    class Program
    {
        static int sharedState = 0;

        static public void Increment()
        {
            for (int i = 0; i < 500000; i++)
            {
                //++sharedState;
                Interlocked.Increment(ref sharedState);
            }
        }

        static public void Decrement()
        {
            for (int i = 0; i < 500000; i++)
            {
                //--sharedState;
                Interlocked.Decrement(ref sharedState);
            }
        }

        static void Main(string[] args)
        {
            Task tsk1 = new Task(Increment);
            Task tsk2 = new Task(Decrement);
            try
            {
                tsk1.Start();
                tsk2.Start();
                Task.WaitAll(tsk1, tsk2);
                Console.WriteLine("Результирующее значение: {0}", sharedState);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                tsk1.Dispose();
                tsk2.Dispose();
            }
        }
    }
}
