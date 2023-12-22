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
    public class Armes_MatsAmelioPersosArmesBLLService : IArmes_MatsAmelioPersosArmesBLLService
    {
        private readonly IArmes_MatsAmelioPersosArmesRepository _repo;

        public Armes_MatsAmelioPersosArmesBLLService(IArmes_MatsAmelioPersosArmesRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<ArmesEntity> GetArmes(int matId)
        {
            return _repo.GetArmes(matId);
        }

        public IEnumerable<MateriauxAmeliorationPersonnagesEtArmesEntity> GetMateriaux(int armeId)
        {
            return _repo.GetMateriaux(armeId);
        }
    }
}
