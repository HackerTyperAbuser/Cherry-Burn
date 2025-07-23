using Users.Api.Dto;
using Users.Api.Entity;

public interface IUserService
{
    public Task<UserResponseDto> RegisterUserAsync(UserCreateDto user);
    public Task<UserResponseDto?> GetUserByIdAsync(Guid id);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private static UserResponseDto MapToUserResponseDto(User user)
    {
        return new UserResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Description = user.Description
        };
    }

    public async Task<UserResponseDto> RegisterUserAsync(UserCreateDto user)
    {
        if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Username))
            throw new ArgumentException("Username, Email and password are required");

        var existingUser = await _userRepository.GetUserByEmail(user.Email);

        if (existingUser != null)
            throw new InvalidOperationException("User with this email already exists");

        var newUser = new User
        {
            Username = user.Username,
            Email = user.Email,
            Description = user.Description,
            Password = user.Password,
        };

        var createdUser = await _userRepository.CreateUser(newUser);

        return MapToUserResponseDto(createdUser);
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(Guid id)
    {
        var foundUser = await _userRepository.GetUserById(id);
        if (foundUser == null)
        {
            return null;
        }

        return MapToUserResponseDto(foundUser);
    }

}