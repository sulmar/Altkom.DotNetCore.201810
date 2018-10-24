using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.DotNetCore._201810.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // snippet: cw
            Console.WriteLine("Hello World!");

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} UI");

            // SyncTest();

           //  TaskTest();

            Task.Run(()=> AsyncAwaitTest());


            //for (int i = 0; i < 100; i++)
            //{
            //    Task.Run(() => Calculate());
            //}

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }



        private static void TaskTest()
        {
            Task<decimal> task = CalculateAsync();

            task
                .ContinueWith(t => Console.WriteLine(t.Result));
        }

        private static async Task AsyncTestAsync()
        {
            decimal result = await CalculateAsync();
            Console.WriteLine(result);
        }


        private static async Task AsyncAwaitTest()
        {
            decimal result = await CalculateAsync();



            await SendAsync(result);

            Console.WriteLine("thank you");
        }


        private static void SyncTest()
        {
            decimal result = Calculate();
            Console.WriteLine(result);
        }

        static Task<decimal> CalculateAsync()
        {
            return Task.Run(() => Calculate());
        }

        static Task SendAsync(decimal amount)
        {
            return Task.Run(() => Send(amount));
        }

        static void Send(decimal amount)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sending...");

            Thread.Sleep(TimeSpan.FromSeconds(10));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sent.");
        }

        static decimal Calculate()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculating...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculated.");

            return 100;

        }
    }
}
