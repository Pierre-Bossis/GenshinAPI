using Dapper;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genshin.DAL.DataAccess
{
    public class MateriauxElevationPersonnagesService : IMateriauxElevationPersonnagesRepository
    {
        private readonly DbConnection _connection;

        public MateriauxElevationPersonnagesService(DbConnection connection)
        {
            _connection = connection;
        }
        public void Create(MateriauxElevationPersonnagesEntity mat)
        {
            string sql = "INSERT INTO MateriauxElevationPersonnages VALUES (@nom,@icone,@source,@rarete)";
            _connection.ExecuteScalar(sql, new { nom = mat.Nom, icone = mat.Icone, source = mat.Source, rarete = mat.Rarete });
        }

        public IEnumerable<MateriauxElevationPersonnagesEntity> GetAll()
        {
            string sql = "SELECT * FROM MateriauxElevationPersonnages";
            return _connection.Query<MateriauxElevationPersonnagesEntity>(sql);
        }

        public MateriauxElevationPersonnagesEntity GetByName(string name)
        {
            string sql = "SELECT * FROM MateriauxElevationPersonnages WHERE Nom = @name";
            MateriauxElevationPersonnagesEntity? mat = _connection.QuerySingleOrDefault<MateriauxElevationPersonnagesEntity?>(sql, new { name = name });
            if (mat is not null) return mat;

            return null;
        }

        public MateriauxElevationPersonnagesEntity GetById(int id)
        {
            string sql = "SELECT * FROM MateriauxElevationPersonnages WHERE Id = @id";
            MateriauxElevationPersonnagesEntity? mat = _connection.QuerySingleOrDefault<MateriauxElevationPersonnagesEntity?>(sql, new { id = id });
            if (mat is not null) return mat;

            return null;
        }
    }
}
