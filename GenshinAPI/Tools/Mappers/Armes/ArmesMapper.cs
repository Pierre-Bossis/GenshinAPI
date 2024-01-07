using Genshin.DAL.Entities;
using GenshinAPI.Models.Armes;
using GenshinAPI.Models.Armes.MateriauxElevationArmes;

namespace GenshinAPI.Tools.Mappers.Armes
{
    public static class ArmesMapper
    {
        #region Materiaux Elevation Armes
        public static MateriauxElevationArmesEntity ToBLL(this MateriauxElevationArmesFormDTO dto, string relativePath)
        {
            if (dto is not null)
            {

                return new MateriauxElevationArmesEntity
                {
                    Nom = dto.Nom,
                    Icone = relativePath,
                    Source = dto.Source,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static MateriauxElevationArmesDTO ToDto(this MateriauxElevationArmesEntity e)
        {
            if (e is not null)
            {
                string base64String = string.Empty;

                if (!string.IsNullOrEmpty(e.Icone) && File.Exists(e.Icone))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Icone);
                    base64String = Convert.ToBase64String(imageBytes);
                }

                return new MateriauxElevationArmesDTO
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
        #endregion

        #region Armes
        public static ArmesEntity ToBLL(this ArmesFormDTO dto)
        {
            if (dto is not null)
            {

                return new ArmesEntity
                {
                    Nom = dto.Nom,
                    TypeArme = dto.TypeArme,
                    Description = dto.Description,
                    Icone = dto.Icone,
                    Image = dto.Image,
                    NomStatPrincipale = dto.NomStatPrincipale,
                    ValeurStatPrincipale = dto.ValeurStatPrincipale,
                    EffetPassif = dto.EffetPassif,
                    ATQBase = dto.ATQBase,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static ArmesDTO ToDto(this ArmesEntity e)
        {
            if (e is not null)
            {
                string base64Icone = Convert.ToBase64String(e.Icone);
                string base64Image = Convert.ToBase64String(e.Image);

                return new ArmesDTO
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    TypeArme = e.TypeArme,
                    Description = e.Description,
                    Icone = base64Icone,
                    Image = base64Image,
                    NomStatPrincipale = e.NomStatPrincipale,
                    ValeurStatPrincipale = e.ValeurStatPrincipale,
                    EffetPassif = e.EffetPassif,
                    ATQBase = e.ATQBase,
                    Rarete = e.Rarete
                };
            }
            return null;
        }
        #endregion
    }
}
