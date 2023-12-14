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

        public void Create(MateriauxElevationArmes mat)
        {
            string sql = "INSERT INTO MateriauxElevationArmes VALUES (@nom,@icone,@source,@rarete)";
            _connection.ExecuteScalar(sql, new { nom = mat.Nom, icone = mat.Icone, source = mat.Source, rarete = mat.Rarete });
        }

        public MateriauxElevationArmes GetByName(string name)
        {
            string sql = "SELECT * FROM MateriauxElevationArmes WHERE Nom = @name";
            MateriauxElevationArmes? mat = _connection.QuerySingleOrDefault<MateriauxElevationArmes>(sql, new { name = name });
            if (mat is not null) return mat;

            return null;
        }

        public IEnumerable<MateriauxElevationArmes> GetAll()
        {
            string sql = "SELECT * FROM MateriauxElevationArmes";
            return _connection.Query<MateriauxElevationArmes>(sql);
        }

        //traitement pour create
    }
}
