using Altkom.DotNetCore.FakeGenerator;
using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using System;
using System.Linq;
using System.Text;

namespace Altkom.DotNetCore.FakeServices
{
    public class FakeCustomersService : FakeEntitiesService<Customer>, ICustomersService 
    {
        CustomerGenerator generator = new CustomerGenerator();

        public FakeCustomersService()
        {
            entities = generator.GetCustomers(50);
        }

    }
}
