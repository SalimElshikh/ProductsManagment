namespace ProductsManagment.Web.Controllers;
public class ServiceProvidersController : Controller
{
    private readonly IServiceProviderService _serviceProviderService;

    public ServiceProvidersController(IServiceProviderService serviceProviderService)
    {
        _serviceProviderService = serviceProviderService;
    }

    public async Task<IActionResult> Index()
    {
        var providers = await _serviceProviderService.GetAllAsync();
        var viewModels = providers.Adapt<List<ServiceProviderListViewModel>>();
        return View(viewModels);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceProviderViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _serviceProviderService.AddAsync(model.Adapt<Core.Entities.ServiceProvider>());
        return RedirectToAction(nameof(Index));
    }
}

