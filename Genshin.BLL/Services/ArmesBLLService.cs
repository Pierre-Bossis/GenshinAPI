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
    public class ArmesBLLService : IArmesBLLService
    {
        private readonly IArmesRepository _repo;

        public ArmesBLLService(IArmesRepository repo)
        {
            _repo = repo;
        }
        public void Create(ArmesEntity arme, List<int> selectedMats, List<int> selectedMatsAmelioList)
        {
            _repo.Create(arme,selectedMats, selectedMatsAmelioList);
        }

        public IEnumerable<ArmesEntity> GetAll()
        {
            IEnumerable<ArmesEntity> armes = _repo.GetAll();
            return armes;
        }

        public ArmesEntity GetByName(string name)
        {
            ArmesEntity arme = _repo.GetByName(name);
            return arme;
        }

        public ArmesEntity GetById(int id)
        {
            ArmesEntity arme = _repo.GetById(id);
            return arme;
        }
    }
}
