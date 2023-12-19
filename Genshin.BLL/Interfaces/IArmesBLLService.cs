using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IArmesBLLService
    {
        IEnumerable<ArmesEntity> GetAll();
        ArmesEntity GetByName(string name);
        ArmesEntity GetById(int id);
        void Create(ArmesEntity arme);
    }
}
