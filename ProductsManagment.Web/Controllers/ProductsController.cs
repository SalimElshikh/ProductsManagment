

namespace ProductsManagment.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IServiceProviderService _serviceProviderService;

        public ProductsController(IProductService productService, IServiceProviderService serviceProviderService)
        {
            _productService = productService;
            _serviceProviderService = serviceProviderService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            var viewModels = products.Adapt<List<ProductListViewModel>>();
            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var providers = await _serviceProviderService.GetAllAsync();

            var model = new CreateProductViewModel
            {
                CreatedOn = DateOnly.FromDateTime(DateTime.Today),
                Providers = providers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var providers = await _serviceProviderService.GetAllAsync();
                model.Providers = providers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();

                return View(model);
            }

            var dto = model.Adapt<CreateProductDto>();
            await _productService.AddAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _productService.GetByIdAsync(id);
            if (dto == null)
                return NotFound();

            var viewModel = dto.Adapt<EditProductViewModel>();

            var providers = await _serviceProviderService.GetAllAsync();
            viewModel.Providers = providers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var providers = await _serviceProviderService.GetAllAsync();
                model.Providers = providers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                });

                return View(model);
            }

            var dto = model.Adapt<EditProductDto>();
            await _productService.UpdateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Filter(FilterProductViewModel filter)
        {
            var products = await _productService.FilterAsync(
                filter.MinPrice,
                filter.MaxPrice,
                filter.DateFrom,
                filter.DateTo,
                filter.SelectedServiceProviderId);

            var viewModels = products.Adapt<List<ProductListViewModel>>();
            filter.Products = viewModels;

            var providers = await _serviceProviderService.GetAllAsync();
            filter.Providers = providers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            return View(filter);
        }
    }
}
