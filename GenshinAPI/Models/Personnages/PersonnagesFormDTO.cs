using System.ComponentModel.DataAnnotations;

namespace GenshinAPI.Models.Personnages
{
    public class PersonnagesFormDTO
    {
        [Required]
        [MinLength(2)]
        public string Nom { get; set; }
        [Required]
        public string OeilDivin { get; set; }
        [Required]
        public string TypeArme { get; set; }
        [Required]
        public string Lore { get; set; }
        [Required]
        public string Nationalite { get; set; }
        [Required]
        public string TrailerYT { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public IFormFile Icone { get; set; }
        [Required]
        public DateTime DateSortie { get; set; }
        [Required]
        public int Rarete { get; set; }
        public int? Arme_Id { get; set; }
        [Required]
        public int MateriauxAmeliorationPersonnage_Id { get; set; }
        [Required]
        public int Produit_Id { get; set; }

        public List<int> SelectedLivres { get; set; }
        public List<int> SelectedMatsElevation { get; set; }
        public List<int> SelectedMatsAmelioPersosArmes { get; set; }
    }
}
