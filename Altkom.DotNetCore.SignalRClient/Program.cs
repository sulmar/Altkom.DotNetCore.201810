using Altkom.DotNetCore.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Altkom.DotNetCore.SignalRClient
{
    // Install-Package Microsoft.AspnetCore.SignalR.Client
    class Program
    {

        private static HubConnection connection;

        static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        static async Task MainAsync(string[] args)
        {
                Console.WriteLine("Hello SignalR Client!");

           

                await SetupHubConnection();

            // connection.On<Product>("Added", p => Console.WriteLine($"Received {p.Name}"));

            Random random = new Random();

            while (true)
            {
                int id = random.Next(100, 1000);

                Product product = new Product
                {
                    Id = id,
                    Name = $"Product {id}",
                    UnitPrice = 100
                };

                await SendProductAsync(product);

                Console.WriteLine($"Send product {id}");

                await Task.Delay(TimeSpan.FromSeconds(3));
            }


            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        // Install-Package Microsoft.AspnetCore.SignalR.Client
        private static async Task SendProductAsync(Product product)
        {
            await connection.SendAsync("AddedAsync", product);
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
