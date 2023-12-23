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
    public class AptitudesBLLService : IAptitudesBLLService
    {
        private readonly IAptitudesRepository _repo;

        public AptitudesBLLService(IAptitudesRepository repo)
        {
            _repo = repo;
        }
        public void Create(AptitudesEntity aptitude)
        {
            _repo.Create(aptitude);
        }

        public IEnumerable<AptitudesEntity> GetAll(int personnageId)
        {
            return _repo.GetAll(personnageId);
        }
    }
}
