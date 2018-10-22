using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotNetCore.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/klienci")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService customersService;

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(customersService.Get());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(customersService.Get(id));

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            customersService.Add(customer);

            return Ok();
        }
    }
}
