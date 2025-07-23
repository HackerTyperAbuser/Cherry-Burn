using CherryBurn.Api.Database;
using Microsoft.EntityFrameworkCore;
using Users.Api.Dto;
using Users.Api.Entity;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(Guid id);
    Task<User> CreateUser(User usersDto);
    Task<User> UpdateUser(User usersDto);
    Task<bool> DeleteUser(Guid id);
}

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.User.ToListAsync();
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

    public async Task<User> UpdateUser(User user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await GetUserById(id);
        if (user == null)
        {
            return false;
        }

        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}