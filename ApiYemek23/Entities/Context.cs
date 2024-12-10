using ApiYemek23.Entities.AppEntities;
using Microsoft.EntityFrameworkCore;

namespace ApiYemek23.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
}