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
    public class ConstellationsService : IConstellationsRepository
    {
        private readonly DbConnection _connection;

        public ConstellationsService(DbConnection connection)
        {
            _connection = connection;
        }
        public void Create(ConstellationsEntity constellation)
        {
            string sql = "INSERT INTO Constellations VALUES (@nom,@description,@icone,@personnage_Id)";
            _connection.Execute(sql, new { nom = constellation.Nom, description = constellation.Description, icone = constellation.Icone, personnage_Id = constellation.Personnage_Id });
        }

        public IEnumerable<ConstellationsEntity> GetAll(int personnageId)
        {
            string sql = "SELECT * FROM Constellations WHERE Personnage_Id = @personnageId";
            IEnumerable<ConstellationsEntity?> constellations = _connection.Query<ConstellationsEntity?>(sql, new { personnageId = personnageId });
            if (constellations is not null) return constellations;
            return Enumerable.Empty<ConstellationsEntity>();
        }
    }
}
