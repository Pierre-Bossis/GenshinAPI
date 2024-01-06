using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.Personnages.MateriauxAmeliorationPersonnages
{
    public class MateriauxAmeliorationPersonnagesFormDTO
    {
        [Required]
        [MinLength(2),MaxLength(100)]
        public string Nom { get; set; }
        [Required]
        public IFormFile Icone { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public int Rarete { get; set; }
    }
}
