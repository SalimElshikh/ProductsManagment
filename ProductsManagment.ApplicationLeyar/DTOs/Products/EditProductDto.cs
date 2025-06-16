
namespace ProductsManagment.ApplicationLeyar.DTOs.Products;
public record EditProductDto(
    int Id,
    string Name,
    decimal Price,
    DateOnly CreatedOn,
    int ServiceProviderId
    );