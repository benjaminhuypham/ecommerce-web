using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Repository;
using eCommerce.Models; 

namespace eCommerce.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IDataRepository<Product> _dataRep; 

        public ProductController(IDataRepository<Product> dataRep)
        {
            _dataRep = dataRep; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _dataRep.GetAll();
            return Ok(products); 
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Product product = _dataRep.Get(id); 
            if (product == null)
            {
                return NotFound("The product couldn't be found"); 
            }
            return Ok(product); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Employee is null"); 
            }

            _dataRep.Add(product);
            return CreatedAtRoute(
                "Get",
                new { Id = product.Id } ,
                product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null"); 
            }

            Product updatedProduct = _dataRep.Get(id); 
            if (updatedProduct == null)
            {
                return NotFound("The product couldn't be found"); 
            }

            _dataRep.Update(updatedProduct, product);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _dataRep.Get(id); 
            if (product == null)
            {
                return NotFound("Product couldn't be found"); 
            }

            _dataRep.Delete(product);
            return NoContent(); 
        }
    }
}
