using ProyClienteSpaHelena.Services;
using ProyClienteSpaHelena.Services.Impl;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<ClienteService, ClienteServiceImpl>(client => { 
    client.BaseAddress = new Uri("http://localhost:5269/");
    client.Timeout = TimeSpan.FromSeconds(15);
});

builder.Services.AddControllersWithViews();

builder.Services.AddSession(opc => opc.IdleTimeout = TimeSpan.FromMinutes(20));

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
