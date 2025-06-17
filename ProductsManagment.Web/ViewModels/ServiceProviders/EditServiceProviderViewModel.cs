

namespace ProductsManagment.Web.ViewModels.ServiceProviders;

public class EditServiceProviderViewModel
{
    public int Id { get; set; }

    [Display(Name = " الاسم")]
    public string Name { get; set; } = null!;
    [Display(Name = " العنوان")]

    public string Address { get; set; } = null!;
    [Display(Name = " رقم الهاتف ")]

    public string PhoneNumber { get; set; } = null!;
}
