using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ProductsManagment.Web.ViewModels;

public class FilterProductViewModel
{
    [Display(Name = "من سعر")]
    public decimal? MinPrice { get; set; }

    [Display(Name = "إلى سعر")]
    public decimal? MaxPrice { get; set; }

    [Display(Name = "من تاريخ")]
    public DateOnly? DateFrom { get; set; }

    [Display(Name = "إلى تاريخ")]
    public DateOnly? DateTo { get; set; }

    [Display(Name = "مقدم الخدمة")]
    public int? SelectedServiceProviderId { get; set; }

    public IEnumerable<SelectListItem>? Providers { get; set; }

    // النتائج بعد التصفية
    public List<ProductListViewModel>? Products { get; set; }
}
