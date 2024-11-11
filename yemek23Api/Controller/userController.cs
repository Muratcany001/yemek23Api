using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using yemek23Api.Abstract;
using yemek23Api.Entities.appEntities;

namespace yemek23Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    internal class userController : ControllerBase
    {
        private readonly IuserRepository _userRepository;

        public userController(IuserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("createUser")]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            var createdUser = _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(createdUser), new { id = createdUser.User_id }, createdUser);
        }

    }
}
