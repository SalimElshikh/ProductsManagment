using ProductsManagment.ApplicationLeyar.DTOs.Products;
using ProductsManagment.Core.Entities;

namespace ProductsManagment.ApplicationLeyar.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductListDto>> GetAllAsync();
    Task<EditProductDto?> GetByIdAsync(int id);
    Task AddAsync(CreateProductDto dto);
    Task UpdateAsync(EditProductDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<ProductListDto>> FilterAsync(
        decimal? minPrice, decimal? maxPrice, DateOnly? fromDate, DateOnly? toDate, int? serviceProviderId);
}
