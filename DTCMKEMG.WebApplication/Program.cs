using DTCMKEMG.DataAccess;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar DataAccess
builder.Services.AddDataAccessServices(builder.Configuration);

// Registrar MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        Assembly.Load("DTCMKEMG.BusinessLogic")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();