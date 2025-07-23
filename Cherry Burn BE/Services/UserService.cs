using Users.Api.Dto;
using Users.Api.Entity;

public interface IUserService
{
    public Task<List<UserResponseDto>> GetAllUsersAsync();
    public Task<UserResponseDto> RegisterUserAsync(UserCreateDto user);
    public Task<UserResponseDto?> GetUserByIdAsync(Guid id);
    public Task<UserResponseDto> UpdateUserAsync(UserCreateDto user, Guid id);
    // public Task<UserResponseDto> DeleteUserAsync(Guid id);

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

    public async Task<List<UserResponseDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsers();

        return users.Select(user => MapToUserResponseDto(user)).ToList();
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

    public async Task<UserResponseDto> UpdateUserAsync(UserCreateDto user, Guid id)
    {
        var existingUser = await _userRepository.GetUserById(id);
        if (existingUser == null)
            throw new InvalidOperationException("User not found");

        if (!string.IsNullOrWhiteSpace(user.Username))
        {
            existingUser.Username = user.Username;
        }

        if (!string.IsNullOrWhiteSpace(user.Email))
        {
            existingUser.Email = user.Email;
        }

        if (!string.IsNullOrWhiteSpace(user.Description))
        {
            existingUser.Description = user.Description;
        }

        var updatedUser = await _userRepository.UpdateUser(existingUser);

        return MapToUserResponseDto(updatedUser);
    
    }

}