using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.DAL.Repositories
{
    public  interface IUserRepository
    {
        string CheckPassword(string email);
        UserEntity Login(string email);
        void Register(string username, string motDePasse, string email);

    }
}
