using Microsoft.AspNetCore.Mvc;
using Users.Api.Dto;

namespace Athentication.Controller
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto user)
        {
            try
            {
                var responseUser = await _userService.LoginUserAsync(user);
                if (responseUser == null)
                {
                    return Unauthorized(new { error = "Invalid Credentials" });
                }
                return Ok(responseUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }
    }
}