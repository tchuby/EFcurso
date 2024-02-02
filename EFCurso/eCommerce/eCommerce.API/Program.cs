global using eCommerce.Models;
using eCommerce.API.Database;
using eCommerce.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region CofigureService
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando a configura��o do banco de dados passando a connectionString do appsettings
builder.Services.AddDbContext<eCommerceContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("eCommerce"))
);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRespository>();
#endregion

var app = builder.Build();

#region Configure
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion