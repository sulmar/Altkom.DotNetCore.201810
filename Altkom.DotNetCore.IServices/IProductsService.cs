using Altkom.DotNetCore.Models;
using System;
using System.Collections.Generic;

namespace Altkom.DotNetCore.IServices
{
    public interface IProductsService
    {
        IList<Product> Get();
        Product Get(int id);
    }
}
