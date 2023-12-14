using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models
{
    public class MateriauxElevationArmesFormDTO
    {

        public string Nom { get; set; }

        public byte[] Icone { get; set; }

        public string Source { get; set; }

        public int Rarete { get; set; }
    }
}
