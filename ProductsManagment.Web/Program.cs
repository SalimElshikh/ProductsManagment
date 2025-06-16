

using ProductsManagment.Web.Validator.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();


builder.Services.AddValidatorsFromAssemblyContaining<EditProductViewModelValidator>();


// Add Dependency Injections 
builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<IServiceProviderService, ServiceProviderServices>();

//Configure DataBase 
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));

});
// Add Mapster 
MappingConfig.RegisterMappings(); 

builder.Services.AddMapster();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}else
{
    app.UseDeveloperExceptionPage();
}

    app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
