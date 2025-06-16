using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagment.Core.Entities;
public  class Product
{
    public int Id { get; set; }
    public string Name   { get; set; } = null!;
    public decimal Price { get; set; }
    public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.Today);



    [ForeignKey("ServiceProviderId")]
    public int ServiceProviderId { get; set; }
    public ServiceProvider? ServiceProvider { get; set; } 
}
