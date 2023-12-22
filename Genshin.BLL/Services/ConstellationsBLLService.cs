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
    public class ConstellationsBLLService : IConstellationsBLLService
    {
        private readonly IConstellationsRepository _repo;

        public ConstellationsBLLService(IConstellationsRepository repo)
        {
            _repo = repo;
        }
        public void Create(ConstellationsEntity constellation)
        {
            _repo.Create(constellation);
        }

        public IEnumerable<ConstellationsEntity> GetAll(int personnageId)
        {
            return _repo.GetAll(personnageId);
        }
    }
}
