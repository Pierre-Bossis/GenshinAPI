using Dapper;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Genshin.DAL.DataAccess
{
    public class Personnages_LivresAptitudeService : IPersonnages_LivresAptitudeRepository
    {
        private readonly DbConnection _connection;

        public Personnages_LivresAptitudeService(DbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<LivresAptitudeEntity> GetLivres(int personnageId)
        {
            string query = "SELECT * " +
                "FROM LivresAptitude AS L " +
                "INNER JOIN Personnages_LivresAptitude AS PLA ON L.Id = PLA.LivreAptitude_Id " +
            "WHERE PLA.Personnage_Id = @personnageId";

            return _connection.Query<LivresAptitudeEntity>(query, new { personnageId = personnageId });
        }

        public IEnumerable<PersonnagesEntity> GetPersonnages(int livreId)
        {
            string query = "SELECT * " +
                            "FROM Personnages AS P " +
                            "INNER JOIN Personnages_LivresAptitude AS PLA ON P.Id = PLA.Personnage_Id " +
                            "WHERE PLA.LivreAptitude_Id = @livreId";

            return _connection.Query<PersonnagesEntity>(query, new { livreId = livreId });
        }
    }
}
