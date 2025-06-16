using Mapster;
using Microsoft.EntityFrameworkCore;
using ProductsManagment.ApplicationLeyar.DTOs.Products;
using ProductsManagment.ApplicationLeyar.Interfaces;
using ProductsManagment.Core.Entities;
using ProductsManagment.Infrastructure.Data;


namespace ProductsManagment.Infrastructure.Services;
public class ProductServices : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductListDto>> GetAllAsync()
    {
        var products = await _context.Products
            .Include(p => p.ServiceProvider)
            .Where(p => !p.IsDeleted)
            .ToListAsync();

        return products.Adapt<IEnumerable<ProductListDto>>();
    }

    public async Task<EditProductDto?> GetByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.ServiceProvider)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        return product?.Adapt<EditProductDto>();
    }

    public async Task AddAsync(CreateProductDto dto)
    {
        var product = dto.Adapt<Product>();
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EditProductDto dto)
    {
        var product = await _context.Products.FindAsync(dto.Id);
        if (product is null) return;

        dto.Adapt(product); // يحدث الخصائص الموجودة فقط
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is not null)
        {
            product.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ProductListDto>> FilterAsync(
        decimal? minPrice,
        decimal? maxPrice,
        DateOnly? fromDate,
        DateOnly? toDate,
        int? serviceProviderId)
    {
        var query = _context.Products
            .Include(p => p.ServiceProvider)
            .Where(p => !p.IsDeleted)
            .AsQueryable();

        if (minPrice is not null)
            query = query.Where(p => p.Price >= minPrice.Value);

        if (maxPrice is not null)
            query = query.Where(p => p.Price <= maxPrice.Value);

        if (fromDate is not null)
            query = query.Where(p => p.CreatedOn >= fromDate.Value);

        if (toDate is not null)
            query = query.Where(p => p.CreatedOn <= toDate.Value);

        if (serviceProviderId is not null)
            query = query.Where(p => p.ServiceProviderId == serviceProviderId.Value);

        var products = await query.ToListAsync();
        return products.Adapt<IEnumerable<ProductListDto>>();
    }
}
