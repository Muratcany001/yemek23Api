using ApiYemek23.Abstract;
using ApiYemek23.Entities.AppEntities;
using Microsoft.AspNetCore.Mvc;

namespace ApiYemek23.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            var createdOrder = _orderRepository.GetOrderById(id);
            return Ok(createdOrder);
        }
        [HttpPost("CreateOrtder")]
        public IActionResult CreateOrder(Order order)
        {
            var createdOrder = _orderRepository.AddOrder(order);
            return Ok(createdOrder);
        }
        [HttpPatch]
        public IActionResult UpdateOrder(Order order)
        {
            var updatedOrder = _orderRepository.UpdateOrder(order);
            return Ok(updatedOrder);
        }
        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            var deleteOrder = _orderRepository.DeleteOrderById(id);
            return Ok(deleteOrder);
        }


    }
}
