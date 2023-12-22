using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IConstellationsRepository
    {
        IEnumerable<ConstellationsEntity> GetAll(int personnageId);
        void Create(ConstellationsEntity constellation);
    }
}
