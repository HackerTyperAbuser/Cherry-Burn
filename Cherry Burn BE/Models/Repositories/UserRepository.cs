using CherryBurn.Api.Database;
using Microsoft.EntityFrameworkCore;
using Users.Api.Dto;
using Users.Api.Entity;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserResponseDto?> GetUserByEmailAsync(string email)
    {
        User? foundUser = await _context.User.FirstOrDefaultAsync(user => user.Email == email);

        if (foundUser == null)
            return null;

        var returnUser = new UserResponseDto
        {
            Username = foundUser.Username,
            Email = foundUser.Email,
            Description = foundUser.Description
        };

        return returnUser;
    }

    public async Task<UserResponseDto?> CreateUserAsync(UserCreateDto user)
    {
        if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            throw new ArgumentException("Email and password are required");

        var existingUser = await GetUserByEmailAsync(user.Email);

        if (existingUser != null)
            throw new InvalidOperationException("User with this email already exists");

        var newUser = new User
        {
            Username = user.Username,
            Email = user.Email,
            Description = user.Description,
            Password = user.Password,
        };

        await _context.User.AddAsync(newUser);
        await _context.SaveChangesAsync();

        var responseUser = new UserResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Description = user.Description,
        };

        return responseUser;
    }
}