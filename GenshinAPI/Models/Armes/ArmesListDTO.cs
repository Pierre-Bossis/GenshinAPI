namespace GenshinAPI.Models.Armes
{
    public class ArmesListDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string TypeArme { get; set; }
        public string Image { get; set; }
        public string NomStatPrincipale { get; set; }
        public decimal ValeurStatPrincipale { get; set; }
        public string EffetPassif { get; set; }
        public int ATQBase { get; set; }
        public int Rarete { get; set; }
    }
}
