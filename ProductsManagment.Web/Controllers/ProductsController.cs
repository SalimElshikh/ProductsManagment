using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductsManagment.Web.Controllers;
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
            // إعادة تعبئة القائمة في حال وجود خطأ في النموذج
            var providers = await _serviceProviderService.GetAllAsync();
            model.Providers = providers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            return View(model);
        }

        // تحويل ViewModel إلى Entity باستخدام Mapster
        var product = model.Adapt<Product>();
        await _productService.AddAsync(product);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Filter(FilterProductViewModel filter)
    {
        var products = await _productService.GetAllAsync();

        // فلترة حسب السعر
        if (filter.MinPrice.HasValue)
            products = products.Where(p => p.Price >= filter.MinPrice.Value).ToList();

        if (filter.MaxPrice.HasValue)
            products = products.Where(p => p.Price <= filter.MaxPrice.Value).ToList();

        // فلترة حسب التاريخ
        if (filter.DateFrom.HasValue)
            products = products.Where(p => p.CreatedOn >= filter.DateFrom.Value).ToList();

        if (filter.DateTo.HasValue)
            products = products.Where(p => p.CreatedOn <= filter.DateTo.Value).ToList();

        // فلترة حسب مقدم الخدمة
        if (filter.SelectedServiceProviderId.HasValue)
            products = products.Where(p => p.Id == filter.SelectedServiceProviderId.Value).ToList();

        // إعداد القائمة المنسدلة لمقدمي الخدمات
        var providers = await _serviceProviderService.GetAllAsync();
        filter.Providers = providers.Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = p.Name
        });

        // تعيين النتائج بعد الفلترة
        filter.Products = products.Adapt<List<ProductListViewModel>>();

        return View(filter);
    }

}
