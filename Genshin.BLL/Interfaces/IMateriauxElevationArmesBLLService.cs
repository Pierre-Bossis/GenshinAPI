using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IMateriauxElevationArmesBLLService
    {
        IEnumerable<MateriauxElevationArmes> GetAll();
        void create(MateriauxElevationArmes mat);
        MateriauxElevationArmes GetByName(string name);
    }
}
