using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages.LivresAptitude;
using GenshinAPI.Models.Produits;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class LivresAptitudeMapper
    {
        public static LivresAptitudeEntity ToBLL(this LivresAptitudeFormDTO dto)
        {
            if (dto is not null)
            {

                return new LivresAptitudeEntity
                {
                    Nom = dto.Nom,
                    Icone = dto.Icone,
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
                string base64String = Convert.ToBase64String(e.Icone);

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
