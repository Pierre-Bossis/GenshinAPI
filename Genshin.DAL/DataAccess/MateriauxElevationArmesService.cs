using Dapper;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.DataAccess
{
    public class MateriauxElevationArmesService : IMateriauxElevationArmesRepository
    {
        private readonly SqlConnection _connection;

        public MateriauxElevationArmesService(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<MateriauxElevationArmes> GetAll()
        {
            string sql = "SELECT * FROM MateriauxElevationArmes";
            return _connection.Query<MateriauxElevationArmes>(sql);
        }

        //traitement pour create
    }
}
