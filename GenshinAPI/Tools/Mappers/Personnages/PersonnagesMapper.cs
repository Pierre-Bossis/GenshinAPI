using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages;
using GenshinAPI.Models.Personnages.MateriauxAmeliorationPersonnages;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class PersonnagesMapper
    {
        public static PersonnagesEntity ToBLL(this PersonnagesFormDTO dto, string relativePathPortrait, string relativePathSplashArt)
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
                    Portrait = relativePathPortrait,
                    SplashArt = relativePathSplashArt,
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
                string base64Portrait = string.Empty;

                if (!string.IsNullOrEmpty(e.Portrait) && File.Exists(e.Portrait))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Portrait);
                    base64Portrait = Convert.ToBase64String(imageBytes);
                }

                string base64SplashArt = string.Empty;

                if (!string.IsNullOrEmpty(e.SplashArt) && File.Exists(e.SplashArt))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.SplashArt);
                    base64SplashArt = Convert.ToBase64String(imageBytes);
                }

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

        public static PersonnagesListDTO ToDtoList(this PersonnagesEntity e)
        {
            if (e is not null)
            {
                string base64Portrait = string.Empty;

                if (!string.IsNullOrEmpty(e.Portrait) && File.Exists(e.Portrait))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Portrait);
                    base64Portrait = Convert.ToBase64String(imageBytes);
                }

                return new PersonnagesListDTO
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    TypeArme = e.TypeArme,
                    Nationalite = e.Nationalite,
                    OeilDivin = e.OeilDivin,
                    DateSortie = e.DateSortie,
                    Portrait = base64Portrait,
                    Rarete = e.Rarete
                };
            }
            return null;
        }
    }
}
