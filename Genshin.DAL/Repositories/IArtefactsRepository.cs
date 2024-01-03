using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IArtefactsRepository
    {
        IEnumerable<ArtefactsEntity> GetAll();
        IEnumerable<ArtefactsEntity> GetBySet(string nomSet);
        void create(ArtefactsEntity entity);
    }
}
