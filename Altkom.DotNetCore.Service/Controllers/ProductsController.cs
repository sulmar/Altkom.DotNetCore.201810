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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await productsService.GetAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await productsService.GetAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            await productsService.AddAsync(product);

            // zła praktyka
            // return Created($"http://localhost:5000/api/products/{product.Id}", product);

            return CreatedAtRoute(new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await productsService.RemoveAsync(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await productsService.UpdateAsync(product);

            return Ok();
        }


        [HttpHead("{id}")]
        public ActionResult Head(int id)
        {
            var product = productsService.Get(id);

            if (product != null)
                return Ok();
            else
                return NotFound();
        }






    }
}
