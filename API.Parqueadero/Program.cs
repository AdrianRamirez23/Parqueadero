using Application.Parqueadero.Contracts;
using Application.Parqueadero.Interfaces;
using Data.Parqueadero.Models;
using Microsoft.EntityFrameworkCore;
using Models.Parqueadero.EncodeString;
using Services.Parqueadero.Contracts;
using Services.Parqueadero.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ParqueaderoContext>(options => options.UseSqlServer(configuration.GetConnectionString("parqueaderoConection")));
builder.Services.AddTransient<ITipoUsuarioApp, TipoUsuarioApp>();
builder.Services.AddTransient<ITipoUsuarioSrv, TipoUsuarioSrv>();

builder.Services.AddTransient<ITipoVehiculoApp, TipoVehiculoApp>();
builder.Services.AddTransient<ITipoVehiculoSrv, TipoVehiculoSrv>();

builder.Services.AddTransient<IEstadosApp, EstadosApp>();
builder.Services.AddTransient<IEstadosSrv, EstadosSvr>();

builder.Services.AddTransient<IVehiculoApp, VehiculoApp>();
builder.Services.AddTransient<IVehiculoSrv, VehiculoSrv>();

builder.Services.AddTransient<IVehiculoApp, VehiculoApp>();
builder.Services.AddTransient<IVehiculoSrv, VehiculoSrv>();

builder.Services.AddTransient<IEmpleadosApp, EmpleadosApp>();
builder.Services.AddTransient<IEmpleadosSrv, EmpleadosSrv>();

builder.Services.AddTransient<IRegistroApp, RegistroApp>();
builder.Services.AddTransient<IRegistroSrv, RegistroSrv>();

builder.Services.AddTransient<IEncondeString, EncondeString>();

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
