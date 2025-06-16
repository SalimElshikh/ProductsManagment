using Mapster;
using Microsoft.EntityFrameworkCore;
using ProductsManagment.ApplicationLeyar.DTOs.ServiceProvider;

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

    public async Task<IEnumerable<ServiceProviderListDto>> GetAllAsync()
    {
        var providers = await _context.Providers
            .Include(sp => sp.Products)
            .ToListAsync();

        return providers.Adapt<List<ServiceProviderListDto>>();
    }

    public async Task<EditServiceProviderDto?> GetByIdAsync(int id)
    {
        var provider = await _context.Providers
            .Include(sp => sp.Products)
            .FirstOrDefaultAsync(sp => sp.Id == id);

        return provider?.Adapt<EditServiceProviderDto>();
    }

    public async Task AddAsync(CreateServiceProviderDto dto)
    {
        var provider = dto.Adapt<ServiceProvider>();
        _context.Providers.Add(provider);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EditServiceProviderDto dto)
    {
        var provider = await _context.Providers.FindAsync(dto.Id);
        if (provider is null)
            throw new Exception("مقدم الخدمة غير موجود");

        // تحديث البيانات
        dto.Adapt(provider);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var provider = await _context.Providers
            .Include(p => p.Products)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (provider == null)
            return false;

        if (provider.Products.Any())
            throw new InvalidOperationException("لا يمكن حذف مقدم الخدمة لوجود منتجات مرتبطة به.");

        _context.Providers.Remove(provider);
        await _context.SaveChangesAsync();
        return true;
    }
}
