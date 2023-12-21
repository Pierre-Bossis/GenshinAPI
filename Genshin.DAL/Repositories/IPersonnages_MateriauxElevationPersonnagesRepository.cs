using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IPersonnages_MateriauxElevationPersonnagesRepository
    {
        IEnumerable<PersonnagesEntity> GetPersonnages(int materiauId);
        IEnumerable<MateriauxElevationPersonnagesEntity> GetMateriauxElevation(int personnageId);
    }
}
