using CherryBurn.Api.Database;
using Microsoft.EntityFrameworkCore;
using Users.Api.Dto;
using Users.Api.Entity;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(Guid id);
    Task<User> CreateUser(User usersDto);
}

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        User? foundUser = await _context.User.FirstOrDefaultAsync(user => user.Email == email);

        if (foundUser == null)
            return null;

        return foundUser;
    }

    public async Task<User?> GetUserById(Guid id)
    {
        User? foundUser = await _context.User.FirstOrDefaultAsync(user => user.Id == id);

        if (foundUser == null)
            return null;

        return foundUser;
    }

    public async Task<User> CreateUser(User user)
    {
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
}