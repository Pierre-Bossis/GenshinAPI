using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Entities
{
    public class AptitudesEntity
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public bool IsAptitudeCombat { get; set; }
        public string Icone { get; set; }
        public int Personnage_Id { get; set; }
    }
}
