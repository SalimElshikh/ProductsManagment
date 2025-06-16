using Microsoft.AspNetCore.Mvc;
using ProductsManagment.Web.Models;
using System.Diagnostics;

namespace ProductsManagment.Web.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
