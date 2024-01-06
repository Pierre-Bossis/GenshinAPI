using Genshin.DAL.Entities;
using GenshinAPI.Models.Produits;

namespace GenshinAPI.Tools.Mappers.Produits
{
    public static class ProduitsMapper
    {
        public static ProduitsEntity ToBLL(this ProduitsFormDTO dto,string relativePath)
        {
            if (dto is not null)
            {

                return new ProduitsEntity
                {
                    Nom = dto.Nom,
                    Source = dto.Source,
                    Rarete = dto.Rarete,
                    Icone = relativePath
                };
            }
            return null;
        }

        public static ProduitsDTO ToDto(this ProduitsEntity e)
        {
            if (e is not null)
            {
                string base64String = string.Empty;

                if (!string.IsNullOrEmpty(e.Icone) && File.Exists(e.Icone))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Icone);
                    base64String = Convert.ToBase64String(imageBytes);
                }

                return new ProduitsDTO
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
