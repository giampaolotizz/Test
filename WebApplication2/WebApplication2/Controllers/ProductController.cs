using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository;
using WebApplication1.Models;
using System.Transactions;
using Consul;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
                  var finalResults = _productRepository.GetProducts().ToList();
                    return Ok(finalResults);
      
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductByID(id);
            return new OkObjectResult(product);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
          _productRepository.InsertProduct(product);

            return new OkResult();
        }

        // PUT: api/Product
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            Product p = _productRepository.GetProductByID(product.Id);

            if (p != null) {
                p.Name = product.Name;
                p.Price = product.Price;
                p.Description = product.Description;
                p.CategoryId = product.CategoryId;
                _productRepository.UpdateProduct(p);
            }

            return new OkResult();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
    
}
