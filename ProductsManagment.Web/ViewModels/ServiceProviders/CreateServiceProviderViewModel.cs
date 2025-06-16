using System.ComponentModel.DataAnnotations;

namespace ProductsManagment.Web.ViewModels.ServiceProviders;

public class CreateServiceProviderViewModel
{
    
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
