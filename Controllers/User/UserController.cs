using Microsoft.AspNetCore.Mvc;
using TestProduct.Models;
using TestProduct.Repositories;

namespace TestProduct.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAllUser")]
        public ActionResult<IEnumerable<UserModel>> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok (users);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserModel userModel)
        {
             _userRepository.CreateUser(userModel);
            return Ok();
        }
    }
}
