using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IArmes_MateriauxElevationArmesBLLService
    {
        IEnumerable<MateriauxElevationArmesEntity> GetMateriaux(int armeId);
        IEnumerable<ArmesEntity> GetArmes(int matId);
    }
}
