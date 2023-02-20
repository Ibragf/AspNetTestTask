using AspNetTestTask.Db;
using AspNetTestTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetTestTask.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDb _appDb;
        public OrdersController(AppDb appDb)
        {
            _appDb = appDb;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = new List<Order>();
            foreach (var key in _appDb.Orders.Keys)
            {
                orders.Add(_appDb.Orders[key]);
            }

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrdersById([FromRoute] string id)
        {
            var order = _appDb.Orders[id];

            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            order.Id = Guid.NewGuid().ToString();
            order.Amount = 0;

            foreach (var id in order.ProductsId)
            {
                var product = _appDb.Products[id];
                if(product != null)
                {
                    order.Amount += product.Price;
                }
                else
                {
                    ModelState.AddModelError("errors", $"Product with id - {id} not found");
                    return NotFound(ModelState);
                }
            }

            _appDb.Orders.Add(order.Id, order);

            var response = new {order.Id, order.Amount};
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder([FromRoute] string id)
        {
            _appDb.Orders.Remove(id);

            return Ok();
        }
    }
}
