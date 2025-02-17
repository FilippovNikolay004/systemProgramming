using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronization_Lock
{
    public class SharedState
    {
        public int State { get; set; }
    }

    public class Job
    {
        SharedState sharedState;
        public Job(SharedState sharedState)
        {
            this.sharedState = sharedState;
        }
        public void DoTheJob()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (sharedState)
                {
                    ++sharedState.State;
                }
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numTasks = 20;
            var state = new SharedState();
            var tasks = new Task[numTasks];
            try
            {
                for (int i = 0; i < numTasks; i++)
                {
                    tasks[i] = new Task(new Job(state).DoTheJob);
                    tasks[i].Start();
                }

                for (int i = 0; i < numTasks; i++)
                {
                    tasks[i].Wait();
                }

                Console.WriteLine("Суммарное значение: {0}", state.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                for (int i = 0; i < numTasks; i++)
                {
                    tasks[i].Dispose();
                }
            }
        }
    }
}
