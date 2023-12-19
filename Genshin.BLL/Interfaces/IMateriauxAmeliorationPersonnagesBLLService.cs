using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IMateriauxAmeliorationPersonnagesBLLService
    {
        IEnumerable<MateriauxAmeliorationPersonnagesEntity> GetAll();
        MateriauxAmeliorationPersonnagesEntity GetByName(string name);
        MateriauxAmeliorationPersonnagesEntity GetById(int id);
        void Create(MateriauxAmeliorationPersonnagesEntity mat);
    }
}
