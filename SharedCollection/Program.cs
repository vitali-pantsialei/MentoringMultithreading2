using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedCollection
{
    class Program
    {
        private static AutoResetEvent event1 = new AutoResetEvent(false);
        private static AutoResetEvent event2 = new AutoResetEvent(true);

        static void Main(string[] args)
        {
            const int count = 10;
            int[] collection = new int[count];
            Task task1 = new Task(SetCollection, collection);
            Task task2 = new Task(PrintCollection, collection);
            task1.Start();
            task2.Start();
            task1.Wait();
            task2.Wait();
        }

        private static void SetCollection(object array)
        {
            int[] arr = (int[])array;
            Random rand = new Random();
            for (int i = 0; i != arr.Length; i++)
            {
                event2.WaitOne();
                arr[i] = rand.Next() % 10;
                event1.Set();
            }
        }

        private static void PrintCollection(object array)
        {
            int[] arr = (int[])array;
            for (int i = 0; i!=arr.Length; i++)
            {
                event1.WaitOne();
                Console.WriteLine(arr[i]);
                event2.Set();
            }
        }
    }
}
