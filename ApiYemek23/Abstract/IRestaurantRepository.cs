using ApiYemek23.Entities.AppEntities;

namespace ApiYemek23.Abstract
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetAllRestaurant();
        Restaurant GetRestaurantByName(string name);
        Restaurant AddRestaurant(Restaurant restaurant);
        Task<Restaurant> GetRestaurantById(int id);
        Task AddAsync(Restaurant restaurant);
        Restaurant DeleteRestaurant(int id);
    }
}
