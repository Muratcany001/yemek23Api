using ApiYemek23.Abstract;
using ApiYemek23.Concrete;
using ApiYemek23.Entities;

namespace ApiYemek23.Services
{
    public class RepositoryService
    {
        private readonly Context _context;

        public RepositoryService(Context context)
        {
            _context = context;
        }
        public IRestaurantRepository GetRestaurantRepository()
        {
            return new RestaurantRepository(_context);
        }
    }
}
