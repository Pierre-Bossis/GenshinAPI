using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IMateriauxAmeliorationPersonnagesEtArmesBLLService
    {
        IEnumerable<MateriauxAmeliorationPersonnagesEtArmesEntity> GetAll();
        MateriauxAmeliorationPersonnagesEtArmesEntity GetByName(string name);
        MateriauxAmeliorationPersonnagesEtArmesEntity GetById(int id);
        void Create(MateriauxAmeliorationPersonnagesEtArmesEntity mat);
    }
}
