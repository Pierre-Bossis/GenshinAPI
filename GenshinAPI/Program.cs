using Genshin.BLL.Interfaces;
using Genshin.BLL.Services;
using Genshin.DAL.DataAccess;
using Genshin.DAL.Repositories;
using GenshinAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Injections

builder.Services.AddScoped<JwtGenerator>();
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

builder.Services.AddScoped<IAvatarsRepository, AvatarsService>();
builder.Services.AddScoped<IAvatarsBLLService, AvatarsBLLService>();

builder.Services.AddScoped<IMateriauxElevationPersonnagesRepository, MateriauxElevationPersonnagesService>();
builder.Services.AddScoped<IMateriauxElevationPersonnagesBLLService, MateriauxElevationPersonnagesBLLService>();

builder.Services.AddScoped<ILivresAptitudeRepository, LivresAptitudeService>();
builder.Services.AddScoped<ILivresAptitudeBLLService, LivresAptitudeBLLService>();

builder.Services.AddScoped<IArmes_MateriauxElevationArmesRepository, Armes_MateriauxElevationArmesService>();
builder.Services.AddScoped<IArmes_MateriauxElevationArmesBLLService, Armes_MateriauxElevationArmesBLLService>();

builder.Services.AddScoped<IPersonnages_LivresAptitudeRepository, Personnages_LivresAptitudeService>();
builder.Services.AddScoped<IPersonnages_LivresAptitudeBLLService, Personnages_LivresAptitudeBLLService>();

builder.Services.AddScoped<IPersonnages_MateriauxElevationPersonnagesRepository, Personnages_MateriauxElevationPersonnagesService>();
builder.Services.AddScoped<IPersonnages_MateriauxElevationPersonnagesBLLService, Personnages_MateriauxElevationPersonnagesBLLService>();

builder.Services.AddScoped<IMateriauxAmeliorationPersonnagesEtArmesRepository, MateriauxAmeliorationPersonnagesEtArmesService>();
builder.Services.AddScoped<IMateriauxAmeliorationPersonnagesEtArmesBLLService, MateriauxAmeliorationPersonnagesEtArmesBLLService>();

builder.Services.AddScoped<IPersonnages_MatsAmelioPersosArmesRepository, Personnages_MatsAmelioPersosArmesService>();
builder.Services.AddScoped<IPersonnages_MatsAmelioPersosArmesBLLService, Personnages_MatsAmelioPersosArmesBLLService>();

builder.Services.AddScoped<IArmes_MatsAmelioPersosArmesRepository, Armes_MatsAmelioPersosArmesService>();
builder.Services.AddScoped<IArmes_MatsAmelioPersosArmesBLLService, Armes_MatsAmelioPersosArmesBLLService>();

builder.Services.AddScoped<IConstellationsRepository, ConstellationsService>();
builder.Services.AddScoped<IConstellationsBLLService, ConstellationsBLLService>();

builder.Services.AddScoped<IAptitudesRepository, AptitudesService>();
builder.Services.AddScoped<IAptitudesBLLService, AptitudesBLLService>();

builder.Services.AddScoped<IUserRepository,UserService>();
builder.Services.AddScoped<IUserBLLService, UserBLLService>();

#endregion

#region Authentification
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("tokenInfo").GetSection("secretKey").Value)),
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidAudience = "http://localhost:4200"
        };
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("connectedPolicy", policy => policy.RequireAuthenticatedUser()); 
});

#endregion

builder.Services.AddCors(o => o.AddPolicy("angular", options =>
    options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("angular");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
