using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IPersonnages_LivresAptitudeBLLService
    {
        IEnumerable<PersonnagesEntity> GetPersonnages(int livreId);
        IEnumerable<LivresAptitudeEntity> GetLivres(int personnageId);
    }
}
