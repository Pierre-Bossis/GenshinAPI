using Genshin.DAL.Entities;
using GenshinAPI.Models.MatsAmelioPersosArmes;

namespace GenshinAPI.Tools.Mappers.MatsAmelioPersosArmes
{
    public static class MateriauxAmeliorationPersonnagesEtArmesMapper
    {
        public static MateriauxAmeliorationPersonnagesEtArmesEntity ToBLL(this MateriauxAmeliorationPersonnagesEtArmesFormDTO dto)
        {
            if (dto is not null)
            {

                return new MateriauxAmeliorationPersonnagesEtArmesEntity
                {
                    Nom = dto.Nom,
                    Icone = dto.Icone,
                    Source = dto.Source,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static MateriauxAmeliorationPersonnagesEtArmesDTO ToDto(this MateriauxAmeliorationPersonnagesEtArmesEntity e)
        {
            if (e is not null)
            {
                string base64String = Convert.ToBase64String(e.Icone);

                return new MateriauxAmeliorationPersonnagesEtArmesDTO
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    Icone = base64String,
                    Source = e.Source,
                    Rarete = e.Rarete
                };
            }
            return null;
            //}
        }
    }
}
