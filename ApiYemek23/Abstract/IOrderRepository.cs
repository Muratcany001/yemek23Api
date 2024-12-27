using ApiYemek23.Entities.AppEntities;

namespace ApiYemek23.Abstract
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
        Order GetOrderById(int id);
        Order UpdateOrder(Order order);
        Order DeleteOrderById(int id);
    }
}
