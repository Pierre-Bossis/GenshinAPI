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
        IEnumerable<MateriauxElevationArmes> GetAll();
        void Create(MateriauxElevationArmes mat);
        MateriauxElevationArmes GetByName(string name);
    }
}
