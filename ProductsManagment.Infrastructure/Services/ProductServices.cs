using Microsoft.EntityFrameworkCore;
using ProductsManagment.ApplicationLeyar.Interfaces;
using ProductsManagment.Core.Entities;
using ProductsManagment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagment.Infrastructure.Services;
public class ProductServices : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.ServiceProvider)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.ServiceProvider)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    //public async Task<IEnumerable<Product>> FilterAsync(decimal? minPrice, decimal? maxPrice, DateOnly? fromDate, DateOnly? toDate, int? serviceProviderId)
    //{
    //    var query = _context.Products.Include(p => p.ServiceProvider).AsQueryable();

    //    if (minPrice.HasValue)
    //        query = query.Where(p => p.Price >= minPrice.Value);

    //    if (maxPrice.HasValue)
    //        query = query.Where(p => p.Price <= maxPrice.Value);

    //    if (fromDate.HasValue)
    //        query = query.Where(p => p.CreatedOn >= fromDate.Value);

    //    if (toDate.HasValue)
    //        query = query.Where(p => p.CreatedOn <= toDate.Value);

    //    if (serviceProviderId.HasValue)
    //        query = query.Where(p => p.Id == serviceProviderId.Value);

    //    return await query.ToListAsync();
    //}
    // More Effictive 
    public async Task<IEnumerable<Product>> FilterAsync(decimal? minPrice, decimal? maxPrice, DateOnly? fromDate, DateOnly? toDate, int? serviceProviderId)
    {
        IQueryable<Product> query = _context.Products.Include(p => p.ServiceProvider);

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

        return await query.ToListAsync();
    }

}

