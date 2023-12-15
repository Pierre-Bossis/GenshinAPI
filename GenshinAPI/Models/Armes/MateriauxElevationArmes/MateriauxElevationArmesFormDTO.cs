using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.Armes.MateriauxElevationArmes
{
    public class MateriauxElevationArmesFormDTO
    {

        public string Nom { get; set; }

        public byte[] Icone { get; set; }

        public string Source { get; set; }

        public int Rarete { get; set; }
    }
}
