



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
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var provider = await _serviceProviderService.GetByIdAsync(id);
        if (provider == null)
            return NotFound();

        var viewModel = provider.Adapt<EditServiceProviderViewModel>();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditServiceProviderViewModel model)
    {
        if (id != model.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(model);

        var updatedEntity = model.Adapt<ServiceProvider>();
        await _serviceProviderService.UpdateAsync(updatedEntity);

        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _serviceProviderService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }


}

