using Dapper;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.DataAccess
{
    public class Armes_MateriauxElevationArmesService : IArmes_MateriauxElevationArmesRepository
    {
        private readonly DbConnection _connection;

        public Armes_MateriauxElevationArmesService(DbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<ArmesEntity> GetArmes(int matId)
        {
            string query = @" SELECT *
                            FROM Armes AS A
                            INNER JOIN Armes_MateriauxElevationArmes AS AME ON A.Id = AME.Arme_Id
                            WHERE AME.MateriauxElevationArme_Id = @MatId"
            ;

            return _connection.Query<ArmesEntity>(query, new { MatId = matId });
        }

        public IEnumerable<MateriauxElevationArmesEntity> GetMateriaux(int armeId)
        {
            string query = @" SELECT *
                            FROM MateriauxElevationArmes AS ME
                            INNER JOIN Armes_MateriauxElevationArmes AS AME ON ME.Id = AME.MateriauxElevationArme_Id
                            WHERE AME.Arme_Id = @ArmeId";

            return _connection.Query<MateriauxElevationArmesEntity>(query, new { ArmeId = armeId });
        }
    }
}
