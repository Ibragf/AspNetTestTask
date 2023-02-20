using AspNetTestTask.Db;
using AspNetTestTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetTestTask.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDb _appDb;
        public ProductsController(AppDb appDb)
        {
            _appDb = appDb;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<Product>();
            foreach (var key in _appDb.Products.Keys)
            {
                products.Add(_appDb.Products[key]);
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductsById([FromRoute] string id)
        {
            var product = _appDb.Products[id];

            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Id = Guid.NewGuid().ToString();

            _appDb.Products.Add(product.Id, product);

            return Ok(product.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] string id)
        {
            _appDb.Products.Remove(id);

            return Ok();
        }
    }
}
