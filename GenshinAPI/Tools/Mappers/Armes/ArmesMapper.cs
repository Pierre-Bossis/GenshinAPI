using Genshin.DAL.Entities;
using GenshinAPI.Models;
using System.Collections;
using System.Text;

namespace GenshinAPI.Tools.Mappers.Armes
{
    public static class ArmesMapper
    {
        #region Armes
        public static MateriauxElevationArmes ToBLL(this MateriauxElevationArmesFormDTO dto)
        {
            if (dto is not null)
            {

                return new MateriauxElevationArmes
                {
                    Nom = dto.Nom,
                    Icone = dto.Icone,
                    Source = dto.Source,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static MateriauxElevationArmesDTO ToDto(this MateriauxElevationArmes m)
        {
            if (m is not null)
            {
                string base64String = Convert.ToBase64String(m.Icone);

                return new MateriauxElevationArmesDTO
                {
                    Id = m.Id,
                    Nom = m.Nom,
                    Icone = base64String,
                    Source = m.Source,
                    Rarete = m.Rarete
                };
            }
            return null;
        }
        #endregion
    }
}
