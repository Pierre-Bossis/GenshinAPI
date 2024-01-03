using Genshin.DAL.Entities;
using GenshinAPI.Models.Artefacts;
using GenshinAPI.Models.Produits;

namespace GenshinAPI.Tools.Mappers.Artefacts
{
    public static class ArtefactsMapper
    {
        public static ArtefactsEntity ToBLL(this ArtefactsFormDTO dto)
        {
            if (dto is not null)
            {

                return new ArtefactsEntity
                {
                    Nom = dto.Nom,
                    NomSet = dto.NomSet,
                    Type = dto.Type,
                    Bonus2Pieces = dto.Bonus2Pieces,
                    Bonus4Pieces = dto.Bonus4Pieces,
                    ImagePath = dto.ImagePath,
                    Source = dto.Source
                };
            }
            return null;
        }

        public static ArtefactsDTO ToDto(this ArtefactsEntity e)
        {
            if (e is not null)
            {
                string base64String = string.Empty;

                if (!string.IsNullOrEmpty(e.ImagePath) && File.Exists(e.ImagePath))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.ImagePath);
                    base64String = Convert.ToBase64String(imageBytes);
                }

                return new ArtefactsDTO
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    NomSet = e.NomSet,
                    Type = e.Type,
                    Bonus2Pieces = e.Bonus2Pieces,
                    Bonus4Pieces = e.Bonus4Pieces,
                    ImagePath = base64String,
                    Source = e.Source
                };
            }
            return null;
        }
    }
}
