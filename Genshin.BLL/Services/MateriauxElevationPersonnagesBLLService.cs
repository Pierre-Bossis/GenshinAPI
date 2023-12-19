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
    public class MateriauxElevationPersonnagesBLLService : IMateriauxElevationPersonnagesBLLService
    {
        private readonly IMateriauxElevationPersonnagesRepository _repo;

        public MateriauxElevationPersonnagesBLLService(IMateriauxElevationPersonnagesRepository repo)
        {
            _repo = repo;
        }
        public void Create(MateriauxElevationPersonnagesEntity mat)
        {
            _repo.Create(mat);
        }

        public IEnumerable<MateriauxElevationPersonnagesEntity> GetAll()
        {
            IEnumerable<MateriauxElevationPersonnagesEntity> mats = _repo.GetAll();
            return mats;
        }

        public MateriauxElevationPersonnagesEntity GetById(int id)
        {
            MateriauxElevationPersonnagesEntity mat = _repo.GetById(id);
            return mat;
        }

        public MateriauxElevationPersonnagesEntity GetByName(string name)
        {
            MateriauxElevationPersonnagesEntity mat = _repo.GetByName(name);
            return mat;
        }
    }
}
