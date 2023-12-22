using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages.Constellations;
using GenshinAPI.Models.Personnages.LivresAptitude;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class ConstellationsMapper
    {
        public static ConstellationsEntity ToBLL(this ConstellationsFormDTO dto)
        {
            if (dto is not null)
            {

                return new ConstellationsEntity
                {
                    Nom = dto.Nom,
                    Description = dto.Description,
                    Icone = dto.Icone,
                    Personnage_Id = dto.Personnage_Id
                };
            }
            return null;
        }

        public static ConstellationsDTO ToDto(this ConstellationsEntity e)
        {
            if (e is not null)
            {
                string base64String = Convert.ToBase64String(e.Icone);

                return new ConstellationsDTO
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    Icone = base64String,
                    Description = e.Description,
                    Personnage_Id = e.Personnage_Id
                };
            }
            return null;
        }
    }
}
