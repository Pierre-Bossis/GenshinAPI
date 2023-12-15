using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages;
using GenshinAPI.Models.Personnages.MateriauxAmeliorationPersonnages;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class PersonnagesMapper
    {
        public static PersonnagesEntity ToBLL(this PersonnagesFormDTO dto)
        {
            if (dto is not null)
            {

                return new PersonnagesEntity
                {
                    Nom = dto.Nom,
                    TypeArme = dto.TypeArme,
                    Nationalite = dto.Nationalite,
                    OeilDivin = dto.OeilDivin,
                    DateSortie = dto.DateSortie,
                    TrailerYT = dto.TrailerYT,
                    Lore = dto.Lore,
                    Portrait = dto.Portrait,
                    SplashArt = dto.SplashArt,
                    Arme_Id = dto.Arme_Id,
                    Produit_Id = dto.Produit_Id,
                    MateriauxAmeliorationPersonnage_Id = dto.MateriauxAmeliorationPersonnage_Id,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static PersonnagesDTO ToDto(this PersonnagesEntity e)
        {
            if (e is not null)
            {
                string base64Portrait = Convert.ToBase64String(e.Portrait);
                string base64SplashArt = Convert.ToBase64String(e.SplashArt);

                return new PersonnagesDTO
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    TypeArme = e.TypeArme,
                    Nationalite = e.Nationalite,
                    OeilDivin = e.OeilDivin,
                    DateSortie = e.DateSortie,
                    TrailerYT = e.TrailerYT,
                    Lore = e.Lore,
                    Portrait = base64Portrait,
                    SplashArt = base64SplashArt,
                    Arme_Id = e.Arme_Id,
                    Produit_Id = e.Produit_Id,
                    MateriauxAmeliorationPersonnage_Id = e.MateriauxAmeliorationPersonnage_Id,
                    Rarete = e.Rarete
                };
            }
            return null;
        }
    }
}
}
