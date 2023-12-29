using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.Personnages.Constellations
{
    public class ConstellationsFormDTO
    {
        [Required]
        [MinLength(2)]
        public string Nom { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public byte[] Icone { get; set; }
        [Required]
        public int Personnage_Id { get; set; }
    }
}
