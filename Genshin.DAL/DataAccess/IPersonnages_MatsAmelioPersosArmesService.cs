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
    public class IPersonnages_MatsAmelioPersosArmesService : IPersonnages_MatsAmelioPersosArmesRepository
    {
        private readonly DbConnection _connection;

        public IPersonnages_MatsAmelioPersosArmesService(DbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<MateriauxAmeliorationPersonnagesEtArmesEntity> GetMateriauxAmelioration(int personnageId)
        {
            string query = "SELECT * " +
                "FROM MateriauxAmeliorationPersonnagesEtArmes AS M " +
                "INNER JOIN Personnages_MateriauxAmeliorationPersonnagesEtArmes AS PMEP ON M.Id = PMEP.MateriauxAmeliorationPersonnagesEtArmes_Id " +
                "WHERE PMEP.Personnage_Id = @personnageId";

            return _connection.Query<MateriauxAmeliorationPersonnagesEtArmesEntity>(query, new { personnageId = personnageId });
        }

        public IEnumerable<PersonnagesEntity> GetPersonnages(int materiauId)
        {
            string query = "SELECT * " +
                           "FROM Personnages AS P " +
                           "INNER JOIN Personnages_MateriauxAmeliorationPersonnagesEtArmes AS PMEP ON P.Id = PMEP.Personnage_Id " +
                           "WHERE PMEP.MateriauxAmeliorationPersonnagesEtArmes_Id = @materiauId";
            return _connection.Query<PersonnagesEntity>(query, new { materiauId = materiauId });
        }
    }
}
