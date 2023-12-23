using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IAptitudesBLLService
    {
        IEnumerable<AptitudesEntity> GetAll(int personnageId);
        void Create(AptitudesEntity aptitude);
    }
}
