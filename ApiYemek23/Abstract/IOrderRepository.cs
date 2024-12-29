using ApiYemek23.Entities.AppEntities;
using System.Threading.Tasks;

namespace ApiYemek23.Abstract
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteOrderByIdAsync(int id);
    }
}
