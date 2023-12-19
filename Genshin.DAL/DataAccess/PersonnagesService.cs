using Dapper;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genshin.DAL.DataAccess
{
    public class PersonnagesService : IPersonnagesRepository
    {
        private readonly SqlConnection _connection;

        public PersonnagesService(SqlConnection connection)
        {
            _connection = connection;
        }
        public void Create(PersonnagesEntity p)
        {
            string sql = "INSERT INTO Personnages VALUES " +
                "(@nom,@oeildivin,@typearme,@lore,@nationalite,@traileryt,@splashart,@portrait," +
                "@datesortie,@arme_id,@materiauxameliorationpersonnage_id,@produit_id,@rarete)";
            _connection.ExecuteScalar(sql, new { nom = p.Nom, oeildivin = p.OeilDivin, typearme = p.TypeArme, lore = p.Lore, nationalite = p.Nationalite,
            traileryt = p.TrailerYT, splashart = p.SplashArt, portrait = p.Portrait, datesortie = p.DateSortie, arme_id = p.Arme_Id,
            materiauxameliorationpersonnage_id = p.MateriauxAmeliorationPersonnage_Id, produit_id = p.Produit_Id, rarete = p.Rarete});
        }

        public IEnumerable<PersonnagesEntity> GetAll()
        {
            string sql = "SELECT * FROM Personnages";
            IEnumerable<PersonnagesEntity?> personnages = _connection.Query<PersonnagesEntity?>(sql);

            if (personnages is not null) return personnages;
            return null;
        }

        public PersonnagesEntity GetByName(string name)
        {
            string sql = "SELECT * FROM Personnages WHERE Nom = @nom";
            PersonnagesEntity? personnage = _connection.QuerySingleOrDefault<PersonnagesEntity?>(sql, new { nom = name });

            if (personnage is not null) return personnage;
            return null;
        }

        public IEnumerable<PersonnagesEntity> GetByNationalite(string nationalite)
        {
            string sql = "SELECT * FROM Personnages WHERE Nationalite = @nationalite";
            IEnumerable<PersonnagesEntity?> personnage = _connection.Query<PersonnagesEntity?>(sql, new { nationalite = nationalite });

            if (personnage is not null) return personnage;
            return null;
        }
    }
}
