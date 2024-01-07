using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages.LivresAptitude;
using GenshinAPI.Models.Produits;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class LivresAptitudeMapper
    {
        public static LivresAptitudeEntity ToBLL(this LivresAptitudeFormDTO dto, string relativePath)
        {
            if (dto is not null)
            {

                return new LivresAptitudeEntity
                {
                    Nom = dto.Nom,
                    Icone = relativePath,
                    Source = dto.Source,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static LivresAptitudeDTO ToDto(this LivresAptitudeEntity e)
        {
            if (e is not null)
            {
                string base64String = string.Empty;

                if (!string.IsNullOrEmpty(e.Icone) && File.Exists(e.Icone))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Icone);
                    base64String = Convert.ToBase64String(imageBytes);
                }

                return new LivresAptitudeDTO
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    Icone = base64String,
                    Source = e.Source,
                    Rarete = e.Rarete
                };
            }
            return null;
        }
    }
}
