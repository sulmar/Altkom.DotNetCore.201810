using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Altkom.DotNetCore.DbServices
{
    public class DbProductsService : DbEntitiesService<Product>, IProductsService
    {
        public DbProductsService(MyContext context) : base(context)
        {
        }
    }
}
