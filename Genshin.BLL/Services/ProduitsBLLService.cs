using Genshin.BLL.Interfaces;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Services
{
    public class ProduitsBLLService : IProduitsBLLService
    {
        private readonly IProduitsRepository _repo;

        public ProduitsBLLService(IProduitsRepository repo)
        {
            _repo = repo;
        }
        public void Create(ProduitsEntity produit)
        {
            _repo.Create(produit);
        }

        public IEnumerable<ProduitsEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public ProduitsEntity GetByName(string name)
        {
            return _repo.GetByName(name);
        }
    }
}
