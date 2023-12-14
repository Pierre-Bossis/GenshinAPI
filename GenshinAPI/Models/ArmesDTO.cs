namespace GenshinAPI.Models
{
    public class ArmesDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string TypeArme { get; set; }
        public string Description { get; set; }
        public string Icone { get; set; }
        public string Image { get; set; }
        public string NomStatPrincipale { get; set; }
        public decimal ValeurStatPrincipale { get; set; }
        public string EffetPassif { get; set; }
        public int ATQBase { get; set; }
        public int Rarete { get; set; }
    }
}
