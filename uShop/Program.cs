using MongoDB.Driver;
using System.Text;
using uShop;

var Prov = CodePagesEncodingProvider.Instance;
Encoding.RegisterProvider(Prov);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


Data.InitData(builder.Configuration);

//Data.ImportCSV();     //���������� �������

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute("route1",
       "Product/{id?}",
       new { controller = "Product", action = "Index" });

    endpoints.MapControllerRoute("Admin",
           "Admin/{action}/{id?}",
           new { controller = "Admin", action = "Index" });

    endpoints.MapControllerRoute("Brand",
            "Brand/{id?}",
            new { controller = "Catalog", action = "Brand" });

    endpoints.MapControllerRoute("route2",
       "{controller}/{action}/{id?}",
       new { controller = "Home", action = "Index" });

    endpoints.MapDefaultControllerRoute();
});

app.Run();