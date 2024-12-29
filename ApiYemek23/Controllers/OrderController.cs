using ApiYemek23.Abstract;
using ApiYemek23.Entities.AppEntities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiYemek23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var createdOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (createdOrder == null)
            {
                return NotFound(new { Message = "Order not found" });
            }
            return Ok(createdOrder);
        }

        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdOrder = await _orderRepository.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpPatch("orders")]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedOrder = await _orderRepository.UpdateOrderAsync(order);
            return Ok(updatedOrder);
        }

        [HttpDelete("orders/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var deleteOrder = await _orderRepository.DeleteOrderByIdAsync(id);
            if (deleteOrder == null)
            {
                return NotFound(new { Message = "Order not found" });
            }
            return Ok(deleteOrder);
        }
    }
}
