using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IMateriauxElevationArmesRepository
    {
        IEnumerable<MateriauxElevationArmesEntity> GetAll();
        void Create(MateriauxElevationArmesEntity mat);
        MateriauxElevationArmesEntity GetByName(string name);
    }
}
