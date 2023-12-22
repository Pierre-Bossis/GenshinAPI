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
    public class MateriauxAmeliorationPersonnagesEtArmesBLLService : IMateriauxAmeliorationPersonnagesEtArmesBLLService
    {
        private readonly IMateriauxAmeliorationPersonnagesEtArmesRepository _repo;

        public MateriauxAmeliorationPersonnagesEtArmesBLLService(IMateriauxAmeliorationPersonnagesEtArmesRepository repo)
        {
            _repo = repo;
        }
        public void Create(MateriauxAmeliorationPersonnagesEtArmesEntity mat)
        {
            _repo.Create(mat);
        }

        public IEnumerable<MateriauxAmeliorationPersonnagesEtArmesEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public MateriauxAmeliorationPersonnagesEtArmesEntity GetById(int id)
        {
            return _repo.GetById(id);
        }

        public MateriauxAmeliorationPersonnagesEtArmesEntity GetByName(string name)
        {
            return _repo.GetByName(name);
        }
    }
}
