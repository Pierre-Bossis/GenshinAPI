using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Entities
{
    public class ArtefactsEntity
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string NomSet { get; set; }
        public string Type { get; set; }
        public string Bonus2Pieces { get; set; }
        public string Bonus4Pieces { get; set; }
        public string ImagePath { get; set; }
        public string Source { get; set; }

    }
}
