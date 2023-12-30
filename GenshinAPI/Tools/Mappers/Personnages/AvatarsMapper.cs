using Genshin.DAL.Entities;
using GenshinAPI.Models.Personnages.Aptitudes;
using GenshinAPI.Models.Personnages.Avatars;

namespace GenshinAPI.Tools.Mappers.Personnages
{
    public static class AvatarsMapper
    {
        public static AvatarsDTO ToDto(this AvatarsEntity e)
        {
            if (e is not null)
            {
                return new AvatarsDTO
                {
                    Id = e.Id,
                    Nom = e.Nom
                };
            }
            return null;
        }
    }
}
