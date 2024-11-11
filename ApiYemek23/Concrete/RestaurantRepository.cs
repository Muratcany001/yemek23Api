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

        Restaurant IRestaurantRepository.GetAllRestaurant()
        {
            throw new NotImplementedException();
        }
    }
}
