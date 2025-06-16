

using ProductsManagment.Web.ViewModels.Products;

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

            var product = model.Adapt<Product>();
            await _productService.AddAsync(product);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            var providers = await _serviceProviderService.GetAllAsync();

            var viewModel = product.Adapt<EditProductViewModel>();
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

            var product = model.Adapt<Product>();
            await _productService.UpdateAsync(product);

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
            var products = await _productService.GetAllAsync();

            if (filter.MinPrice.HasValue)
                products = products.Where(p => p.Price >= filter.MinPrice.Value).ToList();

            if (filter.MaxPrice.HasValue)
                products = products.Where(p => p.Price <= filter.MaxPrice.Value).ToList();

            if (filter.DateFrom.HasValue)
                products = products.Where(p => p.CreatedOn >= filter.DateFrom.Value).ToList();

            if (filter.DateTo.HasValue)
                products = products.Where(p => p.CreatedOn <= filter.DateTo.Value).ToList();

            if (filter.SelectedServiceProviderId.HasValue)
                products = products.Where(p => p.ServiceProviderId == filter.SelectedServiceProviderId.Value).ToList();

            var providers = await _serviceProviderService.GetAllAsync();
            filter.Providers = providers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            filter.Products = products.Adapt<List<ProductListViewModel>>();

            return View(filter);
        }
    }
}
