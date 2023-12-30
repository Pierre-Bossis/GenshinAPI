using Dapper;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.DataAccess
{
    public class AvatarsService : IAvatarsRepository
    {
        private readonly DbConnection _connection;

        public AvatarsService(DbConnection connection)
        {
            _connection = connection;
        }

        public void AvatarChange(int avatarId, string userId)
        {
            string sql = "UPDATE Users SET Avatar_Id = @avatarid WHERE Id = @id";
            _connection.Execute(sql, new { avatarId = avatarId, id = userId });
        }

        public IEnumerable<AvatarsEntity> GetAll()
        {
            string sql = "SELECT * FROM Avatars";
            return _connection.Query<AvatarsEntity>(sql);
        }

        public AvatarsEntity GetById(int id)
        {
            string sql = "SELECT * FROM Avatars WHERE Id = @id";
            AvatarsEntity? avatar = _connection.QuerySingleOrDefault<AvatarsEntity?>(sql, new { id = id });
            if (avatar is not null) return avatar;
            return null;
        }
    }
}
