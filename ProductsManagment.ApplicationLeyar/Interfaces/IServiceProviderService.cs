using ProductsManagment.Core.Entities;

namespace ProductsManagment.ApplicationLeyar.Interfaces;
public interface IServiceProviderService
{
    Task<IEnumerable<ServiceProvider>> GetAllAsync();
    Task<ServiceProvider?> GetByIdAsync(int id);
    Task AddAsync(ServiceProvider provider);
    Task UpdateAsync(ServiceProvider provider);
    Task DeleteAsync(int id);
}