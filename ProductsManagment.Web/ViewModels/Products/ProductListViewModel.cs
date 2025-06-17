namespace ProductsManagment.Web.ViewModels.Products;

public class ProductListViewModel
{
    public int Id { get; set; }
    [Display(Name = "الإسم")]

    public string Name { get; set; } = null!;
    [Display(Name = "السعر")]

    public decimal Price { get; set; }
    [Display(Name = "تاريخ الانشاء")]
    public DateOnly CreatedOn { get; set; }
    [Display(Name = "اسم مقدم الخدمة ")]

    public string ServiceProviderName { get; set; } = null!;
}
