using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages.MateriauxAmeliorationPersonnages;
using GenshinAPI.Models.Produits;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class MateriauxAmeliorationPersonnagesMapper
    {
        public static MateriauxAmeliorationPersonnagesEntity ToBLL(this MateriauxAmeliorationPersonnagesFormDTO dto, string relativePath)
        {
            if (dto is not null)
            {

                return new MateriauxAmeliorationPersonnagesEntity
                {
                    Nom = dto.Nom,
                    Icone = relativePath,
                    Source = dto.Source,
                    Rarete = dto.Rarete
                };
            }
            return null;
        }

        public static MateriauxAmeliorationPersonnagesDTO ToDto(this MateriauxAmeliorationPersonnagesEntity e)
        {
            if (e is not null)
            {
                string base64String = string.Empty;

                if (!string.IsNullOrEmpty(e.Icone) && File.Exists(e.Icone))
                {
                    byte[] imageBytes = File.ReadAllBytes(e.Icone);
                    base64String = Convert.ToBase64String(imageBytes);
                }

                return new MateriauxAmeliorationPersonnagesDTO
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
