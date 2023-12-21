﻿using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IPersonnagesBLLService
    {
        IEnumerable<PersonnagesEntity> GetAll();
        PersonnagesEntity GetByName(string name);
        void Create(PersonnagesEntity personnage, List<int>SelectedLivres, List<int>selectedMatsElevationPersonnages);
        IEnumerable<PersonnagesEntity> GetByNationalite(string nationalite);
    }
}
