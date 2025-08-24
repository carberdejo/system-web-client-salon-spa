using ProyClienteSpaHelena.Services;
using ProyClienteSpaHelena.Services.Impl;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<ClienteService, ClienteServiceImpl>(client => { 
    client.BaseAddress = new Uri("http://localhost:5269/");
    client.Timeout = TimeSpan.FromSeconds(15);
});
builder.Services.AddHttpClient<EspecialidadService, EspecialidadesServiceImpl>(espe => {
    espe.BaseAddress = new Uri("http://localhost:5269/");
    espe.Timeout = TimeSpan.FromSeconds(15);
});
builder.Services.AddHttpClient<ServiciosService, ServiciosServiceImpl>(s => {
    s.BaseAddress = new Uri("http://localhost:5269/");
    s.Timeout = TimeSpan.FromSeconds(15);
});
builder.Services.AddHttpClient<TrabajadorService, TrabajadorServiceImpl>(s => {
    s.BaseAddress = new Uri("http://localhost:5269/");
    s.Timeout = TimeSpan.FromSeconds(15);
});
builder.Services.AddHttpClient<SessionService, SessionServiceImpl>(s => {
    s.BaseAddress = new Uri("http://localhost:5269/");
    s.Timeout = TimeSpan.FromSeconds(15);
});
builder.Services.AddHttpClient<ReservaService, ReservaServiceImpl>(s => {
    s.BaseAddress = new Uri("http://localhost:5269/");
    s.Timeout = TimeSpan.FromSeconds(15);
});

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
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
