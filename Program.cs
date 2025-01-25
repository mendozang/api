using Microsoft.EntityFrameworkCore;
using PetPalzAPI.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetEnv;



var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

//env
var connectionString = $"Host={Environment.GetEnvironmentVariable("HOST_DB")};" +
                       $"Database={Environment.GetEnvironmentVariable("NAME_DB")};" +
                       $"Username={Environment.GetEnvironmentVariable("USER_DB")};" +
                       $"Password={Environment.GetEnvironmentVariable("PASSWORD_DB")};" +
                       "SSL Mode=Require;Trust Server Certificate=true";

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión no se pudo construir. Verifica las variables de entorno.");
}


// Configurar EF con PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });


builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PetPalzAPI.Services.UsuarioService>();
builder.Services.AddScoped<PetPalzAPI.Services.MascotaService>();
builder.Services.AddScoped<PetPalzAPI.Services.HistorialMedicoService>();
builder.Services.AddScoped<PetPalzAPI.Services.RecordatorioService>();
builder.Services.AddScoped<PetPalzAPI.Services.VeterinarioService>();
builder.Services.AddScoped<PetPalzAPI.Services.PrimerosAuxiliosService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();
app.Run();



