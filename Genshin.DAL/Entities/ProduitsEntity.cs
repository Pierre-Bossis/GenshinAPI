using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Entities
{
    public class ProduitsEntity
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Icone { get; set; }
        public string Source { get; set; }
        public int Rarete { get; set; }
    }
}
