using Altkom.DotNetCore.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotNetCore.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var products = productsService.Get();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = productsService.Get(id);

            return Ok(product);
        }

       
    }
}
