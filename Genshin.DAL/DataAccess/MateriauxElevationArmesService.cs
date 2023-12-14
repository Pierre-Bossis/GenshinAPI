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

        public void Create(MateriauxElevationArmesEntity mat)
        {
            string sql = "INSERT INTO MateriauxElevationArmes VALUES (@nom,@icone,@source,@rarete)";
            _connection.ExecuteScalar(sql, new { nom = mat.Nom, icone = mat.Icone, source = mat.Source, rarete = mat.Rarete });
        }

        public MateriauxElevationArmesEntity GetByName(string name)
        {
            string sql = "SELECT * FROM MateriauxElevationArmes WHERE Nom = @name";
            MateriauxElevationArmesEntity? mat = _connection.QuerySingleOrDefault<MateriauxElevationArmesEntity>(sql, new { name = name });
            if (mat is not null) return mat;

            return null;
        }

        public IEnumerable<MateriauxElevationArmesEntity> GetAll()
        {
            string sql = "SELECT * FROM MateriauxElevationArmes";
            return _connection.Query<MateriauxElevationArmesEntity>(sql);
        }

        //traitement pour create
    }
}
