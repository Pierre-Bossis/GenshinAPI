using Genshin.BLL.Interfaces;
using Genshin.BLL.Services;
using Genshin.DAL.DataAccess;
using Genshin.DAL.Repositories;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(sp => new SqlConnection(configuration.GetConnectionString("techno")));
builder.Services.AddScoped<IMateriauxElevationArmesRepository, MateriauxElevationArmesService>();
builder.Services.AddScoped<IMateriauxElevationArmesBLLService, MateriauxElevationArmesBLLService>();

builder.Services.AddCors(o => o.AddPolicy("angular", options =>
    options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("angular");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
