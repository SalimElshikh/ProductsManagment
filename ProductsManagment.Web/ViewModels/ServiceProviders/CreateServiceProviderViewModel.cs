using System.ComponentModel.DataAnnotations;

namespace ProductsManagment.Web.ViewModels.ServiceProviders;

public class CreateServiceProviderViewModel
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = null!;
}
