using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IMateriauxAmeliorationPersonnagesRepository
    {
        IEnumerable<MateriauxAmeliorationPersonnagesEntity> GetAll();
        MateriauxAmeliorationPersonnagesEntity GetByName(string name);
        void Create(MateriauxAmeliorationPersonnagesEntity mat);
    }
}
