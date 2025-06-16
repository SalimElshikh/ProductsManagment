using Microsoft.EntityFrameworkCore;
using ProductsManagment.Core.Entities;

namespace ProductsManagment.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ServiceProvider> Providers { get; set; }

}
