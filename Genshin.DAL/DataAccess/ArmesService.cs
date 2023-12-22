using Dapper;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genshin.DAL.DataAccess
{
    public class ArmesService : IArmesRepository
    {
        private readonly DbConnection _connection;

        public ArmesService(DbConnection connection)
        {
            _connection = connection;
        }
        public void Create(ArmesEntity arme, List<int> selectedMats, List<int> selectedMatsAmelioList)
        {
            string sql = "INSERT INTO Armes VALUES (@nom,@typeArme,@description,@icone,@image,@nomStat,@valeurStat,@effetPassif,@ATQBase,@rarete); SELECT SCOPE_IDENTITY();";
            int newArmeId = _connection.ExecuteScalar<int>(sql, new { nom = arme.Nom,typeArme = arme.TypeArme, description = arme.Description, icone = arme.Icone,
                                                 image = arme.Image, nomStat = arme.NomStatPrincipale,valeurStat = arme.ValeurStatPrincipale,
                                                 effetPassif = arme.EffetPassif,ATQBase = arme.ATQBase,rarete = arme.Rarete});

            string sql2 = "INSERT INTO Armes_MateriauxElevationArmes (Arme_Id, MateriauxElevationArme_Id,Quantite) VALUES (@armeId, @matId,0)";

            foreach (int matId in selectedMats)
            {
                _connection.Execute(sql2, new { armeId = newArmeId, matId });
            }

            string sql3 = "INSERT INTO Armes_MateriauxAmeliorationPersonnagesEtArmes VALUES (@armeId, @matId,0)";

            foreach (int matId in selectedMatsAmelioList)
            {
                _connection.Execute(sql3, new { armeId = newArmeId, matId });
            }
        }

        public IEnumerable<ArmesEntity> GetAll()
        {
            string sql = "SELECT * FROM Armes";
            IEnumerable<ArmesEntity?> armes = _connection.Query<ArmesEntity?>(sql);
            if (armes is not null) return armes;
            return null;
        }

        public ArmesEntity GetByName(string name)
        {
            string sql = "SELECT * FROM Armes WHERE Nom = @nom";
            ArmesEntity? arme = _connection.QuerySingleOrDefault<ArmesEntity>(sql, new {nom = name});
            if (arme is not null) return arme;
            return null;
        }

        public ArmesEntity GetById(int id){
            string sql = "SELECT * FROM Armes WHERE Id = @id";
            ArmesEntity? arme = _connection.QuerySingleOrDefault<ArmesEntity>(sql, new { id = id });
            if (arme is not null) return arme;
            return null;
        }
    }
}
