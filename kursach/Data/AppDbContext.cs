using kursach.Models;
using Microsoft.EntityFrameworkCore;

namespace kursach.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<BaseModel> BaseModels { get; set; }
}