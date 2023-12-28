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
    public class UserService : IUserRepository
    {
        private readonly DbConnection _connection;

        public UserService(DbConnection connection)
        {
            _connection = connection;
        }
        public string CheckPassword(string email)
        {
            string sql = "SELECT MotDePasse FROM Users WHERE Email = @email";
            return _connection.QueryFirst<string>(sql, new { email });
        }

        public UserEntity Login(string email)
        {
            string sql = "SELECT * FROM Users WHERE Email = @email";

            return _connection.QueryFirst<UserEntity>(sql, new { email });
        }

        public void Register(string username, string motDePasse, string email)
        {
            string sql = "INSERT INTO Users (Username, Email, MotDePasse) " +
                         "VALUES (@username, @email, @motDePasse)";

            _connection.Execute(sql, new { username, email, motDePasse });
        }
    }
}
