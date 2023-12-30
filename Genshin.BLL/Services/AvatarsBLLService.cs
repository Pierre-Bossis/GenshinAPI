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
    public class AvatarsBLLService : IAvatarsBLLService
    {
        private readonly IAvatarsRepository _repo;

        public AvatarsBLLService(IAvatarsRepository repo)
        {
            _repo = repo;
        }

        public void AvatarChange(int avatarId, string userId)
        {
            _repo.AvatarChange(avatarId, userId);
        }

        public IEnumerable<AvatarsEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public AvatarsEntity GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
