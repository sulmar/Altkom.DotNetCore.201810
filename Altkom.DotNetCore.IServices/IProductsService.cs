using Altkom.DotNetCore.Models;
using System;

namespace Altkom.DotNetCore.IServices
{
    //public interface IProductsService
    //{
    //    IList<Product> Get();
    //    Product Get(int id);
    //}

    public interface IProductsService : IEntitiesService<Product>
    {

    }

    public interface ICustomersService : IEntitiesService<Customer>
    {
    }

}
