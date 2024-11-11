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
    internal class userRepository : IuserRepository
    {
        private readonly Context _context;
        public userRepository(Context context)
        {
            _context = context;
        }
        public User CreateUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
