using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IMateriauxElevationPersonnagesBLLService
    {
        IEnumerable<MateriauxElevationPersonnagesEntity> GetAll();
        MateriauxElevationPersonnagesEntity GetByName(string name);
        MateriauxElevationPersonnagesEntity GetById(int id);
        void Create(MateriauxElevationPersonnagesEntity mat);
    }
}
