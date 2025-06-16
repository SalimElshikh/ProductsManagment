using Microsoft.EntityFrameworkCore;
using ProductsManagment.ApplicationLeyar.Interfaces;
using ProductsManagment.Core.Entities;
using ProductsManagment.Infrastructure.Data;

namespace ProductsManagment.Infrastructure.Services;
public class ServiceProviderServices : IServiceProviderService
{

    private readonly ApplicationDbContext _context;

    public ServiceProviderServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ServiceProvider>> GetAllAsync()
    {
        return await _context.Providers
            .Include(sp => sp.Products)
            .ToListAsync();
    }

    public async Task<ServiceProvider?> GetByIdAsync(int id)
    {
        return await _context.Providers
            .Include(sp => sp.Products)
            .FirstOrDefaultAsync(sp => sp.Id == id);
    }

    public async Task AddAsync(ServiceProvider provider)
    {
        _context.Providers.Add(provider);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ServiceProvider provider)
    {
        _context.Providers.Update(provider);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var provider = await _context.Providers.FindAsync(id);
        if (provider != null)
        {
            _context.Providers.Remove(provider);
            await _context.SaveChangesAsync();
        }
    }
}
