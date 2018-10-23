using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Altkom.DotNetCore.DbServices
{

    public class DbCustomersService : DbEntitiesService<Customer>, ICustomersService
    {
        public DbCustomersService(MyContext context) : base(context)
        {
        }

        public override IList<Customer> Get()
        {
            string sql = "SELECT * from dbo.Customers";

            return context.Customers.FromSql(sql).ToList();

            return context.Customers.FromSql("exec uspGetCustomers").ToList();
        }

       

        public List<Customer> GetCustomersByCity(string city)
        {
            string sql = "SELECT * from dbo.Customers WHERE city = @city";

            SqlParameter cityParameter = new SqlParameter("@city", city);

            // api/customers?city=Warsaw OR 1=1

            // WHERE City = 'Warsaw OR 1=1'

            return context.Customers.FromSql(sql, cityParameter).ToList();

        }
    }
}
