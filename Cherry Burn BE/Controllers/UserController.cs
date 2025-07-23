using Microsoft.AspNetCore.Mvc;
using Users.Api.Dto;
using Users.Api.Entity;

namespace Users.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserCreateDto user)
        {
            try
            {
                var createdUser = await _userRepository.CreateUserAsync(user);

                if (createdUser == null)
                {
                    return BadRequest(new { error = "User could not be created" });
                }

                var responseUser = new UserResponseDto
                {
                    Username = createdUser.Username,
                    Email = createdUser.Email,
                };

                return Ok(createdUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                Console.WriteLine($"Received email: {email}");
                var foundUser = await _userRepository.GetUserByEmailAsync(email);

                if (foundUser == null)
                {
                    return BadRequest(new
                    {
                        error = "No user with that email"
                    });
                }

                return Ok(foundUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }
    }

}
