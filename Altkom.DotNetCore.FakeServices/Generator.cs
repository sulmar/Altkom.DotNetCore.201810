using Altkom.DotNetCore.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Altkom.DotNetCore.FakeServices
{
    class Generator
    {
        public Faker<Product> FakerProducts => new Faker<Product>()
            .StrictMode(true)
            .RuleFor(p => p.Id, f => f.IndexFaker)
            .RuleFor(p => p.Name, f => f.Commerce.Product())
            .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(1, 100))
            .FinishWith( (f, product) => Debug.WriteLine($"Product {product.Name} was generated."));

        public IList<Product> GetProducts(int count) => FakerProducts.Generate(count);
    }

    class CustomerGenerator
    {
        public Faker<Customer> FakerCustomers => new Faker<Customer>()
            .StrictMode(true)
            .RuleFor(p => p.Id, f => f.IndexFaker)
            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
            .RuleFor(p => p.LastName, f => f.Person.LastName)
            .FinishWith((f, c) => Debug.WriteLine($"Customer {c.FirstName} {c.LastName} was generated."));


        public IList<Customer> GetCustomers(int count) => FakerCustomers.Generate(count);

    }
}
