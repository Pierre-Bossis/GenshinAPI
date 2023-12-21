using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IPersonnages_MateriauxElevationPersonnagesBLLService
    {
        IEnumerable<PersonnagesEntity> GetPersonnages(int materiauId);
        IEnumerable<MateriauxElevationPersonnagesEntity> GetMateriauxElevation(int personnageId);
    }
}
