namespace GenshinAPI.Models.Personnages.Aptitudes
{
    public class AptitudesFormDTO
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public bool IsAptitudeCombat { get; set; }
        public byte[] Icone { get; set; }
        public int Personnage_Id { get; set; }
    }
}
