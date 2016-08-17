using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            const int taskCount = 100;
            Task[] tasks = new Task[taskCount];
            for (int i = 0; i != taskCount; i++)
            {
                tasks[i] = new Task(Iterate, i);
            }
            for (int i = 0; i != taskCount; i++)
            {
                tasks[i].Start();
            }
            Task.WaitAll(tasks);
        }

        private static void Iterate(object number)
        {
            const int iterNumber = 1000;
            int num = (int)number;
            for (int i = 1; i <= iterNumber; i++)
            {
                Console.WriteLine("Task #{0} - {1}", num, i);
            }
        }
    }
}
