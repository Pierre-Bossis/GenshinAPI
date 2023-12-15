using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages.MateriauxAmeliorationPersonnages;
using GenshinAPI.Models.Produits;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class MateriauxAmeliorationPersonnagesMapper
    {
        public static MateriauxAmeliorationPersonnagesEntity ToBLL(this MateriauxAmeliorationPersonnagesFormDTO dto)
        {
            if (dto is not null)
            {

                return new MateriauxAmeliorationPersonnagesEntity
                {
                    Nom = dto.Nom,
                    Icone = dto.Icone,
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
                string base64String = Convert.ToBase64String(e.Icone);

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
