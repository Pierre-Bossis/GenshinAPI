using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface ILivresAptitudeRepository
    {
        IEnumerable<LivresAptitudeEntity> GetAll();
        LivresAptitudeEntity GetByName(string name);
        LivresAptitudeEntity GetById(int id);
        void Create(LivresAptitudeEntity livre);
    }
}
