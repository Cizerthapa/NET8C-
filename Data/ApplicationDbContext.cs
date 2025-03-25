using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }
    
    // DbSet properties for your entities
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
}