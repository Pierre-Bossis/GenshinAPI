using Genshin.DAL.Entities;
using GenshinAPI.Models.MatsAmelioPersosArmes;

namespace GenshinAPI.Tools.Mappers.MatsAmelioPersosArmes
{
    public static class MateriauxAmeliorationPersonnagesEtArmesMapper
    {
        public static MateriauxAmeliorationPersonnagesEtArmesEntity ToBLL(this MateriauxAmeliorationPersonnagesEtArmesFormDTO dto, string relativePath)
        {
            if (dto is not null)
            {

                return new MateriauxAmeliorationPersonnagesEtArmesEntity
                {
                    Nom = dto.Nom,
                    Icone = relativePath,
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
                string base64String = string.Empty;

                if (!string.IsNullOrEmpty(e.Icone) && File.Exists(e.Icone))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Icone);
                    base64String = Convert.ToBase64String(imageBytes);
                }

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
