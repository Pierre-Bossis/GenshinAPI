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
    public class MateriauxAmeliorationPersonnagesBLLService : IMateriauxAmeliorationPersonnagesBLLService
    {
        private readonly IMateriauxAmeliorationPersonnagesRepository _repo;

        public MateriauxAmeliorationPersonnagesBLLService(IMateriauxAmeliorationPersonnagesRepository repo)
        {
            _repo = repo;
        }
        public void Create(MateriauxAmeliorationPersonnagesEntity mat)
        {
            _repo.Create(mat);
        }

        public IEnumerable<MateriauxAmeliorationPersonnagesEntity> GetAll()
        {
            IEnumerable<MateriauxAmeliorationPersonnagesEntity> matListe = _repo.GetAll();

            return matListe;
        }

        public MateriauxAmeliorationPersonnagesEntity GetByName(string name)
        {
            MateriauxAmeliorationPersonnagesEntity mat = _repo.GetByName(name);

            return mat;
        }

        public MateriauxAmeliorationPersonnagesEntity GetById(int id)
        {
            MateriauxAmeliorationPersonnagesEntity mat = _repo.GetById(id);

            return mat;
        }
    }
}
