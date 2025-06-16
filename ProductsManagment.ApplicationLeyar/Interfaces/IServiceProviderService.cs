using ProductsManagment.ApplicationLeyar.DTOs.ServiceProvider;


namespace ProductsManagment.ApplicationLeyar.Interfaces;
public interface IServiceProviderService
{
    Task<IEnumerable<ServiceProviderListDto>> GetAllAsync();
    Task<EditServiceProviderDto?> GetByIdAsync(int id);
    Task AddAsync(CreateServiceProviderDto dto);
    Task UpdateAsync(EditServiceProviderDto dto);
    Task<bool> DeleteAsync(int id);
}
