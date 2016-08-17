using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContinuationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 -- Simple exampe\n2 -- Parent failed\n3 -- Parent reused after failing\n4 -- Outside thread pool");
            string num = "";
            num = Console.ReadLine();
            switch(num)
            {
                case "1":
                    RunCase1();
                    break;
                case "2":
                    RunCase2();
                    break;
                case "3":
                    RunCase3();
                    break;
                case "4":
                    RunCase4();
                    break;
            }
        }

        private static void RunCase1()
        {
            Task<string> task1 = new Task<string>(() => "Hello world", TaskCreationOptions.DenyChildAttach);
            Task task2 = task1.ContinueWith((answ) => { Console.WriteLine("No need result"); });
            task1.Start();
            task2.Wait();
        }

        private static void RunCase2()
        {
            Task<string> task1 = new Task<string>(() => { throw new Exception("This is error"); });
            Task task2 = task1.ContinueWith((answ) => { Console.WriteLine("I don't care"); }, TaskContinuationOptions.OnlyOnFaulted);
            task1.Start();
            task2.Wait();
        }

        private static void RunCase3()
        {
            Task<string> task1 = new Task<string>(() => { throw new Exception("This is error"); });
            Task task2 = task1.ContinueWith((answ) => { Console.WriteLine("I don't care"); }, TaskContinuationOptions.ExecuteSynchronously);
            task1.Start();
            task2.Wait();
        }

        private static void RunCase4()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task<string> task1 = new Task<string>(() => { while (true);  }, token);
            Task task2 = task1.ContinueWith((answ) => { Console.WriteLine("I don't care"); }, TaskContinuationOptions.OnlyOnCanceled);
            task1.Start();
            tokenSource.Cancel();
            task2.Wait();
        }
    }
}
