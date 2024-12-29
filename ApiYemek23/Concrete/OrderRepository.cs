using ApiYemek23.Abstract;
using ApiYemek23.Entities;
using ApiYemek23.Entities.AppEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiYemek23.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        // Asenkron metot ile ekleme işlemi
        public async Task<Order> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // Asenkron metot ile bir siparişi id ile alma
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(c => c.OrderId == id);
        }

        // Asenkron metot ile siparişi güncelleme
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // Asenkron metot ile siparişi silme
        public async Task<Order> DeleteOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return null;  // Eğer sipariş bulunamazsa null döndür
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
