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
    public class Armes_MateriauxElevationArmesBLLService : IArmes_MateriauxElevationArmesBLLService
    {
        private readonly IArmes_MateriauxElevationArmesRepository _repo;

        public Armes_MateriauxElevationArmesBLLService(IArmes_MateriauxElevationArmesRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<ArmesEntity> GetArmes(int matId)
        {
            IEnumerable<ArmesEntity> armes = _repo.GetArmes(matId);
            return armes;
        }

        public IEnumerable<MateriauxElevationArmesEntity> GetMateriaux(int armeId)
        {
            IEnumerable<MateriauxElevationArmesEntity> mats = _repo.GetMateriaux(armeId);
            return mats;
        }
    }
}
