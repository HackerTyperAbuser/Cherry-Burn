using Users.Api.Dto;
using Users.Api.Entity;

public interface IUserRepository
{
    Task<UserResponseDto?> GetUserByEmailAsync(string email);
    Task<UserResponseDto?> CreateUserAsync(UserCreateDto usersDto);
}