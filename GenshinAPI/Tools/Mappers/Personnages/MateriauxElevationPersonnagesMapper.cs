using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages.MateriauxAmeliorationPersonnages;
using GenshinAPI.Models.Personnages.MateriauxElevationPersonnages;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class MateriauxElevationPersonnagesMapper
    {
        public static MateriauxElevationPersonnagesEntity ToBLL(this MateriauxElevationPersonnagesFormDTO dto)
        {
            if (dto is not null)
            {

                return new MateriauxElevationPersonnagesEntity
                {
                    Nom = dto.Nom,
                    Icone = dto.Icone,
                    Source = dto.Source,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static MateriauxElevationPersonnagesDTO ToDto(this MateriauxElevationPersonnagesEntity e)
        {
            if (e is not null)
            {
                string base64String = Convert.ToBase64String(e.Icone);

                return new MateriauxElevationPersonnagesDTO
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
