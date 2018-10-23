using Altkom.DotNetCore.DbServices.Configurations;
using Altkom.DotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.DotNetCore.DbServices
{ 
    // Install-Package Microsoft.Entityrameworkcore
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
           // this.Database.EnsureDeleted();

            // this.Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //    .Property(p => p.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //modelBuilder.Entity<Customer>()
            //   .Property(p => p.LastName)
            //   .HasMaxLength(50)
            //   .IsRequired();

            //// Install_Package Microsoft.EntityFrameworkCore.Relational
            //modelBuilder.Entity<Product>()
            //    .Property(p => p.UnitPrice)
            //    .HasColumnType("decimal(10,2)");

            //modelBuilder.Entity<Customer>()
            //    .Property(p => p.FirstName)
            //    .HasMaxLength(50);


            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
