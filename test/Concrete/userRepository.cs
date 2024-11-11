using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Abstract;
using test.Entities;
using test.Entities.appEntities;

namespace test.Concrete
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