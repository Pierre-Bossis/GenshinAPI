using Genshin.BLL.Interfaces;
using Genshin.BLL.Services;
using Genshin.DAL.DataAccess;
using Genshin.DAL.Repositories;
using GenshinAPI.Tools;
using System.Data.Common;
using System.Data.SqlClient;

namespace GenshinAPI.Services
{
    public static class DependencyInjectionService
    {
        public static void ConfigureDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<JwtGenerator>();
            services.AddTransient<DbConnection>(sp => new SqlConnection(configuration.GetConnectionString("techno")));
            services.AddScoped<IMateriauxElevationArmesRepository, MateriauxElevationArmesService>();
            services.AddScoped<IMateriauxElevationArmesBLLService, MateriauxElevationArmesBLLService>();

            services.AddScoped<IArmesRepository, ArmesService>();
            services.AddScoped<IArmesBLLService, ArmesBLLService>();

            services.AddScoped<IProduitsRepository, ProduitsService>();
            services.AddScoped<IProduitsBLLService, ProduitsBLLService>();

            services.AddScoped<IMateriauxAmeliorationPersonnagesRepository, MateriauxAmeliorationPersonnagesService>();
            services.AddScoped<IMateriauxAmeliorationPersonnagesBLLService, MateriauxAmeliorationPersonnagesBLLService>();

            services.AddScoped<IPersonnagesRepository, PersonnagesService>();
            services.AddScoped<IPersonnagesBLLService, PersonnagesBLLService>();

            services.AddScoped<IAvatarsRepository, AvatarsService>();
            services.AddScoped<IAvatarsBLLService, AvatarsBLLService>();

            services.AddScoped<IMateriauxElevationPersonnagesRepository, MateriauxElevationPersonnagesService>();
            services.AddScoped<IMateriauxElevationPersonnagesBLLService, MateriauxElevationPersonnagesBLLService>();

            services.AddScoped<ILivresAptitudeRepository, LivresAptitudeService>();
            services.AddScoped<ILivresAptitudeBLLService, LivresAptitudeBLLService>();

            services.AddScoped<IArmes_MateriauxElevationArmesRepository, Armes_MateriauxElevationArmesService>();
            services.AddScoped<IArmes_MateriauxElevationArmesBLLService, Armes_MateriauxElevationArmesBLLService>();

            services.AddScoped<IPersonnages_LivresAptitudeRepository, Personnages_LivresAptitudeService>();
            services.AddScoped<IPersonnages_LivresAptitudeBLLService, Personnages_LivresAptitudeBLLService>();

            services.AddScoped<IPersonnages_MateriauxElevationPersonnagesRepository, Personnages_MateriauxElevationPersonnagesService>();
            services.AddScoped<IPersonnages_MateriauxElevationPersonnagesBLLService, Personnages_MateriauxElevationPersonnagesBLLService>();

            services.AddScoped<IMateriauxAmeliorationPersonnagesEtArmesRepository, MateriauxAmeliorationPersonnagesEtArmesService>();
            services.AddScoped<IMateriauxAmeliorationPersonnagesEtArmesBLLService, MateriauxAmeliorationPersonnagesEtArmesBLLService>();

            services.AddScoped<IPersonnages_MatsAmelioPersosArmesRepository, Personnages_MatsAmelioPersosArmesService>();
            services.AddScoped<IPersonnages_MatsAmelioPersosArmesBLLService, Personnages_MatsAmelioPersosArmesBLLService>();

            services.AddScoped<IArmes_MatsAmelioPersosArmesRepository, Armes_MatsAmelioPersosArmesService>();
            services.AddScoped<IArmes_MatsAmelioPersosArmesBLLService, Armes_MatsAmelioPersosArmesBLLService>();

            services.AddScoped<IConstellationsRepository, ConstellationsService>();
            services.AddScoped<IConstellationsBLLService, ConstellationsBLLService>();

            services.AddScoped<IAptitudesRepository, AptitudesService>();
            services.AddScoped<IAptitudesBLLService, AptitudesBLLService>();

            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<IUserBLLService, UserBLLService>();

            services.AddScoped<IArtefactsRepository, ArtefactsService>();
            services.AddScoped<IArtefactsBLLService, ArtefactsBLLService>();
        }
    }
}
