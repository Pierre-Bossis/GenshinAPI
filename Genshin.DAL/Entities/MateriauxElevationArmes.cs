using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Entities
{
    public class MateriauxElevationArmes
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string PathIcone { get; set; }
        public string Source { get; set; }
        public int Rarete { get; set; }
    }
}
