
using ProductsManagment.ApplicationLeyar.DTOs.ServiceProvider;

namespace ProductsManagment.Web.Controllers
{
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

            var dto = model.Adapt<CreateServiceProviderDto>();
            await _serviceProviderService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _serviceProviderService.GetByIdAsync(id);
            if (dto == null)
                return NotFound();

            var viewModel = dto.Adapt<EditServiceProviderViewModel>();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditServiceProviderViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            var dto = model.Adapt<EditServiceProviderDto>();
            await _serviceProviderService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceProviderService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "حدث خطأ غير متوقع أثناء محاولة الحذف.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
