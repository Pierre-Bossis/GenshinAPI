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
    public class MateriauxElevationArmesBLLService : IMateriauxElevationArmesBLLService
    {
        private readonly IMateriauxElevationArmesRepository _repo;

        public MateriauxElevationArmesBLLService(IMateriauxElevationArmesRepository repo)
        {
            _repo = repo;
        }

        public void Create(MateriauxElevationArmesEntity mat)
        {
            _repo.Create(mat);
        }

        public IEnumerable<MateriauxElevationArmesEntity> GetAll()
        {
            IEnumerable<MateriauxElevationArmesEntity> matList = _repo.GetAll();

            return matList;
        }

        public MateriauxElevationArmesEntity GetByName(string name)
        {
            MateriauxElevationArmesEntity mat = _repo.GetByName(name);

            return mat;
        }
    }
}
