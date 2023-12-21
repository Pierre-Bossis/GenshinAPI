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
    public class Personnages_LivresAptitudeBLLService : IPersonnages_LivresAptitudeBLLService
    {
        private readonly IPersonnages_LivresAptitudeRepository _repo;

        public Personnages_LivresAptitudeBLLService(IPersonnages_LivresAptitudeRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<LivresAptitudeEntity> GetLivres(int personnageId)
        {
           return _repo.GetLivres(personnageId);
        }

        public IEnumerable<PersonnagesEntity> GetPersonnages(int livreId)
        {
            return _repo.GetPersonnages(livreId);
        }
    }
}
