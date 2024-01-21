using Genshin.BLL.Interfaces;
using Genshin.BLL.Services;
using Genshin.DAL.DataAccess;
using Genshin.DAL.Repositories;
using GenshinAPI.Services;
using GenshinAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Service lié aux injections de dépendances
DependencyInjectionService.ConfigureDependencyInjection(builder.Services, builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()./*AllowCredentials().*/WithExposedHeaders("Content-Disposition")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors("angular");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
