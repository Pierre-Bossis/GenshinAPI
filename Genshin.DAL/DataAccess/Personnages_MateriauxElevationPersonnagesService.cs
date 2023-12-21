using Dapper;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.DataAccess
{
    public class Personnages_MateriauxElevationPersonnagesService : IPersonnages_MateriauxElevationPersonnagesRepository
    {
        private readonly DbConnection _connection;

        public Personnages_MateriauxElevationPersonnagesService(DbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<MateriauxElevationPersonnagesEntity> GetMateriauxElevation(int personnageId)
        {
            string query = "SELECT * " +
                            "FROM MateriauxElevationPersonnages AS M " +
                            "INNER JOIN Personnages_MateriauxElevationPersonnages AS PMEP ON M.Id = PMEP.MateriauxElevationPersonnage_Id " +
                            "WHERE PMEP.Personnage_Id = @personnageId";

            return _connection.Query<MateriauxElevationPersonnagesEntity>(query, new { personnageId = personnageId });
        }

        public IEnumerable<PersonnagesEntity> GetPersonnages(int materiauId)
        {
            string query = "SELECT * " +
                           "FROM Personnages AS P " +
                           "INNER JOIN Personnages_MateriauxElevationPersonnages AS PMEP ON P.Id = PMEP.Personnage_Id " +
                           "WHERE PMEP.MateriauxElevationPersonnage_Id = @materiauId";
            return _connection.Query<PersonnagesEntity>(query, new { materiauId = materiauId });
        }
    }
}
