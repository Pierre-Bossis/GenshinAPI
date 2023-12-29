using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.Personnages.MateriauxElevationPersonnages
{
    public class MateriauxElevationPersonnagesFormDTO
    {
        [Required]
        [MinLength(2),MaxLength(100)]
        public string Nom { get; set; }
        [Required]
        public byte[] Icone { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public int Rarete { get; set; }
    }
}
