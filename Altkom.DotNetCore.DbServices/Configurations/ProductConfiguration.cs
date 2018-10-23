using Altkom.DotNetCore.FakeGenerator;
using Altkom.DotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.DotNetCore.DbServices.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
              .Property(p => p.Name)
              .IsRequired()
              .HasMaxLength(100);

            builder
              .Property(p => p.UnitPrice)
              .HasColumnType("decimal(10,2)");

            // Generator generator = new Generator();
            //var products = generator.GetProducts(100);

            //builder.HasData(
            //    new Product { Id = 1, Name = "Test 1", UnitPrice = 1.0m }
            //    );
        }
    }
}
