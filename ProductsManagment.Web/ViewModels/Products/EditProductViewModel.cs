

namespace ProductsManagment.Web.ViewModels.Products;

public class EditProductViewModel
{
    
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateOnly CreatedOn { get; set; }

    [Display(Name = "مقدم الخدمة")]
    public int ServiceProviderId { get; set; }

    public IEnumerable<SelectListItem>? Providers { get; set; }
}
