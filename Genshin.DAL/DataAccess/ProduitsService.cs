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

namespace Genshin.DAL.DataAccess
{
    public class ProduitsService : IProduitsRepository
    {
        private readonly SqlConnection _connection;

        public ProduitsService(SqlConnection connection)
        {
            _connection = connection;
        }
        public void Create(ProduitsEntity produit)
        {
            string sql = "INSERT INTO Produits VALUES (@nom,@icone,@source,@rarete)";
            _connection.ExecuteScalar(sql, new { nom = produit.Nom, icone = produit.Icone, source = produit.Source, rarete = produit.Rarete });
        }

        public IEnumerable<ProduitsEntity> GetAll()
        {
            string sql = "SELECT * FROM Produits";
            IEnumerable<ProduitsEntity?> produits = _connection.Query<ProduitsEntity?>(sql);
            if (produits is not null) return produits;
            return null;
        }

        public ProduitsEntity GetByName(string name)
        {
            string sql = "SELECT * FROM Produits WHERE Nom = @nom";
            ProduitsEntity? produit = _connection.QuerySingleOrDefault<ProduitsEntity?>(sql, new { nom = name });
            if (produit is not null) return produit;
            return null;
        }
        public ProduitsEntity GetById(int id)
        {
            string sql = "SELECT * FROM Produits WHERE Id = @id";
            ProduitsEntity? produit = _connection.QuerySingleOrDefault<ProduitsEntity?>(sql, new { id = id });
            if (produit is not null) return produit;
            return null;
        }
    }
}
