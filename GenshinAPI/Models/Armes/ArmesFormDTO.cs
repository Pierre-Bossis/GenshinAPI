using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.Armes
{
    public class ArmesFormDTO
    {
        [Required]
        [MinLength(2)]
        public string Nom { get; set; }
        [Required]
        public string TypeArme { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Icone { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string NomStatPrincipale { get; set; }
        [Required]
        [Range(0,1000)]
        public decimal ValeurStatPrincipale { get; set; }
        [Required]
        public string EffetPassif { get; set; }
        [Required]
        [Range(0, 1000)]
        public int ATQBase { get; set; }
        [Required]
        public int Rarete { get; set; }

        public List<int> SelectedMats { get; set; }
        public List<int> selectedMatsAmelio { get; set; }

    }
}
