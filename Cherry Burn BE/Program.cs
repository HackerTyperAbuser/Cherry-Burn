using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using CherryBurn.Api.Database;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "Host=localhost;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword";

if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Connection string could not be built from environment variables.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();


app.Run();
