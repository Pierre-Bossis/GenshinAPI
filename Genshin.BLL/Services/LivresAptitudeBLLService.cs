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
    public class LivresAptitudeBLLService : ILivresAptitudeBLLService
    {
        private readonly ILivresAptitudeRepository _repo;

        public LivresAptitudeBLLService(ILivresAptitudeRepository repo)
        {
            _repo = repo;
        }
        public void Create(LivresAptitudeEntity livre)
        {
            _repo.Create(livre);
        }

        public IEnumerable<LivresAptitudeEntity> GetAll()
        {
            IEnumerable<LivresAptitudeEntity> livres = _repo.GetAll();
            return livres;
        }

        public LivresAptitudeEntity GetById(int id)
        {
            LivresAptitudeEntity livre = _repo.GetById(id);
            return livre;
        }

        public LivresAptitudeEntity GetByName(string name)
        {
            LivresAptitudeEntity livre = _repo.GetByName(name);
            return livre;
        }
    }
}
