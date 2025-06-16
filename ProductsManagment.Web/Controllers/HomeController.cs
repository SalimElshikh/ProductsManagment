using Microsoft.AspNetCore.Mvc;

namespace ProductsManagment.Web.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
