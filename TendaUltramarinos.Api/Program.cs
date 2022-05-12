using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

using TendaUltramarinos.Api.Datos;
using TendaUltramarinos.Api.Repositorios;
using TendaUltramarinos.Api.Repositorios.Contratos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//preparamos o contexto da base de datos para Dependency Injection
builder.Services.AddDbContextPool<UltramarinosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UltramarinosConnection")));
//usamos AddScoped para rexistrar a nosa clase ProductoRepositorio
//para dependency injection
//con AddScoped cada instancia do obxecto inxectase
//nas clases relevantes dentro dunha peticion http particular
//neste caso crease unha nova instancia do obxecto relevante
//para cada peticion http
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<ICestaCompraRepositorio, CestaCompraRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//isto facemolo para evitar a exception relacionada con CORS
//porque borramos Index.razor
//e cambiaron algunhas rutas
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7039", "https://localhost:7039")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
