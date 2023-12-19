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
    public class MateriauxAmeliorationPersonnagesService : IMateriauxAmeliorationPersonnagesRepository
    {
        private readonly DbConnection _connection;

        public MateriauxAmeliorationPersonnagesService(DbConnection connection)
        {
            _connection = connection;
        }
        public void Create(MateriauxAmeliorationPersonnagesEntity mat)
        {
            string sql = "INSERT INTO MateriauxAmeliorationPersonnages VALUES (@nom,@icone,@source,@rarete)";
            _connection.ExecuteScalar(sql, new { nom = mat.Nom, icone = mat.Icone, source = mat.Source, rarete = mat.Rarete });
        }

        public IEnumerable<MateriauxAmeliorationPersonnagesEntity> GetAll()
        {
            string sql = "SELECT * FROM MateriauxAmeliorationPersonnages";
            return _connection.Query<MateriauxAmeliorationPersonnagesEntity>(sql);
        }

        public MateriauxAmeliorationPersonnagesEntity GetByName(string name)
        {
            string sql = "SELECT * FROM MateriauxAmeliorationPersonnages WHERE Nom = @name";
            MateriauxAmeliorationPersonnagesEntity? mat = _connection.QuerySingleOrDefault<MateriauxAmeliorationPersonnagesEntity?>(sql, new { name = name });
            if (mat is not null) return mat;

            return null;
        }

        public MateriauxAmeliorationPersonnagesEntity GetById(int id)
        {
            string sql = "SELECT * FROM MateriauxAmeliorationPersonnages WHERE Id = @id";
            MateriauxAmeliorationPersonnagesEntity? mat = _connection.QuerySingleOrDefault<MateriauxAmeliorationPersonnagesEntity?>(sql, new { id = id });
            if (mat is not null) return mat;

            return null;
        }
    }
}
