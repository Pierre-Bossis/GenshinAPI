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
    public class LivresAptitudeService : ILivresAptitudeRepository
    {
        private readonly DbConnection _connection;

        public LivresAptitudeService(DbConnection connection)
        {
            _connection = connection;  
        }
        public void Create(LivresAptitudeEntity livre)
        {
            string sql = "INSERT INTO LivresAptitude VALUES (@nom,@icone,@source,@rarete)";
            _connection.ExecuteScalar(sql, new { nom = livre.Nom, icone = livre.Icone, source = livre.Source, rarete = livre.Rarete });
        }

        public IEnumerable<LivresAptitudeEntity> GetAll()
        {
            string sql = "SELECT * FROM LivresAptitude";
            IEnumerable<LivresAptitudeEntity?> livres = _connection.Query<LivresAptitudeEntity?>(sql);
            if (livres is not null) return livres;
            return null;
        }

        public LivresAptitudeEntity GetById(int id)
        {
            string sql = "SELECT * FROM LivresAptitude WHERE Id = @id";
            LivresAptitudeEntity? livre = _connection.QuerySingleOrDefault<LivresAptitudeEntity>(sql, new { id = id });
            if (livre is not null) return livre;
            return null;
        }

        public LivresAptitudeEntity GetByName(string name)
        {
            string sql = "SELECT * FROM LivresAptitude WHERE Nom = @nom";
            LivresAptitudeEntity? livre = _connection.QuerySingleOrDefault<LivresAptitudeEntity>(sql, new { nom = name });
            if (livre is not null) return livre;
            return null;
        }
    }
}
