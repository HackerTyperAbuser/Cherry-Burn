using System.ComponentModel.DataAnnotations;

namespace Users.Api.Dto
{
    public class UserResponseDto
    {
        public string Username { get; set; }

        public string Email { get; set; }
        public string? Description { get; set; }
    }

}
