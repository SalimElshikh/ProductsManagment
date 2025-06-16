using System;


namespace ProductsManagment.ApplicationLeyar.DTOs.Products;
public record CreateProductDto(
    int Id,
    string Name,
    decimal Price,
    DateOnly CreatedOn,
    int ServiceProviderId

    );


