using Ecommerce.Models.EntityModels;
using Ecommerce.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrdersControllers>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersControllers>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersControllers>
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            var isSuccess = _orderService.Add(order);

            if (isSuccess)
            {
                return Ok(order);
            }

            return BadRequest("Order could not be saved!");
        }

        // PUT api/<OrdersControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
