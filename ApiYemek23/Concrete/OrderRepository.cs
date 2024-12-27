using ApiYemek23.Abstract;
using ApiYemek23.Entities;
using ApiYemek23.Entities.AppEntities;
using Microsoft.EntityFrameworkCore;

namespace ApiYemek23.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }
        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }
        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(c => c.OrderId == id);
            
        }
        public Order UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges(true);
            return order;
        }
        public Order DeleteOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return order;
        }


    }
}
