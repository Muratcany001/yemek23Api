using ApiYemek23.Abstract;
using ApiYemek23.Entities;
using ApiYemek23.Entities.AppEntities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace ApiYemek23.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        public UserController(IUserRepository userRepository, IRestaurantRepository restaurantRepository)
        {
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet("GetUserList")]
        public ActionResult<IEnumerable  <User>> GetAllUser()
        {
            var users = _userRepository.GetUser();
            return Ok(users);

        }
        [HttpPost("Register")]
        public ActionResult<User> Register(User user)
        {

            if (_userRepository.GetUserByMail(user.User_Email) != null)
            {
                return Conflict("Bu mail adresine kayıtlı bir kullanıcı zaten var.");
            }
            _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(Register), user);
        }
        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] LoginModel loginModel)
        {
            var existingUser = _userRepository.GetUserByMail(loginModel.mail);
            if (existingUser == null || !VerifyPassword(loginModel.password, existingUser.User_Password))
            {
                return Unauthorized("Kullanıcı adı veya şifre yanlış.");
            }
            var token = GenerateToken(existingUser);
            return Ok(new {token = token});
        }
        [HttpPost("GetUserById/{User_Id}")]
        public async Task<IActionResult> GetUserById(int id) {
            var Users = await _userRepository.GetUserById(id);
            return Ok(Users);
        }
        [HttpGet("GetFavoritesById/{User_Id}")]
        public async Task<IActionResult> GetFavoritesById(int id)
        {
            try
            {
                var Restaurant_Ids = await _userRepository.GetFavoritesById(id);
                if (Restaurant_Ids == null || Restaurant_Ids.Count == 0)
                {
                    return BadRequest("Favorilerde restoran bulunamadı");
                }
                var Restaurants = new List<Restaurant>();
                foreach (var Restaurant_Id in Restaurant_Ids)
                {
                    var Restaurant = await _restaurantRepository.GetRestaurantById(Restaurant_Id);
                    if (Restaurant != null)
                    {
                        Restaurants.Add(Restaurant);
                    }
                }

                if (Restaurants.Count == 0)
                {
                    return NotFound("Favorilerde restoran bulunamadı");
                }

                return Ok(Restaurants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddFavorite")]
        public async Task<IActionResult> AddFavorite([FromBody] AddFavoriteRequest request)
        {
            try
            {
                var user = await _userRepository.AddFavoriteAsync(request.User_Id, request.Restaurant_Id);

                return Ok(new
                {
                    Message = "Restorant favorilere eklendi",
                    Favorites = user.FavoriteRestaurantIds
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
            return hash == parts[1]; 
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
            return Convert.ToBase64String(salt) + "." + hashed;
        }
        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
