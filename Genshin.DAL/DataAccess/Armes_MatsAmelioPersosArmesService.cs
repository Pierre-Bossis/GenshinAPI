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
    public class Armes_MatsAmelioPersosArmesService : IArmes_MatsAmelioPersosArmesRepository
    {
        private readonly DbConnection _connection;

        public Armes_MatsAmelioPersosArmesService(DbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<ArmesEntity> GetArmes(int matId)
        {
            string query = "SELECT * " +
                           "FROM Armes AS A " +
                           "INNER JOIN Armes_MateriauxAmeliorationPersonnagesEtArmes AS AME ON A.Id = AME.Arme_Id " +
                           "WHERE AME.MateriauxAmeliorationPersonnagesEtArmes_Id = @MatId";

            return _connection.Query<ArmesEntity>(query, new { MatId = matId });
        }

        public IEnumerable<MateriauxAmeliorationPersonnagesEtArmesEntity> GetMateriaux(int armeId)
        {
            string query = "SELECT * " +
                           "FROM MateriauxAmeliorationPersonnagesEtArmes AS ME " +
                           "INNER JOIN Armes_MateriauxAmeliorationPersonnagesEtArmes AS AME ON ME.Id = AME.MateriauxAmeliorationPersonnagesEtArmes_Id " +
                           "WHERE AME.Arme_Id = @ArmeId";

            return _connection.Query<MateriauxAmeliorationPersonnagesEtArmesEntity>(query, new { ArmeId = armeId });
        }
    }
}
