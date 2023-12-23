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
    public class AptitudesService : IAptitudesRepository
    {
        private readonly DbConnection _connection;

        public AptitudesService(DbConnection connection)
        {
            _connection = connection;
        }
        public void Create(AptitudesEntity aptitude)
        {
            string sql = "INSERT INTO Aptitudes VALUES (@nom,@description,@isAptitudeCombat,@icone,@personnage_Id)";
            _connection.Execute(sql, new { nom = aptitude.Nom, description = aptitude.Description,isAptitudeCombat = aptitude.IsAptitudeCombat, icone = aptitude.Icone, personnage_Id = aptitude.Personnage_Id });
        }

        public IEnumerable<AptitudesEntity> GetAll(int personnageId)
        {
            string sql = "SELECT * FROM Aptitudes WHERE Personnage_Id = @personnageId";
            IEnumerable<AptitudesEntity?> aptitudes = _connection.Query<AptitudesEntity?>(sql, new { personnageId = personnageId });
            if (aptitudes is not null) return aptitudes;
            return Enumerable.Empty<AptitudesEntity>();
        }
    }
}
