using Altkom.DotNetCore.FakeGenerator;
using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotNetCore.FakeServices
{
    
    public class FakeProductsService : IProductsService
    {
        private IList<Product> products;

        private Generator generator = new Generator();

        // snippet: ctor
        public FakeProductsService()
        {
            products = generator.GetProducts(100);
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public IList<Product> Get() => products;

        public Product Get(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            Product product = Get(id);
            products.Remove(product);
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
