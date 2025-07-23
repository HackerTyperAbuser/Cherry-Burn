using System.ComponentModel.DataAnnotations;

namespace Users.Api.Dto
{
    public class UserCreateDto
    {
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Description { get; set; }

        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string? Password { get; set; }
    }
}