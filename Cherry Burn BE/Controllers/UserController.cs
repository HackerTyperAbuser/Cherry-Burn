using Microsoft.AspNetCore.Mvc;
using Users.Api.Dto;
using Users.Api.Entity;

namespace Users.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserCreateDto user)
        {
            try
            {
                var responseUser = await _userService.RegisterUserAsync(user);
                return Ok(responseUser);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> FindUserId(Guid id)
        {
            try
            {
                var foundUser = await _userService.GetUserByIdAsync(id);

                if (foundUser == null)
                {
                    return BadRequest(new
                    {
                        error = "User not found"
                    });
                }

                return Ok(foundUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPost]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserCreateDto user, Guid id)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(user, id);
                return Ok(new
                {
                    message = "User have been updated!",
                    data  = updatedUser ,
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message }); 
            }
        }
    }

}
