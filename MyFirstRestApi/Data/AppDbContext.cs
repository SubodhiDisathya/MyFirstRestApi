using Microsoft.EntityFrameworkCore;
using MyFirstRestApi.Data.Models;

namespace TodoApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<TestUser> TestUsers { get; set; } = null!;
}