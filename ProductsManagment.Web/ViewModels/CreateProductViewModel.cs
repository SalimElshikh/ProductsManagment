using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ProductsManagment.Web.ViewModels;

public class CreateProductViewModel 
{
    [Required]
    public string Name { get; set; } = null!;


    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من 0")]
    public decimal Price { get; set; }

    [Required]
    public DateOnly CreatedOn { get; set; }

    [Required]
    [Display(Name = "مقدم الخدمة")]
    public int ServiceProviderId { get; set; }

    // لعرض القائمة المنسدلة في الـ View
    public IEnumerable<SelectListItem>? Providers { get; set; }
}
