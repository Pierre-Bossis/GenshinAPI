using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IPersonnages_LivresAptitudeRepository
    {
        IEnumerable<PersonnagesEntity> GetPersonnages(int livreId);
        IEnumerable<LivresAptitudeEntity> GetLivres(int personnageId);

    }
}
