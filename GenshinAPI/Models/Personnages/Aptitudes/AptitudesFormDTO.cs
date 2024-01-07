using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.Personnages.Aptitudes
{
    public class AptitudesFormDTO
    {
        [Required]
        [MinLength(2)]
        public string Nom { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsAptitudeCombat { get; set; }
        [Required]
        public IFormFile Icone { get; set; }
        [Required]
        public int Personnage_Id { get; set; }
    }
}
