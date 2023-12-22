using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IPersonnages_MatsAmelioPersosArmesRepository
    {
        IEnumerable<PersonnagesEntity> GetPersonnages(int materiauId);
        IEnumerable<MateriauxAmeliorationPersonnagesEtArmesEntity> GetMateriauxAmelioration(int personnageId);
    }
}
