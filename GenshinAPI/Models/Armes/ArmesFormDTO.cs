namespace GenshinAPI.Models.Armes
{
    public class ArmesFormDTO
    {
        public string Nom { get; set; }
        public string TypeArme { get; set; }
        public string Description { get; set; }
        public byte[] Icone { get; set; }
        public byte[] Image { get; set; }
        public string NomStatPrincipale { get; set; }
        public decimal ValeurStatPrincipale { get; set; }
        public string EffetPassif { get; set; }
        public int ATQBase { get; set; }
        public int Rarete { get; set; }
    }
}
