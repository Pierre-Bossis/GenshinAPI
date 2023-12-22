using Genshin.BLL.Interfaces;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Services
{
    public class Personnages_MatsAmelioPersosArmesBLLService : IPersonnages_MatsAmelioPersosArmesBLLService
    {
        private readonly IPersonnages_MatsAmelioPersosArmesRepository _repo;

        public Personnages_MatsAmelioPersosArmesBLLService(IPersonnages_MatsAmelioPersosArmesRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<MateriauxAmeliorationPersonnagesEtArmesEntity> GetMateriauxAmelioration(int personnageId)
        {
            return _repo.GetMateriauxAmelioration(personnageId);
        }

        public IEnumerable<PersonnagesEntity> GetPersonnages(int materiauId)
        {
            return GetPersonnages(materiauId);
        }
    }
}
