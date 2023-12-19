using Genshin.BLL.Interfaces;
using Genshin.BLL.Services;
using Genshin.DAL.DataAccess;
using Genshin.DAL.Repositories;
using System.Data.Common;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DbConnection>(sp => new SqlConnection(configuration.GetConnectionString("techno")));
builder.Services.AddScoped<IMateriauxElevationArmesRepository, MateriauxElevationArmesService>();
builder.Services.AddScoped<IMateriauxElevationArmesBLLService, MateriauxElevationArmesBLLService>();

builder.Services.AddScoped<IArmesRepository, ArmesService>();
builder.Services.AddScoped<IArmesBLLService, ArmesBLLService>();

builder.Services.AddScoped<IProduitsRepository,ProduitsService>();
builder.Services.AddScoped<IProduitsBLLService,ProduitsBLLService>();

builder.Services.AddScoped<IMateriauxAmeliorationPersonnagesRepository, MateriauxAmeliorationPersonnagesService>();
builder.Services.AddScoped<IMateriauxAmeliorationPersonnagesBLLService,MateriauxAmeliorationPersonnagesBLLService>();

builder.Services.AddScoped<IPersonnagesRepository, PersonnagesService>();
builder.Services.AddScoped<IPersonnagesBLLService, PersonnagesBLLService>();

builder.Services.AddScoped<IMateriauxElevationPersonnagesRepository, MateriauxElevationPersonnagesService>();
builder.Services.AddScoped<IMateriauxElevationPersonnagesBLLService, MateriauxElevationPersonnagesBLLService>();

builder.Services.AddScoped<ILivresAptitudeRepository, LivresAptitudeService>();
builder.Services.AddScoped<ILivresAptitudeBLLService, LivresAptitudeBLLService>();

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
