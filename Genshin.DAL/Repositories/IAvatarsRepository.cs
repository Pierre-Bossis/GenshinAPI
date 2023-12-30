using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IAvatarsRepository
    {
        AvatarsEntity GetById(int id);
        IEnumerable<AvatarsEntity> GetAll();
        void AvatarChange(int avatarId, string userId);
    }
}
