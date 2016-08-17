using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsRandomMagic
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            int[] arr = new int[count];
            Task task1 = new Task(TenRandomNumbers, arr);
            Task task2 = new Task(MultiplyIt, arr);
            Task task3 = new Task(SortArrayByAsc, arr);
            Task task4 = new Task(AvrgValue, arr);
            task1.Start();
            task1.Wait();
            task2.Start();
            task2.Wait();
            task3.Start();
            task3.Wait();
            task4.Start();
            task4.Wait();
        }

        private static void TenRandomNumbers(object array)
        {
            int[] arr = (int[])array;
            Random rand = new Random();
            Console.WriteLine("Generated array:");
            for (int i = 0; i != arr.Length; i++)
            {
                arr[i] = rand.Next() % 10;
                if (i == arr.Length - 1)
                    Console.WriteLine(arr[i]);
                else
                    Console.Write(arr[i] + ", ");
            }
        }

        private static void MultiplyIt(object array)
        {
            int[] arr = (int[])array;
            int randNumber = new Random().Next() % 10;
            Console.WriteLine("Array multiplied on {0}:", randNumber);
            for (int i = 0; i != arr.Length; i++)
            {
                arr[i] *= randNumber;
                if (i == arr.Length - 1)
                    Console.WriteLine(arr[i]);
                else
                    Console.Write(arr[i] + ", ");
            }
        }

        private static void SortArrayByAsc(object array)
        {
            int[] arr = (int[])array;
            Array.Sort(arr);
            Console.WriteLine("Sorted array:");
            for (int i = 0; i != arr.Length; i++)
            {
                if (i == arr.Length - 1)
                    Console.WriteLine(arr[i]);
                else
                    Console.Write(arr[i] + ", ");
            }
        }

        private static void AvrgValue(object array)
        {
            int[] arr = (int[])array;
            double avrg = 0;
            for (int i = 0; i != arr.Length; i++)
            {
                avrg += arr[i];
            }
            avrg /= arr.Length;
            Console.WriteLine("Average value: {0}", avrg);
        }
    }
}
