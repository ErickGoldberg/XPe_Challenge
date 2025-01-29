using Microsoft.EntityFrameworkCore;
using XPe_Challenge.Data;
using XPe_Challenge.Repositories;
using XPe_Challenge.Services;

var builder = WebApplication.CreateBuilder(args);

// 1) Configurar EF Core com SQL Server
builder.Services.AddDbContext<XPeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2) Registrar Repositórios e Serviços na Injeção de Dependência
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

// 3) Adicionar Controllers 
builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();