using ApiYemek23.Abstract;
using ApiYemek23.Entities.AppEntities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace ApiYemek23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(Register), user);
        }
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginModel loginModel)
        {
            var existingUser = _userRepository.GetUserByMail(loginModel.mail);
            if (existingUser == null || !VerifyPassword(loginModel.password, existingUser.User_Password))
            {
                return Unauthorized("Kullanıcı adı veya şifre yanlış.");
            }
            return Ok("Giriş başarılı!");
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
        


    }
}
