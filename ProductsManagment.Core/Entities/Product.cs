using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsManagment.Core.Entities;
public  class Product
{
    public int Id { get; set; }
    public string Name   { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; } 
    public DateOnly? CreatedOn { get; set; }



    [ForeignKey("ServiceProviderId")]
    public int ServiceProviderId { get; set; }
    public ServiceProvider? ServiceProvider { get; set; } 
}
