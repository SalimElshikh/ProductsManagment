

namespace ProductsManagment.Web.ViewModels.Products;

public class CreateProductViewModel 
{
    [Display(Name = "الإسم")]

    public string Name { get; set; } = null!;
    [Display(Name = "السعر")]

    public decimal Price { get; set; }
    [Display(Name = "تاريخ الانشاء")]
    public DateOnly CreatedOn { get; set; }

    [Display(Name = "مقدم الخدمة")]
    public int ServiceProviderId { get; set; }

    public IEnumerable<SelectListItem>? Providers { get; set; }
}
