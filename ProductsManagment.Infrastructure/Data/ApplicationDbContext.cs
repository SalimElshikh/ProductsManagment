using Microsoft.EntityFrameworkCore;
using ProductsManagment.Core.Entities;

namespace ProductsManagment.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ServiceProvider> Providers { get; set; }

}
