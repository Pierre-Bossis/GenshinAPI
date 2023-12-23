using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages.Aptitudes;
using GenshinAPI.Models.Personnages.Constellations;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class AptitudesMapper
    {
        public static AptitudesEntity ToBLL(this AptitudesFormDTO dto)
        {
            if (dto is not null)
            {

                return new AptitudesEntity
                {
                    Nom = dto.Nom,
                    Description = dto.Description,
                    IsAptitudeCombat = dto.IsAptitudeCombat,
                    Icone = dto.Icone,
                    Personnage_Id = dto.Personnage_Id
                };
            }
            return null;
        }

        public static AptitudesDTO ToDto(this AptitudesEntity e)
        {
            if (e is not null)
            {
                string base64String = Convert.ToBase64String(e.Icone);

                return new AptitudesDTO
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    Description = e.Description,
                    IsAptitudeCombat = e.IsAptitudeCombat,
                    Icone = base64String,
                    Personnage_Id = e.Personnage_Id
                };
            }
            return null;
        }
    }
}
