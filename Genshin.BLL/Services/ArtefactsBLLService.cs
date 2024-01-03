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
    public class ArtefactsBLLService : IArtefactsBLLService
    {
        private readonly IArtefactsRepository _repo;

        public ArtefactsBLLService(IArtefactsRepository repo)
        {
            _repo = repo;
        }
        public void create(ArtefactsEntity entity)
        {
            _repo.create(entity);
        }

        public IEnumerable<ArtefactsEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<ArtefactsEntity> GetBySet(string nomSet)
        {
            return _repo.GetBySet(nomSet);
        }
    }
}
