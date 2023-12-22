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
    public class PersonnagesService : IPersonnagesRepository
    {
        private readonly DbConnection _connection;

        public PersonnagesService(DbConnection connection)
        {
            _connection = connection;
        }
        public void Create(PersonnagesEntity p, List<int> SelectedLivres, List<int> selectedMatsElevationPersonnages, List<int> selectedMatsAmelioListe)
        {
            string sql = "INSERT INTO Personnages VALUES " +
                "(@nom,@oeildivin,@typearme,@lore,@nationalite,@traileryt,@splashart,@portrait," +
                "@datesortie,@arme_id,@materiauxameliorationpersonnage_id,@produit_id,@rarete); SELECT SCOPE_IDENTITY();";
            int newPersonnageId = _connection.ExecuteScalar<int>(sql, new { nom = p.Nom, oeildivin = p.OeilDivin, typearme = p.TypeArme, lore = p.Lore, nationalite = p.Nationalite,
            traileryt = p.TrailerYT, splashart = p.SplashArt, portrait = p.Portrait, datesortie = p.DateSortie, arme_id = p.Arme_Id,
            materiauxameliorationpersonnage_id = p.MateriauxAmeliorationPersonnage_Id, produit_id = p.Produit_Id, rarete = p.Rarete});

            string sql2 = "INSERT INTO Personnages_LivresAptitude (Personnage_Id, LivreAptitude_Id,Quantite) VALUES (@personnageId, @livreId,0)";

            foreach (int livreId in SelectedLivres)
            {
                _connection.Execute(sql2, new { personnageId = newPersonnageId, livreId });
            }

            string sql3 = "INSERT INTO Personnages_MateriauxElevationPersonnages (Personnage_Id, MateriauxElevationPersonnage_Id,Quantite) VALUES (@personnageId, @matsId,0)";

            foreach (int matsId in selectedMatsElevationPersonnages)
            {
                _connection.Execute(sql3, new { personnageId = newPersonnageId, matsId });
            }

            string sql4 = "INSERT INTO Personnages_MateriauxAmeliorationPersonnagesEtArmes VALUES (@personnageId, @matsId,0)";

            foreach (int matsId in selectedMatsAmelioListe)
            {
                _connection.Execute(sql4, new { personnageId = newPersonnageId, matsId });
            }
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
