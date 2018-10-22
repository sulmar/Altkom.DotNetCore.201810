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
}
