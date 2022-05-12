using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using TendaUltramarinos_Blazor.Web;
using TendaUltramarinos_Blazor.Web.Servicios;
using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//linea orixinal
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//modificada para aceptar a nosa url base
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7289/") });
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<ICestaCompraServicio, CestaCompraServicio>();


await builder.Build().RunAsync();
