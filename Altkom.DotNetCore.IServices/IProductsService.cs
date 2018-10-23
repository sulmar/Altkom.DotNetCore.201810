using Altkom.DotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotNetCore.IServices
{
    public interface IProductsServiceMarcin
    {
        IList<Product> Get();
        Product Get(int id);

        IQueryable<Product> GetByTest();
    }

    public interface IProductsService : IEntitiesService<Product>
    {

    }

    public interface ICustomersService : IEntitiesService<Customer>
    {
    }

}
