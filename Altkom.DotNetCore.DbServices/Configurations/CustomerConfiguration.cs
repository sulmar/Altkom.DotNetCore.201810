using Altkom.DotNetCore.FakeGenerator;
using Altkom.DotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.DotNetCore.DbServices.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50);

            builder
               .Property(p => p.LastName)
               .HasMaxLength(50)
               .IsRequired();

            CustomerGenerator generator = new CustomerGenerator();

            // var customers = generator.GetCustomers(100);

            //builder
            //    .HasData(customers);

        }
    }
}
