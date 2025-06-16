

namespace ProductsManagment.ApplicationLeyar.DTOs.Products;
public record ProductListDto(
    int Id,
    string Name,
    decimal Price,
    DateOnly CreatedOn,
    string ServiceProviderName
    );
