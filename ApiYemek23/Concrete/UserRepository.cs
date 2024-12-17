using ApiYemek23.Abstract;
using ApiYemek23.Entities;
using ApiYemek23.Entities.AppEntities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace ApiYemek23.Concrete
{
    public class UserRepository : IUserRepository
    {                               
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }
        public User CreateUser(User user) {

            user.User_Password = HashPassword(user.User_Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public List<User> GetUser()
        {
            return _context.Users.ToList();
        }
        public async Task<User> AddFavoriteAsync(int User_Id, int Restaurant_Id)
        {
            var user  = await _context.Users
                .FirstOrDefaultAsync(u=> u.User_Id== User_Id);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            if (!user.FavoriteRestaurantIds.Contains(Restaurant_Id)) 
            {
                user.FavoriteRestaurantIds.Add(Restaurant_Id);
                await _context.SaveChangesAsync();
            }
            return user; 
            
        }
        public async Task<User> GetUserById(int id)
        {
            return  await _context.Users.FirstOrDefaultAsync(c=> c.User_Id== id);
        }

        public User GetUserByMail(string mail)
        {
            return _context.Users.FirstOrDefault(c => c.User_Email == mail);
        }

        public async Task<List<int>> GetFavoritesById(int id)
        {
            var user = await _context.Users.
                FirstOrDefaultAsync(c => c.User_Id== id);

            if (user == null)
            {
                throw new KeyNotFoundException("Kullanıcı bulunamadı");
            }
            return user.FavoriteRestaurantIds ?? new List<int>();
        }
        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges(true);
            return user;
        }
        
        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32));
            return Convert.ToBase64String(salt) + "." + hashed; // Salt ile birleştirip döndür
        }
        private bool VerifyPassword(string password, string storedPassword)
        {
            var parts = storedPassword.Split('.');
            if (parts.Length != 2) return false;
            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32));
            return hash == parts[1]; // Hash'leri karşılaştır
        }

    }
}
