using AcceptingOrdersForDeliveryWebApi.Data;
using AcceptingOrdersForDeliveryWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcceptingOrdersForDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext context;

        public OrdersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            order.OrderNumber = GenerateOrderNumber();
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        private string GenerateOrderNumber()
        {
            return "ORD-" + DateTime.Now.ToString("yyyyMMddHHmmss") +"-" + new Random().Next(10,100);
        }
    }
}
