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
    public class MateriauxAmeliorationPersonnagesEtArmesService : IMateriauxAmeliorationPersonnagesEtArmesRepository
    {
        private readonly DbConnection _connection;

        public MateriauxAmeliorationPersonnagesEtArmesService(DbConnection connection)
        {
            _connection = connection;
        }
        public void Create(MateriauxAmeliorationPersonnagesEtArmesEntity mat)
        {
            string sql = "INSERT INTO MateriauxAmeliorationPersonnagesEtArmes VALUES (@nom,@icone,@source,@rarete)";
            _connection.ExecuteScalar(sql, new { nom = mat.Nom, icone = mat.Icone, source = mat.Source, rarete = mat.Rarete });
        }

        public IEnumerable<MateriauxAmeliorationPersonnagesEtArmesEntity> GetAll()
        {
            string sql = "SELECT * FROM MateriauxAmeliorationPersonnagesEtArmes";
            return _connection.Query<MateriauxAmeliorationPersonnagesEtArmesEntity>(sql);
        }

        public MateriauxAmeliorationPersonnagesEtArmesEntity GetById(int id)
        {
            string sql = "SELECT * FROM MateriauxAmeliorationPersonnagesEtArmes WHERE Id = @id";
            MateriauxAmeliorationPersonnagesEtArmesEntity? mat = _connection.QuerySingleOrDefault<MateriauxAmeliorationPersonnagesEtArmesEntity?>(sql, new { id = id });
            if (mat is not null) return mat;

            return null;
        }

        public MateriauxAmeliorationPersonnagesEtArmesEntity GetByName(string name)
        {
            string sql = "SELECT * FROM MateriauxAmeliorationPersonnagesEtArmes WHERE Nom = @name";
            MateriauxAmeliorationPersonnagesEtArmesEntity? mat = _connection.QuerySingleOrDefault<MateriauxAmeliorationPersonnagesEtArmesEntity?>(sql, new { name = name });
            if (mat is not null) return mat;

            return null;
        }
    }
}
