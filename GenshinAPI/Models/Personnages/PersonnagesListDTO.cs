namespace GenshinAPI.Models.Personnages
{
    public class PersonnagesListDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Portrait { get; set; }
        public string OeilDivin { get; set; }
        public string Nationalite { get; set; }
        public DateTime DateSortie { get; set; }
        public int Rarete { get; set; }
        public string TypeArme { get; set; }
    }
}
