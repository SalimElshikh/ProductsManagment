
public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<CreateProductViewModel, Product>.NewConfig()
            .IgnoreNullValues(true)
            .Ignore(dest => dest.ServiceProvider); ;

        TypeAdapterConfig<Product, ProductListViewModel>.NewConfig();

        TypeAdapterConfig<CreateServiceProviderViewModel, ServiceProvider>.NewConfig();

        TypeAdapterConfig<ServiceProvider, ServiceProviderListViewModel>.NewConfig();
    }
}