using ApiYemek23.Abstract;
using ApiYemek23.Entities;
using ApiYemek23.Entities.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
        public async Task<Restaurant> GetRestaurantById(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(c => c.Restaurant_Id == id);
        }
        public async Task AddAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);  // Veritabanına ekle
            await _context.SaveChangesAsync();  // Değişiklikleri kaydet
        }
        public Restaurant GetRestaurantByName(string name)
        {
            return _context.Restaurants.FirstOrDefault(c => c.Restaurant_Name == name);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
             _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }
        
    }
}
