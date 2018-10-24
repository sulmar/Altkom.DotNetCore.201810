using Altkom.DotNetCore.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotNetCore.HubService.Hubs
{
    public class ProductsHub : Hub
    {
        public Task AddedAsync(Product product)
        {
            return this.Clients.All.SendAsync("Added", product);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
