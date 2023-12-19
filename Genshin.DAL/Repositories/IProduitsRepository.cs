using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IProduitsRepository
    {
        IEnumerable<ProduitsEntity> GetAll();
        ProduitsEntity GetByName(string name);
        ProduitsEntity GetById(int id);
        void Create(ProduitsEntity produit);
    }
}
