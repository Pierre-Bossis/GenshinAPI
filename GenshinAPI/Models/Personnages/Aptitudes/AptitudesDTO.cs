namespace GenshinAPI.Models.Personnages.Aptitudes
{
    public class AptitudesDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public bool IsAptitudeCombat { get; set; }
        public string Icone { get; set; }
        public int Personnage_Id { get; set; }
    }
}
