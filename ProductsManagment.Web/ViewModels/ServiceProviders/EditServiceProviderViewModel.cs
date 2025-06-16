

namespace ProductsManagment.Web.ViewModels.ServiceProviders;

public class EditServiceProviderViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "الاسم مطلوب")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "العنوان مطلوب")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "رقم التلفون مطلوب")]
    [Phone]
    public string PhoneNumber { get; set; } = null!;
}
