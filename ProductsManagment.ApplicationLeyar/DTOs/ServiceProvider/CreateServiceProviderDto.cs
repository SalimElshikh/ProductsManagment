using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagment.ApplicationLeyar.DTOs.ServiceProvider;
public record CreateServiceProviderDto(
    string Name,
    string Address,
    string PhoneNumber
    
    );
