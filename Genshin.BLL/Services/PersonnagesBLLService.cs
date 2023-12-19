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
    public class PersonnagesBLLService : IPersonnagesBLLService
    {
        private readonly IPersonnagesRepository _repo;

        public PersonnagesBLLService(IPersonnagesRepository repo)
        {
            _repo = repo;
        }
        public void Create(PersonnagesEntity personnage)
        {
            _repo.Create(personnage);
        }

        public IEnumerable<PersonnagesEntity> GetAll()
        {
            IEnumerable<PersonnagesEntity> personnages = _repo.GetAll();
            return personnages;
        }

        public PersonnagesEntity GetByName(string name)
        {
            PersonnagesEntity personnage = _repo.GetByName(name);
            return personnage;
        }
        public IEnumerable<PersonnagesEntity> GetByNationalite(string nationalite)
        {
           IEnumerable<PersonnagesEntity> personnages = _repo.GetByNationalite(nationalite);
            return personnages;
        }
    }
}
