using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public interface IPersonnagesRepository
    {
        IEnumerable<PersonnagesEntity> GetAll();
        PersonnagesEntity GetByName(string name);
        PersonnagesEntity GetById(int id);
        IEnumerable<PersonnagesEntity> GetByNationalite(string nationalite);
        void Create(PersonnagesEntity p, List<int> SelectedLivres, List<int> selectedMatsElevationPersonnages, List<int> selectedMatsAmelioListe);
    }
}
