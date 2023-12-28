using Genshin.DAL.Entities;
using GenshinAPI.Models.Produits;
using GenshinAPI.Models.User;

namespace GenshinAPI.Tools.Mappers.Users
{
    public static class UsersMapper
    {
        public static ConnectedUserDTO ToDto(this UserEntity e)
        {
            if (e is not null)
            {
                return new ConnectedUserDTO
                {
                    Id = e.Id,
                    Username = e.Username,
                    Email = e.Email,
                    Avatar_Id = e.Avatar_Id,
                    IsAdmin = e.IsAdmin
                };
            }
            return null;
        }
    }
}
