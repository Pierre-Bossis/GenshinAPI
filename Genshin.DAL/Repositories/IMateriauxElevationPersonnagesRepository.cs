using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IMateriauxElevationPersonnagesRepository
    {
        IEnumerable<MateriauxElevationPersonnagesEntity> GetAll();
        void Create(MateriauxElevationPersonnagesEntity mat);
        MateriauxElevationPersonnagesEntity GetByName(string name);
        MateriauxElevationPersonnagesEntity GetById(int id);
    }
}
