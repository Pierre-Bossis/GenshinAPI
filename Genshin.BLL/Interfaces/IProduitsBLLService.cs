using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IProduitsBLLService
    {
        IEnumerable<ProduitsEntity> GetAll();
        ProduitsEntity GetByName(string name);
        void Create(ProduitsEntity produit);
    }
}
