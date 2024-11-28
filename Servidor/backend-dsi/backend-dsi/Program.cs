using DataBase.Data;
using Microsoft.EntityFrameworkCore;
using Servicios.Interfaces;
using Servicios.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<dsiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<ICineService, CineService>();
builder.Services.AddScoped<IDomicilioService, DomicilioService>();
builder.Services.AddScoped<ILocalidadService, LocalidadService>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
