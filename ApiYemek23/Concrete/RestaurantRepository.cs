using ApiYemek23.Abstract;
using ApiYemek23.Entities;
using ApiYemek23.Entities.AppEntities;

namespace ApiYemek23.Concrete
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly Context _context;
        public RestaurantRepository(Context context)
        {
            _context = context;
        }

        public List<Restaurant> GetAllRestaurant()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetRestaurantByName(string name)
        {
            return _context.Restaurants.FirstOrDefault(c => c.Restaurant_Name == name);
        }

        Restaurant IRestaurantRepository.GetAllRestaurant()
        {
            throw new NotImplementedException();
        }
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
             _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }
        
    }
}
