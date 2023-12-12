using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models
{
    public class MateriauxElevationArmesFormDTO
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string PathIcone { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public int Rarete { get; set; }
    }
}
