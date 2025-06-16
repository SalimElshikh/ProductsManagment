using System.ComponentModel.DataAnnotations;

namespace ProductsManagment.Web.ViewModels.Products;

public class EditProductViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public DateOnly CreatedOn { get; set; }

    [Required]
    [Display(Name = "مقدم الخدمة")]
    public int ServiceProviderId { get; set; }

    public IEnumerable<SelectListItem>? Providers { get; set; }
}
