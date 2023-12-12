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

        public IEnumerable<MateriauxElevationArmes> GetAll()
        {
            return _repo.GetAll();
        }

        //traitement pour create
    }
}
