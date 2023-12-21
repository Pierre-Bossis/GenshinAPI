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
    public class Personnages_MateriauxElevationPersonnagesBLLService : IPersonnages_MateriauxElevationPersonnagesBLLService
    {
        private readonly IPersonnages_MateriauxElevationPersonnagesRepository _repo;

        public Personnages_MateriauxElevationPersonnagesBLLService(IPersonnages_MateriauxElevationPersonnagesRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<MateriauxElevationPersonnagesEntity> GetMateriauxElevation(int personnageId)
        {
            return _repo.GetMateriauxElevation(personnageId);
        }

        public IEnumerable<PersonnagesEntity> GetPersonnages(int materiauId)
        {
            return _repo.GetPersonnages(materiauId);
        }
    }
}
