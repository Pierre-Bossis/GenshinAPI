namespace GenshinAPI.Models.Personnages
{
    public class PersonnagesDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string OeilDivin { get; set; }
        public string TypeArme { get; set; }
        public string Lore { get; set; }
        public string Nationalite { get; set; }
        public string TrailerYT { get; set; }
        public string SplashArt { get; set; }
        public string Portrait { get; set; }
        public DateTime DateSortie { get; set; }
        public int Rarete { get; set; }
        public int Arme_Id { get; set; }
        public int MateriauxAmeliorationPersonnage_Id { get; set; }
        public int Produit_Id { get; set; }
    }
}
