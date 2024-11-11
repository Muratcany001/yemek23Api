using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Entities.appEntities;

namespace test.Entities
{
    public class Context
    {
        public DbSet<User> Companies { get; set; }
        public DbSet<Restaurant> Products { get; set; }
    }
}