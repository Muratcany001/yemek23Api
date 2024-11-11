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
        // Eğer model ayarlarını burada yapmak istiyorsanız
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // alarınızı buraya ekleyebilirsiniz
        }
    }
}