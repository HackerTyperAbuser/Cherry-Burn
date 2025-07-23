using Microsoft.EntityFrameworkCore;
using Users.Api.Entity;

namespace CherryBurn.Api.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }
}