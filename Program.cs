
using MusikalAPI.Interfaces;
using MusikalAPI.Context;
using MusikalAPI.Services; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Conexion a la base de datos SQL Server
builder.Services.AddDbContext<MusikalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MusikalConnection")));

//Inyeccion de dependencias (Sevices)
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<ITipoService, TipoService>();
builder.Services.AddScoped<IModeloService, ModeloService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
//builder.Services.AddScoped<IPasarelaPagoService, PasarelaPagoService>();

// Servicios base de ASP.NET Core
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 


var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //Genera el JSON con la descripcion de la API
    app.UseSwaggerUI(); //Genera la UI visual en /swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
