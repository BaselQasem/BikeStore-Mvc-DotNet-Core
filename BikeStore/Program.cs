using Core.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.ServiceClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BikeStoreContext>((optionsBuilder) => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Conn")), ServiceLifetime.Scoped);
builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BikeStoreContext>();


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBrand, BrandService>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IStore, StoreService>();
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IStaff, StaffService>();
builder.Services.AddScoped<IStock, StockService>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IOrderItem, OrderItemService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//For AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

    options.LoginPath = "/Identity/Account/Login";
    // ReturnUrlParameter requires 
    //using Microsoft.AspNetCore.Authentication.Cookies;

    options.SlidingExpiration = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.MapRazorPages();
app.UseRouting();
app.UseAuthentication(); // Must be after UseRouting()
app.UseAuthorization();
app.UseHttpsRedirection();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers().RequireAuthorization();

//});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


