using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IArmesRepository
    {
        IEnumerable<ArmesEntity> GetAll();
        ArmesEntity GetByName(string name);
        ArmesEntity GetById(int id);
        void Create(ArmesEntity arme);
    }
}
