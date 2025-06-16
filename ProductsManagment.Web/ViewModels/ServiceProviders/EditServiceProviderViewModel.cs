

namespace ProductsManagment.Web.ViewModels.ServiceProviders;

public class EditServiceProviderViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}
