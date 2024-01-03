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
    public class ArtefactsService : IArtefactsRepository
    {
        private readonly DbConnection _connection;

        public ArtefactsService(DbConnection connection)
        {
            _connection = connection;
        }
        public void create(ArtefactsEntity a)
        {
            string sql = "INSERT INTO Artefacts VALUES(@nom,@nomset,@type,@bonus2pieces,@bonus4pieces,@imagepath,@source)";
            _connection.Execute(sql, new { nom = a.Nom, nomset = a.NomSet, type = a.Type, bonus2pieces = a.Bonus2Pieces, bonus4pieces = a.Bonus4Pieces, imagepath = a.ImagePath, source = a.Source });
        }

        public IEnumerable<ArtefactsEntity> GetAll()
        {
            string sql = "SELECT * FROM Artefacts WHERE Type = 'Fleur'";
            return _connection.Query<ArtefactsEntity>(sql);
        }

        public IEnumerable<ArtefactsEntity> GetBySet(string nomSet)
        {
            string sql = "SELECT * FROM Artefacts WHERE NomSet = @nomset";
            return _connection.Query<ArtefactsEntity>(sql, new { nomset = nomSet });
        }
    }
}
