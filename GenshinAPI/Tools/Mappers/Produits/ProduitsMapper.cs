using Genshin.DAL.Entities;
using GenshinAPI.Models.Produits;

namespace GenshinAPI.Tools.Mappers.Produits
{
    public static class ProduitsMapper
    {
        public static ProduitsEntity ToBLL(this ProduitsFormDTO dto)
        {
            if (dto is not null)
            {

                return new ProduitsEntity
                {
                    Nom = dto.Nom,
                    Icone = dto.Icone,
                    Source = dto.Source,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static ProduitsDTO ToDto(this ProduitsEntity e)
        {
            if (e is not null)
            {
                string base64String = Convert.ToBase64String(e.Icone);

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
