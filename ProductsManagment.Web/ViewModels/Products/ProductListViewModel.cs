namespace ProductsManagment.Web.ViewModels.Products;

public class ProductListViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public DateOnly CreatedOn { get; set; }

    public string ServiceProviderName { get; set; } = null!;
}
