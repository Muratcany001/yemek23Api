using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yemek23Api.Abstract;
using yemek23Api.Entities;
using yemek23Api.Entities.appEntities;

namespace yemek23Api.Concrete
{
    internal class restaurantRepository : IrestaurantRepository
    {
        private readonly Context _context;

        public restaurantRepository(Context context)
        {
            _context = context;
        }
    }
}
