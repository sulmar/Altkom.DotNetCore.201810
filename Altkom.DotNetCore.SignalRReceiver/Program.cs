using Altkom.DotNetCore.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Altkom.DotNetCore.SignalRReceiver
{
    // Install-Package Microsoft.AspnetCore.SignalR.Client
    class Program
    {
        private static HubConnection connection;

        static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Hello SignalR Receiver!");

            await SetupHubConnection();

            Console.BackgroundColor = ConsoleColor.Blue;

            connection.On<Product>("Added", p => Console.WriteLine($"Received {p.Name}"));

            Console.ResetColor();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

        private static async Task SetupHubConnection()
        {
            string url = "http://localhost:51138/products";

            connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            await connection.StartAsync();
        }
    }
}
