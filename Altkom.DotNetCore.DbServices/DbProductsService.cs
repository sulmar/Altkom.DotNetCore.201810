using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Altkom.DotNetCore.DbServices
{
    public class DbProductsService : IProductsService
    {
        private readonly MyContext context;

        public DbProductsService(MyContext context)
        {
            this.context = context;
        }

        public void Add(Product entity)
        {
            Debug.WriteLine(context.Entry(entity).State);

            context.Products.Add(entity);

            Debug.WriteLine(context.Entry(entity).State);

            entity.UnitPrice = 99;

            Debug.WriteLine(context.Entry(entity).State);

            context.SaveChanges();

            Debug.WriteLine(context.Entry(entity).State);

            entity.UnitPrice = 88;

            Debug.WriteLine(context.Entry(entity).State);

            context.SaveChanges();

            Debug.WriteLine(context.Entry(entity).State);
        }

        public IList<Product> Get()
        {
            return context.Products.ToList();
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public void Remove(int id)
        {
            var product = new Product { Id = id };

            Debug.WriteLine(context.Entry(product).State);

            context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            // context.Products.Remove(product);

            Debug.WriteLine(context.Entry(product).State);

            context.SaveChanges();
            Debug.WriteLine(context.Entry(product).State);
        }

        public void Update(Product entity)
        {
            context.Products.Update(entity);
            context.SaveChanges();
        }
    }
}
