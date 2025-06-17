using System.ComponentModel.DataAnnotations;

namespace ProductsManagment.Web.ViewModels.ServiceProviders;

public class CreateServiceProviderViewModel
{
    [Display(Name= " الاسم")]
    public string Name { get; set; } = null!;
    [Display(Name = " العنوان")]

    public string Address { get; set; } = null!;
    [Display(Name = " رقم الهاتف ")]

    public string PhoneNumber { get; set; } = null!;
}
